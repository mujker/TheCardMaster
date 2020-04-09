using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCardMaster
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 调用虚拟键盘
        /// </summary>
        /// <param name="bVk">第一个为按键的虚拟键值，可以使用枚举值System.Windows.Forms.Keys</param>
        /// <param name="bScan">第二个参数为扫描码，一般不用设置，用0代替就行。</param>
        /// <param name="dwFlags">第三个参数为选项标志，如果为keydown则置"0"，如果为keyup则设成"2"。 </param>
        /// <param name="dwExtraInfo">第四个参数一般也是置0即可。</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        private static extern byte MapVirtualKey(byte wCode, int wMap);

        /// <summary>
        /// ini文件地址
        /// </summary>
        public static string DefaultIniPath =
            $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Config.ini";


        private CardConfig config = new CardConfig();

        private bool cardTaskFlag;


        #region 启停字符串

        private string startTxt = "启动";
        private string stopTxt = "停止";

        #endregion


        public MainForm()
        {
            InitializeComponent();
        }


        #region 启停、加载配置

        /// <summary>
        /// 启动
        /// </summary>
        private void Start()
        {
            if (cardTaskFlag)
            {
                return;
            }

            LoadConfig();
            cardTaskFlag = true;
            btn_Start.Invoke((Action) delegate { btn_Start.Text = stopTxt; });
            gb_Settings.Invoke((Action) delegate
            {
                foreach (Control control in gb_Settings.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Enabled = false;
                    }
                }
            });
            Task.Factory.StartNew(SelectCard);
        }

        private void SelectCard()
        {
            while (cardTaskFlag)
            {
                //黄牌
                if (KeyPressState(config.KeyYellow) && !KeyPressState(17))
                {
                    if (config.KeyYellow != 87)
                    {
                        W_Press();
                    }

                    LookUpCardColor(config.ArgbYellowCard);
                    continue;
                }

                //蓝牌
                if (KeyPressState(config.KeyBlue) && !KeyPressState(17))
                {
                    W_Press();
                    LookUpCardColor(config.ArgbBlueCard);
                    continue;
                }

                //红牌
                if (KeyPressState(config.KeyRed) && !KeyPressState(17))
                {
                    W_Press();
                    LookUpCardColor(config.ArgbRedCard);
                    continue;
                }

                //大招自动黄牌
                if (KeyPressState(82) && !KeyPressState(17) && config.RAutoYellowCard)
                {
                    W_Press();
                    LookUpCardColor(config.ArgbYellowCard);
                    continue;
                }

                //黄牌ARGB
                if (KeyPressState(49) && KeyPressState(18))
                {
                    var tempColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);
                    WriteIni("CardColorArgb", "Yellow", tempColor.ToArgb().ToString());
                }

                //蓝牌ARGB
                if (KeyPressState(50) && KeyPressState(18))
                {
                    var tempColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);
                    WriteIni("CardColorArgb", "Blue", tempColor.ToArgb().ToString());
                }

                //红牌ARGB
                if (KeyPressState(51) && KeyPressState(18))
                {
                    var tempColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);
                    WriteIni("CardColorArgb", "Red", tempColor.ToArgb().ToString());
                }

                //W键位坐标
                if (KeyPressState(36))
                {
                    WriteIni("CardPosition", "X", MousePosition.X.ToString());
                    WriteIni("CardPosition", "Y", MousePosition.Y.ToString());
                }

                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        private void Stop()
        {
            if (cardTaskFlag == false)
            {
                return;
            }

            cardTaskFlag = false;
            btn_Start.Invoke((Action) delegate { btn_Start.Text = startTxt; });
            gb_Settings.Invoke((Action) delegate
            {
                foreach (Control control in gb_Settings.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Enabled = true;
                    }
                }
            });
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            if (!File.Exists(DefaultIniPath))
            {
                return;
            }

            config.ArgbYellowCard = Convert.ToInt32(INIComm.IniReadValue("CardColorArgb", "Yellow", DefaultIniPath));
            config.ArgbBlueCard = Convert.ToInt32(INIComm.IniReadValue("CardColorArgb", "Blue", DefaultIniPath));
            config.ArgbRedCard = Convert.ToInt32(INIComm.IniReadValue("CardColorArgb", "Red", DefaultIniPath));

            config.KeyYellow = Convert.ToInt32(INIComm.IniReadValue("CardKey", "Yellow", DefaultIniPath));
            config.KeyBlue = Convert.ToInt32(INIComm.IniReadValue("CardKey", "Blue", DefaultIniPath));
            config.KeyRed = Convert.ToInt32(INIComm.IniReadValue("CardKey", "Red", DefaultIniPath));

            config.CardPositionX = Convert.ToInt32(INIComm.IniReadValue("CardPosition", "X", DefaultIniPath));
            config.CardPositionY = Convert.ToInt32(INIComm.IniReadValue("CardPosition", "Y", DefaultIniPath));

            config.KeyBlank = Convert.ToInt32(INIComm.IniReadValue("Frequency", "KeyBlank", DefaultIniPath));
            config.TimeOut = Convert.ToInt32(INIComm.IniReadValue("Frequency", "TimeOut", DefaultIniPath));

            config.RAutoYellowCard =
                Convert.ToBoolean(INIComm.IniReadValue("Function", "RAutoYellowCard", DefaultIniPath));

            gb_Settings.BeginInvoke((Action) delegate
            {
                tb_Yellow.Text = ((Keys) config.KeyYellow).ToString();
                tb_Blue.Text = ((Keys) config.KeyBlue).ToString();
                tb_Red.Text = ((Keys) config.KeyRed).ToString();
                lb_Color_Y.BackColor = Color.FromArgb(config.ArgbYellowCard);
                lb_Color_B.BackColor = Color.FromArgb(config.ArgbBlueCard);
                lb_Color_R.BackColor = Color.FromArgb(config.ArgbRedCard);
                tb_CardPosX.Text = config.CardPositionX.ToString();
                tb_CardPosY.Text = config.CardPositionY.ToString();
                tb_KeyDownDelay.Text = config.KeyBlank.ToString();
                tb_getCardTimeOut.Text = config.TimeOut.ToString();
                cb_rAutoYellow.Checked = config.RAutoYellowCard;
            });
        }

        #endregion

        #region 事件

        /// <summary>
        /// 查找指定色牌
        /// </summary>
        /// <param name="targetCardArgb"></param>
        /// <returns></returns>
        private bool LookUpCardColor(int targetCardArgb)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int count = 0;
            while (cardTaskFlag)
            {
                var changeColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);

                if (changeColor.ToArgb().Equals(targetCardArgb))
                {
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    W_Press();
                    return true;
                }

                Thread.Sleep(1);
                if (sw.ElapsedMilliseconds > config.TimeOut)
                {
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    break;
                }

                count++;
            }

            return false;
        }

        /// <summary>
        /// 单击W
        /// </summary>
        private void W_Press()
        {
            //keyup
            // keybd_event((byte) 87, MapVirtualKey((byte) 87, 0), 2, 0);
            // Thread.Sleep(config.KeyBlank);
            //keydown
            keybd_event((byte) 87, MapVirtualKey((byte) 87, 0), 0, 0);
            Thread.Sleep(config.KeyBlank);
            //keyup
            keybd_event((byte) 87, MapVirtualKey((byte) 87, 0), 2, 0);
        }

        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
            btn_Start.Text = startTxt;
        }

        private bool KeyPressState(int keys)
        {
            return (GetKeyState(keys) & 32768) != 0;
        }

        /// <summary>
        /// 窗体Close事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cardTaskFlag = false;
        }

        /// <summary>
        /// 设置切牌快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            var box = sender as TextBox;
            if (box == null) return;
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.ShiftKey || e.KeyData == Keys.ControlKey ||
                e.KeyData == Keys.Alt)
            {
                return;
            }

            box.Text = e.KeyData.ToString();
            if (box.Name.Contains("Yellow"))
            {
                WriteIni("CardKey", "Yellow", e.KeyValue.ToString());
            }

            if (box.Name.Contains("Blue"))
            {
                WriteIni("CardKey", "Blue", e.KeyValue.ToString());
            }

            if (box.Name.Contains("Red"))
            {
                WriteIni("CardKey", "Red", e.KeyValue.ToString());
            }
        }

        /// <summary>
        /// 启动按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (btn_Start.Text.Equals(startTxt))
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        /// <summary>
        /// 加载配置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadConfig_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }

        #endregion

        private void Tb_KeyDownDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b') //这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9')) //这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void tb_KeyDownDelay_Leave(object sender, EventArgs e)
        {
            var tempBlank = Convert.ToInt32(tb_KeyDownDelay.Text);
            if (tempBlank <= 0)
            {
                tempBlank = 1;
            }

            if (tempBlank >= 150)
            {
                tempBlank = 150;
            }

            WriteIni("Frequency", "KeyBlank", tempBlank.ToString());
        }

        private void tb_getCardTimeOut_Leave(object sender, EventArgs e)
        {
            var CardTimeOut = Convert.ToInt32(tb_getCardTimeOut.Text);
            if (CardTimeOut <= 1000)
            {
                CardTimeOut = 1000;
            }

            if (CardTimeOut >= 5000)
            {
                CardTimeOut = 5000;
            }

            WriteIni("Frequency", "TimeOut", CardTimeOut.ToString());
        }

        private void cb_rAutoYellow_Click(object sender, EventArgs e)
        {
            WriteIni("Function", "RAutoYellowCard", cb_rAutoYellow.Checked.ToString());
        }

        private void WriteIni(string section, string key, string value)
        {
            INIComm.IniWrite(section, key, value, DefaultIniPath);
            LoadConfig();
        }
    }
}