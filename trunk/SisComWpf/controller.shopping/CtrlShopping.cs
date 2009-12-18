using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.View;
using SisComWpf.model.bll.shopping;
using SisComWpf.model.datamodel;
using SisComWpf.view.common;
using SisComWpf.model.bll.product;

namespace SisComWpf.controller.shopping {
    public class CtrlShopping : DefaultCtrl, ICtrlShopping {

        BllShopping bllShopping = new BllShopping();
        BllSeaProduct bllProduct = new BllSeaProduct();

        public CtrlShopping() {
        }

        public string ViewName {
            get { return "Entrada de produtos"; }
        }

        #region ICtrlShopping Members

        public List<compra_item> GetShoppingItems() {
            return this.bllShopping.GetItems;
        }

        public void AddProduct(SisComWpf.model.datamodel.produto prod) {
            compra_item item = new compra_item();
            item.produto = prod;
            this.bllShopping.GetItems.Add(item);
        }

        public void UpdateListValues() {
            this.bllShopping.UpdateValues();
        }

        public void OpenShopping(compra buy) {
            this.bllShopping.SearchShopping(buy);
        }

        public void SaveShopping() {
            try {
                this.bllShopping.SaveShopping();
                View.Update("Compra salva com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                View.Update(ex.Message, WarningMsgType.Error);
            }
        }

        public void NewShopping() {
            this.bllShopping.NewShopping();
        }

        /// <summary>
        /// Caso ache o produto com o código informado, inclui na lista;
        /// Senão devolve uma interface para o usuário procurar o produto;
        /// </summary>
        /// <param name="sCode"></param>
        public void FindProduct(string sCode) {
            var result = bllProduct.DoSearch("", sCode);
            
        }

        #endregion
    }
}
