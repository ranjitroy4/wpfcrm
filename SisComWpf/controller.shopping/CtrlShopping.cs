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
using SisComWpf.view.search;
using SisComWpf.View.Search;
using System.Windows.Forms;
using SisComWpf.view.shopping;

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

        /// <summary>
        /// Este método deve fornecer uma View para que o usuário
        /// possa selecionar uma compra, e então a lista deve ser carregada baseada naqueles itens
        /// </summary>
        /// <param name="buy"></param>
        public void OpenShopping(compra buy) {
            this.bllShopping.SearchShopping(buy);
        }

        public void SaveShopping() {
            try {
                this.bllShopping.SaveShopping(View.DataObject as compra);
                View.Update("Compra salva com sucesso!", WarningMsgType.Warning);
            } catch (Exception ex) {
                View.Update(ex.Message, WarningMsgType.Error);
            }
        }

        /// <summary>
        /// Limpa a lista e cria uma nova compra
        /// </summary>
        public void NewShopping() {
            this.bllShopping.NewShopping();
            ((IViewShopping)View).Update();
            View.DataObject = new compra();
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
                ((IViewShopping)View).Update();
            } else {
                SearchWindow searchWindow = CommonView.BuildSearchWindow(SearchType.Products);
                searchWindow.Closed += new EventHandler(searchWindow_Closed);
                searchWindow.ShowDialog();
            }
        }

        /// <summary>
        /// Quando a janela for fechada, caso o usuário tenha escolhido um valor, adiciona o produto à lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchWindow_Closed(object sender, EventArgs e) {
            var obj = sender as SearchWindow;
            if (obj.DataObject != null) {
                AddProduct((produto)obj.DataObject);
                ((IViewShopping)View).Update();
            }
        }

        #endregion
    }
}
