using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaCartaoTest.Bandeiras
{
    public class Discovery: CartaoBase
    {
        private const int tamanho = 16;
        private string comecaCom = "6011";

        public Discovery() : base("Discovery")
        {

        }

        protected override bool ValidaBandeira(string numero)
        {
            return numero.Length == tamanho && numero.StartsWith(comecaCom);
        }      
    }
}
