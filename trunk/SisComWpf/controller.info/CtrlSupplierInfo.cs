using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.bll.supplier;
using SisComWpf.view.register;

namespace SisComWpf.controller.info {
    public class CtrlSupplierInfo : ICtrlInfoField {

        IViewInfoField view;

        BllSeaSupplier bll = new BllSeaSupplier();

        public CtrlSupplierInfo(IViewInfoField view) {
            this.view = view;
        }

        #region ICtrlInfoField Members

        public IViewInfoField View {
            get { return view;  }
            set { view = value; }
        }

        public void GetInfoFields() {
            var found = bll.DoSearch(string.Empty, string.Empty);
            View.SetInfoFields(found);
        }

        #endregion
    }
}
