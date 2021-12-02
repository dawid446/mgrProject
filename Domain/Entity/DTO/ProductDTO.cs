using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class ProductDTO
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

    }
}
