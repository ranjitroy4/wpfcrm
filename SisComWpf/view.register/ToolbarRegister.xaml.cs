using System.Windows;
using System.Windows.Controls;
using SisComWpf.Controller;

namespace SisComWpf.View.Register {
    /// <summary>
    /// Interaction logic for DefaultRegister.xaml
    /// </summary>
    public partial class ToolbarRegister : UserControl {

        private IViewRegister view;

        public IViewRegister View {
            get { return view; }
            set { view = value; }
        }

        public ToolbarRegister() {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {
            view.ClearFields();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            var controller = view.BusinessObject as ICtrlRegister;
            controller.Save(view.DataObject);
        }

        private void btnDel_Click(object sender, RoutedEventArgs e) {
            var controller = view.BusinessObject as ICtrlRegister;
            controller.Delete(view.DataObject);
        }
    }
}
