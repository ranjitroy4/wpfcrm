using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.model.bll.seller {
    public class BllRegSeller: DataModel {

         public void Save(vendedor vend) {
            // Aqui devem vir as validações antes de salvar um cliente!
            if (vend.ven_id == 0)
                Insert(vend);
            else
                Update(vend);
            dataModel.SaveChanges();
        }

        public void Delete(vendedor dataObject) {
            // Aqui devem vir as validações antes de excluir um cliente!
            dataModel.DeleteObject(dataObject);
        }

        private void Insert(vendedor c) {
            dataModel.AddTovendedor(c);
        }

        private void Update(vendedor c) {
            var dataObject = dataModel.vendedor.First(p => p.ven_id == c.ven_id);
            dataObject.ven_nome = c.ven_nome;
            dataObject.ven_cpf = c.ven_cpf;
        }
    
    }
}
