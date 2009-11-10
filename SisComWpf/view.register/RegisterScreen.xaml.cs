using System;
using System.Windows;
using System.Windows.Controls;
using SisComWpf.Controller;
using SisComWpf.view.common;

namespace SisComWpf.View.Register {
    /// <summary>
    /// Interaction logic for CustomerRegister.xaml
    /// </summary>
    public partial class RegisterScreen : UserControl, IViewRegister {

        IViewRegister registerControls;
        RegisterType registerFor;

        public RegisterScreen() {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) {
                InitializeComponent();
                this.titleBar.CloseButton.Click += new RoutedEventHandler(btnClose_Click);
                this.toolbar.View = this;
            }
        }

        public string WindowTitle {
            set { this.titleBar.Title = value; }
            get { return this.titleBar.Title; }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            (this.Parent as Panel).Children.Remove(this);
        }

        #region IViewRegister Members

        public object DataObject {
            get { return this.registerControls.DataObject; }
            set { this.registerControls.DataObject = value; }
        }

        public void ClearFields() {
            warningMessage.Hide();
            this.registerControls.ClearFields();
        }

        public IDefaultCtrl BusinessObject {
            get { return registerControls.BusinessObject; }
            set {
                registerControls.BusinessObject = value;
                this.WindowTitle = value.ViewName;
            }
        }

        public void Update(String sMessage, WarningMsgType msgType) {
            warningMessage.Show(sMessage, SisComWpf.view.common.WarningMsgType.Error);
            this.registerControls.Update(sMessage, msgType);
        }

        public RegisterType RegisterFor {
            get { return this.registerFor; }
            set { this.registerFor = value; }
        }

        public IViewRegister UcRegister {
            get { return registerControls; }
            set {
                registerControls = value;
                stkFields.Children.Add(registerControls as UIElement);
            }
        }

        #endregion
    }
}