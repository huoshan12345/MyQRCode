using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QRCodeSample
{
    public class BatchEncode
    {
        private string filePath;
        private string fileDirectory;
        private string createDirectory;
        private MainForm mainForm;
        private ArrayList resultList;
        private bool reading;

        private AutoResetEvent readStart;
        private AutoResetEvent readLineFinish;
        private AutoResetEvent allFinish;
        private CountdownEvent handler;

        public BatchEncode(string filePath, MainForm mainForm)
        {
            this.filePath = filePath;
            this.fileDirectory = Path.GetDirectoryName(filePath);
            this.createDirectory = this.fileDirectory + "\\CreatedQRcode";
            this.mainForm = mainForm;
            this.resultList = new ArrayList();
            this.readStart = new AutoResetEvent(false);
            this.readLineFinish = new AutoResetEvent(false);
            this.allFinish = new AutoResetEvent(false);
            this.handler = new CountdownEvent(2);
            Directory.CreateDirectory(this.createDirectory);
        }

        public void Start()
        {
            reading = true;
            readStart.Set();
            try
            {
                Thread readFileThead = new Thread(() =>
                {
                    ReadFile();
                    readLineFinish.Set();
                    reading = false;
                    handler.Signal();
                });                
                Thread encodeThread = new Thread(() =>
                {
                    EncodeAll2();
                    handler.Signal();
                });
                readFileThead.IsBackground = true;
                encodeThread.IsBackground = true;
                readFileThead.Name = "读取文件线程";
                encodeThread.Name = "生成二维码线程";
                readFileThead.Start();
                encodeThread.Start();
            } 
            finally
            {
                handler.Wait();
            }
        }

        public void ReadFile()
        {
            readStart.Set();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);//读取文件设定
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GB2312"));//设定读写的编码
                //使用StreamReader类来读取文件
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                //  从数据流中读取每一行，直到文件的最后一行
                string strLine ="";
                int resultNum = 0;
                while (true)
                {
                    try
                    {
                        strLine = sr.ReadLine();                        
                        if (strLine == null)
                        {
                            break;
                        }
                        strLine = strLine.Replace("\t", "##");
                        strLine = strLine.Replace("\r\n", "##");
                        strLine = strLine.Replace(" ", "##");
                        strLine = strLine.Replace("######", "##");
                        strLine = strLine.Replace("####", "##");
                    }
                    catch
                    {
                        continue;
                    }
                    
                    lock (this)
                    {                       
//                         string threadName = Thread.CurrentThread.Name;
//                         mainForm.Invoke(new MethodInvoker(() =>
//                         {
//                             mainForm.toolStripStatusLabel2.Text = threadName + "正在读取";
//                         }));
                        resultList.Add(strLine);
                        resultNum = resultList.Count;
                        readLineFinish.Set();                        
                        //Monitor.Pulse(this);//通知另外一个线程中正在等待的方法
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            ListViewItem tempViewItem = new ListViewItem(resultNum.ToString());
                            tempViewItem.SubItems.Add(strLine);
                            tempViewItem.SubItems.Add("未生成");
                            mainForm.listFileReaded.Items.Add(tempViewItem);
                        }));
                    }

                }
                sr.Close();
                fs.Close();
            }
            finally
            {                
            }
        }

        //读取文件和编码并发
        public void EncodeAll()
        {
            readStart.WaitOne();
            int resultNum = 0;

            for (int i = 0; ; )
            {
                try
                {
                start:
                    lock (this)
                    {
//                         mainForm.Invoke(new MethodInvoker(() =>
//                         {
//                             resultNum = mainForm.listFileReaded.Items.Count;
//                         }));
                        resultNum = resultList.Count;
                        if (i >= resultNum)
                        {
                            if (reading == true)
                            {
                                //Monitor.Wait(this);
                                Monitor.Exit(this);
                                readLineFinish.WaitOne();
                                //Thread.Sleep(1000);
                                goto start;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            string threadName = Thread.CurrentThread.Name;
                            mainForm.Invoke(new MethodInvoker(() =>
                            {
                                mainForm.toolStripStatusLabel2.Text = threadName + "正在生成";
                            }));
                            try
                            {
                                EncodeAtList(i);
                            }
                            finally
                            {
                                i++;
                            }
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }        

        public void EncodeAtList(int index)
        {
            try
            {
                string source = resultList[index].ToString();
                Image image = Operate.QRcodeHelper.Encode(source);
                string imageName = "QRcode_" + (index + 1).ToString() + ".jpg";
                FileStream fs = new FileStream(this.createDirectory + "\\" + imageName, FileMode.OpenOrCreate, FileAccess.Write);
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();

                mainForm.Invoke(new MethodInvoker(() =>
                {
                    mainForm.listFileReaded.Items[index].SubItems[2].Text = "已生成";
                }));
            }
            catch
            {
                mainForm.Invoke(new MethodInvoker(() =>
                {
                    mainForm.listFileReaded.Items[index].SubItems[2].Text = "失败";
                }));
            }
        }

        //读取文件和编码并行
        public void EncodeAll2()
        {
            readStart.WaitOne();
            int resultNum = 0;
            int index = 0;
            string source = "";

            for (int i = 0; ; )
            {
                try
                {
                start:
                    lock (this)
                    {
//                         mainForm.Invoke(new MethodInvoker(() =>
//                         {
//                             resultNum = mainForm.listFileReaded.Items.Count;
//                         }));
                        resultNum = resultList.Count;
                        if (i >= resultNum)
                        {
                            if (reading == true)
                            {
                                //Monitor.Wait(this);
                                Monitor.Exit(this);
                                readLineFinish.WaitOne();
                                //Thread.Sleep(1000);
                                goto start;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
//                             string threadName = Thread.CurrentThread.Name;
//                             mainForm.Invoke(new MethodInvoker(() =>
//                             {
//                                 mainForm.toolStripStatusLabel2.Text = threadName + "正在生成";
//                             }));
                            index = i;
                            source = resultList[index].ToString();
                        }
                    }
                    try
                    {
                        Image image = Operate.QRcodeHelper.Encode(source);
                        string imageName = "QRcode_" + (index + 1).ToString() + ".png";
                        string imagePath = this.createDirectory + "\\" + imageName;
                        FileStream fs = new FileStream(imagePath, FileMode.OpenOrCreate, FileAccess.Write);
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        fs.Close();
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            mainForm.listFileReaded.Items[index].SubItems[2].Text = "已生成";
                        }));
                    }
                    catch
                    {
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            mainForm.listFileReaded.Items[index].SubItems[2].Text = "失败";
                        }));
                    }
                    finally
                    {
                        i++;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        //多线程编码，待调试
        public void EncodeAll3()
        {
            readStart.WaitOne();
            int resultNum = 0;
            int index = 0;
            string source = "";

            for (int i = 0; ; )
            {
                try
                {
                start:
                    lock (this)
                    {
                        resultNum = resultList.Count;
                        if (i >= resultNum)
                        {
                            if (reading == true)
                            {
                                //Monitor.Wait(this);
                                Monitor.Exit(this);
                                readLineFinish.WaitOne();
                                //Thread.Sleep(1000);
                                goto start;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            index = i;
                            //source = resultList[index].ToString();
                        }
                    }

                    int encodeNum = (resultNum - index) < 10 ? (resultNum - index) : 10;
                    try
                    {                        
                        string[] strResult = new string[encodeNum];
                        CountdownEvent encodeHandler = new CountdownEvent(encodeNum);

                        for (int j = 0; j < encodeNum; j++)
                        {
                            source = resultList[index + j].ToString();
                            int fileNum = j + index + 1;
                            Thread Encode = new Thread(() =>
                            {
                                try
                                {                                    
                                    Image image = Operate.QRcodeHelper.Encode(source);
                                    string imageName = "QRcode_" + fileNum.ToString() + ".jpg";
                                    FileStream fs = new FileStream(this.createDirectory + "\\" + imageName, FileMode.OpenOrCreate, FileAccess.Write);
                                    image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    fs.Close();
                                    lock (strResult)
                                    {
                                        strResult[j] = "已生成";
                                    }                                    
                                }
                                catch
                                {
                                    lock (strResult)
                                    {
                                        strResult[j] = "失败";
                                    }
                                }
                                finally
                                {
                                    encodeHandler.Signal();
                                }

                            });
                            Encode.IsBackground = true;
                            Encode.Name = "编码线程" + (j + 1).ToString(); ;
                            Encode.Start();
                        }
                        encodeHandler.Wait();
                        for (int j = 0; j < encodeNum; j++)
                        {
                            mainForm.Invoke(new MethodInvoker(() =>
                            {
                                mainForm.listFileReaded.Items[j + index].SubItems[2].Text = strResult[j];
                            }));
                        }
                    }
                    finally
                    {
                        i += encodeNum;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
