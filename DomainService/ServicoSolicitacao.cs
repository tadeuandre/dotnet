using DomainModel.Entities;
using DomainModel.Enum;
using System.Linq;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace DomainService
{
    public class ServicoSolicitacao : IServicoSolicitacao
    {
        private ISolicitacaoRepository solicitacaoRepository;

        public ServicoSolicitacao(ISolicitacaoRepository solicitacaoRepository)
        {
            this.solicitacaoRepository = solicitacaoRepository;
        }

        //private static readonly List<Solicitacao> solicitacoes = new List<Solicitacao>();

        public void CancelarSolicitacao(Solicitacao solicitacao)
        {
            if (TipoStatusSolicitacao.AguardandoAutorizacao.Equals(solicitacao.TipoStatusSolicitacao) 
                || TipoStatusSolicitacao.Inviavel.Equals(solicitacao.TipoStatusSolicitacao))
            {
                solicitacaoRepository.Delete(solicitacao.Codigo);
            }
        }

        public void CriarSolicitacao(Solicitacao solicitacao)
        {
            Solicitacao[] solicitacoes = solicitacaoRepository.GetAll();
            solicitacoes.FirstOrDefault(s => s.Codigo == solicitacao.Codigo);

            // Validações.
            if (solicitacoes.Length != 0)
            { 
                for (int i = 0; i < solicitacoes.Length; i++)
                {
                    Solicitacao itemLista = solicitacoes[i];
                    if (itemLista.Departamento.descricao.Equals(solicitacao.Departamento.descricao))
                    {
                        Console.WriteLine("Já existe solicitação do departamento " + solicitacao.Departamento.descricao);
                        return;
                    }
                }
            }

            if (solicitacoes.Length == 0 || !TipoStatusSolicitacao.Concluida.Equals(solicitacoes.ElementAt(0).TipoStatusSolicitacao))
            {
                solicitacaoRepository.Create(solicitacao);
            }
        }

        public IEnumerable<Solicitacao> ObterSolicitacoes()
        {
            return solicitacaoRepository.GetAll();
        }
    }
}
