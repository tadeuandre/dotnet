using Data.Repositories;
using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicoSolicitacaoAPI.Controllers
{
    public class SolicitacoesController : ApiController
    {
        //Infrastructure
        ISolicitacaoRepository solicitacaoRepository;

        //DomainService
        IServicoSolicitacao servicoSolicitacao;

        IEnumerable<Solicitacao> solicitacoes;

        public SolicitacoesController()
        {
            solicitacaoRepository = new SolicitacaoRepository();
            servicoSolicitacao = new ServicoSolicitacao(solicitacaoRepository);
        }

        public IEnumerable<Solicitacao> GetAllSolicitacoes()
        {
            //==== Testando o Serviço de Domínio ====
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.Detalhes = "Criar campanha de Marketing para Julho";
            solicitacao.CustoTotal = 20000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solMarketing = new Solicitacao();
            solMarketing.Detalhes = "Balanço de Campanhas";
            solMarketing.CustoTotal = 15000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solDeptoFin = new Solicitacao();
            solDeptoFin.Detalhes = "Controle de Benefícios";
            solDeptoFin.CustoTotal = 5000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solDiretoria = new Solicitacao();
            solDiretoria.Detalhes = "Orçamentos de Estratégia";
            solDiretoria.CustoTotal = 3000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solSetorLogistica = new Solicitacao();
            solSetorLogistica.Detalhes = "Avaliação Financeira de Itinerários";
            solSetorLogistica.CustoTotal = 7500;

            //Criar Solicitação
            servicoSolicitacao.CriarSolicitacao(solicitacao);
            servicoSolicitacao.CriarSolicitacao(solMarketing);
            servicoSolicitacao.CriarSolicitacao(solDeptoFin);
            servicoSolicitacao.CriarSolicitacao(solDiretoria);
            servicoSolicitacao.CriarSolicitacao(solSetorLogistica);

            //Obter Todas as Solicitações
            solicitacoes = servicoSolicitacao.ObterSolicitacoes();
            solicitacoes.ToList().ForEach(s => Console.WriteLine(s.Detalhes));
            return solicitacoes;
        }

        public IHttpActionResult GetSolicitacao(Guid codigo)
        {
            var solicitacao = solicitacoes.FirstOrDefault((s) => s.Codigo == codigo);
            if (solicitacao == null)
            {
                return NotFound();
            }
            return Ok(solicitacao);
        }
    }
}
