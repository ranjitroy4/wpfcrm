using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;

namespace SisComWpf.model.bll.size {
    public class BllSeaSize : DataModel {
        private List<String> optionsToSearch = new List<string>();

        public List<String> GetOptionsToSearch() {
            optionsToSearch.Add("Nome");
            optionsToSearch.Add("Id");

            return optionsToSearch;
        }

        public IQueryable DoSearch(string option, string value) {
            IQueryable found;

            if (value.Equals(string.Empty)) {
                found = (from p in dataModel.produto_tamanho
                         select p);
            }

            else if (option.Equals("Nome")) {

                found = (from p in dataModel.produto_tamanho
                         where p.prta_descricao.Contains(value)
                         select p);
            } else {

                int iValue = Convert.ToInt32(value);
                found = (from p in dataModel.produto_tamanho
                         where p.prta_id == iValue
                         select p);
            }

            return found;
        }

    }
}