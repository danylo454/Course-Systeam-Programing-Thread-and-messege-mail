using CourseWPF.Models;

namespace CourseWPF
{

    public partial class FormMain : Form
    {

        private static Thread? ThreadF = new Thread(new ParameterizedThreadStart(SearchWords.Start));
        private static List<String> wordsList = new List<String>();
        private static string? namePathWithoutSearching = null;
        private static Random random = new Random();
        private static Thread firstSeach = new Thread(FirstSeach.Start);
        public FormMain()
        {
            InitializeComponent();
            IniteComboBox();
            firstSeach.Start();
        }
        private void IniteComboBox()
        {
            WhereSeachComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DriveInfo[] drives = DriveInfo.GetDrives();
            WhereSeachComboBox.Items.Add(pathDesktop);
            foreach (var item in drives)
            {
                try
                {
                    if (Directory.GetDirectories(item.Name.ToString()).Count() >= 1 || Directory.GetFiles(item.Name.ToString()).Count() >= 1)
                    {
                        WhereSeachComboBox.Items.Add(item.Name.ToString());
                    }

                }
                catch (Exception)
                {

                }
            }
            WhereSeachComboBox.SelectedItem = WhereSeachComboBox.Items[0].ToString();

        }
        private void DeInite()
        {
            manuallyTextBox.Text = null;
            searchWordsTexBox.Text = null;
            wordsList = new List<string>();
            ThreadF = new Thread(new ParameterizedThreadStart(SearchWords.Start));
        }
        private void ExcludeAll()
        {
            addFileBtm.Enabled = false;
            addBtm.Enabled = false;
            searchBtm.Enabled = false;
        }
        private void IncludeAll()
        {
            addFileBtm.Enabled = true;
            addBtm.Enabled = true;
            searchBtm.Enabled = true;
        }
        private void addFileBtm_Click(object sender, EventArgs e)
        {
            searchWordsTexBox.Text = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "View text files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt פאיכû (*.txt)|*.txt|ֲסו פאיכû (*.*)|*.*";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                namePathWithoutSearching = openFileDialog1.FileName;
                string textFile = File.ReadAllText(openFileDialog1.FileName);
                char[] separator = new char[] { ' ', '.', '?', '!', ',', '\n', '\r', '\\', '/' };
                string[] newTextFile = textFile.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in newTextFile)
                {
                    wordsList.Add(word);
                    searchWordsTexBox.Text += word + Environment.NewLine;
                }
            }
        }
        private void addBtm_Click(object sender, EventArgs e)
        {
            char[] separator = new char[] { ' ', '.', '?', '!', ',', '\n', '\r', '\\', '/', '-', '=', '+', ':', ';', ')', '(' };
            string words = manuallyTextBox.Text;
            string[] newWords = words.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in newWords)
            {
                wordsList.Add(word);
                searchWordsTexBox.Text += word + Environment.NewLine;
            }
            manuallyTextBox.Text = null;
        }
        private void startbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchWordsTexBox.Text))
            {
                searchBtm.ForeColor = Color.IndianRed;
                searchBtm.Update();
                Thread.Sleep(500);
                searchBtm.ForeColor = Color.Black;
                searchBtm.Update();

            }
            else
            {
                timer1.Start();
                CreateCtrBySearchWords createCtr = new CreateCtrBySearchWords()
                {
                    List = wordsList,
                    Path = WhereSeachComboBox.SelectedItem.ToString(),
                    NamePathWithoutSearching = namePathWithoutSearching
                };
                ThreadF.Start(createCtr);
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ThreadF.IsAlive == true)
            {
                searchBtm.Text = "Searching";
                searchBtm.BackColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), 0);
                searchBtm.Update();
                ExcludeAll();
            }
            else
            {
                IncludeAll();
                DeInite();
                this.BackColor = Color.FromArgb(153, 180, 209);
                timer1.Stop();
                searchBtm.Text = "Search End";
                searchBtm.Update();
                Thread.Sleep(1000);
                searchBtm.Text = "Start";
                searchBtm.Update();
                searchBtm.BackColor = Color.FromArgb(153, 180, 209);

            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (firstSeach.IsAlive == false)
            {
                timer2.Stop();
                this.Close();
            }
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (firstSeach.IsAlive == true)
            {
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Interval = 500;
                timer2.Start();
                e.Cancel = true;
                this.Visible = false;
            }
            else
            {
            }
        }
        private void minus_Click(object sender, EventArgs e)
        {
            if (wordsList.Count() != 0)
            {
                var tempList = wordsList.Take(wordsList.Count() - 1).ToArray();
                wordsList.Clear();
                wordsList.AddRange(tempList);
                searchWordsTexBox.Clear();
                foreach (var word in wordsList)
                {
                    searchWordsTexBox.Text += word + Environment.NewLine;
                }
                searchWordsTexBox.Update();
            }
        }
    }
}