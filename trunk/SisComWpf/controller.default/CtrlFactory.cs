﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Register;
using SisComWpf.View.Search;
using SisComWpf.Controller.Search;
using SisComWpf.Model;
using System.Windows.Controls;
using SisComWpf.model.datamodel;
using SisComWpf.view.register;
using SisComWpf.controller.register;
using SisComWpf.controller.search;

namespace SisComWpf.Controller {

    public class CtrlFactory {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userControl"></param>
        /// <returns></returns>
        public static IDefaultCtrl BuildControllerByUC(UserControl userControl) {
            IDefaultCtrl iCtrl;
            Type type = userControl.GetType();
            if (type.Equals(typeof(RegisterScreen)))
                iCtrl = BuildRegisterControl((IViewRegister)userControl);
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
            else if (type.Equals(typeof(fornecedor)))
                iCtrl = new CtrlRegSupplier();
            else if (type.Equals(typeof(vendedor)))
                iCtrl = new CtrlRegSeller();
            else if (type.Equals(typeof(produto_categoria)))
                iCtrl = new CtrlRegCategory();
            else if (type.Equals(typeof(produto)))
                iCtrl = new CtrlRegProduct();
            else
                throw new NotImplementedException();

            return iCtrl;
        }

        private static IDefaultCtrl BuildRegisterControl(IViewRegister registerScreen) {
            IDefaultCtrl iCtrl;
            switch (registerScreen.RegisterFor) {
                case RegisterType.Customers:
                    iCtrl = new CtrlRegCustomer();
                    break;
                case RegisterType.Suppliers:
                    iCtrl = new CtrlRegSupplier();
                    break;
                case RegisterType.Sellers:
                    iCtrl = new CtrlRegSeller();
                    break;
                case RegisterType.Categorys:
                    iCtrl = new CtrlRegCategory();
                    break;
                case RegisterType.Products:
                    iCtrl = new CtrlRegProduct();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return iCtrl;
        }

        private static IDefaultCtrl BuildSearchControl(IViewSearch searchScreen) {
            IDefaultCtrl iCtrl;
            switch (searchScreen.SearchFor) {
                case SearchType.Customers:
                    iCtrl = new CtrlSeaCustomer();
                    break;
                case SearchType.Suppliers:
                    iCtrl = new CtrlSeaSupplier();
                    break;
                case SearchType.Sellers:
                    iCtrl = new CtrlSeaSeller();
                    break;
                case SearchType.Categorys:
                    iCtrl = new CtrlSeaCategory();
                    break;
                case SearchType.Products:
                    iCtrl = new CtrlSeaProduct();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return iCtrl;
        }
    }
}