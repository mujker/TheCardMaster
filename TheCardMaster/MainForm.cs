using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ImageRecognitionLib;
using WinINI;
using WinIOLib;

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
                if (MyGetKeyState(config.KeyYellow) && !MyGetKeyState(17))
                {

                    if (config.KeyYellow != 87)
                    {
                        W_Press();
                    }

                    LookUpCardColor(config.ArgbYellowCard);
                    continue;
                }

                //蓝牌
                if (MyGetKeyState(config.KeyBlue) && !MyGetKeyState(17))
                {
                    W_Press();
                    LookUpCardColor(config.ArgbBlueCard);
                    continue;
                }

                //红牌
                if (MyGetKeyState(config.KeyRed) && !MyGetKeyState(17))
                {
                    W_Press();
                    LookUpCardColor(config.ArgbRedCard);
                    continue;
                }

                //大招自动黄牌
//                if (MyGetKeyState(82) && !MyGetKeyState(17))
//                {
//                    W_Press();
//                    LookUpCardColor(config.ArgbYellowCard);
//                    continue;
//                }

                //启动
                if (MyGetKeyState(120) && !MyGetKeyState(17))
                {
                    Start();
                }

                //停止
                if (MyGetKeyState(121) && !MyGetKeyState(17))
                {
                    Stop();
                }

                //黄牌ARGB
                if (MyGetKeyState(49) && MyGetKeyState(18))
                {
                    var tempColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);
                    INIComm.IniWrite("CardColorArgb", "Yellow", tempColor.ToArgb().ToString(), DefaultIniPath);
                    LoadConfig();
                }

                //蓝牌ARGB
                if (MyGetKeyState(50) && MyGetKeyState(18))
                {
                    var tempColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);
                    INIComm.IniWrite("CardColorArgb", "Blue", tempColor.ToArgb().ToString(), DefaultIniPath);
                    LoadConfig();
                }

                //红牌ARGB
                if (MyGetKeyState(51) && MyGetKeyState(18))
                {
                    var tempColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);
                    INIComm.IniWrite("CardColorArgb", "Red", tempColor.ToArgb().ToString(), DefaultIniPath);
                    LoadConfig();
                }

                //W键位坐标
                if (MyGetKeyState(36))
                {
                    INIComm.IniWrite("CardPosition", "X", MousePosition.X.ToString(), DefaultIniPath);
                    INIComm.IniWrite("CardPosition", "Y", MousePosition.Y.ToString(), DefaultIniPath);
                    LoadConfig();
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
            config.ArgbYellowCard = Convert.ToInt32(INIComm.IniReadValue("CardColorArgb", "Yellow", DefaultIniPath));
            config.ArgbBlueCard = Convert.ToInt32(INIComm.IniReadValue("CardColorArgb", "Blue", DefaultIniPath));
            config.ArgbRedCard = Convert.ToInt32(INIComm.IniReadValue("CardColorArgb", "Red", DefaultIniPath));

            config.KeyYellow = Convert.ToInt32(INIComm.IniReadValue("CardKey", "Yellow", DefaultIniPath));
            config.KeyBlue = Convert.ToInt32(INIComm.IniReadValue("CardKey", "Blue", DefaultIniPath));
            config.KeyRed = Convert.ToInt32(INIComm.IniReadValue("CardKey", "Red", DefaultIniPath));

            config.CardPositionX = Convert.ToInt32(INIComm.IniReadValue("CardPosition", "X", DefaultIniPath));
            config.CardPositionY = Convert.ToInt32(INIComm.IniReadValue("CardPosition", "Y", DefaultIniPath));

            config.KeyBlank = Convert.ToInt32(INIComm.IniReadValue("Frequency", "KeyBlank", DefaultIniPath));

            gb_Settings.BeginInvoke((Action) delegate
            {
                tb_Yellow.Text = ((Keys) config.KeyYellow).ToString();
                tb_Blue.Text = ((Keys) config.KeyBlue).ToString();
                tb_Red.Text = ((Keys) config.KeyRed).ToString();
                tb_Yellow.BackColor = Color.FromArgb(config.ArgbYellowCard);
                tb_Blue.BackColor = Color.FromArgb(config.ArgbBlueCard);
                tb_Red.BackColor = Color.FromArgb(config.ArgbRedCard);
                tb_CardPosX.Text = config.CardPositionX.ToString();
                tb_CardPosY.Text = config.CardPositionY.ToString();
                tb_KeyDownDelay.Text = config.KeyBlank.ToString();
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
            int count = 0;
            while (cardTaskFlag)
            {
                var changeColor = ColorRec.GetPixelColor(config.CardPositionX, config.CardPositionY);

                if (changeColor.ToArgb().Equals(targetCardArgb))
                {
                    W_Press();
                    return true;
                }

                Thread.Sleep(1);
                if (count > 5000)
                {
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

        private void KeyTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
        }

        private bool MyGetKeyState(int keys)
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
            box.Text = e.KeyData.ToString();
            if (box.Name.Contains("Yellow"))
            {
                INIComm.IniWrite("CardKey", "Yellow", e.KeyValue.ToString(), DefaultIniPath);
            }

            if (box.Name.Contains("Blue"))
            {
                INIComm.IniWrite("CardKey", "Blue", e.KeyValue.ToString(), DefaultIniPath);
            }

            if (box.Name.Contains("Red"))
            {
                INIComm.IniWrite("CardKey", "Red", e.KeyValue.ToString(), DefaultIniPath);
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
            if(e.KeyChar!='\b')//这是允许输入退格键  
            {  
                if((e.KeyChar<'0')||(e.KeyChar>'9'))//这是允许输入0-9数字  
                {  
                    e.Handled = true;  
                }  
            }  
        }

        private void Tb_KeyDownDelay_TextChanged(object sender, EventArgs e)
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
            INIComm.IniWrite("Frequency", "KeyBlank", tempBlank.ToString(), DefaultIniPath);
            LoadConfig();

        }
    }
}