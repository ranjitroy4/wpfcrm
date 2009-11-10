using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.datamodel;
using SisComWpf.View.Search;
using SisComWpf.Controller.Search;
using SisComWpf.controller.search;
using SisComWpf.controller.info;

namespace SisComWpf.view.register.info {
    public class SupplierInfo : List<fornecedor>, IViewInfoField {

        ICtrlInfoField ctrl;

        public SupplierInfo() {
            ctrl = new CtrlSupplierInfo(this);
            ctrl.GetInfoFields();
        }

        #region IViewInfoField Members

        public void SetInfoFields(IQueryable info) {
            var list = info.OfType<fornecedor>().ToList();
            foreach (var item in list) {
                this.Add(item);
            }
        }

        #endregion
    }
}
