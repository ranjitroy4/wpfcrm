using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;

namespace SisComWpf.model.bll.category {
    public class BllSeaCategory : DataModel {
        private List<String> optionsToSearch = new List<string>();

        public List<String> GetOptionsToSearch() {
            optionsToSearch.Add("Categoria");
            optionsToSearch.Add("Id");

            return optionsToSearch;
        }

        public IQueryable DoSearch(string option, string value) {
            IQueryable found;

            if (value.Equals(string.Empty)) {
                found = (from p in dataModel.produto_categoria
                         select p);
            }

            else if (option.Equals("Categoria")) {

                found = (from p in dataModel.produto_categoria
                         where p.prca_categoria.Contains(value)
                         select p);
            } else {

                int iValue = Convert.ToInt32(value);
                found = (from p in dataModel.produto_categoria
                         where p.prca_id == iValue
                         select p);
            }

            return found;
        }

    }
}
