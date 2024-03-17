using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Domain.Common;

namespace ProductApp.Domain.Entities
{
    public class Brand : EntityBase
    {

        public Brand()
        {

        }
        public Brand(string name)
        {
            
        }
        public string Name { get; set; }
    }
}