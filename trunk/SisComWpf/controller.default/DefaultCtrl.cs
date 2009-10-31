using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.View.Register;
using SisComWpf.View;

namespace SisComWpf.Controller
{
    public abstract class DefaultCtrl
    {
        private IDefaultView view;
        //protected ComercialEntities dataModel = new ComercialEntities();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DefaultCtrl()
        {

        }
   
        public IDefaultView View
        {
            get { return view; }
            set { view = value; }
        }
    }
}
