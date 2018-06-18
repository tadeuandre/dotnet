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
            IServicoAutorizacao servicoAutorizacao = new ServicoAutorizacao(solicitacaoRepository);

            Departamento dptoMktg = new Departamento("Marketing");
            Departamento dptoFin = new Departamento("Financeiro");
            Departamento dptoPessoal = new Departamento("Pessoal");
            Departamento dptoDiretoria = new Departamento("Diretoria");
            Departamento dptoLogistica = new Departamento("Logística");

            //==== Testando o Serviço de Domínio ====
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.Detalhes = "Criar campanha de Marketing para Julho";
            solicitacao.Departamento = dptoMktg;
            solicitacao.CustoTotal = 20000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solDeptoFin = new Solicitacao();
            solDeptoFin.Detalhes = "Controle de Benefícios";
            solDeptoFin.Departamento = dptoPessoal;
            solDeptoFin.CustoTotal = 5000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solDiretoria = new Solicitacao();
            solDiretoria.Detalhes = "Orçamentos de Estratégia";
            solDiretoria.Departamento = dptoDiretoria;
            solDiretoria.CustoTotal = 3000;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solSetorLogistica = new Solicitacao();
            solSetorLogistica.Detalhes = "Avaliação Financeira de Itinerários";
            solSetorLogistica.Departamento = dptoLogistica;
            solSetorLogistica.CustoTotal = 7500;

            //==== Testando o Serviço de Domínio ====
            Solicitacao solMarketing = new Solicitacao();
            solMarketing.Detalhes = "Balanço de Campanhas";
            solMarketing.Departamento = dptoMktg;
            solMarketing.CustoTotal = 15000;

            Solicitacao[] solicitacoesAtuais = new Solicitacao[] 
            {
                solicitacao, solDeptoFin, solDiretoria, solSetorLogistica, solMarketing
            };
            
            //=======================================
            int num = 0;
            int indiceCriacao = 0;

            do
            {
                Console.WriteLine("Informe a opção desejada.");
                Console.WriteLine("1 - Criar Solicitação");
                Console.WriteLine("2 - Aprovar Solicitação");
                Console.WriteLine("3 - Listar Solicitações");
                Console.WriteLine("4 - Desautorizar Solicitação");
                Console.WriteLine("5 - Cancelar Solicitação");
                Console.WriteLine("0 - Sair");
                //Aguarda o ENTER...
                num = int.Parse(System.Console.ReadLine());

                switch (num)
                {
                    case 1:
                        //==== Testando o Serviço de Domínio ====

                        //Criar Solicitação
                        if (indiceCriacao < solicitacoesAtuais.Length)
                        {
                            // Com os objetos já preenchidos no array.
                            servicoSolicitacao.CriarSolicitacao(solicitacoesAtuais.ElementAt(indiceCriacao++));
                        }
                        break;
                    case 2:
                        //Obter Todas as Solicitações
                        Console.WriteLine("Qual solicitação deseja autorizar?");
                        Guid posicaoAutorizar = Guid.Parse(System.Console.ReadLine());
                        var solicitacoes = servicoSolicitacao.ObterSolicitacoes();
                        solicitacoes = solicitacoes.Where(s => s.Codigo.Equals(posicaoAutorizar)).ToList();
                        servicoAutorizacao.AutorizarSolicitacao(solicitacoes.FirstOrDefault());
                        break;
                    case 3:
                        //Obter Todas as Solicitações
                        solicitacoes = servicoSolicitacao.ObterSolicitacoes();
                        int numSol = 0;
                        solicitacoes.ToList().ForEach(s => Console.WriteLine(
                            numSol++ + " " +
                            s.Codigo + " " + 
                            s.Departamento.descricao.ToUpper() + " " + 
                            s.Detalhes));
                        Console.WriteLine();
                        break;
                    case 4:
                        //Obter Todas as Solicitações
                        Console.WriteLine("Qual solicitação deseja desautorizar?");
                        Guid posicaoDesautorizar = Guid.Parse(System.Console.ReadLine());
                        solicitacoes = servicoSolicitacao.ObterSolicitacoes();
                        solicitacoes = solicitacoes.Where(s => s.Codigo.Equals(posicaoDesautorizar)).ToList();
                        servicoAutorizacao.AutorizarSolicitacao(solicitacoes.FirstOrDefault());
                        break;
                    case 5:
                        //Obter Todas as Solicitações
                        Console.WriteLine("Qual solicitação deseja cancelar?");
                        Guid posicaoCancelar = Guid.Parse(System.Console.ReadLine());
                        solicitacoes = servicoSolicitacao.ObterSolicitacoes();
                        solicitacoes = solicitacoes.Where(s => s.Codigo.Equals(posicaoCancelar)).ToList();
                        servicoSolicitacao.CancelarSolicitacao(solicitacoes.FirstOrDefault());
                        // remove
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            } while (num != 0);
        }
    }
}
