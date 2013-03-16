using System.ComponentModel;
using System.Windows.Forms;

namespace SupplyChainManagementSystem
{
    public partial class Popup
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
                if (Content != null)
                {
                    Control _control = Content;
                    Content = null;
                    _control.Dispose();
                }
            }
        }


        private IContainer components = null;
        private void InitializeComponent()
        {
            components = new Container();
        }

    }
}