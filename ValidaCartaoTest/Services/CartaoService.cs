using ValidaCartaoTest.Bandeiras;
using ValidaCartaoTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidaCartaoTest.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly List<CartaoBase> bandeirasCartao;

        public CartaoService()
        {
            this.bandeirasCartao = new List<CartaoBase>
            {
                new Amex(),
                new Discovery(),
                new Master(),
                new Visa()
            };
        }

        public CartaoBase ValidaCartao(string numero)
        {
            foreach (var cartao in bandeirasCartao)
            {
                if (cartao.Valida(numero))
                {
                    return cartao;
                }
            }
            throw new CartaoInvalidoExcepion("Número do cartão não é válido.");
        }
    }

    public class CartaoInvalidoExcepion : Exception
    {
        public CartaoInvalidoExcepion(string message) : base(message)
        {

        }
    }
}
