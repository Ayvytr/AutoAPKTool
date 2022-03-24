using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using AutoAPKTool.Properties;
using IniParser;

namespace AutoAPKTool
{
    /// <summary>
    /// Description of Form2.
    /// </summary>
    public partial class CertUI : Form
    {
        private readonly string jksFilePath;
        private readonly bool isReadIniJks;

        public CertUI()
        {
            InitializeComponent();
        }

        public CertUI(string jksFilePath, bool isReadIniJks)
        {
            this.jksFilePath = jksFilePath;
            this.isReadIniJks = isReadIniJks;
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        public void Sel_signClick(object sender, EventArgs e)
        {
            var op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                text_path.Text = op.FileName;
            }
        }

        private void Verify_keyClick(object sender, EventArgs e)
        {
            var ver = Util.verify_jks(text_path.Text, text_pass.Text, text_alis.Text, text_alis_pass.Text);
            new Thread(ExcuteJar).Start(ver);
        }


        // ExcuteJar
        public void ExcuteJar(object args)
        {
            var processStartInfo = new ProcessStartInfo("java.exe", args.ToString())
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            var msg = "";
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived +=
                    delegate(object s, DataReceivedEventArgs e)
                    {
                        Invoke(new Action(delegate { msg += e.Data + "\r\n"; }));
                    };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                process.Close();
            }

            //切主线程
            base.Invoke(new Action(delegate
            {
                if (!File.Exists(Constants.IniSettingsPath))
                {
                    var fileStream = File.Create(Constants.IniSettingsPath);
                    fileStream.Close();
                }

                var parser = new FileIniDataParser();
                var data = parser.ReadFile(Constants.IniSettingsPath);

                if (msg.Contains("验证成功"))
                {
                    var dialogResult = MessageBox.Show(
                        isReadIniJks ? Resources.custom_jks_correct : Resources.ask_save_custom_jks,
                        msg, isReadIniJks ? MessageBoxButtons.OK : MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (dialogResult == DialogResult.Yes && !isReadIniJks)
                    {
                        data[Constants.CustomJks]["path"] = text_path.Text;
                        data[Constants.CustomJks]["password"] = text_pass.Text;
                        data[Constants.CustomJks]["alias"] = text_alis.Text;
                        data[Constants.CustomJks]["alias_password"] = text_alis_pass.Text;

                        //不生效
                        // var mainUi = (MainUI)this.Owner;
                        // mainUi.checkCustomJks();

                        MessageBox.Show(Resources.save_succeed);

                        data[Constants.Config][Constants.SelectedCustomJks] = true.ToString();
                    }

                }
                else
                {
                    data["Config"][Constants.SelectedCustomJks] = false.ToString();

                    MessageBox.Show(msg, Resources.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                parser.WriteFile(Constants.IniSettingsPath, data);
            }));
        }

        private void CertUI_Load(object sender, EventArgs e)
        {
            if (isReadIniJks)
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile(Constants.IniSettingsPath);
                text_path.Text = data[Constants.CustomJks]["path"];
                text_pass.Text = data[Constants.CustomJks]["password"];
                text_alis.Text = data[Constants.CustomJks]["alias"];
                text_alis_pass.Text = data[Constants.CustomJks]["alias_password"];
                verify_key.PerformClick();
            }
            else
            {
                text_path.Text = jksFilePath;
            }
        }
    }
}