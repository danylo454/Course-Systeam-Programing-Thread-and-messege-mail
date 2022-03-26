using CourseWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace CourseWPF
{
    public class SearchWords
    {
        private static List<string> wordsToSearching = new List<string>();
        private static List<FoundWords> foundWords = new List<FoundWords>();
        private static string nameFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Search_Data_Cource";
        private static string nameFile = nameFolder + @"\Search_file";
        private static string nameFileCopy = nameFolder + @"\Search_file_Encrypted";
        private static string nameFileStatistics = nameFolder + @"\Search_file_Statistics";
        private static string namePathWithoutSearching;
        private static string messageMailTo;
        public static void SendToEmail()
        {
            try
            {
                MailAddress From = new MailAddress("glebkondratuk86@gmail.com", "Danylo");
                MailAddress To = new MailAddress("glebkondratuk86@gmail.com");
                MailMessage msg = new MailMessage(From, To);
                msg.Subject = "Coursework Test";
                if (foundWords.Count() != 0)
                {
                    msg.Attachments.Add(new Attachment(nameFileCopy));
                    msg.Attachments.Add(new Attachment(nameFileStatistics));
                    msg.Attachments.Add(new Attachment(nameFile));
                }
                else
                {
                    msg.Body = messageMailTo;
                }
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
        private static void ProcessReadFileAndWriteInList(object fileNameT)
        {
            string fileName = fileNameT as string;
            if (fileName.ToString() == namePathWithoutSearching)
            {

            }
            else
            {
                char[] separator = new char[] { ' ', '.', '?', '!', ',', '\n', '\r' };
                string path = fileName as string;
                string text = File.ReadAllText(path);
                string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    foreach (var wordsS in wordsToSearching)
                    {
                        
                        if (word == wordsS)
                        {
                            FoundWords foundWord = new FoundWords()
                            {
                                Word = word,
                                Paths = path,
                                TimeFound = DateTime.Now
                            };
                            foundWords.Add(foundWord);
                        }
                    }
                }
            }
        }
        private static void ProcessDirectory(object targetDirectoryTemp)
        {
            string targetDirectory = targetDirectoryTemp as string;
            try
            {
                string[] fileEntries = Directory.GetFiles(targetDirectory, @"*.txt");
                foreach (string fileName in fileEntries)
                {
                    ProcessReadFileAndWriteInList(fileName);
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
        private static void SaveStatisticInFile()
        {
            File.Create(nameFileStatistics).Close();
            List<FoundWords> allWords = foundWords.OrderBy(p => p.Word).ToList();
            List<Statistics> listStat = new List<Statistics>();
            foreach (var item in allWords)
            {
                int countWord = allWords.Count(p => p.Word == item.Word && p.Paths == item.Paths);
                if (countWord < 0)
                {
                    Statistics statistics = new Statistics()
                    { Count = countWord, Name = item.Word, Path = item.Paths };
                    listStat.Add(statistics);
                }
                else
                {
                    bool ifExist = listStat.Where(p => p.Name == item.Word && p.Path == item.Paths).Any();
                    if (ifExist == true)
                    {
                        foreach (var word in listStat)
                        {
                            if (word.Path == item.Paths && word.Name == item.Word)
                            {
                                word.Count = countWord;
                            }
                        }
                    }
                    else
                    {
                        Statistics statistics = new Statistics()
                        { Count = countWord, Name = item.Word, Path = item.Paths };
                        listStat.Add(statistics);
                    }
                }

            }
            using (StreamWriter writer = File.AppendText(nameFileStatistics))
            {
                foreach (var item in listStat.OrderByDescending(x => x.Count))
                {
                    writer.WriteLine($"Word:| {item.Name} |\tNumber of Words: | {item.Count} |\tPath: {item.Path}");
                }
            }
        }
        private static void SaveInFile()
        {
            if (foundWords.Count > 0)
            {
                if (Directory.Exists(nameFolder))
                {
                    Directory.Delete(nameFolder, true);
                }
                Directory.CreateDirectory(nameFolder);
                File.Create(nameFile).Close();
                File.Create(nameFileCopy).Close();
                SaveStatisticInFile();
                using (StreamWriter writer = File.AppendText(nameFile))
                {
                    foreach (var item in foundWords.OrderBy(x => x.Word))
                    {
                        writer.WriteLine("Word: " + item.Word + "\tPath: " + item.Paths + "\tTime Found: " + item.TimeFound);
                    }
                }
                using (StreamWriter writer = File.AppendText(nameFileCopy))
                {
                    foreach (var item in foundWords.OrderBy(x => x.Word))
                    {
                        writer.WriteLine(new string('*', item.Word.Length) + "\tPath: " + item.Paths + "\tTime Found: " + item.TimeFound);
                    }
                }

            }
            else
            {
                messageMailTo = $"Nothing was found {DateTime.Now}!!!";
            }



        }
        public static void Start(object o)
        {
            foundWords = new List<FoundWords>();
            CreateCtrBySearchWords createCtr = o as CreateCtrBySearchWords;
            wordsToSearching = createCtr.List;
            namePathWithoutSearching = createCtr.NamePathWithoutSearching;
            ProcessDirectory(createCtr.Path);
            SaveInFile();
            SendToEmail();
        }
    }
}
