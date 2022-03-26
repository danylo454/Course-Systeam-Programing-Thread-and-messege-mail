namespace CourseWPF
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WhereSeachComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addFileBtm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.manuallyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchWordsTexBox = new System.Windows.Forms.TextBox();
            this.addBtm = new System.Windows.Forms.Button();
            this.searchBtm = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WhereSeachComboBox
            // 
            this.WhereSeachComboBox.BackColor = System.Drawing.SystemColors.Menu;
            this.WhereSeachComboBox.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WhereSeachComboBox.FormattingEnabled = true;
            this.WhereSeachComboBox.Location = new System.Drawing.Point(12, 68);
            this.WhereSeachComboBox.Name = "WhereSeachComboBox";
            this.WhereSeachComboBox.Size = new System.Drawing.Size(521, 45);
            this.WhereSeachComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Where to look";
            // 
            // addFileBtm
            // 
            this.addFileBtm.FlatAppearance.BorderSize = 4;
            this.addFileBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFileBtm.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addFileBtm.Location = new System.Drawing.Point(12, 223);
            this.addFileBtm.Name = "addFileBtm";
            this.addFileBtm.Size = new System.Drawing.Size(203, 70);
            this.addFileBtm.TabIndex = 2;
            this.addFileBtm.Text = "File";
            this.addFileBtm.UseVisualStyleBackColor = true;
            this.addFileBtm.Click += new System.EventHandler(this.addFileBtm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "Add a word file or add manually";
            // 
            // manuallyTextBox
            // 
            this.manuallyTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.manuallyTextBox.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.manuallyTextBox.Location = new System.Drawing.Point(12, 387);
            this.manuallyTextBox.Multiline = true;
            this.manuallyTextBox.Name = "manuallyTextBox";
            this.manuallyTextBox.Size = new System.Drawing.Size(440, 78);
            this.manuallyTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 45);
            this.label3.TabIndex = 6;
            this.label3.Text = "Manually";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(805, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 50);
            this.label4.TabIndex = 8;
            this.label4.Text = "Search words";
            // 
            // searchWordsTexBox
            // 
            this.searchWordsTexBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.searchWordsTexBox.Location = new System.Drawing.Point(805, 101);
            this.searchWordsTexBox.Multiline = true;
            this.searchWordsTexBox.Name = "searchWordsTexBox";
            this.searchWordsTexBox.ReadOnly = true;
            this.searchWordsTexBox.Size = new System.Drawing.Size(264, 450);
            this.searchWordsTexBox.TabIndex = 9;
            // 
            // addBtm
            // 
            this.addBtm.FlatAppearance.BorderSize = 4;
            this.addBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addBtm.Location = new System.Drawing.Point(461, 387);
            this.addBtm.Name = "addBtm";
            this.addBtm.Size = new System.Drawing.Size(101, 78);
            this.addBtm.TabIndex = 10;
            this.addBtm.Text = "Add";
            this.addBtm.UseVisualStyleBackColor = true;
            this.addBtm.Click += new System.EventHandler(this.addBtm_Click);
            // 
            // searchBtm
            // 
            this.searchBtm.FlatAppearance.BorderSize = 4;
            this.searchBtm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchBtm.Location = new System.Drawing.Point(461, 550);
            this.searchBtm.Name = "searchBtm";
            this.searchBtm.Size = new System.Drawing.Size(233, 74);
            this.searchBtm.TabIndex = 11;
            this.searchBtm.Text = "Start";
            this.searchBtm.UseVisualStyleBackColor = true;
            this.searchBtm.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bauhaus 93", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(714, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 58);
            this.button1.TabIndex = 12;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.minus_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1092, 695);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchBtm);
            this.Controls.Add(this.addBtm);
            this.Controls.Add(this.searchWordsTexBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.manuallyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addFileBtm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WhereSeachComboBox);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox WhereSeachComboBox;
        private Label label1;
        private Button addFileBtm;
        private Label label2;
        private TextBox manuallyTextBox;
        private Label label3;
        private Label label4;
        private TextBox searchWordsTexBox;
        private Button addBtm;
        private System.Windows.Forms.Timer timer1;
        public Button searchBtm;
        private System.Windows.Forms.Timer timer2;
        private Button button1;
    }
}