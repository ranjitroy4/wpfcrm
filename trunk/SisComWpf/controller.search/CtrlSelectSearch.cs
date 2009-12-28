using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Search;
using System.Windows;

namespace SisComWpf.controller.search {

    /// <summary>
    /// 
    /// </summary>
    public class CtrlSelectSearch : ICtrlSearchAction {
        #region ICtrlSearchAction Members

        public void DoAction(IViewSearch iView) {
            ((Window)iView).Close();
        }

        #endregion
    }
}
