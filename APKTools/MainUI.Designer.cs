namespace AutoAPKTool
{
	partial class MainUI
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.open_path = new System.Windows.Forms.TextBox();
            this.btn_Decompiler = new System.Windows.Forms.Button();
            this.btn_SignAPK = new System.Windows.Forms.Button();
            this.btn_BuildAndSign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dex2jar = new System.Windows.Forms.Button();
            this.btn_JdGUI = new System.Windows.Forms.Button();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.btn_jadx = new System.Windows.Forms.Button();
            this.btn_decompileDex = new System.Windows.Forms.Button();
            this.btn_compileDex = new System.Windows.Forms.Button();
            this.btn_env = new System.Windows.Forms.Button();
            this.dec_odex = new System.Windows.Forms.Button();
            this.getArgs = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.打开OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jadxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jdguiItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arm转机器码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.生成签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.签名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.menu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // open_path
            // 
            this.open_path.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.open_path.Location = new System.Drawing.Point(56, 36);
            this.open_path.Margin = new System.Windows.Forms.Padding(6);
            this.open_path.Name = "open_path";
            this.open_path.ReadOnly = true;
            this.open_path.Size = new System.Drawing.Size(347, 26);
            this.open_path.TabIndex = 0;
            // 
            // btn_Decompiler
            // 
            this.btn_Decompiler.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Decompiler.Location = new System.Drawing.Point(18, 74);
            this.btn_Decompiler.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Decompiler.Name = "btn_Decompiler";
            this.btn_Decompiler.Size = new System.Drawing.Size(95, 33);
            this.btn_Decompiler.TabIndex = 1;
            this.btn_Decompiler.Text = "反编译apk";
            this.btn_Decompiler.UseVisualStyleBackColor = true;
            this.btn_Decompiler.Click += new System.EventHandler(this.btn_Decompiler_Click);
            // 
            // btn_SignAPK
            // 
            this.btn_SignAPK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SignAPK.Location = new System.Drawing.Point(321, 74);
            this.btn_SignAPK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_SignAPK.Name = "btn_SignAPK";
            this.btn_SignAPK.Size = new System.Drawing.Size(160, 33);
            this.btn_SignAPK.TabIndex = 3;
            this.btn_SignAPK.Text = "直接选择apk签名";
            this.btn_SignAPK.UseVisualStyleBackColor = true;
            this.btn_SignAPK.Click += new System.EventHandler(this.btn_SignAPK_Click);
            // 
            // btn_BuildAndSign
            // 
            this.btn_BuildAndSign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_BuildAndSign.Location = new System.Drawing.Point(140, 74);
            this.btn_BuildAndSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_BuildAndSign.Name = "btn_BuildAndSign";
            this.btn_BuildAndSign.Size = new System.Drawing.Size(166, 33);
            this.btn_BuildAndSign.TabIndex = 4;
            this.btn_BuildAndSign.Text = "回编译apk并签名";
            this.btn_BuildAndSign.UseVisualStyleBackColor = true;
            this.btn_BuildAndSign.Click += new System.EventHandler(this.btn_BuildAndSign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "路径:\r\n";
            // 
            // btn_dex2jar
            // 
            this.btn_dex2jar.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_dex2jar.Location = new System.Drawing.Point(18, 118);
            this.btn_dex2jar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_dex2jar.Name = "btn_dex2jar";
            this.btn_dex2jar.Size = new System.Drawing.Size(95, 33);
            this.btn_dex2jar.TabIndex = 6;
            this.btn_dex2jar.Text = "dex转jar";
            this.btn_dex2jar.UseVisualStyleBackColor = true;
            this.btn_dex2jar.Click += new System.EventHandler(this.btn_dex2jar_Click);
            // 
            // btn_JdGUI
            // 
            this.btn_JdGUI.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_JdGUI.Location = new System.Drawing.Point(140, 118);
            this.btn_JdGUI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_JdGUI.Name = "btn_JdGUI";
            this.btn_JdGUI.Size = new System.Drawing.Size(95, 33);
            this.btn_JdGUI.TabIndex = 7;
            this.btn_JdGUI.Text = "打开jar";
            this.btn_JdGUI.UseVisualStyleBackColor = true;
            this.btn_JdGUI.Click += new System.EventHandler(this.btn_JdGUI_Click);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openFile.Location = new System.Drawing.Point(412, 34);
            this.btn_openFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(69, 30);
            this.btn_openFile.TabIndex = 9;
            this.btn_openFile.Text = "打开";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // Log
            // 
            this.Log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Log.Location = new System.Drawing.Point(18, 201);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(463, 235);
            this.Log.TabIndex = 11;
            // 
            // btn_jadx
            // 
            this.btn_jadx.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_jadx.Location = new System.Drawing.Point(264, 118);
            this.btn_jadx.Name = "btn_jadx";
            this.btn_jadx.Size = new System.Drawing.Size(95, 33);
            this.btn_jadx.TabIndex = 12;
            this.btn_jadx.Text = "jar转dex";
            this.btn_jadx.UseVisualStyleBackColor = true;
            this.btn_jadx.Click += new System.EventHandler(this.Btn_jarToDexClick);
            // 
            // btn_decompileDex
            // 
            this.btn_decompileDex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_decompileDex.Location = new System.Drawing.Point(18, 162);
            this.btn_decompileDex.Name = "btn_decompileDex";
            this.btn_decompileDex.Size = new System.Drawing.Size(95, 33);
            this.btn_decompileDex.TabIndex = 13;
            this.btn_decompileDex.Text = "反编译dex";
            this.btn_decompileDex.UseVisualStyleBackColor = true;
            this.btn_decompileDex.Click += new System.EventHandler(this.Btn_decompileDexClick);
            // 
            // btn_compileDex
            // 
            this.btn_compileDex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_compileDex.Location = new System.Drawing.Point(140, 162);
            this.btn_compileDex.Name = "btn_compileDex";
            this.btn_compileDex.Size = new System.Drawing.Size(95, 33);
            this.btn_compileDex.TabIndex = 14;
            this.btn_compileDex.Text = "回编译dex";
            this.btn_compileDex.UseVisualStyleBackColor = true;
            this.btn_compileDex.Click += new System.EventHandler(this.Btn_compileDexClick);
            // 
            // btn_env
            // 
            this.btn_env.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_env.Location = new System.Drawing.Point(264, 162);
            this.btn_env.Name = "btn_env";
            this.btn_env.Size = new System.Drawing.Size(95, 33);
            this.btn_env.TabIndex = 15;
            this.btn_env.Text = "查壳";
            this.btn_env.UseVisualStyleBackColor = true;
            this.btn_env.Click += new System.EventHandler(this.Btn_CheckProtect);
            // 
            // dec_odex
            // 
            this.dec_odex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dec_odex.Location = new System.Drawing.Point(386, 118);
            this.dec_odex.Name = "dec_odex";
            this.dec_odex.Size = new System.Drawing.Size(95, 33);
            this.dec_odex.TabIndex = 17;
            this.dec_odex.Text = "odex反编译";
            this.dec_odex.UseVisualStyleBackColor = true;
            this.dec_odex.Click += new System.EventHandler(this.Btn_Dec_odex);
            // 
            // getArgs
            // 
            this.getArgs.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.getArgs.Location = new System.Drawing.Point(386, 162);
            this.getArgs.Name = "getArgs";
            this.getArgs.Size = new System.Drawing.Size(95, 33);
            this.getArgs.TabIndex = 18;
            this.getArgs.Text = "启动命令";
            this.getArgs.UseVisualStyleBackColor = true;
            this.getArgs.Click += new System.EventHandler(this.GetLauncher);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OpenToolStripMenuItem,
            this.arm转机器码ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.settingsItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(495, 25);
            this.menu.TabIndex = 19;
            this.menu.Text = "配置";
            // 
            // 打开OpenToolStripMenuItem
            // 
            this.打开OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jadxItem,
            this.jdguiItem});
            this.打开OpenToolStripMenuItem.Name = "打开OpenToolStripMenuItem";
            this.打开OpenToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.打开OpenToolStripMenuItem.Text = "打开（&Open)";
            // 
            // jadxItem
            // 
            this.jadxItem.Name = "jadxItem";
            this.jadxItem.Size = new System.Drawing.Size(107, 22);
            this.jadxItem.Text = "Jadx";
            this.jadxItem.Click += new System.EventHandler(this.openJadx_Click);
            // 
            // jdguiItem
            // 
            this.jdguiItem.Name = "jdguiItem";
            this.jdguiItem.Size = new System.Drawing.Size(107, 22);
            this.jdguiItem.Text = "Jdgui";
            this.jdguiItem.Click += new System.EventHandler(this.openJdigui_Click);
            // 
            // arm转机器码ToolStripMenuItem
            // 
            this.arm转机器码ToolStripMenuItem.Name = "arm转机器码ToolStripMenuItem";
            this.arm转机器码ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.arm转机器码ToolStripMenuItem.Text = "Arm转机器码";
            this.arm转机器码ToolStripMenuItem.Click += new System.EventHandler(this.Btn_ArmToAsm_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // settingsItem
            // 
            this.settingsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.默认签名ToolStripMenuItem,
            this.自定义签名ToolStripMenuItem,
            this.toolStripSeparator1,
            this.生成签名ToolStripMenuItem,
            this.签名ToolStripMenuItem});
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.Size = new System.Drawing.Size(44, 21);
            this.settingsItem.Text = "签名";
            // 
            // 默认签名ToolStripMenuItem
            // 
            this.默认签名ToolStripMenuItem.Checked = true;
            this.默认签名ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.默认签名ToolStripMenuItem.Name = "默认签名ToolStripMenuItem";
            this.默认签名ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.默认签名ToolStripMenuItem.Text = "使用默认签名";
            this.默认签名ToolStripMenuItem.Click += new System.EventHandler(this.默认签名ToolStripMenuItem_Click);
            // 
            // 自定义签名ToolStripMenuItem
            // 
            this.自定义签名ToolStripMenuItem.Name = "自定义签名ToolStripMenuItem";
            this.自定义签名ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.自定义签名ToolStripMenuItem.Text = "使用自定义签名";
            this.自定义签名ToolStripMenuItem.Click += new System.EventHandler(this.自定义签名ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // 生成签名ToolStripMenuItem
            // 
            this.生成签名ToolStripMenuItem.Name = "生成签名ToolStripMenuItem";
            this.生成签名ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.生成签名ToolStripMenuItem.Text = "生成签名";
            // 
            // 签名ToolStripMenuItem
            // 
            this.签名ToolStripMenuItem.Name = "签名ToolStripMenuItem";
            this.签名ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.签名ToolStripMenuItem.Text = "签名设置";
            this.签名ToolStripMenuItem.Click += new System.EventHandler(this.签名ToolStripMenuItemClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel,
            this.pb});
            this.statusStrip.Location = new System.Drawing.Point(0, 445);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(495, 36);
            this.statusStrip.TabIndex = 20;
            // 
            // tsLabel
            // 
            this.tsLabel.AutoSize = false;
            this.tsLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Size = new System.Drawing.Size(160, 31);
            this.tsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb
            // 
            this.pb.AutoSize = false;
            this.pb.MarqueeAnimationSpeed = 200;
            this.pb.Maximum = 100000;
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(310, 30);
            this.pb.Step = 1;
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb.Tag = "";
            // 
            // MainUI
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 481);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.getArgs);
            this.Controls.Add(this.dec_odex);
            this.Controls.Add(this.btn_env);
            this.Controls.Add(this.btn_compileDex);
            this.Controls.Add(this.btn_decompileDex);
            this.Controls.Add(this.btn_jadx);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.btn_JdGUI);
            this.Controls.Add(this.btn_dex2jar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_BuildAndSign);
            this.Controls.Add(this.btn_SignAPK);
            this.Controls.Add(this.btn_Decompiler);
            this.Controls.Add(this.open_path);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apk反编译";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		private System.Windows.Forms.Button dec_odex;
		private System.Windows.Forms.Button getArgs;
		private System.Windows.Forms.TextBox open_path;
		private System.Windows.Forms.Button btn_Decompiler;
		private System.Windows.Forms.Button btn_SignAPK;
		private System.Windows.Forms.Button btn_BuildAndSign;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_dex2jar;
		private System.Windows.Forms.Button btn_JdGUI;
		private System.Windows.Forms.Button btn_openFile;
		private System.Windows.Forms.TextBox Log;
		private System.Windows.Forms.Button btn_jadx;
		private System.Windows.Forms.Button btn_decompileDex;
		private System.Windows.Forms.Button btn_compileDex;
		private System.Windows.Forms.Button btn_env;
		private System.Windows.Forms.MenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem settingsItem;
		private System.Windows.Forms.ToolStripMenuItem 签名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arm转机器码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jadxItem;
        private System.Windows.Forms.ToolStripMenuItem jdguiItem;
        private System.Windows.Forms.ToolStripMenuItem 生成签名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认签名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义签名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsLabel;
        private System.Windows.Forms.ToolStripProgressBar pb;
    }
}

