namespace TheCardMaster
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_Settings = new System.Windows.Forms.GroupBox();
            this.tb_CardPosY = new System.Windows.Forms.TextBox();
            this.tb_CardPosX = new System.Windows.Forms.TextBox();
            this.tb_Red = new System.Windows.Forms.TextBox();
            this.tb_Blue = new System.Windows.Forms.TextBox();
            this.tb_Yellow = new System.Windows.Forms.TextBox();
            this.lb_CardPosY = new System.Windows.Forms.Label();
            this.lb_CardPosX = new System.Windows.Forms.Label();
            this.lb_Red = new System.Windows.Forms.Label();
            this.lb_Blue = new System.Windows.Forms.Label();
            this.lb_Yellow = new System.Windows.Forms.Label();
            this.gb_Buttons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_LoadConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_KeyDownDelay = new System.Windows.Forms.TextBox();
            this.gb_Settings.SuspendLayout();
            this.gb_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Settings
            // 
            this.gb_Settings.Controls.Add(this.tb_KeyDownDelay);
            this.gb_Settings.Controls.Add(this.tb_CardPosY);
            this.gb_Settings.Controls.Add(this.tb_CardPosX);
            this.gb_Settings.Controls.Add(this.tb_Red);
            this.gb_Settings.Controls.Add(this.tb_Blue);
            this.gb_Settings.Controls.Add(this.tb_Yellow);
            this.gb_Settings.Controls.Add(this.label2);
            this.gb_Settings.Controls.Add(this.lb_CardPosY);
            this.gb_Settings.Controls.Add(this.lb_CardPosX);
            this.gb_Settings.Controls.Add(this.lb_Red);
            this.gb_Settings.Controls.Add(this.lb_Blue);
            this.gb_Settings.Controls.Add(this.lb_Yellow);
            this.gb_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Settings.Location = new System.Drawing.Point(0, 0);
            this.gb_Settings.Name = "gb_Settings";
            this.gb_Settings.Size = new System.Drawing.Size(478, 274);
            this.gb_Settings.TabIndex = 0;
            this.gb_Settings.TabStop = false;
            this.gb_Settings.Text = "按键设置";
            // 
            // tb_CardPosY
            // 
            this.tb_CardPosY.Location = new System.Drawing.Point(102, 174);
            this.tb_CardPosY.Name = "tb_CardPosY";
            this.tb_CardPosY.Size = new System.Drawing.Size(119, 21);
            this.tb_CardPosY.TabIndex = 5;
            // 
            // tb_CardPosX
            // 
            this.tb_CardPosX.Location = new System.Drawing.Point(102, 137);
            this.tb_CardPosX.Name = "tb_CardPosX";
            this.tb_CardPosX.Size = new System.Drawing.Size(119, 21);
            this.tb_CardPosX.TabIndex = 4;
            // 
            // tb_Red
            // 
            this.tb_Red.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Red.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tb_Red.Location = new System.Drawing.Point(102, 97);
            this.tb_Red.Name = "tb_Red";
            this.tb_Red.Size = new System.Drawing.Size(119, 21);
            this.tb_Red.TabIndex = 3;
            this.tb_Red.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // tb_Blue
            // 
            this.tb_Blue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Blue.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tb_Blue.Location = new System.Drawing.Point(102, 66);
            this.tb_Blue.Name = "tb_Blue";
            this.tb_Blue.Size = new System.Drawing.Size(119, 21);
            this.tb_Blue.TabIndex = 2;
            this.tb_Blue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // tb_Yellow
            // 
            this.tb_Yellow.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Yellow.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tb_Yellow.Location = new System.Drawing.Point(102, 35);
            this.tb_Yellow.Name = "tb_Yellow";
            this.tb_Yellow.Size = new System.Drawing.Size(119, 21);
            this.tb_Yellow.TabIndex = 1;
            this.tb_Yellow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // lb_CardPosY
            // 
            this.lb_CardPosY.AutoSize = true;
            this.lb_CardPosY.Location = new System.Drawing.Point(37, 178);
            this.lb_CardPosY.Name = "lb_CardPosY";
            this.lb_CardPosY.Size = new System.Drawing.Size(59, 12);
            this.lb_CardPosY.TabIndex = 0;
            this.lb_CardPosY.Text = "切牌坐标Y";
            // 
            // lb_CardPosX
            // 
            this.lb_CardPosX.AutoSize = true;
            this.lb_CardPosX.Location = new System.Drawing.Point(37, 141);
            this.lb_CardPosX.Name = "lb_CardPosX";
            this.lb_CardPosX.Size = new System.Drawing.Size(59, 12);
            this.lb_CardPosX.TabIndex = 0;
            this.lb_CardPosX.Text = "切牌坐标X";
            // 
            // lb_Red
            // 
            this.lb_Red.AutoSize = true;
            this.lb_Red.Location = new System.Drawing.Point(37, 101);
            this.lb_Red.Name = "lb_Red";
            this.lb_Red.Size = new System.Drawing.Size(29, 12);
            this.lb_Red.TabIndex = 0;
            this.lb_Red.Text = "红牌";
            // 
            // lb_Blue
            // 
            this.lb_Blue.AutoSize = true;
            this.lb_Blue.Location = new System.Drawing.Point(37, 70);
            this.lb_Blue.Name = "lb_Blue";
            this.lb_Blue.Size = new System.Drawing.Size(29, 12);
            this.lb_Blue.TabIndex = 0;
            this.lb_Blue.Text = "蓝牌";
            // 
            // lb_Yellow
            // 
            this.lb_Yellow.AutoSize = true;
            this.lb_Yellow.Location = new System.Drawing.Point(37, 39);
            this.lb_Yellow.Name = "lb_Yellow";
            this.lb_Yellow.Size = new System.Drawing.Size(29, 12);
            this.lb_Yellow.TabIndex = 0;
            this.lb_Yellow.Text = "黄牌";
            // 
            // gb_Buttons
            // 
            this.gb_Buttons.Controls.Add(this.label1);
            this.gb_Buttons.Controls.Add(this.btn_Start);
            this.gb_Buttons.Controls.Add(this.btn_LoadConfig);
            this.gb_Buttons.Dock = System.Windows.Forms.DockStyle.Right;
            this.gb_Buttons.Location = new System.Drawing.Point(278, 0);
            this.gb_Buttons.Name = "gb_Buttons";
            this.gb_Buttons.Size = new System.Drawing.Size(200, 274);
            this.gb_Buttons.TabIndex = 1;
            this.gb_Buttons.TabStop = false;
            this.gb_Buttons.Text = "操作按钮";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 156);
            this.label1.TabIndex = 1;
            this.label1.Text = "快捷键：\r\n\r\nHOME：设置切牌颜色识别坐标；\r\n\r\nALT+1：设置黄牌颜色；\r\n\r\nALT+2：设置蓝牌颜色；\r\n\r\nALT+3：设置红牌颜色；\r\n\r\nF9" +
    "：启动；\r\n\r\nF10：停止；";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(63, 71);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(75, 23);
            this.btn_Start.TabIndex = 7;
            this.btn_Start.Text = "启动";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_LoadConfig
            // 
            this.btn_LoadConfig.Location = new System.Drawing.Point(63, 33);
            this.btn_LoadConfig.Name = "btn_LoadConfig";
            this.btn_LoadConfig.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadConfig.TabIndex = 6;
            this.btn_LoadConfig.Text = "加载配置";
            this.btn_LoadConfig.UseVisualStyleBackColor = true;
            this.btn_LoadConfig.Click += new System.EventHandler(this.btn_LoadConfig_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "按键延迟";
            // 
            // tb_KeyDownDelay
            // 
            this.tb_KeyDownDelay.Location = new System.Drawing.Point(102, 211);
            this.tb_KeyDownDelay.Name = "tb_KeyDownDelay";
            this.tb_KeyDownDelay.Size = new System.Drawing.Size(119, 21);
            this.tb_KeyDownDelay.TabIndex = 5;
            this.tb_KeyDownDelay.TextChanged += new System.EventHandler(this.Tb_KeyDownDelay_TextChanged);
            this.tb_KeyDownDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyDownDelay_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 274);
            this.Controls.Add(this.gb_Buttons);
            this.Controls.Add(this.gb_Settings);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheCardMaster";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gb_Settings.ResumeLayout(false);
            this.gb_Settings.PerformLayout();
            this.gb_Buttons.ResumeLayout(false);
            this.gb_Buttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Settings;
        private System.Windows.Forms.GroupBox gb_Buttons;
        private System.Windows.Forms.Label lb_Red;
        private System.Windows.Forms.Label lb_Blue;
        private System.Windows.Forms.Label lb_Yellow;
        private System.Windows.Forms.TextBox tb_Red;
        private System.Windows.Forms.TextBox tb_Blue;
        private System.Windows.Forms.TextBox tb_Yellow;
        private System.Windows.Forms.TextBox tb_CardPosY;
        private System.Windows.Forms.TextBox tb_CardPosX;
        private System.Windows.Forms.Label lb_CardPosY;
        private System.Windows.Forms.Label lb_CardPosX;
        private System.Windows.Forms.Button btn_LoadConfig;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_KeyDownDelay;
        private System.Windows.Forms.Label label2;
    }
}