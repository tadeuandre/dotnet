using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Departamento
    {
        public Guid codigo { get; set; }

        public string descricao { get; set; }

        public Gerente gerente { get; set; }
    }
}
