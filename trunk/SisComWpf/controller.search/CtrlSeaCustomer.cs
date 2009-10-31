using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.View.Search;
using SisComWpf.Model.BllRegister;

namespace SisComWpf.Controller.Search {
    public class CtrlSeaCustomer : DefaultCtrl, ICtrlSearch {

        private BllSeaCustomer bll = new BllSeaCustomer();

        #region ICtrlSearch Members

        public void OptionsToSearch() {
            ((IViewSearch)View).SetSearchOptions(bll.GetOptionsToSearch());
        }

        public void DoSearch(string option, string value) {
            try {
                IQueryable found = bll.DoSearch(option, value);
                ((IViewSearch)View).GetSearchResult(found);
            } catch (Exception ex) {
                View.Update(ex.Message);
            }
        }

        #endregion
    }
}