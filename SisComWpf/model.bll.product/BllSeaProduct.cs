using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;

namespace SisComWpf.model.bll.product {
    public class BllSeaProduct : DataModel {
        private List<String> optionsToSearch = new List<string>();

        public List<String> GetOptionsToSearch() {
            optionsToSearch.Add("Descrição");
            optionsToSearch.Add("Id");

            return optionsToSearch;
        }

        public IQueryable DoSearch(string option, string value) {
            IQueryable found;

            // Listar todos os produtos
            if ((value.Equals(string.Empty)) && (option.Equals("Descrição"))) {
                found = (from p in dataModel.produto
                         select p);

            // Pesquisar produto por descrição
            } else if (option.Equals("Descrição")) {

                found = (from p in dataModel.produto
                         where p.prod_descricao.Contains(value)
                         select p);
            
            // Pesquisar produto por código do usuário (código de barras)
            } else if (option.Equals("Código")) {

                found = (from p in dataModel.produto
                         where p.prod_codigo.Equals(value)
                         select p);

            // Pesquisar por ID (sistema)
            } else {

                int iValue = Convert.ToInt32(value);
                found = (from p in dataModel.produto
                         where p.prod_id == iValue
                         select p);
            }

            return found;
        }
    }
}
