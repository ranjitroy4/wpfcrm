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
using SisComWpf.View;
using SisComWpf.view.common;
using SisComWpf.Controller;
using SisComWpf.Controller.Search;
using SisComWpf.controller.shopping;

namespace SisComWpf.view.shopping {
    /// <summary>
    /// Interaction logic for ShoppingScreen.xaml
    /// </summary>
    public partial class ShoppingScreen : UserControl, IDefaultView {

        private ICtrlShopping controller;
        private object dataObject;

        public ShoppingScreen() {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) {
                InitializeComponent();
                this.titleBar.CloseButton.Click += new RoutedEventHandler(btnClose_Click);
            }
        }

        public String WindowTitle {
            set { this.titleBar.Title = value; }
            get { return this.titleBar.Title; }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            (this.Parent as Panel).Children.Remove(this);
        }

        #region IDefaultView Members

        public IDefaultCtrl BusinessObject {
            get { return controller; }
            set {
                controller = (ICtrlShopping) value;
                this.WindowTitle = value.ViewName;
                this.dtgItems.ItemsSource = controller.GetShoppingItems();
            }
        }

        public object DataObject {
            get { return dataObject; }
            set { dataObject = value; }
        }

        public void Update(string sMessage, WarningMsgType msgType) {
            warningMessage.Show(sMessage, msgType);
        }

        #endregion

        private void btnFind_Click(object sender, RoutedEventArgs e) {

        }
    }
}