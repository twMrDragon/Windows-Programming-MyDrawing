using MyDrawing.presentationModel;
using System.Windows.Forms;

namespace MyDrawing.controls
{
    public partial class ModifyContentForm : Form
    {
        private PresentationModel presentationModel;

        public ModifyContentForm(PresentationModel presentationModel)
        {
            this.presentationModel = presentationModel;
            InitializeComponent();
            InitButtons();
            InitTextBox();
        }

        private void InitTextBox()
        {
            this.textContent.TextChanged += (s, e) =>
            {
                presentationModel.NewContent = this.textContent.Text;
            };
            this.textContent.Text = presentationModel.OriginalContent;
        }

        private void InitButtons()
        {
            btnConfirm.DataBindings.Add("Enabled", presentationModel, nameof(presentationModel.IsModifyContentConfirmButtonEnable));
            btnConfirm.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
    }
}
