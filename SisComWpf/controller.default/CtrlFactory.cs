using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Register;
using SisComWpf.View.Search;
using SisComWpf.Controller.Search;
using SisComWpf.Model;
using System.Windows.Controls;
using SisComWpf.model.datamodel;

namespace SisComWpf.Controller {

    public class CtrlFactory {

        public static IDefaultCtrl BuildControllerByUC(UserControl userControl) {
            IDefaultCtrl iCtrl;
            Type type = userControl.GetType();
            if (type.Equals(typeof(CustomerRegister)))
                iCtrl = new CtrlRegCustomer();
            else if (type.Equals(typeof(EditSearch)))
                iCtrl = BuildSearchControl((IViewSearch)userControl);
            else
                throw new NotImplementedException();

            return iCtrl;
        }

        public static IDefaultCtrl BuildRegControllerByDO(Type type) {
            IDefaultCtrl iCtrl;
            if (type.Equals(typeof(cliente)))
                iCtrl = new CtrlRegCustomer();
            else
                throw new NotImplementedException();

            return iCtrl;
        }

        private static IDefaultCtrl BuildSearchControl(IViewSearch searchScreen) {
            IDefaultCtrl iCtrl;
            switch (searchScreen.SearchFor) {
                case SearchType.Customers:
                    iCtrl = new CtrlSeaCustomer();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return iCtrl;
        }
    }
}