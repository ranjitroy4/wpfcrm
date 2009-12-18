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

        public void UpdateValues() {
            foreach (var item in items) {
                item.coit_valor_total = item.coit_qtde * item.coit_valor_unitario;
                item.coit_valor_venda = (item.coit_valor_unitario * item.coit_porc_ganho) + item.coit_valor_unitario;
            }
        }

        public void NewShopping() {
            this.items.Clear();
        }

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

        public void SaveShopping() {
            try {
                foreach (var item in items) {
                    dataModel.AddTocompra_item(item);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

    }

}
