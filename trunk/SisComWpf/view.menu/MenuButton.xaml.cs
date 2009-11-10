using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SisComWpf.Controller;
using SisComWpf.View.Register;

namespace SisComWpf.View.Menu {
    /// <summary>
    /// Interaction logic for MenuButton.xaml
    /// </summary>
    public partial class MenuButton : UserControl {
        
        private Panel panel;
        private UserControl userControl;
        
        public MenuButton() {
            InitializeComponent();
        }

        public ImageSource MenuButtonImage {
            get { return imgButton.Source; }
            set { this.imgButton.Source = value; }
        }

        public String MenuLabelText {
            get { return this.lblButton.Text; }
            set { this.lblButton.Text = value; }
        }

        public Panel ControlParent {
            get { return panel; }
            set { panel = value; }
        }

        public UserControl UserControlToShow {
            get { return userControl; }
            set { userControl = value; }
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e) {
            CommonView.CreateViewObject(panel, (IDefaultView)userControl);
        }
    }
}