using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.model.datamodel;

namespace SisComWpf.model.bll.sell {
    public class BllSell : DataModel {

        private List<venda_item> items = new List<venda_item>();

        public List<venda_item> Items {
            get { return items; }
        }

        public BllSell() {
        }



    }
}
