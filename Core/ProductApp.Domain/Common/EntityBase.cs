using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}