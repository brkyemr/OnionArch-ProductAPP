using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.Domain.Common;

namespace ProductApp.Domain.Entities
{
    public class Detail : EntityBase
    {
        public Detail()
        {

        }
        public Detail(string title, string description, int categoryId)
        {

        }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}