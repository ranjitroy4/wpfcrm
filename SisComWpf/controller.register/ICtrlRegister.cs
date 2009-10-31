using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Register;

namespace SisComWpf.Controller {

    public interface ICtrlRegister : IDefaultCtrl {

        void Save(object p);

        void Delete(object p);
    }
}
