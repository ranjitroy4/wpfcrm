using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.model.bll.payment {
    public class BllRegPayment : DataModel {

        public BllRegPayment() {
        }

        public void Save(forma_pagamento fopa) {
            // Aqui devem vir as validações antes de salvar um cliente!
            if (fopa.fopa_id == 0)
                Insert(fopa);
            else
                Update(fopa);
            dataModel.SaveChanges();
        }

        public void Delete(forma_pagamento dataObject) {
            // Aqui devem vir as validações antes de excluir um cliente!
            dataModel.DeleteObject(dataObject);
        }

        private void Insert(forma_pagamento c) {
            dataModel.AddToforma_pagamento(c);
        }

        private void Update(forma_pagamento c) {
            var dataObject = dataModel.forma_pagamento.First(p => p.fopa_id == c.fopa_id);
            dataObject.fopa_descricao = c.fopa_descricao;
            dataObject.fopa_flag_acrescimo = c.fopa_flag_acrescimo;
            dataObject.fopa_porcentagem = c.fopa_porcentagem;
            dataObject.fopa_qtde_vezes = c.fopa_qtde_vezes;
        }
    }
}