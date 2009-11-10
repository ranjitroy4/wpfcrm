using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.bll.seller;
using SisComWpf.model.datamodel;
using SisComWpf.View.Register;
using SisComWpf.view.common;

namespace SisComWpf.controller.register {
    public class CtrlRegSeller : DefaultCtrl, ICtrlRegister {

        BllRegSeller bll = new BllRegSeller();

        public CtrlRegSeller() {

        }

        #region ICtrlRegister Members

        public void Save(object p) {
            var dataObject = p as vendedor;

            try {
                bll.Save(dataObject);
                ((IViewRegister)View).Update("Vendedor salvo com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void Delete(object p) {
            var dataObject = p as vendedor;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Vendedor excluído com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public String ViewName {
            get { return "Cadastro de vendedores"; }
        }

        #endregion

        
    }
}