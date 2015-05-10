using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EncodeUtil
{
    public class BatchEncoder
    {
        public delegate void AfterReadLine(EventInfo eventInfo);
        public delegate void AfterEncodeLineToFile(EventInfo eventInfo);

        private event AfterReadLine OnAfterReadLine;
        private event AfterEncodeLineToFile OnAfterEncodeLineToFile;

        public class ReadLineEventTarget
        {
            public int LineIndex;
            public string Text;
        }

        public class EncodeLineToFileEventTarget
        {
            public int LineIndex;
            public string Text;
            public string FilePath;
        }


        private string _srcFilePath;
        private string _outDir;

        public BatchEncoder(string srcFilePath, string outDir,
            AfterReadLine afterRead = null, AfterEncodeLineToFile afterEncode = null)
        {
            _srcFilePath = srcFilePath;
            _outDir = outDir;
            OnAfterReadLine += afterRead;
            OnAfterEncodeLineToFile += afterEncode;
        }

        public string SrcFilePath
        {
            get { return _srcFilePath; }
        }

        public string OutDir
        {
            get { return _outDir; }
        }

        public void BatchEncode(bool asyn = true)
        {
            BlockingCollection<string> lines = new BlockingCollection<string>();

            Task reader = Task.Factory.StartNew(() =>
            {
                int i = 0;
                foreach (var line in FileOperate.GetFileLine(_srcFilePath, Encoding.Default))
                {
                    string newLine = line.Replace("\t", "|");
                    lines.Add(newLine);
                    if (OnAfterReadLine != null)
                    {
                        OnAfterReadLine(new EventInfo(EventInfo.EventType.OK, new ReadLineEventTarget
                        {
                            Text = newLine,
                            LineIndex = i,
                        }));
                    }
                    
                    ++i;
                }

                lines.CompleteAdding();
            });

            Task writer = Task.Factory.StartNew(() =>
            {
                if (!Directory.Exists(_outDir))
                {
                    Directory.CreateDirectory(_outDir);
                }

                int i = 0;
                while (!lines.IsCompleted)
                {
                    string line = lines.Take();
                    string fileName = string.Format("{0}_{1}.{2}", Path.GetRandomFileName(),
                        DateTime.Now.ToString("yyyyMMddHHmmss"), "png");
                    string fullPath = Path.Combine(_outDir, fileName);
                    try
                    {
                        QRcodeHelper.EncodeToFile(line, fullPath);
                        if (OnAfterEncodeLineToFile != null)
                        {
                            OnAfterEncodeLineToFile(new EventInfo(EventInfo.EventType.OK,
                                new EncodeLineToFileEventTarget
                                {
                                    FilePath = fullPath,
                                    LineIndex = i,
                                    Text = line,
                                }));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (OnAfterEncodeLineToFile != null)
                        {
                            OnAfterEncodeLineToFile(new EventInfo(EventInfo.EventType.ERROR, ex));
                        }
                    }
                    finally
                    {
                        ++i;
                    }
                }
            });

            if (!asyn)
            {
                Task.WaitAll(reader, writer);
            }
        }
    }
}
