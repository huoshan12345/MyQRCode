using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EncodeUtil
{
    public class BatchEncoder
    {
        public delegate void AfterReadLine(string line);



        private string _srcFilePath;
        private string _outDir;

        public BatchEncoder(string srcFilePath, string outDir)
        {
            _srcFilePath = srcFilePath;
            _outDir = outDir;
        }

        public string SrcFilePath
        {
            get { return _srcFilePath; }
        }

        public string OutDir
        {
            get { return _outDir; }
        }

        private TimeSpan BatchEncode()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            BlockingCollection<string> lines = new BlockingCollection<string>();

            Task reader = Task.Factory.StartNew(() =>
            {
                foreach (var line in FileOperate.GetFileLine(_srcFilePath, Encoding.Default))
                {
                    lines.Add(line);
                }
                lines.CompleteAdding();
            });

            Task writer = Task.Factory.StartNew(() =>
            {
                while (!lines.IsCompleted)
                {
                    string line = lines.Take();
                    string fileName = string.Format("{0}_{1}_{2}.{3}", "QRCode", Path.GetRandomFileName(), DateTime.Now.ToString("yyyyMMddHHmmss"), "png");
                    QRcodeHelper.EncodeToFile(line, Path.Combine(_outDir, fileName));
                }
            });
            Task.WaitAll(reader, writer);
            watch.Stop();
            return watch.Elapsed;
        }
    }
}
