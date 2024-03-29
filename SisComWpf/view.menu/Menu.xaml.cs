﻿using System;
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

namespace SisComWpf.View.Menu
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Panel ControlPanel
        {
            get { return this.btnCliente.ControlParent; }
            set
            {
                this.btnCliente.ControlParent = value;
                this.btnFindCustomer.ControlParent = value;
                this.btnSupplier.ControlParent = value;
                this.btnFindSupplier.ControlParent = value;
                this.btnSeller.ControlParent = value;
                this.btnFindSeller.ControlParent = value;
                this.btnCategory.ControlParent = value;
                this.btnFindCategory.ControlParent = value;
                this.btnProduct.ControlParent = value;
                this.btnFindProduct.ControlParent = value;
                this.btnPayment.ControlParent = value;
                this.btnFindPayment.ControlParent = value;
                this.btnShopping.ControlParent = value;
                this.btnSell.ControlParent = value;
            }
        }

        public Menu()
        {
            InitializeComponent();
        }
    }
}
