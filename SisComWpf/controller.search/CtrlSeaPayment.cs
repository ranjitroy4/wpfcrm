using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.bll.payment;
using SisComWpf.model.datamodel;
using SisComWpf.View.Register;
using SisComWpf.view.common;
using SisComWpf.Controller.Search;
using SisComWpf.View.Search;

namespace SisComWpf.controller.search {
    public class CtrlSeaPayment : DefaultCtrl, ICtrlSearch {

        private BllSeaPayment bll = new BllSeaPayment();

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
            get { return "Pesquisar Formas de Pagamento"; }
        }


        #endregion
    }
}