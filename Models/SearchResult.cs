using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SearchResult
    {
        
            public int TotalCount { get; set; }
            public IEnumerable<Product> Products { get; set; }
       
    }
}