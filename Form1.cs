using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CARD
{
    public partial class Form1 : Form
    {
        public Image PokerChips;
        public Image bookIcon; 
        Form3 form3 = new Form3 ();
        public Label Count = new Label();
        public bool OponentCardSelectEnable = false;
        public Button[] PlayerCards = new Button[4];
        public Button prevButt;
        public Image hidden;
        public Image jokers;
        public Image cardSprites;
        public int[] Cards = new int[4];
        public int[] Fases = new int[4];
        public Form1()
        {
            InitializeComponent();


            if (LogInterface()) {
                PokerChips = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\PokerChips.png");
                bookIcon = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\book.jpg");
                hidden = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\HiddenCard.png");
                jokers = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\Jokers.png");
                cardSprites = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\CuteCards.png");

                Init();
            }
            else
            {
                Label label1 = new Label();
                Label label = new Label();
                Image No = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\NoEnter.jpeg");
                Image Gen = new Bitmap("C:\\Users\\User\\source\\repos\\CARD\\Assets\\Error.jpeg");

                label.Location = new Point(150, 200);
                label.Size = new Size(400, 400);
                Image Enter = new Bitmap(400, 400);
                Graphics g = Graphics.FromImage(Enter);
                g.DrawImage(No, new Rectangle(0, 0, 400, 400), 0, 0, 500, 500, GraphicsUnit.Pixel);
                label.BackgroundImage = Enter;
                label.BackColor = Color.Transparent;

                label1.Text = "No Enter?";
                label1.BackColor = Color.Transparent;
                label1.Size = new Size(400, 70);
                label1.Location = new Point(150, 100);
                label1.Font = new Font("Serif", 50, FontStyle.Bold);
                Controls.Add(label);
                Controls.Add(label1);


                if (form3.DataError)
                {
                    Label label2 = new Label();
                    label2.Size = new Size(400, 50);
                    label2.Text = "Error. Incorect Log In Data";
                    label2.Location = new Point(700, 150);
                    label2.Font = new Font("Serif", 20, FontStyle.Bold);

                    Label lab = new Label();
                    lab.Location = new Point(770, 200);
                    lab.Size = new Size(250, 250);
                    Image gn = new Bitmap(250, 250);
                    Graphics g1 = Graphics.FromImage(gn);
                    g1.DrawImage(Gen, new Rectangle(0, 0, 250, 250), 0, 0, 400, 400, GraphicsUnit.Pixel);
                    lab.BackgroundImage = gn;
                    lab.BackColor = Color.Transparent;

                    Controls.Add(lab);
                    Controls.Add(label2);
                }
            }

        }
        public bool LogInterface()
        {
            form3.ShowDialog();
            if (form3.Correct)
            {
                return true;
            }
            return false;
        }
        public void RandomCard()
        {
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Fases[i] = rnd.Next(0, 2);
                    Cards[i] = rnd.Next(0, 10);
                } while (Check(i));

            }
        }

        public bool Check(int i)
        {   
            if(i==0) return false;
            for (int j = 0; j < i; j++)
            {
                if (Fases[i] == Fases[j] && Cards[j] == Cards[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void Init()
        {
            Button Book = new Button();
            Label User = new Label();
            Label labelMeet = new Label();
            Label Chips = new Label();

            Count.Text = "0";
            Count.BackColor = Color.Transparent;
            Count.Location = new Point(950, 50);
            Count.Size = new Size(35, 35);
            Count.Font = new Font("Serif", 15, FontStyle.Bold);
            Count.ForeColor = Color.AliceBlue;
            Count.TextAlign = ContentAlignment.MiddleCenter;

            User.BackColor = Color.Transparent;
            User.Location = new Point(50, 50);
            User.Size = new Size(400 + 10 * form3.LogAndPas[form3.info, 1].Length, 80);
            User.Text = "Welcome,  " + form3.LogAndPas[form3.info, 0];
            User.Font = new Font("Serif", 40, FontStyle.Bold);

            labelMeet.BackColor = Color.FromArgb(96, 60, 137);
            labelMeet.Location = new Point(50, 300);
            labelMeet.Size = new Size(300, 300);
            labelMeet.Text = "Find equal ones";
            labelMeet.Font = new Font("Serif", 50, FontStyle.Bold);
            labelMeet.TextAlign  = ContentAlignment.MiddleCenter;

            Book.Location = new Point(1000, 50);
            Book.Size = new Size(35, 35);
            Book.Click += new EventHandler(TutorialClick);

            Chips.Size = new Size(35, 35);
            Chips.Location = new Point(915, 50);
            Chips.BackColor = Color.Transparent;

            Image book = new Bitmap(35, 35);
            Graphics g = Graphics.FromImage(book);
            g.DrawImage(bookIcon, new Rectangle(0, 0, 35, 35), -10, 0, 1000, 1000, GraphicsUnit.Pixel);
            Book.BackgroundImage = book;

            Image chips = new Bitmap(35, 35);
            Graphics g1 = Graphics.FromImage(chips);
            g1.DrawImage(PokerChips, new Rectangle(0, 0, 35, 35), 0, 0, 80, 80, GraphicsUnit.Pixel);
            Chips.BackgroundImage = chips;

            RandomCard();
            CreateCards();

            Controls.Add(Count);
            Controls.Add(User);
            Controls.Add(labelMeet);
            Controls.Add(Book);
            Controls.Add(Chips);
        }
        public void ReloadBrawlStars() {
            Count.Text = (Convert.ToInt32(Count.Text) + 1).ToString();
        }
        public void CreateCards()
        {
            MakePlayerCards();
            OpponentCards();
        }
        public void CardAssets(Button butt, int i, bool enchant, Image ImgType)
        {
            Image part = new Bitmap(150, 200);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(ImgType, new Rectangle(0, 0, 150, 200), ((i!=-2)?100 * i:-2), (i == -2 && enchant)?-3:(enchant)?145:0, 150, 200, GraphicsUnit.Pixel);
            butt.BackgroundImage = part;
        }
        
        public void TutorialClick(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        public void CunstructCard(Button butt, int SizeH, int SizeW, int i, int Ypoint)
        {
            butt.Size = new Size(SizeH, SizeW);
            butt.Location = new Point(150 * i + 250, Ypoint);
            butt.FlatStyle = FlatStyle.Popup;
            butt.BackColor = Color.Transparent;
        }
        public void MakePlayerCards()
        {
            for (int i = 0; i < 4; i++)
            {
                Button butt = new Button();
                CunstructCard(butt, 100, 140, i + 1, 500);

                butt.Click += new EventHandler(PlayerCardsSelect);

                if (Fases[i] > 0){CardAssets(butt, Cards[i], true, cardSprites);}
                else{CardAssets(butt, Cards[i], false, cardSprites);}

                PlayerCards[i] = butt;
                Controls.Add(butt);
            }
        }
        public Button selected;
        public void PlayerCardsSelect(object sender, EventArgs e)
        {
            if(prevButt != null)
            {
                prevButt.BackColor = Color.Transparent;
            }
            Button pressed = sender as Button;
            pressed.BackColor = Color.Red;
            if(prevButt == pressed)
            {
                pressed.BackColor = Color.Transparent;
                for (int i = 0; i < 4; i++)
                {
                    OponentCards[i].Enabled = false;
                }
                prevButt = null;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    OponentCards[i].Enabled = true;
                }
                prevButt = pressed;
            }
            selected = sender as Button;

        }
        public Button[] OponentCards = new Button[4];
        public void OpponentCards()
        {
            for (int i = 0; i < 4; i++)
            {
                Random chance = new Random();
                int EnchantChance = chance.Next(0, 100);
                Button butt = new Button();
                CunstructCard(butt, 92, 135, i + 1, 300);

                butt.Click += new EventHandler(OnPressOponentCards);
                
                if (EnchantChance == 0){
                    CardAssets(butt, 0, true, hidden);
                    butt.Name = "e";
                }
                else{
                    CardAssets(butt, 0, false, hidden);
                }
                butt.Enabled = false;
                OponentCards[i] = butt;

                Controls.Add(butt);
            }
        }

        public void MakeUntouch(Button pres = null)
        {
            if (pres != null)
            {
                pres.Enabled = false;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    OponentCards[i].Enabled = false;
                }
            }
        }
        
        public void OnPressOponentCards(object sender, EventArgs e)
        {
            Button pressed = sender as Button;
            if(pressed.Name == "e") {
                CardAssets(pressed, -2, true, jokers);
                End();
            }
            else
            { 
                Random rnd = new Random();
                int ran = rnd.Next(0, Cards.Length);
                CardAssets(pressed, Cards[ran], (Fases[ran] == 1)?true:false, cardSprites);
                pressed = PlayerCards[ran];

                Cards[ran] = Cards[Cards.Length - 1];
                PlayerCards[ran] = PlayerCards[PlayerCards.Length - 1];
                Fases[ran] = Fases[Fases.Length - 1];
                

                Array.Resize(ref Cards, Cards.Length - 1);
                Array.Resize(ref PlayerCards, PlayerCards.Length - 1);
                Array.Resize(ref Fases, Fases.Length - 1);

                
            }
            pressed.Enabled = false;
            
            if (selected == pressed) {
               Success(sender as Button);
               MakeUntouch();
               ReloadBrawlStars();
               if (Cards.Length == 0)
               {
                End();
               }
            }
            
            MakeUntouch(sender as Button);
        }
        public void Success(Button btn)
        {
            btn.BackColor = Color.Blue;
        }
        public void End() {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
    
}