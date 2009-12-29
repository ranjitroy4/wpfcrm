using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;

namespace SisComWpf.controller.sell {
    public class CtrlSell: DefaultCtrl, ICtrlSell {

        #region IDefaultCtrl Members

        public string ViewName {
            get { return "Venda de Produtos"; }
        }

        #endregion
    }
}
