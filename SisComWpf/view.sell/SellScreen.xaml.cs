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

namespace SisComWpf.view.sell {
    /// <summary>
    /// Interaction logic for SellScreen.xaml
    /// </summary>
    public partial class SellScreen : UserControl, IViewSell {
        public SellScreen() {
            InitializeComponent();
        }

        #region IViewSell Members

        public void Update() {
            throw new NotImplementedException();
        }

        #endregion

        #region IDefaultView Members

        public SisComWpf.Controller.IDefaultCtrl BusinessObject {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public object DataObject {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public void Update(string sMessage, SisComWpf.view.common.WarningMsgType msgType) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
