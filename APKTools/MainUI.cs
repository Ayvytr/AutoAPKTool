﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using AutoAPKTool.Properties;
using IniParser;
using IniParser.Parser;
using Ionic.Zip;
using Microsoft.WindowsAPICodePack.Taskbar;
using Timer = System.Timers.Timer;

namespace AutoAPKTool
{
    public partial class MainUI : Form
    {
        private string _apkinfo = "";
        private string _alias = "";
        private string _password = "";
        private string _path = "";
        private string _alias_password = "";

        //任务栏进度：https://www.iteye.com/blog/wx1569585608-2501516
        private TaskbarManager windowsTaskbar = TaskbarManager.Instance;

        public MainUI()
        {
            InitializeComponent();
            StartUp();
        }

        private static void StartUp()
        {
            var currentProcess = Process.GetCurrentProcess();
            foreach (var item in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (item.Id == currentProcess.Id ||
                    !((item.StartTime - currentProcess.StartTime).TotalMilliseconds <= 0)) continue;
                item.Kill();
                item.WaitForExit();
                break;
            }
        }


        private void SetLogText(string info)
        {
            if (null == info)
            {
                return;
            }

            Log.AppendText(info);
            Log.AppendText("\r\n");
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }


        private int timerNum = 0;

        private Timer notifyTimer = new Timer();
        NotifyIcon ni = new NotifyIcon();


        private void Execute(string msg, object args, ExecuteType type = ExecuteType.JAVA, bool isShowProgress = true)
        {
            timerNum = 0;

            base.Invoke(new Action(delegate
            {
                Log.Clear();
                tsLabel.ForeColor = Color.Black;
                this.tsLabel.Text = msg;
                pb.Value = pb.Minimum;
                windowsTaskbar.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);
            }));

            var timer = new System.Timers.Timer();
            if (isShowProgress)
            {
                timer.Interval = 10;
                timer.Elapsed += TimerElapsed;
                timer.Start();
            }

            var sh = "";
            if (!string.IsNullOrEmpty(_apkinfo))
            {
                _apkinfo = "";
            }

            switch (type)
            {
                case ExecuteType.CMD:
                    sh = "cmd.exe";
                    break;
                case ExecuteType.JAVA:
                    sh = "java.exe";
                    break;
                default:
                    break;
            }

            var processStartInfo = new ProcessStartInfo(sh, args.ToString())
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            bool isSucceed = true;
            using (var process = new Process())
            {
                process.StartInfo = processStartInfo;
                if (isShowProgress)
                {
                    process.OutputDataReceived += delegate(object s, DataReceivedEventArgs e)
                    {
                        base.Invoke(new Action(delegate
                        {
                            _apkinfo += e.Data + "\n";
                            this.SetLogText(e.Data);
                        }));
                    };
                }

                process.ErrorDataReceived += delegate(object s, DataReceivedEventArgs e)
                {
                    base.Invoke(new Action(delegate { this.SetLogText(e.Data); }));
                    if (isSucceed)
                    {
                        isSucceed = e.Data == null;
                    }
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                if (isShowProgress)
                {
                    process.WaitForExit();
                }

                process.Close();
                process.Dispose();
            }

            if (isShowProgress)
            {
                timer.Stop();
            }


            base.Invoke(new Action(delegate
            {
                tsLabel.ForeColor = isSucceed ? Color.Green : Color.Red;
                tsLabel.Text = isSucceed ? Resources.succeed : Resources.failed;
                pb.Value = pb.Maximum;

                windowsTaskbar.SetProgressState(
                    isSucceed ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Error, this.Handle);
                windowsTaskbar.SetProgressValue(pb.Maximum, pb.Maximum);

                if (File.Exists("icon.ico"))
                {
                    ni.Icon = new Icon("icon.ico");
                    ni.BalloonTipTitle = "Message";
                    ni.BalloonTipIcon = isSucceed ? ToolTipIcon.Info : ToolTipIcon.Error;

                    ni.BalloonTipText = isSucceed ? Resources.execute_succeed : Resources.execute_failed;
                    ni.Visible = true;
                    ni.ShowBalloonTip(0);

                    notifyTimer.Start();
                    notifyTimer.Interval = 10000;
                    notifyTimer.Elapsed += NotifyIconClose;
                }

                TaskbarFlash.FlashWindowEx(Handle, TaskbarFlash.flashType.FLASHW_TIMERNOFG);

                /**
                 * 失败弹框时，如果不是进程被占用，弹框询问是否修改命令并重新执行
                 */
                if (!isSucceed && !Log.Text.Contains("另一个程序正在使用此文件，进程无法访问"))
                {
                    // MessageBox.Show(Resources.exec_command_failed)
                    new AskExecCommandAgainForm(msg, args, type, isShowProgress).Show(this);
                }
            }));
        }

        private void NotifyIconClose(object sender, ElapsedEventArgs e)
        {
            ni.Visible = false;
            notifyTimer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            timerNum += 10;
            if (timerNum <= 90000)
            {
                base.Invoke(new Action(delegate
                {
                    pb.Value = timerNum;
                    windowsTaskbar.SetProgressValue(timerNum, 100000, this.Handle);
                }));
            }
        }

        // button Click
        private void btn_Decompiler_Click(object sender, EventArgs e)
        {
            var inputApk = this.open_path.Text;
            if (Directory.Exists(inputApk))
            {
                if (MessageBox.Show(Resources.need_decompiles, Resources.info, MessageBoxButtons.OKCancel) !=
                    DialogResult.OK) return;
                var fileinfos = Directory.GetFiles(inputApk);
                var size = fileinfos.Length;
                var list = new List<string>();

                for (var i = 0; i < size; i++)
                {
                    if (Path.GetExtension(fileinfos[i]) == ".apk")
                    {
                        list.Add(fileinfos[i]);
                    }
                }

                var len = list.Count;
                if (len == 0)
                {
                    MessageBox.Show(Resources.no_find_apk, Resources.info);
                    return;
                }


                new Thread(() =>
                {
                    for (var k = 0; k < len; k++)
                    {
                        Execute(Resources.decompiling,
                            Util.GetDecompilerArg(list[k],
                                inputApk + "\\" + Path.GetFileNameWithoutExtension(list[k])));
                    }
                }).Start();
            }
            else if (!File.Exists(inputApk) || Path.GetExtension(inputApk) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = Resources.files,
                    InitialDirectory = Path.GetDirectoryName(inputApk),
                    FileName = Path.GetFileNameWithoutExtension(inputApk)
                };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                var outputFolderName = saveFileDialog.FileName.ToString();
                string args = Util.GetDecompilerArg(inputApk, outputFolderName);
                new Thread(() => { Execute(Resources.decompiling, args); }).Start();
            }
        }

        private void btn_SignAPK_Click(object sender, EventArgs e)
        {
            var apkName = this.open_path.Text;
            if (Directory.Exists(apkName))
            {
                if (MessageBox.Show(Resources.need_signs, Resources.info, MessageBoxButtons.OKCancel) !=
                    DialogResult.OK)
                    return;
                var args = Util.GetSignJksArg(apkName);
                new Thread(() => { Execute(Resources.signing, args); }).Start();
            }
            else if (!File.Exists(apkName) || Path.GetExtension(apkName) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
            }
            else
            {
                var cmd = Util.GetSignJksArg(apkName);
                if (File.Exists(Constants.IniSettingsPath) && 自定义签名ToolStripMenuItem.Checked)
                {
                    InitSign();

                    if (!File.Exists(Constants.IniSettingsPath))
                    {
                        MessageBox.Show(Resources.ini_settings_file_not_found, Resources.info);
                        return;
                    }

                    if (_path == null || _alias_password == null || _alias == null || _password == null)
                    {
                        MessageBox.Show(Resources.no_sign, Resources.info);
                        return;
                    }

                    cmd = Util.GetSignCustomJksArg(apkName, _path, _password);
                }

                new Thread(() => { Execute(Resources.signing, cmd); }).Start();
            }
        }

        private void btn_BuildAndSign_Click(object sender, EventArgs e)
        {
            var inputFolder = this.open_path.Text;
            if (!Directory.Exists(inputFolder))
            {
                MessageBox.Show(Resources.pls_confirm_decompile_package, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.apk_files,
                DefaultExt = "apk",
                InitialDirectory = Path.GetDirectoryName(inputFolder),
                FileName = Path.GetFileName(inputFolder) + "_Mod.apk",
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var fileName = saveFileDialog.FileName;
            var args1 = Util.GetBuildArg(inputFolder, fileName);
            var args2 = Util.GetSignJksArg(fileName);
            // Start
            new Thread(() =>
            {
                Execute(Resources.packaging, args1); // Build
                Execute(Resources.signing, args2); // Sign
            }).Start();
        }

        private void btn_dex2jar_Click(object sender, EventArgs e)
        {
            var inputDex = this.open_path.Text;
            if (!File.Exists(inputDex) || Path.GetExtension(inputDex) != ".dex")
            {
                MessageBox.Show(Resources.no_find_dex, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.jar_files,
                InitialDirectory = Path.GetDirectoryName(inputDex),
                FileName = Path.GetFileNameWithoutExtension(inputDex)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputJar = saveFileDialog.FileName.ToString();
            var dex2JarArg = Util.GetDex2JarArg(inputDex, outputJar);
            new Thread(() => { Execute(Resources.dex2jar_ing, dex2JarArg, ExecuteType.CMD); }).Start();
        }

        // Form Event
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop, false) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var fileInfo = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
            var filePath = string.Join("", fileInfo, 0, fileInfo.Length);

            open_path.Text = filePath;
        }


        private void btn_openFile_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog {Filter = Resources.support_file};
            if (op.ShowDialog() == DialogResult.OK)
            {
                open_path.Text = op.FileName;
            }
        }


        private void Btn_decompileDexClick(object sender, EventArgs e)
        {
            var inputDex = this.open_path.Text;
            if (!File.Exists(inputDex) || Path.GetExtension(inputDex) != ".dex")
            {
                MessageBox.Show(Resources.no_find_dex, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.files,
                InitialDirectory = Path.GetDirectoryName(inputDex),
                FileName = Path.GetFileNameWithoutExtension(inputDex)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputFolderName = saveFileDialog.FileName.ToString();
            var decompilerDex = Util.GetDecompilerDex(inputDex, outputFolderName);
            new Thread(() => { Execute(Resources.decompiling_dex, decompilerDex); }).Start();
        }

        private void Btn_compileDexClick(object sender, EventArgs e)
        {
            var folderName = this.open_path.Text;
            if (!Directory.Exists(folderName))
            {
                MessageBox.Show(Resources.no_find_smali_files, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.dex_files,
                DefaultExt = "dex",
                InitialDirectory = Path.GetDirectoryName(folderName),
                FileName = Path.GetFileNameWithoutExtension(folderName) + "_Mod.dex"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var fileName = saveFileDialog.FileName;
            var buildDex = Util.GetBuildDex(folderName, fileName);

            new Thread(() => { Execute(Resources.compiling_dex, buildDex); }).Start();
        }


        private void InitSign()
        {
            if (!File.Exists(Constants.IniSettingsPath))
            {
                return;
            }

            var parser = new FileIniDataParser();
            var data = parser.ReadFile(Constants.IniSettingsPath);
            _path = data[Constants.CustomJks]["path"];
            _password = data[Constants.CustomJks]["password"];
            _alias = data[Constants.CustomJks]["alias"];
            _alias_password = data[Constants.CustomJks]["alias_password"];
        }

        private void 签名ToolStripMenuItemClick(object sender, EventArgs e)
        {
            var f = new CertUI();
            f.Show();
        }


        public void SetText(string str)
        {
            if (str == null)
            {
                return;
            }

            if (this.InvokeRequired) // 获取一个值指示此次调用是否来自非UI线程
            {
                this.Invoke(new delegateSetLogText(SetText), str);
            }
            else
            {
                this.Log.Text = str;
            }
        }

        public delegate void delegateSetLogText(string str);

        private void GetString()
        {
            var sb = "";
            using (new StringReader(_apkinfo))
            {
                sb = sb + ("adb shell am start -D -n " + _apkinfo);
            }

            SetText(sb);
        }


        private void Btn_CheckProtect(object sender, EventArgs e)
        {
            var text = this.open_path.Text;

            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }

            //var cmd = Util.GetPackage(text);
            const string sel = @"classes.dex";

            new Thread(() =>
            {
                var zip = new ZipFile(text);
                var file = zip.SelectEntries(sel, @"\");

                if (file.Count <= 0) return;
                //这个文件存在！
                Stream decompressedStream = new MemoryStream();
                //解压文件 也可以直接使用上面的 file 来操作
                zip[sel].Extract(decompressedStream);
                decompressedStream.Position = 0;
                var reader = new StreamReader(decompressedStream);
                var dex = reader.ReadToEnd();
                MessageBox.Show(CheckProtect.checkProtect(dex), Resources.info);
            }).Start();
        }


        private void GetLauncher(object sender, EventArgs e)
        {
            var text = this.open_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".apk")
            {
                MessageBox.Show(Resources.no_find_apk, Resources.info);
                return;
            }

            var args = Util.GetPackageNew(text);
            new Thread(() =>
            {
                Execute(Resources.launching, args, ExecuteType.JAVA, false);
                GetString();
            }).Start();
        }

        private void Btn_Dec_odex(object sender, EventArgs e)
        {
            var text = this.open_path.Text;

            if (!Directory.Exists(Constants.OdexFramework))
            {
                MessageBox.Show(Resources.no_find_framework, Resources.info);
                return;
            }

            if (!File.Exists(text) || Path.GetExtension(text) != ".odex")
            {
                MessageBox.Show(Resources.no_find_odex, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.files,
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputFolderName = saveFileDialog.FileName.ToString();
            var decodex = Util.DecOdex(text, outputFolderName);

            new Thread(() => { Execute(Resources.odex_ing, decodex); }).Start();
        }

        private void Btn_ArmToAsm_Click(object sender, EventArgs e)
        {
            var f = new ArmForm();
            f.Show();
        }


        private void openJadx_Click(object sender, EventArgs e)
        {
            new Thread(() => { Execute(Resources.open + "Jadx", "/c " + Constants.Jadx, ExecuteType.CMD, false); })
                .Start();
        }

        private void openJdigui_Click(object sender, EventArgs e)
        {
            new Thread(() => { Execute(Resources.open + "JdGui", "-jar " + Constants.Jdgui, ExecuteType.JAVA, false); })
                .Start();
        }

        private void Btn_jarToDexClick(object sender, EventArgs e)
        {
            var text = this.open_path.Text;
            if (!File.Exists(text) || Path.GetExtension(text) != ".jar")
            {
                MessageBox.Show(Resources.no_find_jar, Resources.info);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = Resources.dex_files,
                InitialDirectory = Path.GetDirectoryName(text),
                FileName = Path.GetFileNameWithoutExtension(text)
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var outputJar = saveFileDialog.FileName;
            var jar2DexArg = Util.GetJar2DexArg(text, outputJar);
            new Thread(() => { Execute(Resources.jar2dex_ing, jar2DexArg, ExecuteType.CMD); }).Start();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            CheckSelectedCustomJks();

            //初始化界面和进度条
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.Normal, this.Handle);
            windowsTaskbar.SetProgressValue(0, 100000, this.Handle);
        }

        private void 默认签名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchSelectJksMenu(false);
        }


        private void 自定义签名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customJksExists = File.Exists(Constants.IniSettingsPath);
            if (customJksExists)
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile(Constants.IniSettingsPath);
                var path = data[Constants.CustomJks]["path"];
                customJksExists = path != String.Empty && File.Exists(path);
            }

            if (customJksExists)
            {
                var dialogResult = MessageBox.Show(Resources.ask_found_custom_jks, Resources.info,
                    MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    ShowCertDialog(null, true);
                }
                else if (dialogResult == DialogResult.No)
                {
                    SelectCustomJks();
                }
            }
            else
            {
                var dialogResult = MessageBox.Show(Resources.ask_custom_jks, Resources.info,
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SelectCustomJks();
                }
            }
        }

        private void SelectCustomJks()
        {
            var dialog = new OpenFileDialog() {Filter = Resources.support_jks};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ShowCertDialog(dialog.FileName, false);
            }
        }

        private void ShowCertDialog(string jksFilePath, bool isReadInJks)
        {
            var certUi = new CertUI(jksFilePath, isReadInJks);
            certUi.ShowDialog(this);

            CheckSelectedCustomJks();
        }

        private void CheckSelectedCustomJks()
        {
            var selectedCustomJks = false;
            if (File.Exists(Constants.IniSettingsPath))
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile(Constants.IniSettingsPath);
                var value = data[Constants.Config][Constants.SelectedCustomJks];
                selectedCustomJks = value != null && bool.Parse(value);
            }

            switchSelectJksMenu(selectedCustomJks);
        }

        private void switchSelectJksMenu(bool selectedCustomJks)
        {
            默认签名ToolStripMenuItem.Checked = !selectedCustomJks;
            自定义签名ToolStripMenuItem.Checked = selectedCustomJks;
        }

        public void performExecute(string msg, string args, ExecuteType type, bool isShowProgress)
        {
            new Thread(() => { Execute(msg, args, type, isShowProgress); }).Start();
        }


        //切到最顶部不起作用
        private void MainUi_GetFocus(object sender, EventArgs e)
        {
            var isTrue = TaskbarFlash.FlashWindowEx(Handle, TaskbarFlash.flashType.FLASHW_TIMERNOFG);
            if (isTrue == false)
            {
                //如果窗口未激活，那么就停止闪烁，高亮
                TaskbarFlash.FlashWindowEx(Handle, TaskbarFlash.flashType.FLASHW_STOP);
            }

            if (pb.Value == pb.Maximum)
            {
                windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
        }
    }
}