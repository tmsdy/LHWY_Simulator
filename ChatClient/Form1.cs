using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;
namespace ChatClient
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
public class Form1 : System.Windows.Forms.Form
{
    private string sCompany = "力豪";
    private string sVer = "模拟登录 V1.1.1     ";
    private IContainer components = null;

    //static IPAddress HostIP = IPAddress.Parse("192.168.100.5"); //14.152.107.119
    //IPEndPoint ChatServer = new IPEndPoint(HostIP, Int32.Parse("9988"));

    static IPAddress HostIP = IPAddress.Parse("14.152.107.119"); //14.152.107.119
    IPEndPoint ChatServer = new IPEndPoint(HostIP, Int32.Parse("3000"));
    //static IPAddress HostIP = IPAddress.Parse("183.62.138.3"); //14.152.107.119
    //IPEndPoint ChatServer = new IPEndPoint(HostIP, Int32.Parse("5566")); 
    static int iPktCommandIndex = 4;//PGD是5  LHWY是4
    private Socket ChatSocket;
    private bool flag = true;
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
    //private bool keepalivethread_shouldstop = false;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private CheckBox checkBox1;
    private TextBox textBox3;
    private RadioButton radioButton3;
    private Button button4;
    public System.Threading.Thread thread;
    public System.Threading.Thread threadRecvPkt;
    public double iVoiceMaxPktLenth = 900.00;
    private string sIMEI = "";
    private int iMaxPktLenth = 1024;
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
    private CheckBox checkBox5;
    private Button button7;
    private CheckBox checkBox6;
    private TextBox textBox5;
    private Label label7;
    private CheckBox checkBox7;
    private Label label8;
    private TextBox textBox6;
    private TextBox textBox7;
    private Label label9;
    private TextBox textBox8;
    private Label label10;
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

            threadRecvPkt = new Thread(new ThreadStart(RcvPkt));
 
            threadRecvPkt.Start();


            //RcvPktTimer.Elapsed += new System.Timers.ElapsedEventHandler(RcvPkt);
            //RcvPktTimer.Interval = 1000;
            //RcvPktTimer.Enabled = true;

            statusBar1.Text = "连接成功  " + ChatServer.Address.ToString() + ":" + ChatServer.Port;

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
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(12, 67);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(731, 488);
            this.textBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(656, 575);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 59);
            this.button2.TabIndex = 4;
            this.button2.Text = "发送\r\n\r\n自定义报文";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.SendBtn_click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("宋体", 14F);
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(454, 570);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "退出";
            this.button3.Click += new System.EventHandler(this.DiscBtn_click);
            // 
            // statusBar1
            // 
            this.statusBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar1.Location = new System.Drawing.Point(0, 642);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(769, 20);
            this.statusBar1.TabIndex = 11;
            this.statusBar1.Text = "Status";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(343, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 28);
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
            this.checkBox1.Location = new System.Drawing.Point(253, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "发心跳";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(239, 7);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(513, 633);
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
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(12, 571);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 65);
            this.button4.TabIndex = 20;
            this.button4.Text = "登录";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(253, 36);
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
            this.checkBox4.Location = new System.Drawing.Point(325, 10);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(42, 16);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.Text = "SOS";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.Location = new System.Drawing.Point(234, 575);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 59);
            this.button5.TabIndex = 26;
            this.button5.Text = "发送\r\n\r\n位置报文";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(121, 569);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "自动发送间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "经纬度变化强度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "弱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "强";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Location = new System.Drawing.Point(123, 617);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(43, 23);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "10";
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar2.LargeChange = 3;
            this.trackBar2.Location = new System.Drawing.Point(107, 587);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 33;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 622);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 8);
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
            this.trackBar1.Location = new System.Drawing.Point(503, 7);
            this.trackBar1.Maximum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 29;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(343, 606);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 28);
            this.button6.TabIndex = 37;
            this.button6.Text = "关机下线";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(324, 36);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "脱落";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(655, 13);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(84, 16);
            this.checkBox5.TabIndex = 39;
            this.checkBox5.Text = "自定义发送";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Location = new System.Drawing.Point(454, 606);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 30);
            this.button7.TabIndex = 40;
            this.button7.Text = "打开语音";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(654, 40);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(84, 16);
            this.checkBox6.TabIndex = 41;
            this.checkBox6.Text = "16进制发送";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(422, 9);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(43, 19);
            this.textBox5.TabIndex = 42;
            this.textBox5.Text = "50";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(378, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 43;
            this.label7.Text = "电量";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(197, 7);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(42, 16);
            this.checkBox7.TabIndex = 44;
            this.checkBox7.Text = "PGD";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(378, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 46;
            this.label8.Text = "计步";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(422, 34);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(43, 19);
            this.textBox6.TabIndex = 45;
            this.textBox6.Text = "1";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox7.Location = new System.Drawing.Point(604, 616);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(28, 19);
            this.textBox7.TabIndex = 47;
            this.textBox7.Text = "3";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(538, 617);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 48;
            this.label9.Text = "可存语音";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox8.Location = new System.Drawing.Point(600, 577);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(50, 24);
            this.textBox8.TabIndex = 49;
            this.textBox8.Text = "1";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(538, 581);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 50;
            this.label10.Text = "重复次数";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(770, 662);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkBox5);
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
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
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
        return GetDayMonthYear() + "A" + GetLat() + "N" + GetLon() + "E000.1" + GetHourMinSec() +  "000.00090005" + Convert.ToInt32(textBox5.Text).ToString("D3")+"00100,460,000,9779,4092";
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

    public  void write2file(string filename, int indexofCurrentPktCount, byte[] sNewVoice)
    {
        string filepath = Application.StartupPath + @"\voicedata\" + filename + ".amr";
        FileStream fs = null;
        //int offset = 0;
        if (!File.Exists(filepath))
        {
            //文件不存在
            fs = File.Create(filepath);
        }
        else
        {
            //如果是第1个分包，则覆盖
            if (1 == indexofCurrentPktCount)
            {
                fs = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
            }
            else
            {
                fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);

            }
             
            
        }
        BinaryWriter bw = new BinaryWriter(fs);
        //移动到当前流的末尾
        bw.Seek(0, SeekOrigin.End);


        bw.Write(sNewVoice);
        bw.Close();
        fs.Close();
         
    }

//53 57 42 50 34 37 30 30 30 30 30 30 2c 	---A-----  SWBP47000000,
//54 df 54 df 55 ef 						---U-----  哟哟嗯
//ff ff									    ---B-----  联系人结束标志符
//7c 31 38 36 38 30 36 36 30 39 38 37 2c 	---A-----  |18680660987,
//00 46 00 67 00 64 00 68 00 66 			---U-----  Fgdhf
//ff ff									    ---B-----  联系人结束标志符
//7c 31 33 34 32 34 37 30 37 33 33 34 2c 	---A-----  |13424707334,
//53 d4 53 d4 							    ---U-----  叔叔
//ff ff									    ---B-----  联系人结束标志符
//7c 31 33 36 33 32 38 34 37 39 33 39 23    ---A-----  |13632847939#
    void HandlePhoneBook(byte[] bPkt)
    {
        string sOutput = "";
        int iLenthofChar = 1;
        for (int i = 0; i < bPkt.Length; )
        {
            if ((bPkt[i] == 0xFF) && (bPkt[i + 1] == 0xFF))
            {
                sOutput += "FFFF";
                i += 2;
                iLenthofChar = 1;
                continue;
            }
            else if (iLenthofChar == 1)
            {
                byte[] bAsc = new byte[1];
                bAsc[0] = bPkt[i];
                sOutput += Encoding.ASCII.GetString(bAsc);

                if (bPkt[i] == 0x2C)
                    iLenthofChar = 2;
                i++;
                continue;
            }
            else if (iLenthofChar == 2)
            {
                byte[] b = new byte[2];
                b[0] = bPkt[i + 1];
                b[1] = bPkt[i];
                sOutput += Encoding.Unicode.GetString(b);
                i += 2;
                continue;

            }

        }
        //显示收到的内容：
        textBox2.AppendText(DateTime.Now.ToString("G") + ": ↓" + sOutput);
        textBox2.AppendText("\r\n");
    }

//    53 57 42 50 30 30 2c 32 30 31 35 30 38 32 31 31 32 33 37 33 36 23 
    //53 57 42 50 34 34 2c 32 30 31 35 30 38 32 31 32 30 33 37 33 36 2c 33 38 2c 31 2c 39 30 30 2c 23 21 41 4d 52 0a 3c 91 17 16 be 66 79 e1 e0 01 e7 af f0 00 00 00 80 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 3c 48 77 24 96 66 79 e1 e0 01 e7 ba f0 00 00 00 c0 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 3c 55 00 88 b6 66 79 e1 e0 01 e7 cf f0 00 00 00 80 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 3c 48 f9 1f 96 66 79 e1 e0 01 e7 8a f0 00 00 00 c0 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 3c 54 fd 1f b6 66 79 e1 e0 01 e7 cf f0 00 00 00 80 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 3c 28 54 1f e6 66 79 e1 e2 01 e7 fa f0 00 00 10 c0 00 00 00 00 00 5d 4c 00 00 00 00 00 16 a4 80 3c 1e 6f 61 34 e6 59 61 40 47 cd 9b a1 10 32 02 06 50 00 00 b7 b4 0b b4 3a 78 00 04 9d f6 51 c0 3c 28 40 26 8c 0e 58 a3 e1 63 96 2a b6 4d 50 92 fa b9 f4 47 44 54 39 8e 3e ce 0f 6b a1 2b 02 20 3c 18 c8 61 73 8d e2 f7 63 c5 a5 4b bc 89 ec 5f 7f 70 a8 ee 30 c4 7b 1c a2 f5 bb ee 13 ff 4f c0 3c 1e da 2b 87 f2 87 9b 92 c4 fd 55 e4 03 ea 83 56 32 b5 79 a0 3b 7d 29 bb c6 c0 8f 9f b8 05 f0 3c 16 4d 63 2f 4d c0 47 74 a2 f0 1c 66 b1 0d 4c 1d 36 fe 76 63 9c 0c 04 19 1f 51 40 68 98 0b 30 3c d8 7a 69 4f bf 2e 03 cb 55 b0 fa 0a 7e 0e 11 3e 72 cd cd cd d7 e3 46 09 41 4b dc 34 ec 44 10 3c 16 58 29 45 dc 61 0f 45 ba 6b 2c 81 92 64 fe 07 d5 0e 89 c9 e6 1c c1 1e 21 0e 89 48 4e ff 00 3c 20 6d 60 1b b8 4c 14 a3 dc eb 37 cb 6a 09 d5 0e 06 b4 5f 4f 64 9d c4 43 8d 8f 7f a3 27 79 a0 3c 1e 5a 2d 3b a3 92 16 85 bb 93 5b 74 cd 94 b6 58 83 72 84 e8 bf f6 b7 5e 4f 53 62 b7 be fb 80 3c 1e 58 71 79 1a 7c a0 49 76 39 d4 83 bd c4 cc 2f f4 d6 79 a4 80 25 6c 73 5d 8b 77 d4 b3 cf 70 3c 26 c9 83 4b bb e0 0c 09 76 64 8a 92 4f 2c 84 01 50 9b cb d6 4b e9 45 76 9a 37 43 47 52 ac e0 3c 1a 62 79 24 ea 06 55 21 ff 6b b5 df 7c 13 5e 42 16 13 19 9a de 17 4a 1e c8 66 f0 50 31 4e 20 3c 28 c8 1e 4b bc 8d 10 f0 ee 88 cb 13 01 5b 85 48 8c af 40 d9 73 a7 75 5e 36 c2 72 ec 14 92 40 3c 24 42 78 2b b7 38 03 a1 ff b4 66 ff 56 5b 1a a2 d4 89 4e 11 15 af 23 ae 7a 56 2b 88 83 6e e0 3c 1e 54 16 57 ec 78 01 c1 fe c2 9c 7a 04 63 8a 1c 42 d9 d3 b6 38 1e a8 3a 3c 03 a0 29 f3 15 60 3c 20 73 61 21 d8 f2 0b 61 fe 16 2a af 26 a9 02 0a de 88 79 98 c9 22 ab 40 45 e9 0b 91 10 b1 70 3c 1c 53 81 50 f1 4c 21 c1 fe d5 1b 3e d8 16 a4 60 73 95 12 fe 30 02 71 84 20 a5 1f 58 86 c0 30 3c 18 7a 63 2f ff 76 05 f4 ab c4 e5 70 29 dd 8a 74 f5 41 6a 88 d9 ce 2a d2 cb 54 bf 5f c1 d6 50 3c 2e 52 26 46 e9 84 15 94 a3 76 ec 97 fb 00 98 37 34 08 6c 52 0a 33 a1 ab a0 fb 1d 2f 6e 2b 00 3c e0 d8 74 27 ff 2e 41 25 ba ea 3a 74 35 db bf 19 e4 03 c0 78 87 7f be d3 7e 31 36 a6 9c e8 e0 3c 1c 63 7d 4b 8d d5 01 f8 63 f4 4b 13 98 33 47 ba a0 78 e5 76 f9 e4 ef 18 e8 5b a4 9c 1a e9 40 3c d8 c8 64 1b da ea 11 f0 ef 76 eb 15 ad 4d 24 64 30 6b a1 7a 07 ef 25 ba eb ae 6e 9f 3f 23 
    void HandleVoiceMessage(byte[] bPkt)
    {
        //SWBP44,20150821203736,38,1,900,#!AMR

        byte bFlagofEnd = 35; //结束标记'#'
        string ReceivedStr = System.Text.Encoding.ASCII.GetString(bPkt);
        int indexofDate = ReceivedStr.IndexOf(',',0) + 1;//7
        int indexofAllPktCount = ReceivedStr.IndexOf(',', indexofDate) + 1;//22
        int indexofCurrentPktCount = ReceivedStr.IndexOf(',', indexofAllPktCount) + 1;//25
        int indexofPktLenth = ReceivedStr.IndexOf(',', indexofCurrentPktCount) + 1;//27   ///////////////////**************************************************************///////////
        int indexofData = ReceivedStr.IndexOf(',', indexofPktLenth) + 1;//31

        int indexofEnd = Array.LastIndexOf(bPkt, bFlagofEnd);
        string sDate = ReceivedStr.Substring(indexofDate, indexofAllPktCount - indexofDate - 1);
        int iAllPktCount = Convert.ToInt32(ReceivedStr.Substring(indexofAllPktCount, indexofCurrentPktCount - indexofAllPktCount - 1));
        int iCurrentPktCount = Convert.ToInt32(ReceivedStr.Substring(indexofCurrentPktCount, indexofPktLenth - indexofCurrentPktCount - 1));
        int iPktLenth = Convert.ToInt32(ReceivedStr.Substring(indexofPktLenth, indexofData - indexofPktLenth - 1));
        byte[] voicedata = new byte[iPktLenth];
        Array.Copy(bPkt,indexofData,voicedata,0,voicedata.Length);
        write2file(sDate, iCurrentPktCount, voicedata);

        //显示收到的内容：
        textBox2.AppendText( DateTime.Now.ToString("G") + ": ↓" + ReceivedStr.Substring(0, indexofData) + "语音数据");
        textBox2.AppendText("\r\n");

        string sPkt = string.Empty;
        //判断是否可以接收语音
        int iVoiceCount = Convert.ToInt32(textBox7.Text);
        if (0 == iVoiceCount)
        {
            sPkt = sPkt = "SWAP44," + sDate + "," + iAllPktCount.ToString() + "," + iCurrentPktCount.ToString() + ",0#";
            //textBox7.Text = (iVoiceCount - 1).ToString();
            return;
        }
        else
        {
        //SWAP44,20140818064408,6,1,1#
          sPkt = "SWAP44," + sDate + "," + iAllPktCount.ToString() + "," + iCurrentPktCount.ToString() + ",1#";
        }
        //临时模拟下发过程中，设备不回包的情况
        //if (5 < iCurrentPktCount)
        //    return;
        SendPacket(sPkt);
        if (iCurrentPktCount == iAllPktCount)
        {
            if (0 < iVoiceCount)
            {
                //Thread.Sleep(300);
                textBox7.Text = (iVoiceCount - 1).ToString();
                string sVoiceCount = "SWAP46," + textBox7.Text + "#";
                //屏蔽掉发完语音之后上报AP46 
                //SendPacket(sVoiceCount);
            }
            textBox2.AppendText("---------------语音文件已保存在./voicedata/" + sDate + ".amr-------------------\r\n");
               
        }
        
    }
    int GetPktHeader(string ReceivedStr)
    {
        string head = ReceivedStr.Substring(iPktCommandIndex,2);
        int iRet = Convert.ToInt32(head);
        return iRet;
    }
     
    void ParsePkt(byte[] bPkt)
    {
        string ReceivedStr = System.Text.Encoding.ASCII.GetString(bPkt);
        string str = DateTime.Now.ToString("G");
        if (ReceivedStr[0] != '\0')
        {
            int iMultiPktIndex = ReceivedStr.LastIndexOf("SWBP");
            if (iMultiPktIndex > 4 )
            {
                //此分支表示有粘包
                Byte[] FirstPktByte = new Byte[iMaxPktLenth];
                Array.Copy(bPkt, 0, FirstPktByte, 0, iMultiPktIndex);

                Byte[] SecondPktByte = new Byte[iMaxPktLenth];
                Array.Copy(bPkt, iMultiPktIndex, SecondPktByte, 0, bPkt.Length - iMultiPktIndex);

                ParsePkt(FirstPktByte);

                ParsePkt(SecondPktByte);

            }
            else
            {
                switch (GetPktHeader(ReceivedStr))
                {
                    case 44:
                        HandleVoiceMessage(bPkt);
                        break;
                    case 47:
                        HandlePhoneBook(bPkt);
                        //textBox2.Text += ("45\r\n");
                        break;
                    case 0:

                    case 1:

                    case 45:
                    default:
                        textBox2.AppendText(str + ": ↓" + ReceivedStr);
                        textBox2.AppendText("\r\n");
                        break;
                }
            }


        }

    }

    //object sender, System.Timers.ElapsedEventArgs e
    void RcvPkt()
    {
        try
        {
            while (ChatSocket.Connected && (flag))
            {



                Byte[] ReceivedByte = new Byte[iMaxPktLenth];
                ChatSocket.Receive(ReceivedByte, ReceivedByte.Length, 0);
   
                Thread.Sleep(100);
                ParsePkt(ReceivedByte);
                


            }
            //else
            //{
            //    /*如果socket断开 则重连*/
            //    if (!ChatSocket.Connected)
            //    {
            //        textBox2.AppendText("接收报文：由于socket断开，重连" + "\r\n");
            //        ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //        ChatSocket.Connect(ChatServer);
            //        statusBar1.Text = "连接成功";
            //        RcvPktTimer.Enabled = true;

            //    }
            //}
        }
        catch (Exception ee)
        { 
            //statusBar1.Text = ("接收报文 " + ee.Message + "\r\n"); 
        }


    }

    private bool ConnectServer()
    {
        return true;

    }

    private void SendHexPkt(byte[] b)
    {
        try
        {
             
            ChatSocket.Send(b, b.Length, 0);
            //SWAP45,111111111111112,20150822102031,5,1,900,
            string str = DateTime.Now.ToString("G");
            string ReceivedStr = System.Text.Encoding.Default.GetString(b);

            int indexofIMEI = ReceivedStr.IndexOf(',', 0) + 1;//7
            int indexofDate = ReceivedStr.IndexOf(',', indexofIMEI) + 1;//23
            int indexofAllPktCount = ReceivedStr.IndexOf(',', indexofDate) + 1;//38
            int indexofCurrentPktCount = ReceivedStr.IndexOf(',', indexofAllPktCount) + 1;//40
            int indexofPktLenth = ReceivedStr.IndexOf(',', indexofCurrentPktCount) + 1;//42  ///////////////////**************************************************************///////////
            int indexofData = ReceivedStr.IndexOf(',', indexofPktLenth) + 1;//46

            textBox2.AppendText(str + ": ↑" + ReceivedStr.Substring(0, indexofData) + "语音数据");

            textBox2.AppendText("\r\n");

        }
        catch (Exception ee)
        { statusBar1.Text = ("发送报文异常 " + ee.Message + "\r\n"); }
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
                //RcvPktTimer.Enabled = true;

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
                //keepalivethread_shouldstop = false;
                thread = new Thread(new ThreadStart(keepalivethread));
                thread.Start(); 
            }


            string[] str = textBox3.Text.Split('\n');
            int iAllRepeatTimes = Convert.ToInt32(textBox8.Text.Trim());
            for (int iRepeat = 0; iRepeat < iAllRepeatTimes; )
            {

                textBox8.Text = iRepeat.ToString();
                    for (int i = 0; i < str.Length; i++)
                    {


                        str[i] = str[i].Replace("\r", string.Empty).Replace(" ", string.Empty);
                        //如果是空行则跳过
                        if (str[i] == string.Empty)
                            continue;
                        //如果是//开头 则跳过
                        if ((str[i][0] == '/') && (str[i][1] == '/'))
                            continue;
                        /********************************************/
                        if (checkBox6.Checked == false)
                        {
                            SendPacket(str[i]);
                        }
                        else
                        {
                            byte[] bytes = new byte[str[i].Length / 2];

                            for (int j = 0; j < bytes.Length; j++)
                            {
                                try
                                {
                                    // 每两个字符是一个 byte。
                                    bytes[j] = byte.Parse(str[i].Substring(j * 2, 2),
                                    System.Globalization.NumberStyles.HexNumber);
                                    //bytes[j] = Convert.ToByte(str[j].Substring(j * 2, 2).Trim(), 10);   
                                }
                                catch
                                {
                                    throw new ArgumentException("hex is not a valid hex number!", "str[i]");
                                }
                            }


                            /********************************************/
                            SendHexPkt(bytes);
                        }

                        if (i < (str.Length - 1))
                        {
                            if (checkBox6.Checked == true)
                            {
                                EventSleep(1); //1秒发一个位置报文

                            }
                            else
                            {
                                EventSleep(Convert.ToInt32(textBox4.Text)); //1秒发一个位置报文
                            }

                        }
                    }

                    textBox8.Text = (++iRepeat).ToString();
                }
            
		}
        catch (Exception ee)
        { statusBar1.Text = ("发送其它报文 " + ee.Message + "\r\n"); }
	}



    private void keepalivethread()
    {
        try
        {
            while (true)
            {
                if (g_start)
                {
                    int iStep = Convert.ToInt32(textBox6.Text);
                    textBox6.Text = (iStep + 1).ToString("D4");
                    string sPkt = "SWCP01" + Convert.ToInt32(textBox5.Text).ToString("D3") + textBox6.Text+"#";
                    
                    //SWCP01075#
                    SendPacket(sPkt);
                    //SendPacket(textBox1.Text);
                    //EventSleep(60);  //10秒发一个心跳包
                    Thread.Sleep(iKeepAliveInterval);
                }
                else
                {
                    EventSleep(1); 
                }
            }
            //Thread.CurrentThread.Abort();
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
            //keepalivethread_shouldstop = true;
            thread.Abort();
            //RcvPktTimer.Enabled = false;
            //RcvPktTimer.Close();
            ChatSocket.Close();

        }
        catch (Exception ee)
        { statusBar1.Text = ("发送离线报文 " + ee.Message + "\r\n"); }
    }


    private void DiscBtn_click(object sender, System.EventArgs e)
    {
        try
        {

            //RcvPktTimer.Enabled = false;
            //RcvPktTimer.Close();

            g_start = false;
            //keepalivethread_shouldstop = true;
            thread.Abort();
            
            ChatSocket.Close();
            statusBar1.Text = "The connection is disconnected!";
            //Thread.Sleep(500);
            this.Close();
            Application.Exit();
        }
        catch (Exception ee)
        {
            statusBar1.Text = ("断开连接 " + ee.Message + "\r\n");

            this.Close();
            Application.Exit();
        }
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {

    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111111";
        if (radioButton1.Checked)
        {
            this.Text = sCompany + sVer + "当前登录：111";
        }
      
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111112";
        if (radioButton2.Checked)
        {
            this.Text = sCompany + sVer + "当前登录：112";
        }

    }

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111113";
        if (radioButton3.Checked)
        {
            this.Text = sCompany + sVer + "当前登录：113";
        }
    }

    private void radioButton4_CheckedChanged(object sender, EventArgs e)
    {
        sIMEI = "111111111111114";
        if (radioButton4.Checked)
        {
            this.Text = sCompany + sVer + "当前登录：114";
        }
    }
  

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        radioButton1.Checked = false;
        radioButton2.Checked = false;
        radioButton3.Checked = false;
        radioButton4.Checked = false;

        sIMEI = this.textBox1.Text;
        this.Text = sCompany + sVer + "当前登录：" + this.textBox1.Text;
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
        this.trackBar2.Value = 2;
        this.textBox3.MaxLength = 999999;
        //this.textBox3.AppendText(GetHourMinSec());
        //sIMEI = this.textBox1.Text;
        string sPath = Application.StartupPath + @"\voicedata\";
        if (!Directory.Exists(sPath))
        {
            Directory.CreateDirectory(sPath);
        }


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

                statusBar1.Text = "连接成功  " + ChatServer.Address.ToString() + ":" + ChatServer.Port;
                /*启动收包定时器*/
                //RcvPktTimer.Enabled = true;
                threadRecvPkt = new Thread(new ThreadStart(RcvPkt));
                threadRecvPkt.Start();
                thread = new Thread(new ThreadStart(keepalivethread));
                thread.Start();
            }

            //如果勾选了发心跳，则开始发心跳
            if (checkBox1.Checked)
            {
                g_start = true;
            }
            else
            {
                g_start = false;
            }

            //textBox2.AppendText("心跳线程状态 " + thread.ThreadState + "\r\n");
            //if (ThreadState.Stopped == thread.ThreadState)
            //{
            //    keepalivethread_shouldstop = false;
            //    thread = new Thread(new ThreadStart(keepalivethread));
            //    thread.Start();
            //}

            string sLogininPkt = "SWAP00" + sIMEI + "#";
            SendPacket(sLogininPkt);


            string sVoiceCount = "SWAP46," + textBox7.Text + "#";
            SendPacket(sVoiceCount);
        }
        catch (Exception ee)
        { statusBar1.Text = ("发送登录报文 " + ee.Message + "\r\n"); }
    }
    public bool bSend = false;
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
            if (bSend)
            {
                bSend = false;
                this.button5.Text = "发送\n\n位置报文";
            }
                
            else
            {
                bSend = true;
                this.button5.Text = "停止发送";
            }
                

            if (!ChatSocket.Connected)
            {
                ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ChatSocket.Connect(ChatServer);
                /*启动收包定时器*/
                //RcvPktTimer.Enabled = true;
                threadRecvPkt = new Thread(new ThreadStart(RcvPkt));
                threadRecvPkt.Start();

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
                //keepalivethread_shouldstop = false;
                thread = new Thread(new ThreadStart(keepalivethread));
                thread.Start();
            }



            while (bSend)
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
            //keepalivethread_shouldstop = true;
            thread.Abort();
            //RcvPktTimer.Enabled = false;
            //RcvPktTimer.Close();
            ChatSocket.Close();

        }
        catch (Exception ee)
        { statusBar1.Text = ("发送关机报文 " + ee.Message + "\r\n"); }
    }

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox5.Checked)
        {
            button2.Visible = true;
            textBox3.Visible = true;
            this.FindForm().Size = new Size(1300, 700);
            //checkBox6.Checked = true;
        }
        else
        {
            button2.Visible = false;
            textBox3.Text = string.Empty;
            textBox3.Visible = false;
            this.FindForm().Size = new Size(786, 700);
            checkBox6.Checked = false;
        }
    }
    private void pringASCII(string s2)
    {
        //将ASCII转16进制

        byte[] ba = System.Text.ASCIIEncoding.Default.GetBytes(s2);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in ba)
        {
            sb.Append(b.ToString("x2") + " ");
        }
        textBox3.Text += (sb.ToString());

    }
    private void button7_Click(object sender, EventArgs e)
    {
        checkBox5.Checked = true;
        checkBox6.Checked = true;
        button2.Visible = true;
        textBox3.Visible = true;
        this.FindForm().Size = new Size(1300, 700);
        //richTextBox1.AppendText("登录包\r\n");
        //string sLogin = "SWAP00" + textBox1.Text + "#";
        //pringASCII(sLogin);
        //richTextBox1.AppendText("\r\n");
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //设置打开文件的格式
        openFileDialog1.Filter = "录音文件(*.amr)|*.amr";
        if (openFileDialog1.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        //richTextBox1.Text = string.Empty;
        //使用“打开”对话框中选择的文件名实例化FileStream对象
        FileStream myStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
        int iStreamLength = (int)myStream.Length;
        byte[] byteFile = new byte[iStreamLength];

        double dPktPartCount = myStream.Length / iVoiceMaxPktLenth;
        //一共有iPktPartCount个包
        int iPktPartCount = Convert.ToInt32(Math.Ceiling(dPktPartCount));
        int iPktIndex = 0;
        string sTime = DateTime.Now.ToString("yyyyMMddhhmmss");
        int iPktLenth = (int)iVoiceMaxPktLenth;
        string sPktPrefix = string.Empty;

        myStream.Read(byteFile, 0, iStreamLength);
        textBox3.Text = string.Empty;
        //关闭当前文件流
        myStream.Close();

        int j = 0;
        for (int i = 1; i <= iPktPartCount; i++)
        {
            textBox3.Text += ("//一共" + iPktPartCount.ToString() + "个分包，当前第" + i.ToString() + "个分包\r\n");
            if ((i == iPktPartCount) && (iVoiceMaxPktLenth * i != iStreamLength))
                iPktLenth = iStreamLength - (int)(iVoiceMaxPktLenth) * (i - 1);


            sPktPrefix = "SWAP45," + sIMEI + "," + sTime + "," + iPktPartCount.ToString() +
                "," + i.ToString() + "," + iPktLenth.ToString() + ",";
            //richTextBox1.AppendText(sPktPrefix );

            //richTextBox1.AppendText("\r\n");
            pringASCII(sPktPrefix);

            StringBuilder sb = new StringBuilder();
         
            for (j = 0; j < iPktLenth; j++, iPktIndex++)
            {
                sb.Append(byteFile[iPktIndex].ToString("x2") + " ");
            }
            textBox3.Text += sb.ToString();
            pringASCII("#");
            textBox3.Text += ("\r\n");
            //iPktIndex += iPktLenth;

        }
    }

    private void checkBox7_CheckedChanged(object sender, EventArgs e)
    {
        //RcvPktTimer.Enabled = false;
         
        ChatSocket.Close();
        if (checkBox7.Checked)
        {
            //IPHostEntry hostinfo = Dns.GetHostEntry(@"mapgoo1307.eicp.net");
            //IPAddress[] aryIP = hostinfo.AddressList;
             
            //ChatServer = new IPEndPoint(aryIP[0], Int32.Parse("9988"));

            IPAddress HostIP = IPAddress.Parse("183.62.138.3");
            ChatServer = new IPEndPoint(HostIP, Int32.Parse("5566"));
            sCompany  = "品冠达";
        }
        else
        {
            IPAddress HostIP = IPAddress.Parse("14.152.107.119"); //14.152.107.119
            ChatServer = new IPEndPoint(HostIP, Int32.Parse("3000"));
            sCompany = "力豪";
        }
        try
        {
            ChatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ChatSocket.Connect(ChatServer);
            threadRecvPkt = new Thread(new ThreadStart(RcvPkt));
            threadRecvPkt.Start();
            this.Text =sCompany +  sVer;
            statusBar1.Text = "连接成功  " + ChatServer.Address.ToString() + ":" + ChatServer.Port;
        }
        catch
        {
            statusBar1.Text = "切换服务器失败";
            if (checkBox7.Checked)
            {
                checkBox7.Checked = false;
            }
            else
            {
                checkBox7.Checked = true;
            }
        }

    }

 
     
}
}



