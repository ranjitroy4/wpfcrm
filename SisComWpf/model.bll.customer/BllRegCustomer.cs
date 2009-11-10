using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.datamodel;

namespace SisComWpf.Model.BllRegister {

    /// <summary>
    /// Contém toda a regra de negócio
    /// </summary>
    public class BllRegCustomer: DataModel {

        public BllRegCustomer() {
        }

        public void Save(cliente clie) {
            // Aqui devem vir as validações antes de salvar um cliente!
            if (clie.cli_id == 0)
                Insert(clie);
            else
                Update(clie);
            dataModel.SaveChanges();
        }

        public void Delete(cliente dataObject) {
            // Aqui devem vir as validações antes de excluir um cliente!
            dataModel.DeleteObject(dataObject);
        }

        private void Insert(cliente c) {
            dataModel.AddTocliente(c);
        }

        private void Update(cliente c) {
            var dataObject = dataModel.cliente.First(p => p.cli_id == c.cli_id);
            dataObject.cli_nome = c.cli_nome;
            dataObject.cli_endereco = c.cli_endereco;
        }
    }
}
