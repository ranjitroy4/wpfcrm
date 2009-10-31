using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.Model;
using SisComWpf.View.Register;
using SisComWpf.model.datamodel;

namespace SisComWpf.View {
    public class ViewFactory {

        public static IDefaultView BuildViewByEntitie(Type type) {
            IDefaultView iView;
            if (type.Equals(typeof(cliente)))
                iView = new CustomerRegister();
            else
                throw new NotImplementedException();

            return iView;
        }
    }
}
