using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.datamodel;
using SisComWpf.Model;

namespace SisComWpf.model.bll.shopping {

    public class BllShopping : DataModel {

        private List<compra_item> items = new List<compra_item>();

        public BllShopping() {
        }

        public List<compra_item> GetItems {
            get { return items; }
        }

        /// <summary>
        /// Recalcula os valores da lista
        /// </summary>
        public void UpdateValues() {
            foreach (var item in items) {
                item.coit_valor_total = item.coit_qtde * item.coit_valor_unitario;
                item.coit_valor_venda = (item.coit_valor_unitario * item.coit_porc_ganho / 100) + item.coit_valor_unitario;
                item.coit_valor_total_venda = item.coit_qtde * item.coit_valor_venda;
            }
        }

        /// <summary>
        /// Cria uma nova compra e limpa a lista de itens
        /// </summary>
        public void NewShopping() {
            this.items.Clear();
        }

        /// <summary>
        /// Abre uma compra já realizada
        /// </summary>
        /// <param name="buy"></param>
        /// <returns></returns>
        public bool SearchShopping(compra buy) {
            bool bRet;

            var result = from p in dataModel.compra_item
                         where p.compra.com_id == buy.com_id
                         select p;

            if (result.Count() > 0) {
                items = result.ToList();
                bRet = true;
            } else
                bRet = false;

            return bRet;
        }

        /// <summary>
        /// Salva a compra com todos os itens
        /// </summary>
        /// <param name="_compra"></param>
        public void SaveShopping(compra _compra) {
            try {
                
                // Salva os itens na compra (Ainda não suporta Update!)
                foreach (var item in items) {
                    item.compra = _compra;
                    dataModel.AddTocompra_item(item);
                }

                // Salva a compra
                if (_compra.com_id == 0)
                    dataModel.AddTocompra(_compra);
 
                // Atualiza o Estoque
                UpdateStock();

                dataModel.SaveChanges();
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza a quantidade de itens no estoque
        /// </summary>
        private void UpdateStock() {
            foreach (var item in GetItems) {
                var product = (from p in dataModel.estoque
                               where p.prod_id == item.produto.prod_id
                               select p).First();

                product.est_qtde_estoque = product.est_qtde_estoque + item.coit_qtde;
                product.est_valor_total = product.est_qtde_estoque * item.coit_valor_unitario;
            }
        }
    }
}