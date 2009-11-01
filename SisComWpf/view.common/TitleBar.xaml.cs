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

namespace SisComWpf.view {
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl {
        public TitleBar() {
            InitializeComponent();
        }

        public String Title { 
            get { return this.lblTitle.Text; } 
            set { this.lblTitle.Text = value; } 
        }

        public Button CloseButton { 
            get { return this.btnClose; } 
        }
    }
}
