using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.datamodel;

namespace SisComWpf.controller.shopping {

    public interface ICtrlShopping : IDefaultCtrl {

        List<compra_item> GetShoppingItems();
        
        void AddProduct(produto prod);

        void UpdateListValues();

        void OpenShopping(compra buy);

        void SaveShopping();

        void NewShopping();

        void FindProduct(string sCode);

    }
}
