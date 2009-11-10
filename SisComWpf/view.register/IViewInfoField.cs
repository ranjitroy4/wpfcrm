using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.View.Register;

namespace SisComWpf.view.register {
    public interface IViewInfoField {

        void SetInfoFields(IQueryable info);
    }
}
