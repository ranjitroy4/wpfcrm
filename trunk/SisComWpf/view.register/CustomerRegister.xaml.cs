using System;
using System.Windows;
using System.Windows.Controls;
using SisComWpf.Controller;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.View.Register {
    /// <summary>
    /// Interaction logic for CustomerRegister.xaml
    /// </summary>
    public partial class CustomerRegister : UserControl, IViewRegister {
        
        //ICtrlRegister controller;
        IDefaultCtrl controller;

        public CustomerRegister() {
            InitializeComponent();
            this.toolbar.View = this;
        }

        #region IViewRegister Members

        public object DataObject {
            get { return this.stkFields.DataContext; }
            set { this.stkFields.DataContext = value; }
        }

        public void ClearFields() {
            this.DataObject = new cliente();
            this.Update(string.Empty);
            CommonView.ClearFields(this.stkFields);
        }

        public IDefaultCtrl BusinessObject {
            get { return controller; }
            set { controller = value; }
        }

        public void Update(String sMessage) {
            lblMessage.Text = sMessage;
        }

        #endregion

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
