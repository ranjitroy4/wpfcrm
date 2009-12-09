using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;

namespace SisComWpf.model.bll.payment {
    public class BllSeaPayment: DataModel {
        private List<String> optionsToSearch = new List<string>();

        public List<String> GetOptionsToSearch() {
            optionsToSearch.Add("Descrição");
            optionsToSearch.Add("Id");

            return optionsToSearch;
        }

        public IQueryable DoSearch(string option, string value) {
            IQueryable found;

            if (value.Equals(string.Empty)) {
                found = (from p in dataModel.forma_pagamento
                         select p);

            } else if (option.Equals("Descrição")) {

                found = (from p in dataModel.forma_pagamento
                         where p.fopa_descricao.Contains(value)
                         select p);
            } else {

                int iValue = Convert.ToInt32(value);
                found = (from p in dataModel.forma_pagamento
                         where p.fopa_id == iValue
                         select p);
            }

            return found;
        }

    }
}
