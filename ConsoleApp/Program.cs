using Data.Repositories;
using DomainModel.Entities;
using DomainModel.Interfaces.Repositories;
using DomainModel.Interfaces.Services;
using DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Infrastructure
            ISolicitacaoRepository solicitacaoRepository = new SolicitacaoRepository();

            //DomainService
            IServicoSolicitacao servicoSolicitacao = new ServicoSolicitacao(solicitacaoRepository);

            //==== Testando o Serviço de Domínio ====
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.Detalhes = "Criar campanha de Marketing para Julho";
            solicitacao.CustoTotal = 20000;

            //Criar Solicitação
            servicoSolicitacao.CriarSolicitacao(solicitacao);

            //Obter Todas as Solicitações
            var solicitacoes = servicoSolicitacao.ObterSolicitacoes();
            solicitacoes.ToList().ForEach(s => Console.WriteLine(s.Detalhes));
            //=======================================

            Console.ReadLine(); //Aguarda o ENTER...
        }
    }
}
