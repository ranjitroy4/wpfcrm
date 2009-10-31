using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisComWpf.Controller.Search {

    public interface ICtrlSearch : IDefaultCtrl {

        void OptionsToSearch();

        void DoSearch(String option, String value);
    }
}