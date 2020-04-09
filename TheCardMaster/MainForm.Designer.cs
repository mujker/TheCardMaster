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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gb_Settings = new System.Windows.Forms.GroupBox();
            this.tb_getCardTimeOut = new System.Windows.Forms.TextBox();
            this.tb_KeyDownDelay = new System.Windows.Forms.TextBox();
            this.tb_CardPosY = new System.Windows.Forms.TextBox();
            this.tb_CardPosX = new System.Windows.Forms.TextBox();
            this.tb_Red = new System.Windows.Forms.TextBox();
            this.tb_Blue = new System.Windows.Forms.TextBox();
            this.tb_Yellow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_CardPosY = new System.Windows.Forms.Label();
            this.lb_CardPosX = new System.Windows.Forms.Label();
            this.lb_Color_R = new System.Windows.Forms.Label();
            this.lb_Red = new System.Windows.Forms.Label();
            this.lb_Color_B = new System.Windows.Forms.Label();
            this.lb_Blue = new System.Windows.Forms.Label();
            this.lb_Color_Y = new System.Windows.Forms.Label();
            this.lb_Yellow = new System.Windows.Forms.Label();
            this.gb_Buttons = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_LoadConfig = new System.Windows.Forms.Button();
            this.gb_Settings.SuspendLayout();
            this.gb_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Settings
            // 
            this.gb_Settings.Controls.Add(this.tb_getCardTimeOut);
            this.gb_Settings.Controls.Add(this.tb_KeyDownDelay);
            this.gb_Settings.Controls.Add(this.tb_CardPosY);
            this.gb_Settings.Controls.Add(this.tb_CardPosX);
            this.gb_Settings.Controls.Add(this.tb_Red);
            this.gb_Settings.Controls.Add(this.tb_Blue);
            this.gb_Settings.Controls.Add(this.tb_Yellow);
            this.gb_Settings.Controls.Add(this.label3);
            this.gb_Settings.Controls.Add(this.label2);
            this.gb_Settings.Controls.Add(this.lb_CardPosY);
            this.gb_Settings.Controls.Add(this.lb_CardPosX);
            this.gb_Settings.Controls.Add(this.lb_Color_R);
            this.gb_Settings.Controls.Add(this.lb_Red);
            this.gb_Settings.Controls.Add(this.lb_Color_B);
            this.gb_Settings.Controls.Add(this.lb_Blue);
            this.gb_Settings.Controls.Add(this.lb_Color_Y);
            this.gb_Settings.Controls.Add(this.lb_Yellow);
            resources.ApplyResources(this.gb_Settings, "gb_Settings");
            this.gb_Settings.Name = "gb_Settings";
            this.gb_Settings.TabStop = false;
            // 
            // tb_getCardTimeOut
            // 
            resources.ApplyResources(this.tb_getCardTimeOut, "tb_getCardTimeOut");
            this.tb_getCardTimeOut.Name = "tb_getCardTimeOut";
            this.tb_getCardTimeOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyDownDelay_KeyPress);
            this.tb_getCardTimeOut.Leave += new System.EventHandler(this.tb_getCardTimeOut_Leave);
            // 
            // tb_KeyDownDelay
            // 
            resources.ApplyResources(this.tb_KeyDownDelay, "tb_KeyDownDelay");
            this.tb_KeyDownDelay.Name = "tb_KeyDownDelay";
            this.tb_KeyDownDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tb_KeyDownDelay_KeyPress);
            this.tb_KeyDownDelay.Leave += new System.EventHandler(this.tb_KeyDownDelay_Leave);
            // 
            // tb_CardPosY
            // 
            resources.ApplyResources(this.tb_CardPosY, "tb_CardPosY");
            this.tb_CardPosY.Name = "tb_CardPosY";
            // 
            // tb_CardPosX
            // 
            resources.ApplyResources(this.tb_CardPosX, "tb_CardPosX");
            this.tb_CardPosX.Name = "tb_CardPosX";
            // 
            // tb_Red
            // 
            this.tb_Red.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tb_Red, "tb_Red");
            this.tb_Red.Name = "tb_Red";
            this.tb_Red.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // tb_Blue
            // 
            this.tb_Blue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tb_Blue, "tb_Blue");
            this.tb_Blue.Name = "tb_Blue";
            this.tb_Blue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // tb_Yellow
            // 
            this.tb_Yellow.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tb_Yellow, "tb_Yellow");
            this.tb_Yellow.Name = "tb_Yellow";
            this.tb_Yellow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lb_CardPosY
            // 
            resources.ApplyResources(this.lb_CardPosY, "lb_CardPosY");
            this.lb_CardPosY.Name = "lb_CardPosY";
            // 
            // lb_CardPosX
            // 
            resources.ApplyResources(this.lb_CardPosX, "lb_CardPosX");
            this.lb_CardPosX.Name = "lb_CardPosX";
            // 
            // lb_Color_R
            // 
            resources.ApplyResources(this.lb_Color_R, "lb_Color_R");
            this.lb_Color_R.Name = "lb_Color_R";
            // 
            // lb_Red
            // 
            resources.ApplyResources(this.lb_Red, "lb_Red");
            this.lb_Red.Name = "lb_Red";
            // 
            // lb_Color_B
            // 
            resources.ApplyResources(this.lb_Color_B, "lb_Color_B");
            this.lb_Color_B.Name = "lb_Color_B";
            // 
            // lb_Blue
            // 
            resources.ApplyResources(this.lb_Blue, "lb_Blue");
            this.lb_Blue.Name = "lb_Blue";
            // 
            // lb_Color_Y
            // 
            resources.ApplyResources(this.lb_Color_Y, "lb_Color_Y");
            this.lb_Color_Y.Name = "lb_Color_Y";
            // 
            // lb_Yellow
            // 
            resources.ApplyResources(this.lb_Yellow, "lb_Yellow");
            this.lb_Yellow.Name = "lb_Yellow";
            // 
            // gb_Buttons
            // 
            this.gb_Buttons.Controls.Add(this.label1);
            this.gb_Buttons.Controls.Add(this.btn_Start);
            this.gb_Buttons.Controls.Add(this.btn_LoadConfig);
            resources.ApplyResources(this.gb_Buttons, "gb_Buttons");
            this.gb_Buttons.Name = "gb_Buttons";
            this.gb_Buttons.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btn_Start
            // 
            resources.ApplyResources(this.btn_Start, "btn_Start");
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_LoadConfig
            // 
            resources.ApplyResources(this.btn_LoadConfig, "btn_LoadConfig");
            this.btn_LoadConfig.Name = "btn_LoadConfig";
            this.btn_LoadConfig.UseVisualStyleBackColor = true;
            this.btn_LoadConfig.Click += new System.EventHandler(this.btn_LoadConfig_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Buttons);
            this.Controls.Add(this.gb_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
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
        private System.Windows.Forms.TextBox tb_getCardTimeOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_Color_R;
        private System.Windows.Forms.Label lb_Color_B;
        private System.Windows.Forms.Label lb_Color_Y;
    }
}