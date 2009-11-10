using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.view.common;
using SisComWpf.Controller;

namespace SisComWpf.View {
    public interface IDefaultView {

        IDefaultCtrl BusinessObject { get; set; }

        object DataObject { get; set; }

        void Update(String sMessage, WarningMsgType msgType);
    }
}