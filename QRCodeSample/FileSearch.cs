using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using QRCodeSample;
using System.Collections.Generic;

namespace WinSearchFile
{
    /// <summary>
    /// Summary description for FileSearch.
    /// </summary>
    public class FileSearch
    {
        public enum FileTimeType { CreationTime, LastAccessTime, LastWriteTime };

        public struct SearchInput
        {
            public String[] SearchPatterns;
            public String SearchForText;
        };

        private String Dir;
        private SearchInput searchInput;
        private MainForm mainForm;
        private ArrayList resultList;
        private bool Searching;
        private AutoResetEvent searchStart;
        private AutoResetEvent searchFileFinish;
        private AutoResetEvent allFinish;
        private List<Thread> searchThreads;
        private CountdownEvent handler;

        public FileSearch(string Dir, string SearchPattern, string SearchForText, MainForm mainForm)
        {
            this.Dir = Dir;
            this.mainForm = mainForm;
            this.resultList = new ArrayList();
            this.searchInput.SearchForText = SearchForText;
            this.searchStart = new AutoResetEvent(false);
            this.searchFileFinish = new AutoResetEvent(false);
            this.allFinish = new AutoResetEvent(false);

            Regex SearchPatternDelim = new Regex(",");
            String[] SearchPatterns = SearchPatternDelim.Split(SearchPattern);
            for (int i = 0; i < SearchPatterns.Length; i++)
            {
                SearchPatterns[i] = SearchPatterns[i].Trim();
            }
            this.searchInput.SearchPatterns = SearchPatterns;
            this.searchThreads = new List<Thread>();
            this.handler = new CountdownEvent(searchInput.SearchPatterns.Length);
        }

        /// <summary>
        /// Start searching
        /// </summary>
        public void Start()
        {
            Searching = true;
            //searchStart.Set();
            try
            {
                foreach (string SearchPattern in searchInput.SearchPatterns)
                {
                    Thread searchThread = new Thread(() =>
                    {
                        GetFiles(Dir, Dir, SearchPattern);
                        handler.Signal();
                    });
                    searchThread.Name = "搜索线程：" + SearchPattern;
                    searchThread.IsBackground = true;
                    searchThreads.Add(searchThread);
                    searchThread.Start();
                }
                Thread searchTextThread = new Thread(new ThreadStart(FileContainsText2));
                searchTextThread.IsBackground = true;
                searchTextThread.Name = "解码线程";
                searchTextThread.Start();
            }
            finally
            {
                handler.Wait();
                Searching = false;
                searchFileFinish.Set();
                allFinish.WaitOne();
            }
        }

        /// <summary>
        /// Get files
        /// </summary>
        private void GetFiles(string RootDir, string Dir, string SearchPattern)
        {
            try
            {
                int resultNum = 0;
                string[] files = Directory.GetFiles(Dir, SearchPattern);
                foreach (string File in files)
                {
                    lock (this)
                    {
                        resultList.Add(File);
                        resultNum = resultList.Count;
                        ListViewItem tempViewItem = new ListViewItem(resultNum.ToString());
                        tempViewItem.SubItems.Add(File);
                        tempViewItem.SubItems.Add("未比对");
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            mainForm.listFileFounded.Items.Add(tempViewItem);
                        }));
                        searchFileFinish.Set();
                    }
                }
                // Recursively add all the files in the
                // current directory's subdirectories.
                foreach (string D in Directory.GetDirectories(Dir))
                {
                    GetFiles(RootDir, D, SearchPattern);
                }
            }
            finally
            {

            }
        }

        /// <summary>
        /// if SearchForText length i > 0
        /// search it inside the file content
        /// </summary>
        public void FileContainsText()
        {
            searchStart.WaitOne();
            int resultNum = 0;
            for (int i = 0; ; )
            {
                try
                {
                start:
                    lock (this)
                    {
                        //                          mainForm.Invoke(new MethodInvoker(() =>
                        //                          {
                        //                              resultNum = mainForm.listFileFounded.Items.Count;
                        //                          }));
                        resultNum = resultList.Count;
                        if (i >= resultNum)
                        {
                            if (Searching == true)
                            {
                                //Monitor.Wait(this);
                                Monitor.Exit(this);
                                searchFileFinish.WaitOne();
                                //Thread.Sleep(1000);
                                goto start;
                            }
                            else
                            {
                                allFinish.Set();
                                return;
                            }
                        }
                        else
                        {
                            //                              mainForm.Invoke(new MethodInvoker(() =>
                            //                              {
                            //                                  mainForm.toolStripStatusLabel2.Text = "正在比对";
                            //                              }));
                            try
                            {
                                FileContainsTextAtList(i);
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

        public void FileContainsTextAtList(int index)
        {
            try
            {
                string fileName = resultList[index].ToString();
                string source = Operate.QRcodeHelper.Decode(fileName);
                string target = searchInput.SearchForText;
                string[] sourceSubStr = source.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries);
                string[] targetSubStr = target.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries);

                if (sourceSubStr.Length > 1 && targetSubStr.Length > 1)
                {
                    source = sourceSubStr[1];
                    target = targetSubStr[1];
                }

                if (Operate.EditDistanceHelper.Compare(source, target))
                {
                    mainForm.Invoke(new MethodInvoker(() =>
                    {
                        mainForm.listFileFounded.Items[index].SubItems[2].Text = "符合";
                    }));
                }
                else
                {
                    mainForm.Invoke(new MethodInvoker(() =>
                    {
                        mainForm.listFileFounded.Items[index].SubItems[2].Text = "不符合";
                    }));
                }
            }
            catch
            {
                mainForm.Invoke(new MethodInvoker(() =>
                {
                    mainForm.listFileFounded.Items[index].SubItems[2].Text = "失败";
                }));
            }
        }

        public void FileContainsText2()
        {
            //searchStart.WaitOne();
            int resultNum = 0;
            string fileName = "";
            int index = 0;
            string target = searchInput.SearchForText;
            string[] targetSubStr = target.Split(new string[] { "##", ",", "/r", "/n", " " }, 
                StringSplitOptions.RemoveEmptyEntries);

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
                            if (Searching == true)
                            {
                                Monitor.Exit(this);
                                searchFileFinish.WaitOne();
                                goto start;
                            }
                            else
                            {
                                allFinish.Set();
                                return;
                            }
                        }
                        else
                        {
                            fileName = resultList[i].ToString();
                            index = i;
                        }
                    }
                    try
                    {
                        string source = Operate.QRcodeHelper.Decode(fileName);                        
                        string[] sourceSubStr = source.Split(new string[] { "##", ",", "/r", "/n", " " }, 
                            StringSplitOptions.RemoveEmptyEntries);
                        
                        //if (sourceSubStr.Length > 1)
                        //{
                        //    source = sourceSubStr[1];                            
                        //}
                        //if (targetSubStr.Length > 1)
                        //{
                        //    target = targetSubStr[1];
                        //}

                        if (Operate.EditDistanceHelper.Compare(sourceSubStr, targetSubStr))
                        {
                            mainForm.Invoke(new MethodInvoker(() =>
                            {
                                mainForm.listFileFounded.Items[index].SubItems[2].Text = "符合";
                            }));
                        }
                        else
                        {
                            mainForm.Invoke(new MethodInvoker(() =>
                            {
                                mainForm.listFileFounded.Items[index].SubItems[2].Text = "不符合";
                            }));
                        }
                    }
                    catch
                    {
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            mainForm.listFileFounded.Items[index].SubItems[2].Text = "失败";
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

    }
}
