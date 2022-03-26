using CourseWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CourseWPF
{
    public class FirstSeach
    {
        private static readonly List<string> baseWords = new List<string> { "shit", "feck", "fuck", "bitch", "bastard", "whore", "jerk" };
        private static List<FoundWords> foundWords = new List<FoundWords>();
        private static List<Statistics> statisticsWords = new List<Statistics>();

        private static void ProcessSearchWords(string path)
        {
            string text = File.ReadAllText(path);
            char[] separator = new char[] { ' ', '.', '?', '!', ',', '\n', '\r' };
            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                foreach (var baseWord in baseWords)
                {
                    if (baseWord.ToLower() == word.ToLower())
                    {
                        FoundWords found = new FoundWords
                        {
                            Paths = path,
                            Word = word,
                            TimeFound = DateTime.Now
                        };
                        foundWords.Add(found);
                    }
                }
            }

        }
        private static void ProcessDirectory(string targetDirectory)
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(targetDirectory, @"*.txt");
                foreach (string fileName in fileEntries)
                {
                    ProcessSearchWords(fileName);
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    ProcessDirectory(subdirectory);
                }

            }
            catch (Exception)
            {

            }
        }
        public static void Statistics()
        {
            if (foundWords.Count() == 0)
            {

            }
            else
            {
                foreach (var item in foundWords)
                {
                    var countWords = foundWords.Where(w => w.Word == item.Word && w.Paths == item.Paths).Select(w => w.Word);
                    if (countWords!= null)
                    {
                        bool isExist = false;
                        foreach (var statistics in statisticsWords)
                        {
                            if (statistics.Name == item.Word)
                            {
                                isExist = true;
                                break;
                            }
                            else
                            {

                            }
                        }
                        if (isExist == false)
                        {
                            var countWordsTemp = foundWords.Where(w => w.Word == item.Word && w.Paths == item.Paths).Count();
                            Statistics statistics = new Statistics
                            {
                                Count = countWordsTemp,
                                Name = item.Word,
                                Path = item.Paths
                            };
                            statisticsWords.Add(statistics);
                        }
                    }
                }
            }
        }
        private static void SendToEmail()
        {
            string? message = null;
            try
            {
                MailAddress From = new MailAddress("glebkondratuk86@gmail.com", "Danylo");
                MailAddress To = new MailAddress("glebkondratuk86@gmail.com");
                MailMessage msg = new MailMessage(From, To);
                msg.Subject = "Coursework Test First Scan";
                foreach (var item in statisticsWords)
                {
                    message += $"Word: {item.Name}   Count: {item.Count}   Path:{item.Path}<br />";
                }
                if (message == null)
                {
                    message = "First scan nothing is finded!!!";
                }
                msg.Body = message;
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("glebkondratuk86@gmail.com", "TestCoursEmail123");
                smtp.EnableSsl = true;
                smtp.Send(msg);

            }
            catch (Exception ex)
            {
            }
        }
        public static void Start()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var item in drives)
            {
                ProcessDirectory(item.Name);
            }
            Statistics();
            SendToEmail();
        }
    }
}
