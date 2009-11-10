using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.model.bll.category {
    public class BllRegCategory : DataModel {

        public BllRegCategory() {
        }

        public void Save(produto_categoria cat) {
            // Aqui devem vir as validações antes de salvar um cliente!
            if (cat.prca_id == 0)
                Insert(cat);
            else
                Update(cat);
            dataModel.SaveChanges();
        }

        public void Delete(produto_categoria dataObject) {
            // Aqui devem vir as validações antes de excluir um cliente!
            dataModel.DeleteObject(dataObject);
        }

        private void Insert(produto_categoria c) {
            dataModel.AddToproduto_categoria(c);
        }

        private void Update(produto_categoria c) {
            var dataObject = dataModel.produto_categoria.First(p => p.prca_id == c.prca_id);
            dataObject.prca_categoria = c.prca_categoria;
        }
    }
}
