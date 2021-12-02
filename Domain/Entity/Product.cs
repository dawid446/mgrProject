using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entity
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public float Price { get; set; }
        public float? Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string ContentText { get; set; }
        public int IdCategoryFk { get; set; }

        public virtual Category IdCategoryFkNavigation { get; set; }
    }
}
