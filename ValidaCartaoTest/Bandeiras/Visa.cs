using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaCartaoTest.Bandeiras
{
    public class Visa : CartaoBase
    {
        private int[] comprimento = new int[] { 13, 16 };
        private string comecaCom = "4";

        public Visa() : base("Visa")
        {

        }

        protected override bool ValidaBandeira(string numero)
        {
            return comprimento.Any(x => x == numero.Length) && numero.StartsWith(comecaCom);
        }
    }
}
