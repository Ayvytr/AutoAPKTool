using System.ComponentModel;

namespace AutoAPKTool
{
    partial class AskExecCommandAgainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btnSure = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(99, 75);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(100, 40);
            this.btnSure.TabIndex = 0;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 28);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 12);
            this.label.TabIndex = 1;
            this.label.Text = "修改命令";
            // 
            // tbCommand
            // 
            this.tbCommand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCommand.Location = new System.Drawing.Point(71, 23);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(352, 21);
            this.tbCommand.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(268, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AskExecCommandAgainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 162);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnSure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AskExecCommandAgainForm";
            this.Text = "执行命令失败，是否修改命令重新执行？";
            this.Load += new System.EventHandler(this.AskExecCommandAgainForm_Load);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.Button btnCancel;
    }
}