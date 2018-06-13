using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public abstract class TEntity
    {
        public Guid Id { get; set; }
    }
}
