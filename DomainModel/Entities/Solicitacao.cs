using DomainModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Entities
{
    public class Solicitacao : TEntity
    {
        public Solicitacao()
        {
            this.Codigo = Guid.NewGuid();
        }

        public Guid Codigo { get; set; }

        public string Detalhes { get; set; }

        public TipoPrioridade TipoPrioridade { get; set; }

        public Double CustoTotal { get; set; }

        public int HorasTotais { get; set; }

        public TipoStatusSolicitacao TipoStatusSolicitacao { get; set; }

        public Departamento Departamento { get; set; }

        public Avaliador Avaliador { get; set; }

        public Relevancia Relevancia { get; set; }
    }
}
