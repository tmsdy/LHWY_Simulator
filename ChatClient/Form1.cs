using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ChatClient
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
public class Form1 : System.Windows.Forms.Form
{
    private string sVer = "力豪模拟登录 V1.0.2     ";
    private IContainer components = null;
    static IPAddress HostIP = IPAddress.Parse("14.152.107.119"); //14.152.107.119
	private IPEndPoint ChatServer = new IPEndPoint(HostIP, Int32.Parse("3000"));
	private Socket ChatSocket;
	private bool flag=true;
	private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
	private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.StatusBar statusBar1;
    private System.Timers.Timer RcvPktTimer = new System.Timers.Timer();
    //private System.Timers.Timer timer = new System.Timers.Timer(1000);
    //private System.Timers.Timer SendPktTimer = new System.Timers.Timer();

    private Button button1;
    private bool g_start = false;
    private bool keepalivethread_shouldstop = false;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private CheckBox checkBox1;
    private TextBox textBox3;
    private RadioButton radioButton3;
    private Button button4;
    public System.Threading.Thread thread;

    private string sIMEI = "";
    private int iMaxPktLenth = 512;
    private int iKeepAliveInterval = 60000;
    private int iLonPrefix = 11352;
    private int iLatPrefix = 2234;
    private int iLatLonChangeRangeMin = 1000;
    private int iLatLonChangeRangeMax = 9999;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private Button button5;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox textBox4;
    private TrackBar trackBar2;
    private Label label5;
    private Label label6;
    private RadioButton radioButton4;
    private TrackBar trackBar1;
    private Button button6;
    private CheckBox checkBox2;
    private Label label1;
	public Form1()
	{
				//
				// Windows 窗体设计器支持所必需的
				//
		InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;
        

        try
        {
            ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ChatSocket.Connect(ChatServer);
            //statusBar1.Text=textBox1.Text+" has logoned on.Now begin to connect...";

            /*开一个线程去发心跳报文*/
            thread = new Thread(new ThreadStart(keepalivethread));
            //thread.Name= "keepalivethread";
            thread.Start();

            RcvPktTimer.Elapsed += new System.Timers.ElapsedEventHandler(RcvPkt);
            RcvPktTimer.Interval = 100;
            RcvPktTimer.Enabled = true;
            statusBar1.Text = "连接成功";
   
        }
        catch (Exception ee)
        { statusBar1.Text = ee.Message; }
				//
				// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
				//
	}

			/// <summary>
			/// 清理所有正在使用的资源。
			/// </summary>
	protected override void Dispose( bool disposing )
	{
		if( disposing )
			{
			if (components != null) 
				{
					components.Dispose();
				}
			}
		base.Dispose( disposing );
	}

			#region Windows Form Designer generated code
			/// <summary>
			/// 设计器支持所需的方法 - 不要使用代码编辑器修改
			/// 此方法的内容。
			/// </summary>
	private void InitializeComponent()
	{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 67);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(743, 291);
            this.textBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 65);
            this.button2.TabIndex = 4;
            this.button2.Text = "Send";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.SendBtn_click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(543, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 65);
            this.button3.TabIndex = 5;
            this.button3.Text = "退出";
            this.button3.Click += new System.EventHandler(this.DiscBtn_click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 449);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(767, 16);
            this.statusBar1.TabIndex = 11;
            this.statusBar1.Text = "Status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 65);
            this.button1.TabIndex = 12;
            this.button1.Text = "下线";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 11);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(41, 16);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "111";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "112";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(304, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "发心跳";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 67);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(670, 51);
            this.textBox3.TabIndex = 6;
            this.textBox3.Visible = false;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(59, 11);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(41, 16);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "113";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 378);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 65);
            this.button4.TabIndex = 20;
            this.button4.Text = "登录";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(304, 35);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 16);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.Text = "低电压";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(374, 35);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 16);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.Text = "SOS";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(234, 378);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 65);
            this.button5.TabIndex = 26;
            this.button5.Text = "发送\r\n\r\n位置报文";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(121, 372);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "自动发送间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "经纬度变化强度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "弱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(637, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "强";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(123, 420);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(43, 23);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "10";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 3;
            this.trackBar2.Location = new System.Drawing.Point(107, 390);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 33;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "手动输入IMEI";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(59, 36);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(41, 16);
            this.radioButton4.TabIndex = 36;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "114";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 3;
            this.trackBar1.Location = new System.Drawing.Point(531, 7);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 29;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(441, 378);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 65);
            this.button6.TabIndex = 37;
            this.button6.Text = "关机下线";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(422, 35);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "脱落";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(767, 465);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text =  sVer;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
			#endregion

			/// <summary>
			/// 应用程序的主入口点。
			/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new Form1());
	}





    /*获取经度*/
    private string GetLon()
    {
        Random ran = new Random(new Random().Next());
        int iLon = ran.Next(iLatLonChangeRangeMin, iLatLonChangeRangeMax);
        //返回的经度为11351XXXX
        return (iLonPrefix + iLon / 10000.00).ToString("#0.0000");
    }

                // 11352.xxxx    1135x.xxxx     113xx.xxxx
               //  2234.xxxx     223x.xxxx      22xx.xxxx
    /*获取纬度*/
    private string GetLat()
    {
        int iLat = new Random().Next(iLatLonChangeRangeMin, iLatLonChangeRangeMax);
        //返回的纬度为2234XXXX
        return (iLatPrefix + iLat / 10000.00).ToString("#0.0000");
    }

    /*获取日期－－－日月年*/
    private string GetDayMonthYear()
    {

        string sDMY = DateTime.UtcNow.ToString("yyMMdd");
        return sDMY;
    }

    /*获取时间－－－时分秒*/
    private string GetHourMinSec()
    {
        string sHMS = DateTime.UtcNow.ToString("HHmmss");
        //int iHour = DateTime.UtcNow.Hour;
        return sHMS;
    }

    /*获取GPS数据数据*/
    private string GetGpsParam()
    {
        //SWAP01150716 A2234. 2757 N11351. 8645 E000.1023201000.0009000502000100,460,000,9779,4092#
        return GetDayMonthYear() + "A" + GetLat() + "N" + GetLon() + "E000.1" + GetHourMinSec() +  "000.0009000502000100,460,000,9779,4092";
    }

    /*获取报警字段*/
    private string GetAlterParam()
    {
        //SWAP10150716A2234.6130N11351.5366E000.1051401000.0009000502000100,460,000,9779,4092,01,zh-cn,11#
        //SWAP10150716A2234.0161N11351.2807E000.1051402000.0009000503000100,460,000,9779,4092,02,zh-cn,11#

        string sAlterParam = "";
 
        //低电压
        if (checkBox3.Checked)
            sAlterParam =  ",02,zh-cn,11";
        //SOS
        else if (checkBox4.Checked)
            sAlterParam =  ",01,zh-cn,11";
        //脱落报警
        else if (checkBox2.Checked)
            sAlterParam = ",03,zh-cn,11";

        return sAlterParam;

    }

    /*发包函数封装*/
    private void SendPacket(string sPkt)
    {
        try
        {
            Byte[] SentByte = new Byte[iMaxPktLenth];
            SentByte = System.Text.Encoding.ASCII.GetBytes(sPkt.ToCharArray());
            ChatSocket.Send(SentByte, SentByte.Length, 0);

            string str = DateTime.Now.ToString("G");
            textBox2.AppendText(str + ": ↑" + sPkt);
            textBox2.AppendText("\r\n");

        }
        catch (Exception ee)
        { statusBar1.Text = ("发送报文异常 " + ee.Message + "\r\n"); }
    }

    void RcvPkt(object sender, System.Timers.ElapsedEventArgs e)
    {
        try
        {
            if (ChatSocket.Connected && (flag))
            {



                Byte[] ReceivedByte = new Byte[iMaxPktLenth];
                ChatSocket.Receive(ReceivedByte, ReceivedByte.Length, 0);
                //string ReceivedStr=System.Text.Encoding.BigEndianUnicode.GetString(ReceivedByte);
                string ReceivedStr = System.Text.Encoding.ASCII.GetString(ReceivedByte);
                string str = DateTime.Now.ToString("G");
                //textBox2.AppendText("\r\n");
                Thread.Sleep(100);
                if (ReceivedStr[0] != '\0')
                {
                    textBox2.AppendText(str + ": ↓" + ReceivedStr);
                    textBox2.AppendText("\r\n");
                }
                


            }
            else
            {
                /*如果socket断开 则重连*/
                if (!ChatSocket.Connected)
                {
                    textBox2.AppendText("接收报文：由于socket断开，重连" + "\r\n");
                    ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ChatSocket.Connect(ChatServer);
                    statusBar1.Text = "连接成功";
                    RcvPktTimer.Enabled = true;

                }
            }
        }
        catch (Exception ee)
        { statusBar1.Text = ("接收报文 " + ee.Message + "\r\n"); }


    }

    private bool ConnectServer()
    {
        return true;

    }
	private void SendBtn_click(object sender, System.EventArgs e)
	{
		try
		{
            

            //Byte[] SentByte = new Byte[iMaxPktLenth];


            /*如果socket断开 则重连*/

            if (!ChatSocket.Connected)
            {
                ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ChatSocket.Connect(ChatServer);
                /*启动收包定时器*/
                RcvPktTimer.Enabled = true;

            }

            if (checkBox1.Checked)
            {
                g_start = true;
            }
            else
            {
                g_start = false;
            }

            //textBox2.AppendText("心跳线程状态 " + thread.ThreadState + "\r\n");
            if (ThreadState.Stopped == thread.ThreadState)
            {
                keepalivethread_shouldstop = false;
                thread = new Thread(new ThreadStart(keepalivethread));
                thread.Start(); 
            }


            string[] str = textBox3.Text.Split('\n');
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = str[i].Replace("\r", string.Empty);
           
                SendPacket(str[i]);
                if (i < (str.Length - 1))
                {

                    EventSleep(Convert.ToInt32( this.textBox4.Text)); //10秒发一个位置报文
            
                } 
            }


		}
        catch (Exception ee)
        { statusBar1.Text = ("发送其它报文 " + ee.Message + "\r\n"); }
	}



    private void keepalivethread()
    {
        try
        {
            while (!keepalivethread_shouldstop)
            {
                if (g_start)
                {
                    //SWCP01075#
                    SendPacket("SWCP01075#");
                    //SendPacket(textBox1.Text);
                    //EventSleep(60);  //10秒发一个心跳包
                    Thread.Sleep(iKeepAliveInterval);
                }
                else
                {
                    EventSleep(1); 
                }
            }
            Thread.CurrentThread.Abort();
        }
        catch (Exception ee)
        { statusBar1.Text = ("发送心跳 " + ee.Message + "\r\n"); }
    }

    void EventSleep(int t)
    {
        int times = t * 1000;
        for (int j = 0; j < times; j += 10)
        {
            Thread.Sleep(10);
            Application.DoEvents();
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string offline = "SWAP20#";
            SendPacket(offline);
            g_start = false;
            keepalivethread_shouldstop = true;
            thread.Abort();
            RcvPktTimer.Enabled = false;
            RcvPktTimer.Close();
            ChatSocket.Close();

        }
        catch (Exception ee)
        { statusBar1.Text = ("发送离线报文 " + ee.Message + "\r\n"); }
    }


    private void DiscBtn_click(object sender, System.EventArgs e)
    {
        try
        {

            RcvPktTimer.Enabled = false;
            RcvPktTimer.Close();

            g_start = false;
            keepalivethread_shouldstop = true;
            thread.Abort();
            
            ChatSocket.Close();
            statusBar1.Text = "The connection is disconnected!";
            //Thread.Sleep(500);
            this.Close();
            Application.Exit();
        }
        catch (Exception ee)
        { statusBar1.Text = ("断开连接 " + ee.Message + "\r\n"); }
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111111";
        if (radioButton1.Checked)
        {
            this.Text = sVer + "当前登录：111";
        }
      
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111112";
        if (radioButton2.Checked)
        {
            this.Text = sVer + "当前登录：112";
        }

    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111113";
        if (radioButton3.Checked)
        {
            this.Text = sVer + "当前登录：113";
        }
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111114";
        if (radioButton4.Checked)
        {
            this.Text = sVer + "当前登录：114";
        }
    }
  

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        radioButton1.Checked = false;
        radioButton2.Checked = false;
        radioButton3.Checked = false;
        radioButton4.Checked = false;

        sIMEI = this.textBox1.Text;
            this.Text = sVer + "当前登录：" + this.textBox1.Text;
    }
    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox1.Checked)
        {
            g_start = true;
        }
        else
        {
            g_start = false;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        this.radioButton2.Checked = true;
        this.trackBar2.Value=2;
        //this.textBox3.AppendText(GetHourMinSec());
        //sIMEI = this.textBox1.Text;

    }

    private void button4_Click(object sender, EventArgs e)
    {
         
        /*如果socket断开 则重连*/
        try
        {


            if (!ChatSocket.Connected)
            {
                ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ChatSocket.Connect(ChatServer);
                /*启动收包定时器*/
                RcvPktTimer.Enabled = true;

            }

            if (checkBox1.Checked)
            {
                g_start = true;
            }
            else
            {
                g_start = false;
            }

            //textBox2.AppendText("心跳线程状态 " + thread.ThreadState + "\r\n");
            if (ThreadState.Stopped == thread.ThreadState)
            {
                keepalivethread_shouldstop = false;
                thread = new Thread(new ThreadStart(keepalivethread));
                thread.Start();
            }

            string sLogininPkt = "SWAP00" + sIMEI + "#";
            SendPacket(sLogininPkt);
        }
        catch (Exception ee)
        { statusBar1.Text = ("发送登录报文 " + ee.Message + "\r\n"); }
    }

    private void button5_Click(object sender, EventArgs e)
    {
        try
        {
            //int i=100;
            //while(Convert.ToBoolean(i--))
            //{
            //    this.textBox2.AppendText(GetLat() + "     " + GetLon() + "\n");
            //}
            //return;
     
            /*如果socket断开 则重连*/

            if (!ChatSocket.Connected)
            {
                ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ChatSocket.Connect(ChatServer);
                /*启动收包定时器*/
                RcvPktTimer.Enabled = true;

            }

            if (checkBox1.Checked)
            {
                g_start = true;
            }
            else
            {
                g_start = false;
            }

            //textBox2.AppendText("心跳线程状态 " + thread.ThreadState + "\r\n");
            if (ThreadState.Stopped == thread.ThreadState)
            {
                keepalivethread_shouldstop = false;
                thread = new Thread(new ThreadStart(keepalivethread));
                thread.Start();
            }

 

            while (true)
            {
                //SWAP01150716A2234.6562N11351.0535E000.1051402000.0009000503000100,460,000,9779,4092#
                //SWAP10150716A2234.6537N11351.4345E000.1051506000.0009000507000100,460,000,9779,4092,01,zh-cn,11#

                string sPktPrefix = "";
                string sPktSuffix = "";
                if (checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
                {
                        sPktPrefix = "SWAP10";
                        sPktSuffix = GetAlterParam() + "#";                
                }

                else
                {
                        sPktPrefix = "SWAP01";
                        sPktSuffix =  "#";
                }
                        

                string sPkt = sPktPrefix  + GetGpsParam()  + sPktSuffix;
                SendPacket(sPkt);
                EventSleep(Convert.ToInt32(this.textBox4.Text)); //10秒发一个位置报文
 
            }


        }
        catch (Exception ee)
        { statusBar1.Text = ("发送其它报文 " + ee.Message + "\r\n"); }
    }

    private void trackBar1_Scroll(object sender, EventArgs e)
    {

        if (0 == trackBar1.Value)
        {
            iLonPrefix = 11352;
            iLatPrefix = 2234;
            iLatLonChangeRangeMin = 1000;
            iLatLonChangeRangeMax = 9999;
        }
        else if (1 == trackBar1.Value)
        {
            iLonPrefix = 11350;
            iLatPrefix = 2230;
            iLatLonChangeRangeMin = 30000;
            iLatLonChangeRangeMax = 69909;
        }
        else if (2 == trackBar1.Value)
        {
            iLonPrefix = 11300;
            iLatPrefix = 2200;
            iLatLonChangeRangeMin = 100000;
            iLatLonChangeRangeMax = 999999;
        }
    }

    private void trackBar2_Scroll(object sender, EventArgs e)
    {
        switch (this.trackBar2.Value)
        {
            case 0:
                this.textBox4.Text = "1";
                break;
            case 1:
                this.textBox4.Text = "5";
                break;
            case 2:
                this.textBox4.Text = "10";
                break;
            case 3:
                this.textBox4.Text = "30";
                break;
            case 4:
                this.textBox4.Text = "60";
                break;
            case 5:
                this.textBox4.Text = "100";
                break;
            case 6:
                this.textBox4.Text = "120";
                break;
            case 7:
                this.textBox4.Text = "180";
                break;
            case 8:
                this.textBox4.Text = "240";
                break;
            case 9:
                this.textBox4.Text = "300";
                break;
            case 10:
                this.textBox4.Text = "590";
                break;
            default:
                this.textBox4.Text = "10";
                break;
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {                
            this.WindowState = FormWindowState.Minimized;//将关闭行为修改成最小化的行为
            e.Cancel = true;
        }
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox3.Checked)
        {
            checkBox4.Checked = false;
            checkBox2.Checked = false;
        }
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox4.Checked)
        {
            checkBox3.Checked = false;
            checkBox2.Checked = false;
        }
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox2.Checked)
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
    }
     

    private void button6_Click(object sender, EventArgs e)
    {
        try
        {
            string offline = "SWAP36#";
            SendPacket(offline);
            g_start = false;
            keepalivethread_shouldstop = true;
            thread.Abort();
            RcvPktTimer.Enabled = false;
            RcvPktTimer.Close();
            ChatSocket.Close();

        }
        catch (Exception ee)
        { statusBar1.Text = ("发送关机报文 " + ee.Message + "\r\n"); }
    }




 




}
}



