using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.bll.supplier;
using SisComWpf.model.datamodel;
using SisComWpf.View.Register;
using SisComWpf.view.common;

namespace SisComWpf.controller.register {
    public class CtrlRegSupplier :  DefaultCtrl, ICtrlRegister {

        BllRegSupplier bll = new BllRegSupplier();

        public CtrlRegSupplier() {

        }

        #region ICtrlRegister Members

        public void Save(object p) {
            var dataObject = p as fornecedor;

            try {
                bll.Save(dataObject);
                ((IViewRegister)View).Update("Fornecedor salvo com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void Delete(object p) {
            var dataObject = p as fornecedor;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Fornecedor excluído com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public String ViewName {
            get { return "Cadastro de fornecedores"; }
        }

        #endregion

        
    }
}