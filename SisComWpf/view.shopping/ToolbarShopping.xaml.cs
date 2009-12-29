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
using SisComWpf.controller.shopping;
using SisComWpf.View;

namespace SisComWpf.view.shopping {
    /// <summary>
    /// Interaction logic for ToolbarShopping.xaml
    /// </summary>
    public partial class ToolbarShopping : UserControl {

        ICtrlShopping controller;

        public ICtrlShopping Controller {
            get { return controller; }
            set { controller = value; }
        }

        public ToolbarShopping() {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {
            var result = CommonView.YesNoMsgBox("Limpar os campos?");
            if (result == MessageBoxResult.Yes) controller.NewShopping();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e) {
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            var result = CommonView.YesNoMsgBox("Salvar entrada de dados?");
            if (result == MessageBoxResult.Yes) controller.SaveShopping();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e) {
            
        }
    }
}