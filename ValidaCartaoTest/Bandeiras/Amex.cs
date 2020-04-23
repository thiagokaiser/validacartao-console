using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaCartaoTest.Bandeiras
{
    public class Amex : CartaoBase
    {
        private const int tamanho = 15;
        private string[] comecaCom = new string[] { "34", "37" };

        public Amex() : base("Amex")
        {

        }

        protected override bool ValidaBandeira(string numero)
        {
            return numero.Length == tamanho && comecaCom.Any(x => numero.StartsWith(x));
        }
    }
}
