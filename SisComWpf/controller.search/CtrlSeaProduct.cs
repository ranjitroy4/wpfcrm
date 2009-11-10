using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.bll.product;
using SisComWpf.View.Search;
using SisComWpf.Controller;
using SisComWpf.Controller.Search;
using SisComWpf.view.common;

namespace SisComWpf.controller.search {
    public class CtrlSeaProduct : DefaultCtrl, ICtrlSearch {

        private BllSeaProduct bll = new BllSeaProduct();

        #region ICtrlSearch Members

        public void OptionsToSearch() {
            ((IViewSearch)View).SetSearchOptions(bll.GetOptionsToSearch());
        }

        public void DoSearch(string option, string value) {
            try {
                IQueryable found = bll.DoSearch(option, value);
                ((IViewSearch)View).GetSearchResult(found);
            } catch (Exception ex) {
                View.Update(ex.Message, WarningMsgType.Error);
            }
        }

        public String ViewName {
            get { return "Pesquisar Produtos"; }
        }


        #endregion
    }
}