using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.model.datamodel;

namespace SisComWpf.controller.sell {
    public interface ICtrlSell : IDefaultCtrl {

        List<venda_item> GetSellingItems();

        void FindCustomer();

        void FindSeller();

        void FindProduct(string sCode);

        void AddProduct(produto prod);

        void UpdateListValues();


    }
}
