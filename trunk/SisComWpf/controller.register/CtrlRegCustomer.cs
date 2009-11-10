using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Register;
using SisComWpf.Model;
using SisComWpf.Model.BllRegister;
using SisComWpf.model.datamodel;
using SisComWpf.view.common;

namespace SisComWpf.Controller {

    public class CtrlRegCustomer : DefaultCtrl, ICtrlRegister {

        BllRegCustomer bll = new BllRegCustomer();

        public CtrlRegCustomer() {

        }

        #region ICtrlRegister Members

        public void Save(object p) {
            var dataObject = p as cliente;

            try {
                bll.Save(dataObject);
                ((IViewRegister)View).Update("Cliente salvo com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void Delete(object p) {
            var dataObject = p as cliente;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Cliente excluído com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public String ViewName {
            get { return "Cadastro de clientes"; }
        }

        #endregion

        
    }
}