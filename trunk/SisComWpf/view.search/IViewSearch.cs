using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisComWpf.View.Search {

    public enum SearchType {
        Customers
    }

    public interface IViewSearch: IDefaultView {

        void SetSearchOptions(List<String> parameters);

        void GetSearchResult(IQueryable result);

        SearchType SearchFor { set; get; }
    }
}