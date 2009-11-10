using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SisComWpf.Controller;
using SisComWpf.model.datamodel;
using SisComWpf.View;
using SisComWpf.View.Register;

namespace SisComWpf.view.register {
    /// <summary>
    /// Interaction logic for CategoryRegister.xaml
    /// </summary>
    public partial class CategoryRegister : UserControl, IViewRegister {

        IDefaultCtrl controller;

        public CategoryRegister() {
            InitializeComponent();
        }

        #region IViewRegister Members

        public void ClearFields() {
            this.DataObject = new produto_categoria();
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