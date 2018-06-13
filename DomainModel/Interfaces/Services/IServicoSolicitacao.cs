using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Services
{
    public interface IServicoSolicitacao
    {
        void CriarSolicitacao(Solicitacao solicitacao);
        void CancelarSolicitacao(Solicitacao solicitacao);
        IEnumerable<Solicitacao> ObterSolicitacoes();
    }
}
