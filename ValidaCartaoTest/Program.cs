using ValidaCartaoTest.Interfaces;
using ValidaCartaoTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidaCartaoTest
{
    class Program
    {
        static CartaoService service = new CartaoService();

        static void Main(string[] args)
        {
            var cartoes = new List<string>();

            cartoes.Add("4111111111111111");
            cartoes.Add("4111111111111");
            cartoes.Add("40128888 88881881");
            cartoes.Add("378282246310005");
            cartoes.Add("6011111111111117");
            cartoes.Add("5105105105105100");
            cartoes.Add("5105 1051 0510 5106");
            cartoes.Add("9111111111111111");

            foreach (var cartao in cartoes)
            {
                ValidaCartao(cartao);
            }
        }

        static void ValidaCartao(string numero)
        {
            try
            {
                var cartao = service.ValidaCartao(numero);

                Console.WriteLine($"{cartao.CardBrand} {cartao.CardNumber} {cartao.IsValid}");
            }
            catch (CartaoInvalidoExcepion ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
