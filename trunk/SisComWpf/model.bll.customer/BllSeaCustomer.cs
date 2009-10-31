using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisComWpf.Model.BllRegister {

    public class BllSeaCustomer: DataModel {
        private List<String> optionsToSearch = new List<string>();

        public List<String> GetOptionsToSearch() {
            optionsToSearch.Add("Nome");
            optionsToSearch.Add("Id");

            return optionsToSearch;
        }

        public IQueryable DoSearch(string option, string value) {
            IQueryable found;

            if (option.Equals("Nome")) {

                found = (from p in dataModel.cliente
                         where p.cli_nome.Contains(value)
                         select p);
            } else {

                int iValue = Convert.ToInt32(value);
                found = (from p in dataModel.cliente
                         where p.cli_id == iValue
                         select p);
            }

            return found;
        }

    }
}
