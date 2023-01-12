using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModule.Domain
{
    class Category: BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}
