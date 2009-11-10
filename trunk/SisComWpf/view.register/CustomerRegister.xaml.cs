using System.Windows.Controls;
using SisComWpf.Controller;
using SisComWpf.model.datamodel;
using SisComWpf.View;
using SisComWpf.View.Register;

namespace SisComWpf.view.register {
    /// <summary>
    /// Interaction logic for CustomerRegister.xaml
    /// </summary>
    public partial class CustomerRegister : UserControl, IViewRegister {

        IDefaultCtrl controller;

        public CustomerRegister() {
            InitializeComponent();
        }

        #region IViewRegister Members

        public void ClearFields() {
            this.DataObject = new cliente();
            CommonView.ClearFields(this.stkFields);
        }

        #endregion

        #region IDefaultView Members

        public IDefaultCtrl BusinessObject {
            get { return this.controller; }
            set { this.controller = value; }
        }

        public object DataObject {
            get { return this.stkFields.DataContext; }
            set { this.stkFields.DataContext = value; }
        }

        public void Update(string sMessage, SisComWpf.view.common.WarningMsgType msgType) {
            // Campos que devem mudar de cor caso haja um erro ou etc...
        }

        public RegisterType RegisterFor {
            get { return ((IViewRegister)this.Parent).RegisterFor; }
            set {
                var parent = ((IViewRegister)this.Parent);
                parent.RegisterFor = value;
            }
        }

        #endregion
    }
}
