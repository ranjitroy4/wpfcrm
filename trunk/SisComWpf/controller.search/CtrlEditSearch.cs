using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Search;
using SisComWpf.View;
using System.Windows.Controls;

namespace SisComWpf.controller.search {

    /// <summary>
    /// Responsável por devolver uma View de registro de acordo com o tipo de Data Object
    /// </summary>
    public class CtrlEditSearch : ICtrlSearchAction {
        #region ICtrlSearchAction Members

        public void DoAction(IViewSearch viewSearch) {
            var iView = ViewFactory.BuildViewByEntitie(viewSearch.DataObject.GetType());
            iView.DataObject = viewSearch.DataObject;
            var uc = viewSearch as UserControl;
            CommonView.CreateViewObject((Panel)uc.Parent, iView, viewSearch.DataObject);
        }

        #endregion
    }
}
