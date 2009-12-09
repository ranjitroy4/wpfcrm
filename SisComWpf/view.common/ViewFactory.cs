using System;
using SisComWpf.View.Register;
using SisComWpf.model.datamodel;
using SisComWpf.view.register;
using System.Windows.Controls;
using SisComWpf.View.Search;

namespace SisComWpf.View {

    /// <summary>
    /// Responsável por fabricar UserControls da camada de visão
    /// </summary>
    public class ViewFactory {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDefaultView BuildViewByEntitie(Type type) {
            RegisterScreen iView = new RegisterScreen();
            if (type.Equals(typeof(cliente)))
                iView.UcRegister = new CustomerRegister();
            else if (type.Equals(typeof(fornecedor)))
                iView.UcRegister = new SupplierRegister();
            else if (type.Equals(typeof(produto_categoria)))
                iView.UcRegister = new CategoryRegister();
            else if (type.Equals(typeof(produto)))
                iView.UcRegister = new ProductRegister();
            else if (type.Equals(typeof(forma_pagamento)))
                iView.UcRegister = new PaymentFormRegister();

            else
                throw new NotImplementedException();

            return iView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iView"></param>
        /// <returns></returns>
        public static UserControl BuildUserContol(IDefaultView iView) {
            IDefaultView uc = null;

            Type type = iView.GetType();

            if (type.Equals(typeof(RegisterScreen)))
                uc = BuildRegisterScreen(iView);
            else // Search Screen
                uc = BuildSearchScreen(iView);

            return (UserControl)uc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iView"></param>
        /// <returns></returns>
        private static IDefaultView BuildRegisterScreen(IDefaultView iView) {
            var uc = new RegisterScreen();
            switch (((RegisterScreen)iView).RegisterFor) {
                case RegisterType.Customers:
                    ((RegisterScreen)uc).UcRegister = new CustomerRegister();
                    ((RegisterScreen)uc).RegisterFor = RegisterType.Customers;
                    break;
                case RegisterType.Suppliers:
                    ((RegisterScreen)uc).UcRegister = new SupplierRegister();
                    ((RegisterScreen)uc).RegisterFor = RegisterType.Suppliers;
                    break;
                case RegisterType.Sellers:
                    ((RegisterScreen)uc).UcRegister = new SellerRegister();
                    ((RegisterScreen)uc).RegisterFor = RegisterType.Sellers;
                    break;
                case RegisterType.Categorys:
                    ((RegisterScreen)uc).UcRegister = new CategoryRegister();
                    ((RegisterScreen)uc).RegisterFor = RegisterType.Categorys;
                    break;
                case RegisterType.Products:
                    ((RegisterScreen)uc).UcRegister = new ProductRegister();
                    ((RegisterScreen)uc).RegisterFor = RegisterType.Products;
                    break;
                case RegisterType.PaymentsForms:
                    ((RegisterScreen)uc).UcRegister = new PaymentFormRegister();
                    ((RegisterScreen)uc).RegisterFor = RegisterType.PaymentsForms;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return uc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iView"></param>
        /// <returns></returns>
        private static IDefaultView BuildSearchScreen(IDefaultView iView) {
            var uc = new EditSearch();
            switch (((EditSearch)iView).SearchFor) {
                case SearchType.Customers:
                    ((EditSearch)uc).SearchFor = SearchType.Customers;
                    break;
                case SearchType.Suppliers:
                    ((EditSearch)uc).SearchFor = SearchType.Suppliers;
                    break;
                case SearchType.Sellers:
                    ((EditSearch)uc).SearchFor = SearchType.Sellers;
                    break;
                case SearchType.Categorys:
                    ((EditSearch)uc).SearchFor = SearchType.Categorys;
                    break;
                case SearchType.Products:
                    ((EditSearch)uc).SearchFor = SearchType.Products;
                    break;
                case SearchType.PaymentsForms:
                    ((EditSearch)uc).SearchFor = SearchType.PaymentsForms;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return uc;
        }
    }
}
