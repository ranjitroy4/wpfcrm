using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.model.bll.product {
    public class BllRegProduct : DataModel {

        public BllRegProduct() {
        }

        public void Save(produto prod) {
            // Aqui devem vir as validações antes de salvar um cliente!
            if (prod.prod_id == 0)
                Insert(prod);
            else
                Update(prod);
            dataModel.SaveChanges();
        }

        public void Delete(produto dataObject) {
            // Aqui devem vir as validações antes de excluir um cliente!
            dataModel.DeleteObject(dataObject);
        }

        private void Insert(produto c) {
            dataModel.AddToproduto(c);
        }

        private void Update(produto c) {
            var dataObject = dataModel.produto.First(p => p.prod_id == c.prod_id);
            dataObject.prod_codigo = c.prod_codigo;
            dataObject.prod_descricao = c.prod_descricao;
            dataObject.produto_categoria = c.produto_categoria;
            dataObject.fornecedor = c.fornecedor;
        }
    }
}
