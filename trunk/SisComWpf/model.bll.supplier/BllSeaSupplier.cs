using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;

namespace SisComWpf.model.bll.supplier {
    public class BllSeaSupplier: DataModel {

        public BllSeaSupplier() {
        }

        private List<String> optionsToSearch = new List<string>();

        public List<String> GetOptionsToSearch() {
            optionsToSearch.Add("Nome");
            optionsToSearch.Add("Id");

            return optionsToSearch;
        }

        public IQueryable DoSearch(string option, string value) {
            IQueryable found;

            if (option.Equals(string.Empty)) {
                found = (from p in dataModel.fornecedor
                         select p);
            }

            else if (option.Equals("Nome")) {

                found = (from p in dataModel.fornecedor
                         where p.for_nome.Contains(value)
                         select p);
            } else {

                int iValue = Convert.ToInt32(value);
                found = (from p in dataModel.fornecedor
                         where p.for_id == iValue
                         select p);
            }

            return found;
        }

    }
}
