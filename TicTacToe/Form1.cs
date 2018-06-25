using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace ticTacToe
{
    public partial class Form1 : Form
    {
        public bool checkStart = false; //need for check at beginning of game
        public bool Center = true;  // if true then computer go to center if not find another way
        private bool queue = true; // multiplayer if queue - true is first cross.
        Graphics g;
        Bitmap DrawArea;
        private PictureBox[] pictureBoxes = new PictureBox[9];
        private int Index;
        private int count = 0;
        string name = "";
        string name1 = "";
        string[] check = { "CHECK" };
        string[] check1 = { "CHECK" };



        private int X = 0, Y = 0;
        private bool player = false; //field for changing player figures each game 
        private int HeightP = 100;
        private int WidthP = 100;
        int w = 0, d = 0, l = 0, bl = 0;
        int w1 = 0, l1 = 0;
        private int uscore = 0;
        private int cmscore = 0;
        private int k;
        private int you = 0;
        public int line = 0;
        public int x = -1;
        public int y = -1;
        public int xfir = -1;
        public int yfir = -1;
        public int xlast = -1;
        public int ylast = -1;
        public int win = 0; //1: computer win 2: player win, 3: draw
        public bool compStep = false; 
        public int firststep = 2; // who goes first, 1: computer, 2: player
        public int[] a = new int[9]; // if 0 - empty cell 1- cross - 2 - circle
        public Form1()
        {

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) // static fields
        {
            Height = 380;
            Width = 380;
            desk.Visible = false;
            mmpanel.Location = new Point(0, 0);
            for (int i = 0; i < 9; i++)
            {
                a[i] = 0;
            }
          
        }
        private void Field(int k) // getting picturebox field for playing
        {
            Index = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    pictureBoxes[Index] = new PictureBox() //each cell element of picturebox array
                    {
                        Name = Index.ToString(),
                        Height = HeightP,
                        Width = WidthP,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = new Point(X, Y),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,

                    };
                    if (k == 2)
                        pictureBoxes[Index].Click += desk_Click;
                    else if (k == 1)
                        pictureBoxes[Index].Click += desk_Click1;

                    desk.Controls.Add(pictureBoxes[Index]);
                    if (Index != 8)
                        Index++;
                    X += WidthP;
                }
                Y += HeightP;
                X = 0;
            }
        }



        private void sp_Click(object sender, EventArgs e) // singleplayer mode start
        {
            winlabel.Visible = false;
            n1tb.Visible = true;

            label4.Visible = false;
            label6.Visible = false;
            mmpanel.Visible = false;
            desk.Visible = true;
            n2tb.Visible = false;
            Height = 450;
            Width = 520;
            k = 2;
            Field(2);
            if (firststep == 1)
            {
                compStep = true;
                Step1(); // first computer step 
            }
            else
            {


                compStep = false;
                userlabel.Text = uscore.ToString();
                cmplabel.Text = cmscore.ToString();
            }
        }
        private void mp_Click(object sender, EventArgs e) // multiplayer mode start
        {
            winlabel.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            n2tb.Visible = true;
            n1tb.Visible = true;

            mmpanel.Visible = false;
            desk.Visible = true;
            Height = 450;
            Width = 520;
            k = 1;
            winlabel.Visible = false;
            Field(1);

            n2label.Text = "Player 2: ";

        }
        private void Exit(object sender, EventArgs e) // exit
        {
            Application.Exit();
        }

        private void desk_Click(object sender, EventArgs e) // onclick event for singleplayer
        {

            PictureBox ClickImage = sender as PictureBox; //index from picturebox array by name
            string ParsName = ClickImage.Name;
            int IndexSelectImage = Convert.ToInt32(ParsName);
            if (checkStart)
            {
                if (compStep == false)
                {
                    label1.Text = "Your Turn!";

                    if (firststep == 2)
                    {
                        if (a[IndexSelectImage] == 0)
                        {

                            DrawArea = new Bitmap(pictureBoxes[IndexSelectImage].Size.Width, pictureBoxes[IndexSelectImage].Size.Height);
                            pictureBoxes[IndexSelectImage].Image = DrawArea;
                            g = Graphics.FromImage(DrawArea);
                            Pen p = new Pen(Color.Black, 3);
                            g.DrawLine(p, 2, 2, 98, 98);
                            g.DrawLine(p, 98, 2, 2, 98);
                            a[IndexSelectImage] = 2;
                            xlast = 0;
                            ylast = 0;

                            compStep = true;
                            checkforwin();

                            NotfirstStep();


                        }
                    }

                    else
                    {

                        if (a[IndexSelectImage] == 0)
                        {
                            DrawArea = new Bitmap(pictureBoxes[IndexSelectImage].Size.Width, pictureBoxes[IndexSelectImage].Size.Height);
                            pictureBoxes[IndexSelectImage].Image = DrawArea;

                            g = Graphics.FromImage(DrawArea);
                            Pen p = new Pen(Color.Black, 3);
                            g.DrawEllipse(p, 4, 4, 92, 92);
                            a[IndexSelectImage] = 2;
                            xlast = 0;
                            ylast = 0;
                            compStep = true;
                            NotfirstStep();

                        }
                    }
                }
            }

        }
        private void desk_Click1(object sender, EventArgs e) // onclick event for multiplayer
        {


            PictureBox ClickImage = sender as PictureBox; //index from picturebox array by name
            string ParsName = ClickImage.Name;
            int IndexSelectImage = Convert.ToInt32(ParsName);
            if (checkStart)
            {
                if (queue == true)
                {

                    if (a[IndexSelectImage] == 0)
                    {

                        label1.Text = name1 + "'s Turn!";

                        DrawArea = new Bitmap(pictureBoxes[IndexSelectImage].Size.Width, pictureBoxes[IndexSelectImage].Size.Height);
                        pictureBoxes[IndexSelectImage].Image = DrawArea;
                        g = Graphics.FromImage(DrawArea);
                        Pen p = new Pen(Color.Black, 3);
                        g.DrawLine(p, 2, 2, 98, 98);
                        g.DrawLine(p, 98, 2, 2, 98);
                        a[IndexSelectImage] = 2;
                        queue = false;
                        deadheat();

                        checkforwin();
                        if (win == 1 || win == 3)
                            winner(1);
                    }
                }
                else
                {
                    if (a[IndexSelectImage] == 0)

                    {


                        label1.Text = name + "'s Turn!";
                        DrawArea = new Bitmap(pictureBoxes[IndexSelectImage].Size.Width, pictureBoxes[IndexSelectImage].Size.Height);
                        pictureBoxes[IndexSelectImage].Image = DrawArea;

                        g = Graphics.FromImage(DrawArea);
                        Pen p = new Pen(Color.Black, 3);
                        g.DrawEllipse(p, 4, 4, 92, 92);
                        a[IndexSelectImage] = 1;
                        queue = true;

                        deadheat();
                        checkforwin();

                        if (win == 1 || win == 3)
                            winner(1);

                    }
                }


            }
        }
        private void Step1() // first bot step
        {
            if (a[4] == 0)
            {
                a[4] = 1;
            }
            else
            {
                random();
            }
            paint();
            compStep = false;
            Center = false;
        }
        private void NotfirstStep()//
        {
            if (checkStart == true)
            {
                deadheat(); // checking for deadheat
                winstep();  // find winner (last tile)
            }
            if (win == 0)
            {
                defend();
                if (compStep == true)
                {
                    if (firststep == 1) 
                    {
                        opposite();
                    }
                    else //if computer goes second
                    {
                        if (xfir == 1 && yfir == 1)  // if user go center comp go on corner
                        {
                            corner();
                        }
                        else //if user not in center comp go in center
                        {
                            if (Center)
                            {
                                Step1();
                                Center = false;
                            }
                            else
                            {
                                corner();
                            }
                        }
                    }
                }
                deadheat();
            }

            else
            {
                if (win != 3) winner(2); // cheking for win if yes draw line
            }

        }
        private void random()
        {

            bool rand = false;
            for (int i = 0; i < 9; i++)
            {

                if (rand == false)
                {
                    if (a[i] == 0)
                    {
                        a[i] = 1;
                        rand = true;
                        compStep = false;
                        paint();
                    }
                }

            } //random step
        }
        private void paint() // paint cross and circle
        {
            int j;

            for (int i = 0; i < 9; i++)
            {

                if (firststep == 1)
                {
                    if (a[i] == 1)
                    {
                        j = i % 3 - 1;
                        if (j == -1)
                            j = 2;
                        DrawArea = new Bitmap(pictureBoxes[i].Size.Width, pictureBoxes[i].Size.Height);
                        pictureBoxes[i].Image = DrawArea;

                        g = Graphics.FromImage(DrawArea);
                        Pen p = new Pen(Color.Black, 3);
                        g.DrawLine(p, 2, 2, 98, 98);
                        g.DrawLine(p, 98, 2, 2, 98);


                    }
                }
                else   //if second 1 - circle
                {
                    if (a[i] == 1)
                    {
                        j = i % 3 - 1;
                        if (j == -1)
                            j = 2;
                        DrawArea = new Bitmap(pictureBoxes[i].Size.Width, pictureBoxes[i].Size.Height);
                        pictureBoxes[i].Image = DrawArea;

                        g = Graphics.FromImage(DrawArea);
                        Pen p = new Pen(Color.Black, 3);
                        g.DrawEllipse(p, 4, 4, 92, 92);
                    }
                }
            }

        }
        private void winner(int k) // if game ended
        {
            int[] arr = new int[3];
            int type = 0;
            bool t = true;
            Pen p = new Pen(Color.Red, 6);
            Pen p1 = new Pen(Color.Black, 3);

            switch (line)
            {

                case 4: arr[0] = 0; arr[1] = 1; arr[2] = 2; type = 0; break;
                case 5: arr[0] = 3; arr[1] = 4; arr[2] = 5; type = 0; break;
                case 6: arr[0] = 6; arr[1] = 7; arr[2] = 8; type = 0; ; break;
                case 1: arr[0] = 0; arr[1] = 3; arr[2] = 6; type = 1; break;
                case 2: arr[0] = 1; arr[1] = 4; arr[2] = 7; type = 1; break;
                case 3: arr[0] = 2; arr[1] = 5; arr[2] = 8; type = 1; break;
                case 7: arr[0] = 0; arr[1] = 4; arr[2] = 8; type = 2; break;
                case 8: arr[0] = 2; arr[1] = 4; arr[2] = 6; type = 3; break;
                default: t = false; break;
            }
            if (line > 0)
            {

                if (k == 1 && queue == false && win == 1)
                {
                    label1.Text = name + " wins!";
                    w++;
                    l1++;
                    player = true;
                    uscore += 1;
                    checkStart = false;
                    userlabel.Text = uscore.ToString();
                    cmplabel.Text = cmscore.ToString();
                }
                else if (k == 1 && queue == true && win == 1)
                {
                    label1.Text = name1 + " wins!";
                    cmscore += 1;
                    w1++;
                    l++;
                    checkStart = false;
                    player = false;
                    userlabel.Text = uscore.ToString();
                    cmplabel.Text = cmscore.ToString();
                }
                else if (k != 1 && you != 1)
                {
                    label1.Text = "Round lost!";
                    bl++;
                    l++;
                    cmscore += 1;
                    userlabel.Text = uscore.ToString();
                    cmplabel.Text = cmscore.ToString();

                }
                else if (you == 1)

                {
                    label1.Text = "Round won!";
                    w++;
                    uscore += 1;
                    userlabel.Text = uscore.ToString();
                    cmplabel.Text = cmscore.ToString();

                }
            }
            else if (win == 3)
            {
                label1.Text = "Draw!";
                d++;

                this.Refresh();

                checkStart = false;
                Thread.Sleep(3000);
                Application.DoEvents();
                newgame(k);


            }

            if (t)
            {
                foreach (int i in arr)
                {
                    DrawArea = new Bitmap(pictureBoxes[i].Size.Width, pictureBoxes[i].Size.Height);
                    pictureBoxes[i].Image = DrawArea;

                    g = Graphics.FromImage(DrawArea);
                    if (type == 0)
                    {
                        g.DrawLine(p, 0, 50, 100, 50);

                    }
                    else if (type == 1)
                        g.DrawLine(p, 50, 0, 50, 100);
                    else if (type == 2)
                        g.DrawLine(p, 0, 0, 98, 100);
                    else if (type == 3)
                        g.DrawLine(p, 0, 100, 100, 0);
                    if (k == 1)
                    {
                        if (queue == true)
                            g.DrawEllipse(p1, 4, 4, 92, 92);
                        else if (queue == false)
                        {
                            g.DrawLine(p1, 2, 2, 98, 98);
                            g.DrawLine(p1, 98, 2, 2, 98);
                        }
                    }
                    else if (k == 2 && you != 1)
                    {
                        if (firststep == 2)
                            g.DrawEllipse(p1, 4, 4, 92, 92);
                        else if (firststep == 1)
                        {
                            g.DrawLine(p1, 2, 2, 98, 98);
                            g.DrawLine(p1, 98, 2, 2, 98);
                        }
                    }
                    else if (you == 1)
                    {
                        if (firststep == 2)
                        {
                            g.DrawLine(p1, 2, 2, 98, 98);
                            g.DrawLine(p1, 98, 2, 2, 98);
                        }
                        else if (firststep == 1)
                        {
                            g.DrawEllipse(p1, 4, 4, 92, 92);
                        }
                    }
                    pictureBoxes[i].Refresh();

                }



                this.Refresh();


                checkStart = false;
                Thread.Sleep(3000);
                Application.DoEvents();
                newgame(k);

            }


        }
        private void checkforwin()
        {

            if ((a[0] == 1 && a[1] == 1 && a[2] == 1) || (a[0] == 2 && a[1] == 2 && a[2] == 2))
            { line = 4; win = 1; }
            if ((a[3] == 1 && a[4] == 1 && a[5] == 1) || (a[3] == 2 && a[4] == 2 && a[5] == 2))
            { line = 5; win = 1; }
            if ((a[6] == 1 && a[7] == 1 && a[8] == 1) || (a[6] == 2 && a[7] == 2 && a[8] == 2))
            { line = 6; win = 1; }
            if ((a[0] == 1 && a[3] == 1 && a[6] == 1) || (a[0] == 2 && a[3] == 2 && a[6] == 2))
            { line = 1; win = 1; }
            if ((a[1] == 1 && a[4] == 1 && a[7] == 1) || (a[1] == 2 && a[4] == 2 && a[7] == 2))
            { line = 2; win = 1; }
            if ((a[2] == 1 && a[5] == 1 && a[8] == 1) || (a[2] == 2 && a[5] == 2 && a[8] == 2))
            { line = 3; win = 1; }
            if ((a[0] == 1 && a[8] == 1 && a[4] == 1) || (a[0] == 2 && a[4] == 2 && a[8] == 2))
            { line = 7; win = 1; }
            if ((a[2] == 1 && a[4] == 1 && a[6] == 1) || (a[2] == 2 && a[4] == 2 && a[6] == 2))
            { line = 8; win = 1; }
            if (k == 2 && line > 0)
            {
                checkStart = false;
                you = 1;

            }


        }
        private void winstep() //final step
        {

            if (((a[0] + a[1] + a[2]) == 2) && (a[0] == 1 || a[1] == 1 || a[2] == 1))  //1-4-7  - 
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[j] == 0)
                    {
                        a[j] = 1;
                    }
                }
                win = 1;
                paint();
                line = 4;
            }
            else
            {
                if (((a[3] + a[4] + a[5]) == 2) && (a[3] == 1 || a[4] == 1 || a[5] == 1))   //2-5-8 
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (a[j + 3] == 0)
                        {
                            a[j + 3] = 1;
                        }
                    }
                    win = 1;
                    paint();
                    line = 5;
                }
                else
                {
                    if (((a[6] + a[7] + a[8]) == 2) && (a[6] == 1 || a[7] == 1 || a[8] == 1))   //3-6-9 
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            if (a[6 + j] == 0)
                            {
                                a[6 + j] = 1;
                            }
                        }
                        win = 1;
                        paint();
                        line = 6;
                    }
                    else
                    {
                        if (((a[0] + a[3] + a[6]) == 2) && (a[0] == 1 || a[3] == 1 || a[6] == 1))   //1-2-3  
                        {

                            for (int i = 0; i < 9; i += 3)
                            {
                                if (a[i] == 0)
                                {
                                    a[i] = 1;
                                }
                            }
                            win = 1;
                            paint();
                            line = 1;
                        }
                        else
                        {
                            if (((a[1] + a[4] + a[7]) == 2) && (a[1] == 1 || a[4] == 1 || a[7] == 1))  //4-5-6 
                            {

                                for (int i = 0; i < 9; i += 3)
                                {
                                    if (a[i + 1] == 0)
                                    {
                                        a[i + 1] = 1;
                                    }
                                }
                                win = 1;
                                paint();
                                line = 2;
                            }
                            else
                            {
                                if (((a[2] + a[5] + a[8]) == 2) && (a[2] == 1 || a[5] == 1 || a[8] == 1))   //7-8-9  
                                {

                                    for (int i = 0; i < 9; i += 3)
                                    {
                                        if (a[i + 2] == 0)
                                        {
                                            a[i + 2] = 1;
                                        }
                                    }
                                    win = 1;
                                    paint();
                                    line = 3;
                                }
                                else
                                {
                                    if (((a[0] + a[4] + a[8]) == 2) && (a[0] == 1 || a[4] == 1 || a[8] == 1))   //1-5-9
                                    {
                                        if (a[0] == 0)
                                            a[0] = 1;
                                        if (a[4] == 0)
                                            a[4] = 1;
                                        if (a[8] == 0)
                                            a[8] = 1;
                                        win = 1;
                                        paint();
                                        line = 7;

                                    }
                                    else
                                    {
                                        if (((a[6] + a[4] + a[2]) == 2) && (a[6] == 1 || a[4] == 1 || a[2] == 1))   //3-5-7  
                                        {
                                            if (a[6] == 0)
                                                a[6] = 1;
                                            if (a[4] == 0)
                                                a[4] = 1;
                                            if (a[2] == 0)
                                                a[2] = 1;
                                            win = 1;
                                            paint();
                                            line = 8;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void defend()
        {

            if ((a[0] + a[1] + a[2]) == 4 && a[0] != 1 && a[1] != 1 && a[2] != 1)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[j] == 0)
                    {
                        a[j] = 1;
                        compStep = false;
                        paint();
                    }
                }
            }
            else
            {
                if (((a[3] + a[4] + a[5]) == 4) && (a[3] != 1 && a[4] != 1 && a[5] != 1))
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (a[j + 3] == 0)
                        {
                            a[j + 3] = 1;

                            compStep = false;
                            paint();
                        }
                    }
                }
                else
                {
                    if (((a[6] + a[7] + a[8]) == 4) && (a[6] != 1 && a[7] != 1 && a[8] != 1))
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            if (a[6 + j] == 0)
                            {
                                a[6 + j] = 1;
                                compStep = false;
                                paint();

                            }
                        }
                    }
                    else
                    {
                        if (((a[0] + a[3] + a[6]) == 4) && (a[0] != 1 && a[3] != 1 && a[6] != 1))
                        {

                            for (int i = 0; i < 9; i += 3)
                            {
                                if (a[i] == 0)
                                {
                                    a[i] = 1;

                                    compStep = false;
                                    paint();
                                }
                            }
                        }
                        else
                        {
                            if (((a[1] + a[4] + a[7]) == 4) && (a[1] != 1 && a[4] != 1 && a[7] != 1))
                            {

                                for (int i = 0; i < 9; i += 3)
                                {
                                    if (a[i + 1] == 0)
                                    {
                                        a[i + 1] = 1;
                                        compStep = false;
                                        paint();
                                    }
                                }
                            }
                            else
                            {
                                if (((a[2] + a[5] + a[8]) == 4) && (a[2] != 1 && a[5] != 1 && a[8] != 1))
                                {

                                    for (int i = 0; i < 9; i += 3)
                                    {
                                        if (a[i + 2] == 0)
                                        {
                                            a[i + 2] = 1;
                                            compStep = false;
                                            paint();
                                        }
                                    }
                                }
                                else
                                {
                                    if (((a[0] + a[4] + a[8]) == 4) && (a[0] != 1 && a[4] != 1 && a[8] != 1))   //1-5-9  
                                    {
                                        if (a[0] == 0)
                                            a[0] = 1;
                                        if (a[4] == 0)
                                            a[4] = 1;
                                        if (a[8] == 0)
                                            a[8] = 1;
                                        compStep = false;
                                        paint();
                                    }
                                    else
                                    {
                                        if (((a[6] + a[4] + a[2]) == 4) && (a[6] != 1 && a[4] != 1 && a[2] != 1))   //3-5-7 
                                        {
                                            if (a[6] == 0)
                                                a[6] = 1;
                                            if (a[4] == 0)
                                                a[4] = 1;
                                            if (a[2] == 0)
                                                a[2] = 1;
                                            compStep = false;
                                            paint();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void opposite()  // bot tactic by opposite position of figures
        {
            if (xlast == 0 && ylast == 0)
            {
                if (a[8] == 0)
                {
                    a[8] = 1;
                    compStep = false;
                    paint();
                }
                else
                {
                    random();
                }
            }
            else
            {
                if (xlast == 2 && ylast == 0)
                {
                    if (a[2] == 0)
                    {
                        a[2] = 1;
                        compStep = false;
                        paint();
                    }
                    else
                    {
                        random();
                    }
                }
                else
                {
                    if (xlast == 0 && ylast == 2)
                    {
                        if (a[6] == 0)
                        {
                            a[6] = 1;
                            compStep = false;
                            paint();
                        }
                        else
                        {
                            random();
                        }
                    }
                    else
                    {
                        if (xlast == 2 && ylast == 2)
                        {
                            if (a[0] == 0)
                            {
                                a[0] = 1;
                                compStep = false;
                                paint();
                            }
                            else
                            {
                                random();
                            }
                        }
                        else
                        {
                            if (xlast == 0 && ylast == 1)
                            {
                                if (a[6] == 0)
                                {
                                    a[6] = 1;
                                    compStep = false;
                                    paint();
                                }
                                else
                                {
                                    if (a[8] == 0)
                                    {
                                        a[8] = 1;
                                        compStep = false;
                                        paint();
                                    }
                                    else
                                    {
                                        random();
                                    }
                                }
                            }
                            else
                            {
                                if (xlast == 1 && ylast == 0)
                                {
                                    if (a[2] == 0)
                                    {
                                        a[2] = 1;
                                        compStep = false;
                                        paint();
                                    }
                                    else
                                    {
                                        if (a[8] == 0)
                                        {
                                            a[8] = 1;
                                            compStep = false;
                                            paint();
                                        }
                                        else
                                        {
                                            random();
                                        }
                                    }
                                }
                                else
                                {
                                    if (xlast == 2 && ylast == 1)
                                    {
                                        if (a[0] == 0)
                                        {
                                            a[0] = 1;
                                            compStep = false;
                                            paint();
                                        }
                                        else
                                        {
                                            if (a[2] == 0)
                                            {
                                                a[2] = 1;
                                                compStep = false;
                                                paint();
                                            }
                                            else
                                            {
                                                random();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (xlast == 1 && ylast == 2)
                                        {
                                            if (a[0] == 0)
                                            {
                                                a[0] = 1;
                                                compStep = false;
                                                paint();
                                            }
                                            else
                                            {
                                                if (a[6] == 0)
                                                {
                                                    a[6] = 1;
                                                    compStep = false;
                                                    paint();
                                                }
                                                else
                                                {
                                                    random();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void deadheat()
        {
            bool dh = true;
            for (int i = 0; i < 9; i++)   //if find 0 its not a deadheat
            {

                if (dh)
                {
                    if (a[i] == 0)
                    {
                        dh = false;
                    }
                }

            }
            if (dh)
            {
                win = 3;
                if (k != 1)
                    winner(2);

            }
        }
        private void newgame(int k) //initializate all fields remove and create new field
        {



            if (w != 5 && l != 5 && w1 != 5 && bl != 5)
            {

                label1.Text = "";
                line = 0;
                Graphics gPanel = desk.CreateGraphics();

                desk.Controls.Clear();


                X = 0;
                Y = 0;
                HeightP = 100;
                WidthP = 100;
                for (int i = 0; i < 9; i++)
                {

                    a[i] = 0;

                }
                Index = 0;
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {

                        pictureBoxes[Index] = new PictureBox()//each cell element of picturebox array
                        {
                            Name = Index.ToString(),
                            Height = HeightP,
                            Width = WidthP,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Location = new Point(X, Y),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,

                        };
                        if (k == 2)
                            pictureBoxes[Index].Click += desk_Click;
                        else if (k == 1)
                            pictureBoxes[Index].Click += desk_Click1;

                        desk.Controls.Add(pictureBoxes[Index]);
                        if (Index != 8)
                            Index++;
                        X += WidthP;
                    }


                    Y += HeightP;
                    X = 0;
                }

                you = 0;

                line = 0;
                x = -1;
                y = -1;
                xfir = -1;
                yfir = -1;
                xlast = -1;
                ylast = -1;
                win = 0;
                compStep = false;
                Center = true;
                if (k == 2)
                {
                    if (firststep == 2)
                    {
                        firststep = 1;
                        Step1();

                    }
                    else
                        firststep = 2;
                }

                checkStart = true;


            }

            else if (bl == 5)
            {

                winlabel.Visible = true;
                winlabel.BackColor = Color.Transparent;

                winlabel.BringToFront();
                winlabel.Text = nlabel.Text + "! You lost! Better luck next time!";
                AddToScore(nlabel.Text, w, bl, "s_rank.txt");
            }
            else if (w == 5)
            {
                winlabel.Visible = true;
                winlabel.BackColor = Color.Transparent;
                winlabel.BringToFront();

                winlabel.Text = nlabel.Text +" has won, congratulations!" ;
                if (k == 2)
                    AddToScore(nlabel.Text, w, l, "s_rank.txt");
                else if (k == 1)
                {
                    AddToScore(nlabel.Text, w, l, "m_rank.txt");
                    AddToScore(n2label.Text, w1, l1, "m_rank.txt");

                }


            }
            else if (w1 == 5)
            {
                winlabel.Visible = true;
                winlabel.BackColor = Color.Transparent;
                winlabel.BringToFront();

                winlabel.Text = n2label.Text + " has won, congratulations!" ;

                if (k == 1)
                {
                    AddToScore(nlabel.Text, w, l, "m_rank.txt");
                    AddToScore(n2label.Text, w1, l1, "m_rank.txt");

                }

            }


        }
        private void corner() // sneaky bot tactics which means it's practically impossible to win!!
        {
            if (a[0] == 0)
            {
                a[0] = 1;
                compStep = false;
                paint();
            }
            else
            {
                if (a[6] == 0)
                {
                    a[6] = 1;
                    compStep = false;
                    paint();
                }
                else
                {
                    if (a[2] == 0)
                    {
                        a[2] = 1;
                        compStep = false;
                        paint();
                    }
                    else
                    {
                        if (a[8] == 0)
                        {
                            a[8] = 1;
                            compStep = false;
                            paint();
                        }
                        else
                        {
                            fight();
                        }
                    }
                }
            }
        }
        private void Restart()
        {
            winlabel.Visible = false;
            w = 0;
            w1 = 0; l1 = 0;
            l = 0;
            bl = 0;
            winlabel.Visible = false;
            uscore = 0;
            cmscore = 0;
            userlabel.Text = uscore.ToString();
            cmplabel.Text = cmscore.ToString();
            newgame(k);
            queue = true;
            player = false;
            count = 0;
        }



        private void rstrtbtn_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void lb_Click(object sender, EventArgs e)
        {
            scorepanel.Visible = true;
            scorepanel.Location = new Point(0, 0);
            mmpanel.Visible = false;
            winlabel.Visible = false;
            Width = 350;
            Height = 470;
            mltView.View = View.Details;
            mltView.GridLines = true;
            snglView.View = View.Details;
            snglView.GridLines = true;
            string[] lines = File.ReadAllLines("m_rank.txt");
            string[] lines1 = File.ReadAllLines("s_rank.txt");

            mltView.FullRowSelect = true;

            if (!(ReferenceEquals(check,lines))|| !(ReferenceEquals(check1, lines1)))
            {
                foreach (ListViewItem i in mltView.Items)
                    mltView.Items.Remove(i);
                foreach (ListViewItem i in snglView.Items)
                    snglView.Items.Remove(i);
                check = lines;
                check1 = lines1;
                int counter = 0;

                // Add items in the listview
                string[] arr = new string[4];
                ListViewItem itm;
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        Regex regex1 = new Regex(@"\S+");
                        Regex regex2 = new Regex(@"Wins:\d+");
                        Regex regex3 = new Regex(@"Losses:\d+");
                        Regex regex4 = new Regex(@"Score:\d+");
                        Match match1 = regex1.Match(lines[i]);
                        Match match2 = regex2.Match(lines[i]);
                        Match match3 = regex3.Match(lines[i]);
                        Match match4 = regex4.Match(lines[i]);
                        arr[0] = match1.Value;
                        arr[1] = match2.Value.Substring(5, match2.Value.Length - 5);
                        arr[2] = match3.Value.Substring(7, match3.Value.Length - 7);
                        arr[3] = match4.Value.Substring(6, match4.Value.Length - 6);
                        itm = new ListViewItem(arr);
                        if (counter == 0)
                            mltView.Items.Add(itm);
                        else
                            snglView.Items.Add(itm);
                    }
                    counter++;
                    lines = File.ReadAllLines("s_rank.txt");
                }
                counter = 0;
            }
        }
            private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                mltView.Visible = false;
                snglView.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                mltView.Visible = true;
                snglView.Visible = false;
            }
        }



        private void mm_Click(object sender, EventArgs e)
        {
            scorepanel.Visible = false;
            label1.Text = "";
            w1 = 0;
            l1 = 0;
            mmpanel.Visible = true;
            desk.Controls.Clear();
            startbtn.Visible = true;
            desk.Visible = false;
            Height = 380;
            Width = 380;
            X = 0;
            Y = 0;
            HeightP = 100;
            WidthP = 100;
            for (int i = 0; i < 9; i++)
            {

                a[i] = 0;

            }
            w = 0;
            l = 0;
            uscore = 0;
            bl = 0;
            cmscore = 0;
            userlabel.Text = "";
            n1tb.Text = "";
            n2tb.Text = "";
            if (k == 1)
            {
                nlabel.Text = "Player: ";
                n2label.Text = "Computer: ";
            }
            if (k == 2)
            {
                nlabel.Text = "Player 1: ";
                n2label.Text = "Player 2: ";
            }
            cmplabel.Text = "";
            checkStart = false;
            Center = true;
            queue = true;




            count = 0;
            name = "";
            name1 = "";

            player = false;

            w = 0; d = 0; l = 0;


            you = 0;
            line = 0;
            x = -1;
            y = -1;
            xfir = -1;
            yfir = -1;
            xlast = -1;
            ylast = -1;
            win = 0;
            compStep = false;
            firststep = 2;

        }


        private void startbtn_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label6.Visible = false;
            if (k == 2)
            {
                if (n1tb.Text != String.Empty)

                {
                    name = n1tb.Text;
                    checkStart = true;

                    n2tb.Visible = false;
                    n1tb.Visible = false;
                    startbtn.Visible = false;
                    label5.Visible = false;
                    nlabel.Text = n1tb.Text;
                    n1tb.Visible = false;

                }
            }
            else if (k == 1)
            {
                if (n1tb.Text != String.Empty && n2tb.Text != String.Empty)
                {
                    name = n1tb.Text;
                    name1 = n2tb.Text;

                    checkStart = true;
                    if (k == 1)
                        n2tb.Visible = false;
                    n1tb.Visible = false;
                    startbtn.Visible = false;
                    label5.Visible = false;
                    nlabel.Text = n1tb.Text;
                    n2label.Text = n2tb.Text;
                    n1tb.Visible = false;
                }
            }

        }
        private void AddToScore(string name, int w, int l, string path)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(path);
            string s = "";
            bool find = false;
            foreach (string p in lines)
            {
                Regex regex = new Regex(@"\S+");
                Match match = regex.Match(p);
                if (match.Value == name)
                {
                    find = true;
                    s = p;
                    break;

                }

            }
            File.WriteAllText(path, String.Empty);
            if (find == true)
            {

                Regex regex1 = new Regex(@"Wins:\d+");
                Regex regex2 = new Regex(@"Losses:\d+");
                //Regex regex3 = new Regex(@"d:\d+");
                Regex regex4 = new Regex(@"Score:\d+");

                Match match1 = regex1.Match(s);
                Match match2 = regex2.Match(s);
                //Match match3 = regex3.Match(s);
                Match match4 = regex4.Match(s);
                sb.Append(name + "   Wins:" + (Int32.Parse(match1.Value.Substring(5, match1.Value.Length - 5)) + w / 5).ToString() + "   Losses:" + (Int32.Parse(match2.Value.Substring(7, match2.Value.Length - 7)) + l / 5).ToString() + "   Score:" + (Int32.Parse(match4.Value.Substring(6, match4.Value.Length - 6)) + (w / 5) * 5).ToString() );
            }
            else
                sb.Append(name + "   Wins:" + (w / 5).ToString() + "   Losses:" + (l / 5).ToString() + "   Score:" + ((w / 5) * 5).ToString());

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(sb.ToString());
                foreach (string p in lines)
                {
                    if (!p.Equals(s))
                    {
                        writer.WriteLine(p);
                    }
                }
                writer.Close();
            }
            string[] lines1 = File.ReadAllLines(path);

            Sorte(lines1);
            File.WriteAllText(path, String.Empty);
            using (StreamWriter writer = new StreamWriter(path))
            {
                
                foreach (string p in lines1)
                {
                  
                        writer.WriteLine(p);
                    
                }
                writer.Close();
            }

        }

        private void Sorte(string[] lines)
        {
            string temp; int k;
            for (int J = 0; J < lines.Length; J++)
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    Regex regex4 = new Regex(@"Losses:\d+");
                    Match match4 = regex4.Match(lines[i]);
                    Match match5 = regex4.Match(lines[i + 1]);


                    if ((Int32.Parse(match4.Value.Substring(7, match4.Value.Length - 7)) * (1)) > (Int32.Parse(match5.Value.Substring(7, match5.Value.Length - 7)) * (1)))
                    {
                        temp = lines[i];
                        lines[i] = lines[i + 1];
                        lines[i + 1] = temp;

                    }

                }
            for (int J = 0; J < lines.Length ; J++)
                for (int i = 0; i < lines.Length-1; i++)
            {
                     Regex regex4 = new Regex(@"Score:\d+");
                    Match match4 = regex4.Match(lines[i]);
                    Match match5 = regex4.Match(lines[i+1]);
                   

                        if ((Int32.Parse(match4.Value.Substring(6, match4.Value.Length - 6)) * (-1)) > (Int32.Parse(match5.Value.Substring(6, match5.Value.Length - 6)) * (-1)))
                        {
                            temp = lines[i];
                            lines[i] = lines[i + 1];
                            lines[i + 1] = temp;

                    }

                }
        }

        private void fight()
        {
            if ((a[0] + a[1] + a[2]) == 1)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[j] == 0)
                    {
                        a[j] = 1;
                    }
                }
                paint();
            }
            else
            {
                if ((a[3] + a[4] + a[5]) == 1)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (a[j + 3] == 0)
                        {
                            a[j + 3] = 1;
                        }
                    }
                    paint();
                }
                else
                {
                    if ((a[6] + a[7] + a[8]) == 1)
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            if (a[j + 6] == 0)
                            {
                                a[j + 6] = 1;
                            }
                        }
                        paint();
                    }
                    else
                    {
                        if ((a[0] + a[3] + a[6]) == 1)   //1-2-3 
                        {

                            for (int i = 0; i < 9; i += 3)
                            {
                                if (a[i] == 0)
                                {
                                    a[i] = 1;
                                }
                            }
                            paint();
                        }
                        else
                        {
                            if ((a[1] + a[4] + a[7]) == 1)  //4-5-6 
                            {

                                for (int i = 0; i < 3; i += 3)
                                {
                                    if (a[i + 1] == 0)
                                    {
                                        a[i + 1] = 1;
                                    }
                                }
                                paint();
                            }
                            else
                            {
                                if ((a[2] + a[5] + a[8]) == 1)   //7-8-9
                                {

                                    for (int i = 0; i < 3; i += 3)
                                    {
                                        if (a[i + 2] == 0)
                                        {
                                            a[i + 2] = 1;
                                        }
                                    }
                                    paint();
                                }
                                else
                                {
                                    if ((a[0] + a[4] + a[8]) == 1)   //1-5-9 
                                    {
                                        if (a[0] == 0)
                                        {
                                            a[0] = 1;
                                        }
                                        else
                                        {
                                            if (a[4] == 0)
                                            {
                                                a[4] = 1;
                                            }
                                            else
                                            {
                                                if (a[8] == 0)
                                                    a[8] = 1;
                                            }
                                        }
                                        paint();
                                    }
                                    else
                                    {
                                        if ((a[6] + a[4] + a[2]) == 1)   //3-5-7
                                        {
                                            if (a[6] == 0)
                                            {
                                                a[6] = 1;
                                            }
                                            else
                                            {
                                                if (a[4] == 0)
                                                {
                                                    a[4] = 1;
                                                }
                                                else
                                                {
                                                    if (a[2] == 0)
                                                    {
                                                        a[2] = 1;
                                                    }
                                                }
                                            }
                                            paint();
                                        }
                                        else
                                        {
                                            random();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



    }
}