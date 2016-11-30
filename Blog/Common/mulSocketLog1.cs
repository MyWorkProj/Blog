using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Blog.Common
{
    public class IOExtention
    {
        static ConcurrentQueue<Tuple<string, string>> logQueue = new ConcurrentQueue<Tuple<string, string>>();

        static volatile Task writeTask = default(Task);

        static IOExtention()
        {

        }

        public static void WriteLog(String preFile, String infoData)
        {
            WriteLog(string.Empty, preFile, infoData);
        }

        static AutoResetEvent pause = new AutoResetEvent(false);

        public static void WriteLog(String customDirectory, String preFile, String infoData)
        {
            string logPath = GetLogPath(customDirectory, preFile);
            string logContent = String.Concat(DateTime.Now, " ", infoData);
            logQueue.Enqueue(new Tuple<string, string>(logPath, logContent));

            if (writeTask == null)
            {
                writeTask = new Task((object obj) =>
                {
                    //pause.WaitOne(1000, true);
                    LogRepository();
                }
                    , null
                    , TaskCreationOptions.LongRunning);
                writeTask.Start();
            }

            if (writeTask.IsCompleted)
            {

                writeTask = new Task((object obj) =>
                {
                    //pause.WaitOne(1000, true);
                    LogRepository();
                }
                  , null
                  , TaskCreationOptions.LongRunning);
                writeTask.Start();
            }
        }

        public static void LogRepository()
        {
            List<string[]> temp = new List<string[]>();
            foreach (var logItem in logQueue)
            {
                string logPath = logItem.Item1;
                string logMergeContent = String.Concat(logItem.Item2, Environment.NewLine, "-----------------------------------------------------------", Environment.NewLine);
                string[] logArr = temp.FirstOrDefault(d => d[0].Equals(logPath));
                if (logArr != null)
                {
                    logArr[1] = string.Concat(logArr[1], logMergeContent);
                }
                else
                {
                    logArr = new string[] { logPath, logMergeContent };
                    temp.Add(logArr);
                }
                Tuple<string, string> val = default(Tuple<string, string>);
                logQueue.TryDequeue(out val);
            }
            foreach (string[] item in temp)
            {
                WriteText(item[0], item[1]);
            }
        }

        private static string GetLogPath(String customDirectory, String preFile)
        {
            string newFilePath = string.Empty;
            String logDir = string.IsNullOrEmpty(customDirectory) ? Path.Combine(Environment.CurrentDirectory, "logs") : customDirectory;
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
            string extension = ".log";
            string fileNameNotExt = String.Concat(preFile, DateTime.Now.ToString("yyyyMMdd"));
            String fileName = String.Concat(fileNameNotExt, extension);
            string fileNamePattern = string.Concat(fileNameNotExt, "(*)", extension);
            List<string> filePaths = Directory.GetFiles(logDir, fileNamePattern, SearchOption.TopDirectoryOnly).ToList();

            if (filePaths.Count > 0)
            {
                int fileMaxLen = filePaths.Max(d => d.Length);
                string lastFilePath = filePaths.Where(d => d.Length == fileMaxLen).OrderByDescending(d => d).FirstOrDefault();
                if (new FileInfo(lastFilePath).Length > 1 * 1024 * 1024)
                {
                    string no = new Regex(@"(?is)(?<=\()(.*)(?=\))").Match(Path.GetFileName(lastFilePath)).Value;
                    int tempno = 0;
                    bool parse = int.TryParse(no, out tempno);
                    string formatno = String.Format("({0})", parse ? (tempno + 1) : tempno);
                    string newFileName = String.Concat(fileNameNotExt, formatno, extension);
                    newFilePath = Path.Combine(logDir, newFileName);
                }
                else
                {
                    newFilePath = lastFilePath;
                }
            }
            else
            {
                string newFileName = String.Concat(fileNameNotExt, String.Format("({0})", 0), extension);
                newFilePath = Path.Combine(logDir, newFileName);
            }
            return newFilePath;
        }

        private static void WriteText(string logPath, string logContent)
        {
            try
            {
                if (!File.Exists(logPath))
                {
                    File.CreateText(logPath).Close();
                }
                StreamWriter sw = File.AppendText(logPath);
                sw.Write(logContent);
                sw.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }


    }
}