using System.Windows.Forms;

namespace MyDrawing.controls
{
    public partial class EditContentForm : Form
    {
        public string TextBoxContent
        {
            get { return textContent.Text; }
            set { textContent.Text = value; }
        }

        public EditContentForm(string originText)
        {
            InitializeComponent();
            InitButtons();
            this.textContent.Text = originText;
        }

        private void InitButtons()
        {
            btnConfirm.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
    }
}
