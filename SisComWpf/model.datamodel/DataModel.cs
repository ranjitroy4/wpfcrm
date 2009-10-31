using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SisComWpf.model.datamodel;

namespace SisComWpf.Model {
    
    /// <summary>
    /// Fornece acesso ao modelo de dados da aplicação
    /// </summary>
    public abstract class DataModel {
        protected ComercialEntities dataModel = new ComercialEntities();
    }
}
