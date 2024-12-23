﻿//                      Projeto: Motor Tributario                                                  
//          Biblioteca C# para Cálculos Tributários Do Brasil
//                    NF-e, NFC-e, CT-e, SAT-Fiscal     
//                                                                                                                                           
//  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la 
// sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  
// Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) 
// qualquer versão posterior.                                                   
//                                                                              
//  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   
// NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      
// ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor
// do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              
//                                                                              
//  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto
// com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  
// no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          
// Você também pode obter uma copia da licença em:                              
// https://github.com/AutomacaoNet/MotorTributarioNet/blob/master/LICENSE      

using System;

namespace MotorTributarioNet.Impostos.Implementacoes
{
    public class ResultadoCalculoIssqn : IResultadoCalculoIssqn
    {
        public ResultadoCalculoIssqn(decimal baseCalculo, decimal valor)
        {
            BaseCalculo = Math.Round(baseCalculo, 2);
            Valor = Math.Round(valor, 2);
        }

        public ResultadoCalculoIssqn(decimal baseCalculo, decimal valor, decimal baseCalculoInss, decimal baseCalculoIrrf, decimal valorRetPis, decimal valorRetCofins, decimal valorRetCsll, decimal valorRetIrrf, decimal valorRetInss)
        {
            BaseCalculo = Math.Round(baseCalculo, 2);
            Valor = Math.Round(valor, 2);
            BaseCalculoInss = Math.Round(baseCalculoInss, 2);
            BaseCalculoIrrf = Math.Round(baseCalculoIrrf, 2);
            ValorRetPis = Math.Round(valorRetPis, 2);
            ValorRetCofins = Math.Round(valorRetCofins, 2);
            ValorRetCsll = Math.Round(valorRetCsll, 2);
            ValorRetIrrf = Math.Round(valorRetIrrf, 2);
            ValorRetInss = Math.Round(valorRetInss, 2);
        }
        
        public decimal BaseCalculo { get; }
        public decimal Valor { get; set; }
        public decimal BaseCalculoInss { get; set; }
        public decimal BaseCalculoIrrf { get; set; }
        public decimal ValorRetPis { get; set; }
        public decimal ValorRetCofins { get; set; }
        public decimal ValorRetCsll { get; set; }
        public decimal ValorRetInss { get; set; }
        public decimal ValorRetIrrf { get; set; }
        
    }
}
