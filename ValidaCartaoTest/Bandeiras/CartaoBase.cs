using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidaCartaoTest.Bandeiras
{
    public abstract class CartaoBase
    {
        public string CardNumber { get; set; }
        public string CardBrand { get; set; }
        public bool IsValid { get; set; }

        public CartaoBase(string bandeira)
        {
            CardBrand = bandeira;
            IsValid = false;
        }

        protected abstract bool ValidaBandeira(string numero);

        public bool Valida(string numero)
        {
            numero = numero.Replace(" ", "");
            this.CardNumber = numero;
            var bandeiraEhValida = ValidaBandeira(numero);

            if (!bandeiraEhValida)
            {
                return false;
            }
            this.CardNumber = numero;

            return ValidaLuhn();
        }
        public bool ValidaLuhn()
        {
            var numeroInvertido = InverteNumero(this.CardNumber);
            var numeroDobrado = DobraNumeros(numeroInvertido);
            var soma = numeroDobrado.Sum();
            var resto = soma % 10;
            if (resto == 0)
            {
                this.IsValid = true;
                return true;
            }
            this.IsValid = false;

            return false;
        }

        public List<int> InverteNumero(string numero)
        {
            var numeroInvertido = numero.Reverse();
            var arrayInt = numeroInvertido.Select(x => int.Parse(x.ToString()));

            return arrayInt.ToList();
        }

        public List<int> DobraNumeros(List<int> numeroInvertido)
        {
            var numeroDobrado = new List<int>();

            for (int i = 0; i < numeroInvertido.Count; i++)
            {
                numeroDobrado.Add(numeroInvertido[i]);

                if (EhPar(i + 1))
                {
                    numeroDobrado[i] = numeroDobrado[i] * 2;

                    if (numeroDobrado[i] >= 10)
                    {
                        numeroDobrado[i] = numeroDobrado[i] - 9;
                    }
                }
            }

            return numeroDobrado;
        }

        public static bool EhPar(int valor)
        {
            return valor % 2 == 0;
        }
    }
}
