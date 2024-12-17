using System.Windows.Forms;

namespace MyDrawing.controls
{
    public partial class ModifyContentForm : Form
    {
        private string originText;

        public string TextBoxContent
        {
            get { return textContent.Text; }
        }

        public ModifyContentForm(string originText)
        {
            this.originText = originText;
            InitializeComponent();
            InitButtons();
            InitTextBox();
        }

        private void InitTextBox()
        {
            this.textContent.TextChanged += (s, e) =>
            {
                this.btnConfirm.Enabled = textContent.Text != originText;
            };
            this.textContent.Text = originText;
        }

        private void InitButtons()
        {
            btnConfirm.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
    }
}
