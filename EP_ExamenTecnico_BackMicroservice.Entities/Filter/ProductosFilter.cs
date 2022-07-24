using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Entities
{
    public class ProductosFilter
    {
        public string Id { get; set; }
        public decimal PrecioInicial { get; set; }
        public decimal PrecioFinal { get; set; }
    }
}
