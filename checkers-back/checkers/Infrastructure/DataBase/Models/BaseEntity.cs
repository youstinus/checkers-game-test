using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkers.Infrastructure.DataBase.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
