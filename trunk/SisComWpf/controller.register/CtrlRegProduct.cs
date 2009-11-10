using System;
using System.Collections.Generic;
using System.Linq;
using SisComWpf.Controller;
using SisComWpf.model.bll.category;
using SisComWpf.model.bll.product;
using SisComWpf.model.bll.supplier;
using SisComWpf.model.datamodel;
using SisComWpf.view.common;
using SisComWpf.view.register;
using SisComWpf.View.Register;

namespace SisComWpf.controller.register {
    public class CtrlRegProduct :  DefaultCtrl, ICtrlRegister {

        BllRegProduct bll = new BllRegProduct();
       
        #region ICtrlRegister Members

        public void Save(object p) {
            var dataObject = p as produto;

            try {
                bll.Save(dataObject);
                ((IViewRegister)View).Update("Produto salvo com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void Delete(object p) {
            var dataObject = p as produto;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Produto excluído com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        #endregion

        #region IDefaultCtrl Members


        public string ViewName {
            get { return "Cadastro de produtos"; }
        }

        #endregion
    }
}
