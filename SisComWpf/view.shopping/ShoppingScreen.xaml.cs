﻿using System;
using System.Windows;
using System.Windows.Controls;
using SisComWpf.controller.shopping;
using SisComWpf.Controller;
using SisComWpf.view.common;

namespace SisComWpf.view.shopping {
    /// <summary>
    /// Interaction logic for ShoppingScreen.xaml
    /// </summary>
    public partial class ShoppingScreen : UserControl, IViewShopping {

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

        #region IViewShopping Members

        public void Update() {
            dtgItems.Items.Refresh();
        }

        #endregion

        private void btnFind_Click(object sender, RoutedEventArgs e) {
            controller.FindProduct(txtInput.Text);
        }

        private void dtgItems_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e) {
            controller.UpdateListValues();
        }
    }
}