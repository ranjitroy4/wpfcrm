using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Register;
using SisComWpf.Model;
using SisComWpf.Model.BllRegister;
using SisComWpf.model.datamodel;

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
                ((IViewRegister)View).Update("Cliente salvo com sucesso!");
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message);
            }
        }

        public void Delete(object p) {
            var dataObject = p as cliente;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Cliente excluído com sucesso!");
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message);
            }
        }

        #endregion

        
    }
}