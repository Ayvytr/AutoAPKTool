using System.Threading;
using System.Windows.Forms;

namespace AutoAPKTool
{
    public partial class AskExecCommandAgainForm : Form
    {
        private readonly string _msg;
        private readonly object _args;
        private readonly ExecuteType _type;
        private readonly bool _isShowProgress;

        public AskExecCommandAgainForm()
        {
            InitializeComponent();
        }

        public AskExecCommandAgainForm(string msg, object args, ExecuteType type, bool isShowProgress)
        {
            _msg = msg;
            _args = args;
            _type = type;
            _isShowProgress = isShowProgress;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnSure_Click(object sender, System.EventArgs e)
        {
            var mainUi = (MainUI) this.Owner;
            mainUi.performExecute(_msg, tbCommand.Text, _type, _isShowProgress);
            Close();
        }

        private void AskExecCommandAgainForm_Load(object sender, System.EventArgs e)
        {
            tbCommand.Text = _args.ToString();
        }
    }
}