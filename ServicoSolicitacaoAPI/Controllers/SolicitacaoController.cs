using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicoSolicitacaoAPI.Controllers
{
    public class SolicitacaoController : ApiController
    {
        Solicitacao solMarketing = new Solicitacao();
        solMarketing.CustoTotal = 15000;
        solMarketing.Detalhes = "Balanço de Campanhas";
        
        Solicitacao solDeptoPessoal = new Solicitacao();
        solDeptoPessoal.CustoTotal = 5000;
        solDeptoPessoal.Detalhes = "Controle de Benefícios";
        
        Solicitacao solDiretoria = new Solicitacao();
        solDiretoria.CustoTotal = 3000;
        solDiretoria.Detalhes = "Orçamentos de Estratégia";
        
        Solicitacao solAreaLogistica = new Solicitacao();
        solAreaLogistica.CustoTotal = 7500;
        solAreaLogistica.Detalhes = "Avaliação Financeira de Itinerários";

        Solicitacao[] solicitacoes;
    }
}
