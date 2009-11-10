using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;

namespace SisComWpf.View.Register
{
    public enum RegisterType {
        Customers,
        Suppliers,
        Sellers,
        Categorys,
        Products
    }

    public interface IViewRegister : IDefaultView
    {
        void ClearFields();

        RegisterType RegisterFor { get; set; }
    }
}