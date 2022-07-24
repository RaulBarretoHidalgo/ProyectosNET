using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EP_Planning_BackMicroservice.Entities
{
    [DataContract]
    public class ProductosEntity
    {
        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal Price { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public decimal SalePrice { get; set; }
    }
}




