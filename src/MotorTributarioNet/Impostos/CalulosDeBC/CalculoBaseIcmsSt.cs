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

using MotorTributarioNet.Flags;
using MotorTributarioNet.Impostos.CalulosDeBC.Base;

namespace MotorTributarioNet.Impostos.CalulosDeBC
{
    public class CalculoBaseIcmsSt : CalculaBaseCalculoBase
    {
        private readonly ITributavel _tributavel;
        private readonly TipoDesconto _tipoDesconto;

        public CalculoBaseIcmsSt(ITributavel tributavel, TipoDesconto tipoDesconto) : base(tributavel)
        {
            _tributavel = tributavel;
            _tipoDesconto = tipoDesconto;
        }

        public decimal CalculaBaseCalculo()
        {
            var baseCalculo = CalculaBaseDeCalculo();
            var baseCalculoSt = CalculaBaseCalculoST(baseCalculo + _tributavel.ValorIpi);
            return baseCalculoSt;
        }

        public decimal CalculaBaseCalculoST(decimal baseCalculoIcms)
        {
            var baseCalculoSt = _tipoDesconto == TipoDesconto.Condincional ? CalculaIcmsComDescontoCondicional(baseCalculoIcms) : CalculaIcmsComDescontoIncondicional(baseCalculoIcms);
            baseCalculoSt *= (1.00m + _tributavel.PercentualMva / 100.00m);
            return baseCalculoSt;
        }

        private decimal CalculaIcmsComDescontoIncondicional(decimal baseCalculoInicial)
        {
            var baseCalculo = baseCalculoInicial - _tributavel.Desconto;
            baseCalculo -= baseCalculo * _tributavel.PercentualReducaoSt / 100;
            return baseCalculo;
        }

        private decimal CalculaIcmsComDescontoCondicional(decimal baseCalculoInicial)
        {
            var baseCalulo = baseCalculoInicial + _tributavel.Desconto;
            baseCalulo -= baseCalulo * _tributavel.PercentualReducaoSt / 100;
            return baseCalulo;
        }
    }
}