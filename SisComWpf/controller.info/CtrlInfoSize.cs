using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.view.register;
using SisComWpf.model.bll.size;

namespace SisComWpf.controller.info {
    public class CtrlInfoSize : ICtrlInfoField {
        
        IViewInfoField view;

        BllSeaSize bll = new BllSeaSize();

        public CtrlInfoSize(IViewInfoField view) {
            this.view = view;
        }

        #region ICtrlInfoField Members

        public IViewInfoField View {
            get { return view; }
            set { view = value; }
        }

        public void GetInfoFields() {
            // Consulta
            var found = bll.DoSearch(string.Empty, string.Empty);
            View.SetInfoFields(found);
        }

        #endregion
    }
}
