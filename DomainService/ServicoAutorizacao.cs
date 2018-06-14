using DomainModel.Interfaces;
using DomainModel.Entities;
using DomainModel.Enum;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;

namespace DomainService
{
    public class ServicoAutorizacao : IServicoAutorizacao
    {
        private ISolicitacaoRepository solicitacaoRepository;

        public ServicoAutorizacao(ISolicitacaoRepository solicitacaoRepository) => this.solicitacaoRepository = solicitacaoRepository;

        public void AutorizarSolicitacao(Solicitacao solicitacao)
        {
            if (TipoStatusSolicitacao.AguardandoAutorizacao.Equals(solicitacao.TipoStatusSolicitacao))
            {
                solicitacao.TipoStatusSolicitacao = TipoStatusSolicitacao.EmAnalise;
                solicitacaoRepository.Update(solicitacao);
            }
        }

        public void DesautorizarSolicitacao(Solicitacao solicitacao)
        {
            if (TipoStatusSolicitacao.AguardandoAutorizacao.Equals(solicitacao.TipoStatusSolicitacao))
            {
                solicitacao.TipoStatusSolicitacao = TipoStatusSolicitacao.Inviavel;
                solicitacaoRepository.Update(solicitacao);
            }
        }
    }
}
