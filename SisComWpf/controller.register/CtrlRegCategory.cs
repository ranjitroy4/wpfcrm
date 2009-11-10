using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.bll.category;
using SisComWpf.model.datamodel;
using SisComWpf.View.Register;
using SisComWpf.view.common;

namespace SisComWpf.controller.register {
    public class CtrlRegCategory : DefaultCtrl, ICtrlRegister {

        BllRegCategory bll = new BllRegCategory();

        public CtrlRegCategory() {

        }

        #region ICtrlRegister Members

        public void Save(object p) {
            var dataObject = p as produto_categoria;

            try {
                bll.Save(dataObject);
                ((IViewRegister)View).Update("Categoria salvo com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void Delete(object p) {
            var dataObject = p as produto_categoria;

            try {
                bll.Delete(dataObject);
                ((IViewRegister)View).Update("Categoria excluído com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                ((IViewRegister)View).Update(ex.Message, WarningMsgType.Error);
            }
        }

        public String ViewName {
            get { return "Cadastro de categorias"; }
        }

        #endregion
        
    }
}