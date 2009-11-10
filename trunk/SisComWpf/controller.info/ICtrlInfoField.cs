using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Controller;
using SisComWpf.view.register;

namespace SisComWpf.controller.info {
    public interface ICtrlInfoField {

        IViewInfoField View { get; set; }

        void GetInfoFields();

    }
}
