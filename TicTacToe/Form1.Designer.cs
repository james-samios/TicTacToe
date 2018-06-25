namespace ticTacToe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.spbtn = new System.Windows.Forms.Button();
            this.mmpanel = new System.Windows.Forms.Panel();
            this.extbtn = new System.Windows.Forms.Button();
            this.lbtn = new System.Windows.Forms.Button();
            this.mLabel = new System.Windows.Forms.Label();
            this.mpbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.desk = new System.Windows.Forms.Panel();
            this.winlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userlabel = new System.Windows.Forms.Label();
            this.cmplabel = new System.Windows.Forms.Label();
            this.mmbtn = new System.Windows.Forms.Button();
            this.nlabel = new System.Windows.Forms.Label();
            this.n2label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.n1tb = new System.Windows.Forms.TextBox();
            this.startbtn = new System.Windows.Forms.Button();
            this.n2tb = new System.Windows.Forms.TextBox();
            this.rstrtbtn = new System.Windows.Forms.Button();
            this.scorepanel = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.snglView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.mltView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.mmpanel.SuspendLayout();
            this.scorepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spbtn
            // 
            this.spbtn.Location = new System.Drawing.Point(95, 79);
            this.spbtn.Name = "spbtn";
            this.spbtn.Size = new System.Drawing.Size(161, 40);
            this.spbtn.TabIndex = 1;
            this.spbtn.Text = "Singleplayer (Play vs AI)";
            this.spbtn.UseVisualStyleBackColor = true;
            this.spbtn.Click += new System.EventHandler(this.sp_Click);
            // 
            // mmpanel
            // 
            this.mmpanel.BackColor = System.Drawing.Color.White;
            this.mmpanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mmpanel.BackgroundImage")));
            this.mmpanel.Controls.Add(this.extbtn);
            this.mmpanel.Controls.Add(this.lbtn);
            this.mmpanel.Controls.Add(this.mLabel);
            this.mmpanel.Controls.Add(this.mpbtn);
            this.mmpanel.Controls.Add(this.spbtn);
            this.mmpanel.Location = new System.Drawing.Point(517, 20);
            this.mmpanel.Name = "mmpanel";
            this.mmpanel.Size = new System.Drawing.Size(352, 348);
            this.mmpanel.TabIndex = 2;
            // 
            // extbtn
            // 
            this.extbtn.Location = new System.Drawing.Point(126, 279);
            this.extbtn.Name = "extbtn";
            this.extbtn.Size = new System.Drawing.Size(94, 50);
            this.extbtn.TabIndex = 1;
            this.extbtn.Text = "Exit";
            this.extbtn.UseVisualStyleBackColor = true;
            this.extbtn.Click += new System.EventHandler(this.Exit);
            // 
            // lbtn
            // 
            this.lbtn.Location = new System.Drawing.Point(95, 210);
            this.lbtn.Name = "lbtn";
            this.lbtn.Size = new System.Drawing.Size(161, 35);
            this.lbtn.TabIndex = 12;
            this.lbtn.Text = "Leaderboard";
            this.lbtn.UseVisualStyleBackColor = true;
            this.lbtn.Click += new System.EventHandler(this.lb_Click);
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mLabel.Location = new System.Drawing.Point(76, 18);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(198, 37);
            this.mLabel.TabIndex = 2;
            this.mLabel.Text = "Tic Tac Toe";
            // 
            // mpbtn
            // 
            this.mpbtn.Location = new System.Drawing.Point(95, 142);
            this.mpbtn.Name = "mpbtn";
            this.mpbtn.Size = new System.Drawing.Size(161, 40);
            this.mpbtn.TabIndex = 1;
            this.mpbtn.Text = "Multiplayer";
            this.mpbtn.UseVisualStyleBackColor = true;
            this.mpbtn.Click += new System.EventHandler(this.mp_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(378, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 45);
            this.label1.TabIndex = 5;
            // 
            // desk
            // 
            this.desk.BackColor = System.Drawing.SystemColors.Menu;
            this.desk.Location = new System.Drawing.Point(14, 20);
            this.desk.Name = "desk";
            this.desk.Size = new System.Drawing.Size(352, 302);
            this.desk.TabIndex = 2;
            // 
            // winlabel
            // 
            this.winlabel.BackColor = System.Drawing.Color.Transparent;
            this.winlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.winlabel.ForeColor = System.Drawing.Color.Maroon;
            this.winlabel.Location = new System.Drawing.Point(6, 328);
            this.winlabel.Name = "winlabel";
            this.winlabel.Size = new System.Drawing.Size(360, 92);
            this.winlabel.TabIndex = 5;
            this.winlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(385, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Player 1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(384, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Player 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(378, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Score:";
            // 
            // userlabel
            // 
            this.userlabel.AutoSize = true;
            this.userlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userlabel.Location = new System.Drawing.Point(458, 61);
            this.userlabel.Name = "userlabel";
            this.userlabel.Size = new System.Drawing.Size(16, 18);
            this.userlabel.TabIndex = 7;
            this.userlabel.Text = "0";
            // 
            // cmplabel
            // 
            this.cmplabel.AutoSize = true;
            this.cmplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmplabel.Location = new System.Drawing.Point(458, 99);
            this.cmplabel.Name = "cmplabel";
            this.cmplabel.Size = new System.Drawing.Size(16, 18);
            this.cmplabel.TabIndex = 7;
            this.cmplabel.Text = "0";
            // 
            // mmbtn
            // 
            this.mmbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mmbtn.Location = new System.Drawing.Point(378, 328);
            this.mmbtn.Name = "mmbtn";
            this.mmbtn.Size = new System.Drawing.Size(100, 30);
            this.mmbtn.TabIndex = 8;
            this.mmbtn.Text = "Main Menu";
            this.mmbtn.UseVisualStyleBackColor = true;
            this.mmbtn.Click += new System.EventHandler(this.mm_Click);
            // 
            // nlabel
            // 
            this.nlabel.AutoSize = true;
            this.nlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nlabel.Location = new System.Drawing.Point(379, 61);
            this.nlabel.Name = "nlabel";
            this.nlabel.Size = new System.Drawing.Size(53, 18);
            this.nlabel.TabIndex = 7;
            this.nlabel.Text = "Player:";
            // 
            // n2label
            // 
            this.n2label.AutoSize = true;
            this.n2label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.n2label.Location = new System.Drawing.Point(379, 99);
            this.n2label.Name = "n2label";
            this.n2label.Size = new System.Drawing.Size(78, 18);
            this.n2label.TabIndex = 7;
            this.n2label.Text = "Computer:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(372, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Enter your name:";
            // 
            // n1tb
            // 
            this.n1tb.Location = new System.Drawing.Point(378, 196);
            this.n1tb.Name = "n1tb";
            this.n1tb.Size = new System.Drawing.Size(100, 21);
            this.n1tb.TabIndex = 11;
            // 
            // startbtn
            // 
            this.startbtn.Location = new System.Drawing.Point(378, 287);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(100, 35);
            this.startbtn.TabIndex = 12;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // n2tb
            // 
            this.n2tb.Location = new System.Drawing.Point(378, 241);
            this.n2tb.Name = "n2tb";
            this.n2tb.Size = new System.Drawing.Size(100, 21);
            this.n2tb.TabIndex = 11;
            // 
            // rstrtbtn
            // 
            this.rstrtbtn.Location = new System.Drawing.Point(378, 287);
            this.rstrtbtn.Name = "rstrtbtn";
            this.rstrtbtn.Size = new System.Drawing.Size(100, 35);
            this.rstrtbtn.TabIndex = 12;
            this.rstrtbtn.Text = "Restart";
            this.rstrtbtn.UseVisualStyleBackColor = true;
            this.rstrtbtn.Click += new System.EventHandler(this.rstrtbtn_Click);
            // 
            // scorepanel
            // 
            this.scorepanel.BackColor = System.Drawing.SystemColors.Menu;
            this.scorepanel.Controls.Add(this.radioButton2);
            this.scorepanel.Controls.Add(this.radioButton1);
            this.scorepanel.Controls.Add(this.snglView);
            this.scorepanel.Controls.Add(this.label3);
            this.scorepanel.Controls.Add(this.mltView);
            this.scorepanel.Controls.Add(this.button1);
            this.scorepanel.Location = new System.Drawing.Point(899, 20);
            this.scorepanel.Name = "scorepanel";
            this.scorepanel.Size = new System.Drawing.Size(347, 421);
            this.scorepanel.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(24, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 19);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Multiplayer";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(24, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 19);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Singleplayer";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // snglView
            // 
            this.snglView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.snglView.Location = new System.Drawing.Point(24, 57);
            this.snglView.Name = "snglView";
            this.snglView.Size = new System.Drawing.Size(270, 323);
            this.snglView.TabIndex = 3;
            this.snglView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Wins";
            this.columnHeader6.Width = 50;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Losses";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Score";
            this.columnHeader8.Width = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Leaderboard";
            // 
            // mltView
            // 
            this.mltView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.mltView.Location = new System.Drawing.Point(24, 57);
            this.mltView.Name = "mltView";
            this.mltView.Size = new System.Drawing.Size(270, 301);
            this.mltView.TabIndex = 3;
            this.mltView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Wins";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Losses";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Score";
            this.columnHeader4.Width = 100;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(24, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Return to Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.mm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 451);
            this.Controls.Add(this.winlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.rstrtbtn);
            this.Controls.Add(this.n2tb);
            this.Controls.Add(this.n1tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mmbtn);
            this.Controls.Add(this.n2label);
            this.Controls.Add(this.nlabel);
            this.Controls.Add(this.cmplabel);
            this.Controls.Add(this.userlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mmpanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.desk);
            this.Controls.Add(this.scorepanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Tic Tac Toe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mmpanel.ResumeLayout(false);
            this.mmpanel.PerformLayout();
            this.scorepanel.ResumeLayout(false);
            this.scorepanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button spbtn;
        private System.Windows.Forms.Panel mmpanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mpbtn;
        private System.Windows.Forms.Panel desk;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Button extbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label userlabel;
        private System.Windows.Forms.Label cmplabel;
        private System.Windows.Forms.Button mmbtn;
        private System.Windows.Forms.Label nlabel;
        private System.Windows.Forms.Label n2label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox n1tb;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.TextBox n2tb;
        private System.Windows.Forms.Button lbtn;
        private System.Windows.Forms.Button rstrtbtn;
        private System.Windows.Forms.Label winlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel scorepanel;
        private System.Windows.Forms.ListView mltView;
        private System.Windows.Forms.ListView snglView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button1;
    }
}


