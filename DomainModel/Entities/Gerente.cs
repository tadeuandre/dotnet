using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Gerente
    {
        public int matricula { get; set; }

        public Guid codigo { get; set; }

        public string nome { get; set; }

        public DateTime admissao { get; set; }
    }
}
