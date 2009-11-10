using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View;

namespace SisComWpf.Controller
{
    public interface IDefaultCtrl
    {
        IDefaultView View { get; set; }

        String ViewName { get; }
    }
}