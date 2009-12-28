using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.datamodel;
using SisComWpf.controller.info;

namespace SisComWpf.view.register.info {
    public class SizeInfo : List<produto_tamanho>, IViewInfoField {

        ICtrlInfoField ctrl;

        public SizeInfo() {
            ctrl = new CtrlInfoSize(this);
            ctrl.GetInfoFields();
        }

        #region IViewInfoField Members

        public void SetInfoFields(IQueryable info) {
            var list = info.OfType<produto_tamanho>().ToList();
            foreach (var item in list) {
                this.Add(item);
            }
        }

        #endregion
    }
}
