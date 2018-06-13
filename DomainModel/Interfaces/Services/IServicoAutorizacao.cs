using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces.Services
{
    public interface IServicoAutorizacao
    {
        void AutorizarSolicitacao(Solicitacao solicitacao);

        void NaoAutorizarSolicitacao(Solicitacao solicitacao);
    }
}
