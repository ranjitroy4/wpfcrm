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
using SisComWpf.View.Register;
using SisComWpf.Controller;
using SisComWpf.View;
using SisComWpf.model.datamodel;

namespace SisComWpf.view.register {
    /// <summary>
    /// Interaction logic for PaymentFormRegister.xaml
    /// </summary>
    public partial class PaymentFormRegister : UserControl, IViewRegister {

        IDefaultCtrl controller;

        public PaymentFormRegister() {
            InitializeComponent();
        }

        #region IViewRegister Members

        public void ClearFields() {
            this.DataObject = new forma_pagamento();
            CommonView.ClearFields(this.stkFields);
        }

        #endregion

        #region IDefaultView Members

        public IDefaultCtrl BusinessObject {
            get { return this.controller; }
            set { this.controller = value; }
        }

        public object DataObject {
            get { return this.stkFields.DataContext; }
            set { this.stkFields.DataContext = value; }
        }

        public void Update(string sMessage, SisComWpf.view.common.WarningMsgType msgType) {
            // Campos que devem mudar de cor caso haja um erro ou etc...
        }

        public RegisterType RegisterFor {
            get { return ((IViewRegister)this.Parent).RegisterFor; }
            set {
                var parent = ((IViewRegister)this.Parent);
                parent.RegisterFor = value;
            }
        }

        #endregion
    }
}

