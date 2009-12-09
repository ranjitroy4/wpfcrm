using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.bll.payment;
using SisComWpf.model.datamodel;
using SisComWpf.View.Register;
using SisComWpf.view.common;

namespace SisComWpf.controller.register {
    public class CtrlRegPayment : DefaultCtrl, ICtrlRegister {
     
        BllRegPayment bll = new BllRegPayment();

        public CtrlRegPayment() {

        }

        #region ICtrlRegister Members

        public void Save(object p) {
            var dataObject = p as forma_pagamento;

            try {
                bll.Save(dataObject);
                ((IViewRegister)View).Update("Cliente salvo com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void Delete(object p) {
            var dataObject = p as forma_pagamento;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Forma de pagamento excluída com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public String ViewName {
            get { return "Formas de pagamento"; }
        }

        #endregion

        
    }
}