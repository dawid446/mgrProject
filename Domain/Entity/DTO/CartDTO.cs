using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity.DTO
{
    public class CartDTO
    {
        public int IdCart { get; set; }
        public string Token { get; set; }
        public string SessionId { get; set; }
        public bool Active { get; set; }
        public int? IdUserFk { get; set; }
    }
}
