using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.bll.supplier;
using SisComWpf.model.bll.category;
using SisComWpf.view.register;

namespace SisComWpf.controller.info {
    public class CtrlInfoCategory : ICtrlInfoField {

        IViewInfoField view;

        BllSeaCategory bll = new BllSeaCategory();

        public CtrlInfoCategory(IViewInfoField view) {
            this.view = view;
        }

        public IViewInfoField View {
            get { return view;  }
            set { view = value; }
        }

        public void GetInfoFields() {
            // Consulta
            var found = bll.DoSearch(string.Empty, string.Empty);
            View.SetInfoFields(found);
        }
    }
}