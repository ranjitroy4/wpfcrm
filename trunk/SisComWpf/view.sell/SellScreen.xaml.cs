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
using SisComWpf.controller.sell;
using SisComWpf.model.datamodel;

namespace SisComWpf.view.sell {
    /// <summary>
    /// Interaction logic for SellScreen.xaml
    /// </summary>
    public partial class SellScreen : UserControl, IViewSell {

        ICtrlSell controller;

        public SellScreen() {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)) {
                InitializeComponent();
                this.titleBar.CloseButton.Click += new RoutedEventHandler(btnClose_Click);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            (this.Parent as Panel).Children.Remove(this);
        }

        #region IViewSell Members

        public void Update() {
            this.lblCustomer.DataContext = ((venda)DataObject).cliente;
            this.lblSeller.DataContext = ((venda)DataObject).vendedor;
            this.dtgItems.Items.Refresh();
        }

        #endregion

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
            get {
                return controller;
            }
            set {
                controller = (ICtrlSell) value;
                this.dtgItems.ItemsSource = controller.GetSellingItems();
                this.titleBar.Title = controller.ViewName;
            }
        }

        public object DataObject {
            get { return grdSell.DataContext;  }
            set { grdSell.DataContext = value; }
        }

        public void Update(string sMessage, SisComWpf.view.common.WarningMsgType msgType) {
            warningMessage.Show(sMessage, msgType);
        }

        #endregion

        private void btnSelSeller_Click(object sender, RoutedEventArgs e) {
            controller.FindSeller();
        }

        private void btnSellCustomer_Click(object sender, RoutedEventArgs e) {
            controller.FindCustomer();
        }
    }
}
