using System;
using System.Collections.Generic;
using System.Linq;
using SisComWpf.Controller;
using SisComWpf.model.bll.product;
using SisComWpf.model.bll.sell;
using SisComWpf.model.datamodel;
using SisComWpf.view.search;
using SisComWpf.view.sell;
using SisComWpf.View;
using SisComWpf.View.Search;

namespace SisComWpf.controller.sell {
    public class CtrlSell: DefaultCtrl, ICtrlSell {

        BllSell bllSell = new BllSell();
        BllSeaProduct bllProduct = new BllSeaProduct();

        #region ICtrlSell Members

        public string ViewName {
            get { return "Venda de Produtos"; }
        }

        /// <summary>
        /// Deve devolver uma View para que o usuário possa selecionar o cliente
        /// </summary>
        public void FindCustomer() {
            SearchWindow searchCustomer = CommonView.BuildSearchWindow(SearchType.Customers);
            searchCustomer.Closed += new EventHandler(searchCustomer_Closed);
            searchCustomer.ShowDialog();
        }

        private void searchCustomer_Closed(object sender, EventArgs e) {
            var obj = sender as SearchWindow;
            if (obj.DataObject != null) {
                ((venda)View.DataObject).cliente = obj.DataObject as cliente;
                ((IViewSell)View).Update();
            }
        }

        /// <summary>
        /// Deve devolver uma View para que o usuário possa selecionar o vendedor
        /// </summary>
        public void FindSeller() {
            SearchWindow searchSeller = CommonView.BuildSearchWindow(SearchType.Sellers);
            searchSeller.Closed += new EventHandler(searchSeller_Closed);
            searchSeller.ShowDialog();
        }

        private void searchSeller_Closed(object sender, EventArgs e) {
            var obj = sender as SearchWindow;
            if (obj.DataObject != null) {
                ((venda)View.DataObject).vendedor = obj.DataObject as vendedor;
                ((IViewSell)View).Update();
            }
        }

        /// <summary>
        /// Caso ache o produto com o código informado, inclui na lista;
        /// Senão devolve uma interface para o usuário procurar o produto;
        /// </summary>
        /// <param name="sCode"></param>
        public void FindProduct(string sCode) {
            var result = bllProduct.DoSearch("Código", sCode).OfType<produto>().ToList<produto>();
            if (result.Count > 0) {
                AddProduct(result[0]);
                ((IViewSell)View).Update();
            } else {
                SearchWindow searchProduct = CommonView.BuildSearchWindow(SearchType.Products);
                searchProduct.Closed += new EventHandler(searchProduct_Closed);
                searchProduct.ShowDialog();
            }
        }

        private void searchProduct_Closed(object sender, EventArgs e) {
            var obj = sender as SearchWindow;
            if (obj.DataObject != null) 
                AddProduct((produto)obj.DataObject);            
        }

        /// <summary>
        /// Adiciona um produto na lista de produtos à venda
        /// </summary>
        /// <param name="prod"></param>
        public void AddProduct(produto prod) {
            venda_item item = new venda_item();
            item.produto = prod;
            this.bllSell.Items.Add(item);
        }

        /// <summary>
        /// Atualiza os valores da lista de acordo com as regras de desconto
        /// </summary>
        public void UpdateListValues() {
            
        }

        /// <summary>
        /// Devolve para a interface a lista de produtos que estão sendo vendidos
        /// </summary>
        /// <returns></returns>
        public List<venda_item> GetSellingItems() {
            return this.bllSell.Items;
        }

        #endregion
    }
}