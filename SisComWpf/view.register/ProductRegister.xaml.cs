using System.Windows.Controls;
using SisComWpf.Controller;
using SisComWpf.model.datamodel;
using SisComWpf.View;
using SisComWpf.View.Register;

namespace SisComWpf.view.register {
    /// <summary>
    /// Interaction logic for ProductRegister.xaml
    /// </summary>
    public partial class ProductRegister : UserControl, IViewRegister {

        IDefaultCtrl controller;

        public ProductRegister() {
            InitializeComponent();
        }

        #region IViewRegister Members

        public void ClearFields() {
            this.DataObject = new produto();
            CommonView.ClearFields(this.stkFields);
        }

        public SisComWpf.View.Register.RegisterType RegisterFor {
            get { return ((IViewRegister)this.Parent).RegisterFor; }
            set { var parent = ((IViewRegister)this.Parent); 
                  parent.RegisterFor = value;
            }
        }

        #endregion

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
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

        #endregion
    }
}
