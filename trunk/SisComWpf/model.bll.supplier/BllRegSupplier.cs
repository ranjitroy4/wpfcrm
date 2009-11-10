using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.model.bll.supplier {
    public class BllRegSupplier: DataModel {

        public BllRegSupplier() {
        }

        public void Save(fornecedor f) {
            // Aqui devem vir as validações antes de salvar um cliente!
            if (f.for_id == 0)
                Insert(f);
            else
                Update(f);
            dataModel.SaveChanges();
        }

        public void Delete(fornecedor dataObject) {
            // Aqui devem vir as validações antes de excluir um cliente!
            dataModel.DeleteObject(dataObject);
        }

        private void Insert(fornecedor c) {
            dataModel.AddTofornecedor(c);
        }

        private void Update(fornecedor c) {
            var dataObject = dataModel.cliente.First(p => p.cli_id == c.for_id);
            dataObject.cli_nome = c.for_nome;
            dataObject.cli_endereco = c.for_endereco;
        }
    }
}
