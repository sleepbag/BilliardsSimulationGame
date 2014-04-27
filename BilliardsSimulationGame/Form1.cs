using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int Default_Ball_Num = 10;//預設球數
        public int Ball_Num = 10;//球數
        public int hole_Num = 6;//洞數
        public int[,] BallCollectionOfTwo;//球元素為二的子集合陣列
        public int Collection_Num = 0;//子集合數
        public float[] timeUnit_tmp = new float[1];//佔存單位時間

        List<Ball> ballList = new List<Ball>();//編輯用
        List<Ball> reload = new List<Ball>();
        
        Ball[] ball;//球 物件陣列
        Hole[] hole;//洞 物件陣列
        Player[] player=new Player[2];

        public int turn = 0;//換人變數
        public int tempPoint=0;//佔存分數
        public float ball_initail_speed;//初始母球速度
        public float ball_initail_angle;//初始母球角度 
        public Point initail_angle_point;//玩家初始角度用
        public bool isDown = false;
        public bool edit = false; //是否可編輯
        public int edit_select = 0;//0:移動,1:增加,2:刪除
        public int edit_move = -1;//移動座標
        public PointF tmpPoint;//

        public String File;


        public Form1()
        {
            InitializeComponent();
            timeUnit_tmp[0] = Ball.timeUnit;//單位時間暫存
            button1.Text = "開始";
            button2.Text = "定格";
            button3.Text = "打";
            button4.Text = "增加子球";
            button5.Text = "減少子球";
            button6.Text = "移動球";

            label3.Text = "現在是 玩家A";
            label4.Text = "玩家A:";
            label5.Text = "玩家B:";
            label6.Text = "分數:0";
            label7.Text = "分數:0";
            this.Text = "撞球模擬程式";
            this.pictureBox1.BackColor = Color.Green;
            openFileDialog1.AddExtension = true;
            openFileDialog1.DefaultExt = "pl";
            openFileDialog1.Filter = "撞球(*.pl)|*.pl";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "pl";
            saveFileDialog1.Filter = "撞球(*.pl)|*.pl";
            

        }
        public void DefaultBallLoad(object sender, EventArgs e) 
        {
            int ball_width = 22;
            ball = new Ball[Default_Ball_Num];
            ball[0] = new Ball(50, 128, ball_width, 0, 0, Color.White);
            ball[1] = new Ball(321, 127, ball_width, 0, 0, Color.Aqua);
            ball[2] = new Ball(341.052F, 116, ball_width, 0, 0, Color.Aqua);
            ball[3] = new Ball(341.052F, 138, ball_width, 0, 0, Color.Aqua);
            ball[4] = new Ball(360.104F, 127, ball_width, 0, 0, Color.Aqua);
            ball[5] = new Ball(360.104F, 149, ball_width, 0, 0, Color.Aqua);
            ball[6] = new Ball(360.104F, 105, ball_width, 0, 0, Color.Aqua);
            ball[7] = new Ball(379.156F, 116, ball_width, 0, 0, Color.Aqua);
            ball[8] = new Ball(379.156F, 138, ball_width, 0, 0, Color.Aqua);
            ball[9] = new Ball(398.208F, 127, ball_width, 0, 0, Color.Aqua);

            reload.Clear();
             
            reload.Add(new Ball(50, 128, ball_width, 0, 0, Color.White));
            reload.Add(new Ball(321, 127, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(341.052F, 116, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(341.052F, 138, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(360.104F, 127, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(360.104F, 149, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(360.104F, 105, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(379.156F, 116, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(379.156F, 138, ball_width, 0, 0, Color.Aqua));
            reload.Add(new Ball(398.208F, 127, ball_width, 0, 0, Color.Aqua));

        }
        public void ReBallLoad()
        {
            int ball_width = 22;

            ball = new Ball[reload.Count];
            ball[0]=new Ball(reload[0].ball_pos.X,reload[0].ball_pos.Y,ball_width, 0, 0, Color.White) ;
            for (int i = 1; i < reload.Count; i++) 
            {
                ball[i] = new Ball(reload[i].ball_pos.X, reload[i].ball_pos.Y, ball_width, 0, 0, Color.Aqua);
            
            }
        }
        public void BallDispose() 
        {
            for (int i = 0; i < Ball_Num; i++)
            {
                ball[i] = null;
            }
            ball = null;
        }

        public void load(object sender, EventArgs e) 
        {

            edit = false;

            this.DoubleBuffered = true;//啟動畫面緩衝
            timer1.Enabled = false;//timer一開始false.
            timer1.Interval = 1;//毫秒驅動一次
            hScrollBar2.Minimum = 10;//最小力道限制
            hScrollBar2.Maximum = 22009;//最大力道限制
            
            
            
            ball_initail_angle = 0;
            ball_initail_speed = 10;//數值初始

            label2.Text = "力道" + ball_initail_speed.ToString() + "(pix/單位時間)";
            button1.Enabled = false;//
            button2.Enabled = false;//時間操作按鈕
            button3.Enabled = true;
            panel1.Enabled = true;
            panel1.Show();
            panel2.Show();
            panel3.Hide();
            Collection_Num = ((Ball_Num - 1) * Ball_Num) / 2;//計算子集合數
            BallCollectionOfTwo = new int[Collection_Num, 3];//子集合陣列初始
            Ball.Ball_Num = Ball_Num;
            Ball.Collection_Num = Collection_Num;
            for (int i = 0, count = 0; i < Ball_Num - 1; i++)//建立子集合列表
            {
                for (int j = i + 1; j < Ball_Num; j++)
                {
                    BallCollectionOfTwo[count, 0] = i;
                    BallCollectionOfTwo[count++, 1] = j;
                }
            }
            
            //_______________________物件初始
            hole = new Hole[hole_Num];
            hole[0] = new Hole(40, 0, 0);
            hole[1] = new Hole(40, this.pictureBox1.Width , 0);
            hole[2] = new Hole(40, 0, this.pictureBox1.Height );
            hole[3] = new Hole(40, this.pictureBox1.Width , this.pictureBox1.Height );
            hole[4] = new Hole(40, this.pictureBox1.Width / 2, -7);
            hole[5] = new Hole(40, this.pictureBox1.Width / 2, this.pictureBox1.Height +7);
            player[0] = new Player();
            player[1] = new Player();

            
        }
        public bool trigger()
        {
            //進洞偵測
            for (int k = 0; k < hole_Num; k++) 
            {
                for (int j = 0; j < Ball_Num; j++) 
                {
                    if (!ball[j].ball_Inhole)
                    {
                        tempPoint += Hole.Ishole(ball[j], hole[k]);
                    }
                }
            }
            bool flag = false;
           
            //母球進洞偵測
            if (ball[0].ball_Inhole)//如果母球進洞
            {
                
                for (int k = 1; k < Ball_Num; k++)
                {
                    if(!ball[k].ball_temp_Inhole)
                    ball[k].ball_nextTime_pos = ball[k].ball_temp_pos;
                    ball[k].ball_speed.X = ball[k].ball_nextTime_speed.X = 0;
                    ball[k].ball_speed.Y = ball[k].ball_nextTime_speed.Y = 0;
                }
                ball[0].ball_nextTime_pos = ball[0].ball_temp_pos;
                ball[0].ball_speed.X =ball[0].ball_nextTime_speed.X= 0;
                ball[0].ball_speed.Y = ball[0].ball_nextTime_speed.Y = 0;
                ball[0].ball_Inhole = false;
                for (int i = 0; i < Ball_Num; i++)
                {
                    ball[i].Ball_GO();
                }//回覆打擊母球局面
                tempPoint = -1;
                player[turn].point += tempPoint;
                if (turn == 0) label6.Text = "分數:" + player[turn].point.ToString();
                if (turn == 1) label7.Text = "分數:" + player[turn].point.ToString();
                turn = (turn + 1) % 2;//換人
                if (turn == 0) label3.Text = "現在是玩家A";
                if (turn == 1) label3.Text = "現在是玩家B";
                this.pictureBox1.Invalidate();//更新畫面
                timer1.Enabled = false;
                tempPoint = 0;
                panel1.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = false;
                button1.Text = "開始";
                MessageBox.Show("母球進袋，扣分並回復母球位置!!");
                return false;
            }
            //float[]  timeUnit_tmp = new float[1];//佔存單位時間
            
            //_________碰撞偵測
            if(
            Ball.CoverCorrection
                (
                this.pictureBox1.ClientSize.Height,
                this.pictureBox1.ClientSize.Width,
                BallCollectionOfTwo,
                ball,
                timeUnit_tmp
                )==false
            )timeUnit_tmp[0] = Ball.timeUnit;//單位時間暫存
            //______________________________________________
            //_______現在位置 = 下一個單位時間位移
            for (int i = 0; i < Ball_Num; i++)
            {
                ball[i].Ball_GO();
            }
            this.pictureBox1.Invalidate();//更新畫面
            //______________________________________________
            //_______碰撞反應

            for (int k = 0; k < Ball_Num; k++)//撞到牆壁處理
            {
                if(!ball[k].ball_Inhole)//如果球沒進洞
                {
                    if (ball[k].wall_x == true)
                    {
                        if(Math.Abs( ball[k].ball_speed.X)>10)System.Media.SystemSounds.Beep.Play();

                        ball[k].ball_nextTime_speed.X = -(ball[k].ball_speed.X*1F);
                        //ball[k].ball_speed.X = -(ball[k].ball_speed.X * 1F);
                       
                       // ball[k].ball_speed.X = -(ball[k].ball_speed.X * 0.98F+10F);
                        ball[k].wall_x = false;
                    }
                    if (ball[k].wall_y == true)
                    {
                        if (Math.Abs( ball[k].ball_speed.Y) > 10)System.Media.SystemSounds.Beep.Play();

                        ball[k].ball_nextTime_speed.Y = -(ball[k].ball_speed.Y * 1F);
                        //ball[k].ball_speed.Y = -(ball[k].ball_speed.Y * 1F);
                        
                        //ball[k].ball_speed.Y = -(ball[k].ball_speed.Y * 0.98F+10F);
                        ball[k].wall_y = false;
                    }
                }
            }

            for (int k = 0; k < Ball_Num; k++)//更新資料 準備動作
            {
                if (!ball[k].ball_Inhole)
                {
                    if (ball[k].ball_bump == 1)
                    {
                        ball[k].ball_nextTime_speed.X = 0;
                        ball[k].ball_nextTime_speed.Y = 0;
                        ball[k].ball_bump = 0;
                    }
                    else
                    {
                        ball[k].ball_speed = ball[k].ball_nextTime_speed;
                    }
                }
            }

            for (int k = 0; k < Collection_Num; k++)//處理碰撞名單 
            {
                if (BallCollectionOfTwo[k, 2] == 1)
                {
                    //System.Media.SystemSounds.Beep.Play();
                    ball[BallCollectionOfTwo[k, 1]].ball_bump += 
                        Ball.ImpulseTrans(ball[BallCollectionOfTwo[k, 1]], ball[BallCollectionOfTwo[k, 0]]);
                    ball[BallCollectionOfTwo[k, 0]].ball_bump +=
                        Ball.ImpulseTrans(ball[BallCollectionOfTwo[k, 0]], ball[BallCollectionOfTwo[k, 1]]);
                }
            }
            for (int k = 0; k < Ball_Num; k++)//更新資料
            {
                if (!ball[k].ball_Inhole)
                {
                    if (ball[k].ball_bump >= 2)
                    {
                        ball[k].ball_nextTime_speed.X = -ball[k].ball_nextTime_speed.X/ball[k].ball_bump;
                        ball[k].ball_nextTime_speed.Y = -ball[k].ball_nextTime_speed.Y /ball[k].ball_bump;
                    }
                    ball[k].ball_speed = ball[k].ball_nextTime_speed;//更新速度
                    ball[k].ball_bump = 0;
                }
            }
            for (int k = 0; k < Ball_Num; k++)//摩擦力處理
            {
                ball[k].ball_frition();
            }
            //______________________________________________
            //__清除 子集合列表 碰撞名單
            for (int k = 0; k < Collection_Num; k++)
            {
                BallCollectionOfTwo[k, 2] = 0;
            }
            //______________________________________________
            //__輸贏判斷
            flag=false;
            for (int k = 0; k < Ball_Num; k++) //偵測所有子球是否進洞
            {
                if (!ball[k].ball_Inhole)
                {
                    if (Math.Sqrt(Math.Pow(ball[k].ball_speed.X, 2) + Math.Pow(ball[k].ball_speed.Y, 2)) == 0)
                    {
                        flag = true;
                    }
                    else { flag = false; break; }
                }
                else { continue; }
            }
            if (flag)//如果所有子球進洞，判斷輸贏
            {
                player[turn].point += tempPoint;
                tempPoint = 0;
                if (turn == 0) label6.Text = "分數:" + player[turn].point.ToString();
                if (turn == 1) label7.Text = "分數:" + player[turn].point.ToString();
                turn = (turn + 1) % 2;
                panel1.Enabled = flag;
                button1.Enabled = !flag;
                button2.Enabled = !flag;
                for (int k = 1; k < Ball_Num; k++)
                {
                    if (ball[k].ball_Inhole) { flag = true; }
                    else { flag = false; break; }
                }
                if (flag)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    panel1.Enabled = false;
                    timer1.Enabled = false;
                    if (player[0].point > player[1].point)
                    {
                        MessageBox.Show("玩家A 勝利");
                    }
                    else if (player[0].point < player[1].point)
                    {

                        MessageBox.Show("玩家B 勝利");
                    }
                    else if (player[0].point == player[1].point)
                    {
                        MessageBox.Show("平手");
                    }
                    return true;
                }
                else 
                {
                    if (turn == 0) label3.Text = "現在是玩家A";
                    if (turn == 1) label3.Text = "現在是玩家B";
                    timer1.Enabled = false;
                    button1.Text = "開始";
                }
            }
            else { panel1.Enabled = false; button1.Enabled = !panel1.Enabled; button2.Enabled = !panel1.Enabled; }
            return false;
            //______________________________________
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (trigger()==true)
            {
                BallDispose();
                Ball.Ball_Num = Ball_Num = reload.Count;
                ReBallLoad();
                load(sender, e);
                this.pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (edit == false) 
            {
                for (int i = 0; i < hole_Num; i++)
                {
                    hole[i].hole_paint(sender, e);
                }
                for (int i = 0; i < Ball_Num; i++) //球 繪圖
                {
                    ball[i].Ball_paint(sender, e);
                }
                
                if (panel1.Enabled)
                {
                        e.Graphics.DrawLine(
                            Pens.Black,
                            ball[0].ball_pos.X,
                            ball[0].ball_pos.Y,
                            initail_angle_point.X,
                            initail_angle_point.Y);
                }
            }
            else if (edit == true)
            {
                for (int i = 0; i < hole_Num; i++)
                {
                    hole[i].hole_paint(sender, e);
                }
                for (int i = 0; i < ballList.Count; i++) { ballList[i].Ball_paint(sender, e); }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //trigger();
            if (timer1.Enabled == true)
            {
                button1.Text = "開始";
            }
            else if (timer1.Enabled==false)
            {
                button1.Text = "暫停";
            }
            timer1.Enabled = !timer1.Enabled;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "開始";
            timer1.Enabled = false;
            trigger();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ball_initail_angle = 
            (float) Math.Pow(Math.Pow(initail_angle_point.Y - ball[0].ball_pos.Y, 2) + Math.Pow(initail_angle_point.X - ball[0].ball_pos.X, 2), 0.5);

            ball[0].ball_nextTime_speed.Y = ball[0].ball_speed.Y = Convert.ToSingle(ball_initail_speed * (initail_angle_point.Y - ball[0].ball_pos.Y)/ball_initail_angle);
                ball[0].ball_nextTime_speed.X = ball[0].ball_speed.X = Convert.ToSingle(ball_initail_speed * (initail_angle_point.X - ball[0].ball_pos.X)/ball_initail_angle);
           
            
            for (int k = 0; k < Ball_Num; k++)
            {
                ball[k].ball_temp_pos = ball[k].ball_pos;
                ball[k].ball_temp_Inhole = ball[k].ball_Inhole;
            }
            timer1.Enabled = true;
            panel1.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
        }
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            ball_initail_speed=hScrollBar2.Value;
            label2.Text = "力道"+ball_initail_speed.ToString()+"(pix/單位時間)";
            this.pictureBox1.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load(this, e);
            DefaultBallLoad(sender, e);
            this.pictureBox1.Invalidate();
        }

        private void 操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void 規則ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void 作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
        private void 重新開始ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Show();
            panel3.Hide();
            edit = false;

            //
            BallDispose();
            Ball.Ball_Num= Ball_Num = reload.Count;
            ReBallLoad();
            load(sender, e);
            this.pictureBox1.Invalidate();
        }

        private void 新球局ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            panel3.Show();

            edit = true;

            int ball_width = 22;
            ballList.Clear();
            
            ballList.Add(new Ball(50, 128, ball_width, 0, 0, Color.White));
            ballList.Add(new Ball(321, 127, ball_width, 0, 0, Color.Aqua));

            this.pictureBox1.Invalidate();


        }
        class Player 
    {
        public string name;
        public  int point;
        public Player() 
        {
            point = 0;
            name = "A";
        }
    }
    //洞類別
     class Hole 
    {
        float width;
        PointF hole_pos;
        public Hole(float Iswidth,float IsposX,float IsposY) 
        {
            width= Iswidth;
            hole_pos.X = IsposX;
            hole_pos.Y = IsposY;
        }
        public void hole_paint(object sender, PaintEventArgs e)//畫球
        {
            e.Graphics.FillEllipse(Brushes.Black,
                hole_pos.X-width/2 ,
                hole_pos.Y -width/2,
                width, width);
        }
        public static int Ishole(Ball ball,Hole hole) 
        {
            if ((hole.width /4+ ball.ball_width / 2) > Math.Sqrt(Math.Pow(hole.hole_pos.X - ball.ball_pos.X, 2) + Math.Pow(hole.hole_pos.Y - ball.ball_pos.Y, 2)))
            {
                System.Media.SystemSounds.Asterisk.Play();
                ball.ball_Inhole=true;
                return 1;
            } return 0;
        }
    }
    //__________________球類別
    class Ball
    {
        public static int Ball_Num;//球數
        public static int Collection_Num;//子集合數
        public static float allowValue = 0.05F;//容許值
        public static float timeUnit = 0.001F;//單位時間
        public Point ball_paint_pos = new Point();//球繪圖位子點
        public PointF ball_pos = new PointF();//球實際位子點
        public PointF ball_nextTime_pos = new PointF();//下一單位時間的位子
        public PointF ball_temp_pos=new PointF();
        public int ball_width;//球 直徑
        public PointF ball_speed = new PointF();//球 速度
        public PointF ball_nextTime_speed = new PointF();//下一單位時間的速度
        public float ball_mass = 1;//球 質量
        public int ball_bump = 0;//判斷是否碰撞用變數
        public bool ball_Inhole = false;//進洞與否
        public bool ball_temp_Inhole;//
        public bool wall_x = false;//水平碰撞
        public bool wall_y = false;//垂直碰撞
        public SolidBrush brush;
        public Color ball_color;
        //速度的單位是 pix/s
        //一單位時間初始是1ms
        //一單位時間*速度=位移量
        //質量單位是 g 球質量相等所以暫時不考慮
        Random Rand = new Random(Guid.NewGuid().GetHashCode());//超屌亂數
        public Ball()//預設建構式
        { 
            ball_pos.X = Rand.Next(25, 1000);
            ball_pos.Y = Rand.Next(25, 1000);
            ball_temp_pos = ball_pos;
            ball_nextTime_pos.X = ball_pos.X;
            ball_nextTime_pos.Y = ball_pos.Y;
            ball_width = Rand.Next(25, 60);
            ball_speed.X = Rand.Next(-50, 50);
            ball_speed.Y = Rand.Next(-50, 50);
            ball_nextTime_speed.X = ball_speed.X;
            ball_nextTime_speed.Y = ball_speed.Y;
            ball_paint_pos.X = (int)ball_pos.X;
            ball_paint_pos.Y = (int)ball_pos.Y;
            ball_color = Color.FromArgb(Rand.Next(0, 255), Rand.Next(0, 255), Rand.Next(0, 255));
            brush = new SolidBrush(ball_color);
            ball_Inhole = false;
        }
        public Ball(float ball_Ipos_X, float ball_Ipos_Y, int ball_Iwidth, float ball_Ispeed_X, float ball_Ispeed_Y,Color ball_Iscolor)//自定建構式
        {
            ball_pos.X = ball_Ipos_X;
            ball_pos.Y = ball_Ipos_Y;
            ball_temp_pos = ball_pos;
            ball_nextTime_pos.X = ball_pos.X;
            ball_nextTime_pos.Y = ball_pos.Y;
            ball_width = ball_Iwidth;
            ball_speed.X = ball_Ispeed_X;
            ball_speed.Y = ball_Ispeed_Y;
            ball_nextTime_speed.X = ball_speed.X;
            ball_nextTime_speed.Y = ball_speed.Y;
            ball_paint_pos.X = (int)ball_pos.X;
            ball_paint_pos.Y = (int)ball_pos.Y;
            ball_color = ball_Iscolor;//Color.FromArgb(Rand.Next(0, 255), Rand.Next(0, 255), Rand.Next(0, 255));
            brush = new SolidBrush(ball_color);
            ball_Inhole = false;
        }
        public void Ball_nextTime(float timeUnit_tmp)//下一時間位置
        {
            if(!ball_Inhole)
            {
                ball_nextTime_pos.X = ball_pos.X;//
                ball_nextTime_pos.Y = ball_pos.Y;//下一時間位置=現在位置
                ball_nextTime_pos.X += ball_speed.X * timeUnit_tmp;
                ball_nextTime_pos.Y += ball_speed.Y * timeUnit_tmp;//下一時間位置=速度*一單位時間
            }
        }
        public void Ball_GO()//現在時間位置
        {
            if (!ball_Inhole)
            {
                ball_pos.Y = ball_nextTime_pos.Y;
                ball_pos.X = ball_nextTime_pos.X;
                ball_paint_pos.X = (int)ball_pos.X;
                ball_paint_pos.Y = (int)ball_pos.Y;
            }
        }
        public void ball_frition()
        {
            //____________________速度不等於0的話
            if (!ball_Inhole)
            {
                if (Math.Sqrt(Math.Pow(ball_speed.X, 2) + Math.Pow(ball_speed.Y, 2)) < 1)
                {
                    ball_speed.Y = 0;
                    ball_nextTime_speed.Y = 0;
                    ball_speed.X = 0;
                    ball_nextTime_speed.X = 0;
                }
                else
                {
                    if (ball_speed.Y > 0.0)
                    {
                        ball_speed.Y = ball_speed.Y*0.98F;
                        ball_nextTime_speed.Y = ball_nextTime_speed.Y * 0.98F;
                    }
                    else if (ball_speed.Y < 0.0)
                    {
                        ball_speed.Y = ball_speed.Y * 1F;
                        ball_nextTime_speed.Y = ball_nextTime_speed.Y * 0.98F;
                    }
                    if (ball_speed.X > 0.0)
                    {
                        ball_speed.X = ball_speed.X * 0.98F;
                        ball_nextTime_speed.X = ball_nextTime_speed.X * 0.98F;
                    }
                    else if (ball_speed.X < 0.0)
                    {
                        ball_speed.X = ball_speed.X * 0.98F;
                        ball_nextTime_speed.X = ball_nextTime_speed.X * 0.98F;
                    }
                }
            }
            //_____________________ 減速
        }
        public void Ball_paint(object sender, PaintEventArgs e)//畫球
        {
            if (!ball_Inhole)
            {
                e.Graphics.FillEllipse(brush,
                    ball_paint_pos.X - ball_width / 2,
                    ball_paint_pos.Y - ball_width / 2,
                    ball_width, ball_width);
                e.Graphics.DrawEllipse(Pens.Black,
                    ball_paint_pos.X - ball_width / 2,
                    ball_paint_pos.Y - ball_width / 2,
                    ball_width, ball_width);
            }
        }
        public static bool IsCoverWall(Ball ball, int Height, int Width)
        {
            //________牆壁碰撞偵測
            if (!ball.ball_Inhole)
            {
                if (
                    (ball.ball_nextTime_pos.Y + ball.ball_width / 2) - Height >= allowValue ||
                    (allowValue <= ball.ball_width / 2 - ball.ball_nextTime_pos.Y) ||
                    (ball.ball_nextTime_pos.X + ball.ball_width / 2) - Width >= allowValue ||
                    (allowValue <= ball.ball_width / 2 - ball.ball_nextTime_pos.X)
                    )
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
        public static void IsbumpWall(Ball ball, int Height, int Width)
        {
            if (!ball.ball_Inhole)
            {
                if (
                    ((ball.ball_nextTime_pos.Y + ball.ball_width / 2) - Height < allowValue &&
                    (ball.ball_nextTime_pos.Y + ball.ball_width / 2) >= Height)
                    ||
                    ((allowValue > ball.ball_width / 2 - ball.ball_nextTime_pos.Y) &&
                    ball.ball_width / 2 >= ball.ball_nextTime_pos.Y)
                    )
                {
                    ball.wall_y = true;
                }
                if (
                    ((ball.ball_nextTime_pos.X + ball.ball_width / 2) - Width < allowValue &&
                    (ball.ball_nextTime_pos.X + ball.ball_width / 2) >= Width)
                    ||
                    ((allowValue > ball.ball_width / 2 - ball.ball_nextTime_pos.X) &&
                    ball.ball_width / 2 >= ball.ball_nextTime_pos.X)
                  )
                {
                    ball.wall_x = true;
                }
            }
        }
        public static bool IsCover(Ball ball1, Ball ball2)//碰撞偵測
        {
            if (!ball1.ball_Inhole && !ball2.ball_Inhole)
            {
                if (
                    ((ball1.ball_width / 2) + (ball2.ball_width / 2)) - Math.Sqrt(
                Math.Pow(ball1.ball_nextTime_pos.X - ball2.ball_nextTime_pos.X, 2) +
                Math.Pow(ball1.ball_nextTime_pos.Y - ball2.ball_nextTime_pos.Y, 2)) >= allowValue
                )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static bool Isbump(Ball ball1, Ball ball2)
        {
            if (!ball1.ball_Inhole && !ball2.ball_Inhole)
            {
                if (
                        ((ball1.ball_width / 2) + (ball2.ball_width / 2)) - Math.Sqrt(
                    Math.Pow(ball1.ball_nextTime_pos.X - ball2.ball_nextTime_pos.X, 2) +
                    Math.Pow(ball1.ball_nextTime_pos.Y - ball2.ball_nextTime_pos.Y, 2)) < allowValue &&
                    ((ball1.ball_width / 2) + (ball2.ball_width / 2)) >= Math.Sqrt(
                    Math.Pow(ball1.ball_nextTime_pos.X - ball2.ball_nextTime_pos.X, 2) +
                    Math.Pow(ball1.ball_nextTime_pos.Y - ball2.ball_nextTime_pos.Y, 2))
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static bool CoverCorrection//碰撞偵測
        (
            int Height,
            int Width,
            int[,] BallCollectionOfTwo,
            Ball[] ball,
            float[] timeUnit_tmp
         )
        {
            bool flag = false;
            bool return_cover_before=false;
            do
            {
                flag = false;
                for (int i = 0; i < Ball_Num; i++)
                {
                    ball[i].Ball_nextTime(timeUnit_tmp[0]);
                }
                for (int k = 0; k < Ball_Num; k++)
                {
                    if (Ball.IsCoverWall(ball[k], Height, Width))
                    {
                        flag = true;
                        break;
                    }
                }
                for (int k = 0; k < Collection_Num; k++)
                {
                    if (Ball.IsCover(ball[BallCollectionOfTwo[k, 0]], ball[BallCollectionOfTwo[k, 1]]))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    timeUnit_tmp[0] = timeUnit_tmp[0] * 0.5F;
                    return_cover_before = true;
                }
            } while (flag);
            for (int i = 0; i < Ball_Num; i++)
            {
                ball[i].Ball_nextTime(timeUnit_tmp[0]);
            }
            for (int k = 0; k < Ball_Num; k++)
            {
                Ball.IsbumpWall(ball[k], Height, Width);
            }
            for (int k = 0; k < Collection_Num; k++)
            {
                if (Ball.Isbump(ball[BallCollectionOfTwo[k, 0]], ball[BallCollectionOfTwo[k, 1]]))
                {
                    
                    BallCollectionOfTwo[k, 2] = 1;
                    ball[BallCollectionOfTwo[k, 0]].ball_bump = 1;
                    ball[BallCollectionOfTwo[k, 1]].ball_bump = 1;
                }
            }
            return return_cover_before;
        }
        public static int ImpulseTrans(Ball ballM, Ball ballS)
        {
            PointF L_vecter = new PointF();//M到S的連心線向量
            float L;//連心線長度
            L_vecter.X = ballS.ball_pos.X - ballM.ball_pos.X;
            L_vecter.Y = ballS.ball_pos.Y - ballM.ball_pos.Y;//向量是後面的點減掉前面的點
            L = (ballM.ball_width / 2) + (ballS.ball_width / 2);
            //L=Convert.ToSingle( Math.Sqrt(Math.Pow(L_vecter.X,2)+Math.Pow(L_vecter.Y,2)));
            PointF P = new PointF();
            P = Projection(ballM.ball_speed, L_vecter, L);
            if (P.X * L_vecter.X >= 0 && P.Y * L_vecter.Y >= 0)//速度向量在該連心線向量的投影為正 
            {
                if (P.X * L_vecter.X >= 0 && P.Y * L_vecter.Y > 30) System.Media.SystemSounds.Beep.Play();
                ballS.ball_nextTime_speed.X += P.X;
                ballS.ball_nextTime_speed.Y += P.Y;//就把該投影向量給ballS的下一時間速度
                ballM.ball_nextTime_speed.X += ballM.ball_speed.X - P.X;
                ballM.ball_nextTime_speed.Y += ballM.ball_speed.Y - P.Y;//把垂直於連心線的分量給ballM的下一時間速度

            }
            else//如果不是正
            {
                ballM.ball_nextTime_speed.X += ballM.ball_speed.X;
                ballM.ball_nextTime_speed.Y += ballM.ball_speed.Y;//把原本的速度加到下一時間速度
            }
            if (P.X * L_vecter.X > 0 && P.Y * L_vecter.Y > 0) { return 1; } else { return 0; }
        }
        public static PointF Projection(PointF V_vecter, PointF L_vecter, float L)//內積函數
        {
            PointF P = new PointF();
            float innerProduct = (V_vecter.X * L_vecter.X) + (V_vecter.Y * L_vecter.Y);
            P.X = innerProduct * L_vecter.X * (1 / Convert.ToSingle(Math.Pow(L, 2)));
            P.Y = innerProduct * L_vecter.Y * (1 / Convert.ToSingle(Math.Pow(L, 2)));
            return P;
        }
     }
    //___________________球類別結束
     
     private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
     {
         if (edit) 
         {
             for(int i=0;i<ballList.Count;i++)
             {

                 if (
                    ballList[i].ball_width  >= Math.Sqrt(
                Math.Pow(ballList[i].ball_pos.X - e.Location.X, 2) +
                Math.Pow(ballList[i].ball_pos.Y - e.Location.Y, 2))&&edit_select==1
                ) { MessageBox.Show("此點之球與" + i.ToString() + "球碰撞"); return; }
                 if (
                    ballList[i].ball_width / 2   >=Math.Sqrt(
                Math.Pow(ballList[i].ball_pos.X - e.Location.X, 2) +
                Math.Pow(ballList[i].ball_pos.Y - e.Location.Y, 2)) 
                ) 
                {
                    switch(edit_select)
                                {
                                     case 0 :
                                        edit_move = i;
                                        tmpPoint = ballList[i].ball_pos;
                                        
                                         //移動
                                     break;

                                     case 1:
                                         MessageBox.Show("此點與"+i.ToString() + "球碰撞");
                                         //增加
                                     break;
                                        
                                     case 2:
                                     if (i > 1)
                                     {
                                         ballList.RemoveAt(i);
                                         this.pictureBox1.Invalidate();
                                     }
                                     else 
                                     {
                                        MessageBox.Show(i.ToString()+"球不能刪除");
                                     }
                                         //刪除
                                     break;
                                 }
                    
                    return;
                }
             }
             if (edit_select == 1) 
             {

                 int ball_width = 22;
                 ballList.Add(new Ball(e.Location.X, e.Location.Y, ball_width, 0, 0, Color.Aqua));
                 for (int k = 0; k < hole_Num; k++) 
                 {
                     Hole.Ishole(ballList[ballList.Count - 1],hole[k]);
                     if (ballList[ballList.Count - 1].ball_Inhole) 
                     {
                         ballList.RemoveAt(ballList.Count - 1);
                         MessageBox.Show("不能放到洞裡");
                     }  
                 }
                 
                 if (
                     Ball.IsCoverWall(ballList[ballList.Count - 1],
                     this.pictureBox1.ClientSize.Height,
                     this.pictureBox1.ClientSize.Width)) 
                 {
                     ballList.RemoveAt(ballList.Count - 1);
                     MessageBox.Show("不能碰到牆壁");
                 }
                 this.pictureBox1.Invalidate();
             }
         }
         else if (edit == false) 
         {
             initail_angle_point = e.Location;
             isDown = true;
             this.pictureBox1.Invalidate();
         }
     }
     private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
     {
         if (edit)
         {

             if (edit_select == 0) 
             {

                 if (edit_move != -1) 
                 {
                     toolStripStatusLabel1.Text = edit_move.ToString();
                     ballList[edit_move].ball_pos.X = ballList[edit_move].ball_nextTime_pos.X = e.Location.X;
                     ballList[edit_move].ball_pos.Y = ballList[edit_move].ball_nextTime_pos.Y=e.Location.Y;
                     ballList[edit_move].ball_paint_pos.X = e.Location.X;
                     ballList[edit_move].ball_paint_pos.Y = e.Location.Y;
                     this.pictureBox1.Invalidate();
                 }
             }
         }
         else if (edit == false)
         {
             if (isDown) 
             {
                 initail_angle_point = e.Location;
                 this.pictureBox1.Invalidate();
             }
         }
     }
     private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
     {
         if (edit)
         {
             if (edit_select == 0)
             {
                 if (edit_move != -1)
                 {
                     if (
                            Ball.IsCoverWall(ballList[edit_move],
                            this.pictureBox1.ClientSize.Height,
                            this.pictureBox1.ClientSize.Width)
                         )
                     {
                             ballList[edit_move].ball_pos = tmpPoint;
                             ballList[edit_move].ball_paint_pos.X = (int)tmpPoint.X;
                             ballList[edit_move].ball_paint_pos.Y = (int)tmpPoint.Y;
                             MessageBox.Show("不能碰到牆壁");
                             this.pictureBox1.Invalidate();
                             edit_move = -1;
                             return;
                     }
                     for (int i = 0; i < ballList.Count; i++)
                     {
                         if (edit_move!= i  &&
                            ballList[i].ball_width >= Math.Sqrt(
                        Math.Pow(ballList[i].ball_pos.X - e.Location.X, 2) +
                        Math.Pow(ballList[i].ball_pos.Y - e.Location.Y, 2)) 
                        )
                         {
                             MessageBox.Show("此點之球與" + i.ToString() + "球碰撞");
                             ballList[edit_move].ball_pos = tmpPoint;
                             ballList[edit_move].ball_paint_pos.X = (int)tmpPoint.X;
                             ballList[edit_move].ball_paint_pos.Y = (int)tmpPoint.Y;
                             this.pictureBox1.Invalidate();
                             edit_move = -1;
                             return;
                         }
                     }
                     for (int k = 0; k < hole_Num; k++)
                     {
                             Hole.Ishole(ballList[edit_move], hole[k]);
                             if (ballList[edit_move].ball_Inhole)
                             {

                                 ballList[edit_move].ball_pos = tmpPoint;
                                 ballList[edit_move].ball_paint_pos.X = (int)tmpPoint.X;
                                 ballList[edit_move].ball_paint_pos.Y = (int)tmpPoint.Y;
                                 ballList[edit_move].ball_Inhole = false;
                                 MessageBox.Show("不能放到洞裡");
                                 this.pictureBox1.Invalidate();
                                 edit_move = -1;
                                 return;
                             }
                     }
                     edit_move = -1;
                 }
             }
         }
         else if (edit == false)
         {
             isDown = false;
         }
     }
     private void 載入球局ToolStripMenuItem_Click(object sender, EventArgs e)
     {
         panel1.Hide();
         panel2.Hide();
         panel3.Show();
         edit = true;
         openFileDialog1.ShowDialog();
     }

     private void 儲存球局ToolStripMenuItem_Click(object sender, EventArgs e)
     {
         panel1.Hide();
         panel2.Hide();
         panel3.Show();

         edit = true;

         saveFileDialog1.ShowDialog();
     }

     private void 載入預設球局ToolStripMenuItem_Click(object sender, EventArgs e)
     {
         panel1.Hide();
         panel2.Hide();
         panel3.Show();
         ballList.Clear();

         int ball_width = 22;
         ballList.Add(new Ball(50, 128, ball_width, 0, 0, Color.White));
         ballList.Add(new Ball(321, 127, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(341.052F, 116, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(341.052F, 138, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(360.104F, 127, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(360.104F, 149, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(360.104F, 105, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(379.156F, 116, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(379.156F, 138, ball_width, 0, 0, Color.Aqua));
         ballList.Add(new Ball(398.208F, 127, ball_width, 0, 0, Color.Aqua));
         this.pictureBox1.Invalidate();


         edit = true;
     }

     private void button6_Click(object sender, EventArgs e)
     {
         edit_select = 0;
         toolStripStatusLabel1.Text = "移動";
     }

     private void button4_Click(object sender, EventArgs e)
     {
         edit_select = 1;
         toolStripStatusLabel1.Text = "增加";
     }

     private void button5_Click(object sender, EventArgs e)
     {
         edit_select = 2;
         toolStripStatusLabel1.Text = "刪除";
     }

     private void 載入球局ToolStripMenuItem1_Click(object sender, EventArgs e)
     {

         panel1.Show();
         panel2.Show();
         panel3.Hide();
         edit = false;

         openFileDialog1.ShowDialog();
     }

     private void 載入預設球局ToolStripMenuItem1_Click(object sender, EventArgs e)
     {
         panel1.Show();
         panel2.Show();
         panel3.Hide();
         edit = false;

         BallDispose();
         Ball.Ball_Num = Ball_Num = Default_Ball_Num;
         DefaultBallLoad(sender,e);
         load(sender, e);
         this.pictureBox1.Invalidate();
     }

     private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
     {
         int ball_width=22;

         File = openFileDialog1.FileName;
         MessageBox.Show(File);
         FileStream openFileStream = new FileStream(File, FileMode.Open);
         BinaryReader objBinaryReader = new BinaryReader(openFileStream);
         if (edit == true) 
         {
                 ballList.Clear();
                 int count =Convert.ToInt32( objBinaryReader.ReadString());
                 double tmpX;
                 double tmpY;
                 //MessageBox.Show(count.ToString());
                 tmpX = Convert.ToDouble(objBinaryReader.ReadString());
                 //MessageBox.Show(tmpX.ToString());
                 tmpY = Convert.ToDouble(objBinaryReader.ReadString());
                 //MessageBox.Show(tmpY.ToString());
                 ballList.Add(new Ball((float)tmpX,(float)tmpY, ball_width, 0, 0, Color.White));
                 for (int i = 0; i < count-1; i++) 
                 {

                     //MessageBox.Show(count.ToString());
                     tmpX = Convert.ToDouble(objBinaryReader.ReadString());
                     //MessageBox.Show(tmpX.ToString());
                     tmpY = Convert.ToDouble(objBinaryReader.ReadString());
                     //MessageBox.Show(tmpY.ToString());
                     ballList.Add(new Ball((float)tmpX, (float)tmpY, ball_width, 0, 0, Color.Aqua));
                 }
                 objBinaryReader.Close();
                 this.pictureBox1.Invalidate();
         }
         else if (edit == false) 
         {
             reload.Clear();
             int count = Convert.ToInt32(objBinaryReader.ReadString());
             double tmpX;
             double tmpY;
             //MessageBox.Show(count.ToString());
             tmpX = Convert.ToDouble(objBinaryReader.ReadString());
             //MessageBox.Show(tmpX.ToString());
             tmpY = Convert.ToDouble(objBinaryReader.ReadString());
             //MessageBox.Show(tmpY.ToString());
             reload.Add(new Ball((float)tmpX, (float)tmpY, ball_width, 0, 0, Color.White));
             for (int i = 0; i < count - 1; i++)
             {

                 //MessageBox.Show(count.ToString());
                 tmpX = Convert.ToDouble(objBinaryReader.ReadString());
                 //MessageBox.Show(tmpX.ToString());
                 tmpY = Convert.ToDouble(objBinaryReader.ReadString());
                 //MessageBox.Show(tmpY.ToString());
                 reload.Add(new Ball((float)tmpX, (float)tmpY, ball_width, 0, 0, Color.Aqua));
             }
             objBinaryReader.Close();
             BallDispose();
             Ball.Ball_Num = Ball_Num = reload.Count;
             load(sender,e);
             ReBallLoad();
             
             
             this.pictureBox1.Invalidate();
         }
         
     }

     private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
     {
         
                File = saveFileDialog1.FileName;
                 MessageBox.Show(File);
                 FileStream saveFileStream = new FileStream(File, FileMode.Create);
                 BinaryWriter objBinaryWriter = new BinaryWriter(saveFileStream);
                 //objBinaryWriter.Write("pl\n");
                 objBinaryWriter.Write(ballList.Count+"\n");
                 for (int i = 0; i < ballList.Count; i++)
                 {
                     
                     objBinaryWriter.Write(ballList[i].ball_pos.X+"\n");
                     objBinaryWriter.Write(ballList[i].ball_pos.Y +"\n");
                 }
                 objBinaryWriter.Close();
     }
    }
}
