using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.datamodel;
using SisComWpf.controller.info;

namespace SisComWpf.view.register.info {
    public class CategoryInfo : List<produto_categoria>, IViewInfoField {
        
      ICtrlInfoField ctrl;

        public CategoryInfo() {
            ctrl = new CtrlInfoCategory(this);
            ctrl.GetInfoFields();
        }

        #region IViewInfoField Members

        public void SetInfoFields(IQueryable info) {
            var list = info.OfType<produto_categoria>().ToList();
            foreach (var item in list) {
                this.Add(item);
            }
        }

        #endregion
    }
}
