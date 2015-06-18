using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Category
    {

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public Uri ImageUri { get; set; }
        public IEnumerable<Category> Subcategories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int TotalNumberOfItems { get; set; }
        public bool HasSubcategories { get; set; }
    
    }
}