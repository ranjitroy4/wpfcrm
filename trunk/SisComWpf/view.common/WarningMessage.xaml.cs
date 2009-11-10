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

namespace SisComWpf.view.common {

    public enum WarningMsgType {
        Warning,
        Error
    }

    /// <summary>
    /// Interaction logic for WarningMessage.xaml
    /// </summary>
    public partial class WarningMessage : UserControl {
        public WarningMessage() {
            InitializeComponent();
        }

        public void Show(String sMessage, WarningMsgType type) {
            this.Visibility = Visibility.Visible;

            switch (type) {
                case WarningMsgType.Error:
                    break;
                default:
                    break;
            }

            lblMessage.Text = sMessage;
        }

        public void Hide() {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
