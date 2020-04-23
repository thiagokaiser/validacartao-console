using ValidaCartaoTest;
using ValidaCartaoTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class CartaoTest1
    {
        [TestMethod]
        public void TestInverteNumero()
        {
            var service = new CartaoService();
            var numeroInvertido = service.InverteNumero("12345");
            var teste = new List<int>() { 5, 4, 3, 2, 1 };

            CollectionAssert.AreEqual(numeroInvertido, teste);            
        }
        [TestMethod]
        public void TestDobraNumeroes()
        {
            var service = new CartaoService();
            var numeroDobrado = service.DobraNumeros(new List<int>() { 1,2,3,4,5 });

            var teste = new List<int>() { 1,4,3,8,5 };

            CollectionAssert.AreEqual(numeroDobrado, teste);
        }
        [TestMethod]
        public void TestValidaCartaoFalse()
        {
            var service = new CartaoService();
            var cartao = new Cartao("12345");

            service.Valida(cartao);

            Assert.IsFalse(cartao.Valido);
        }
        [TestMethod]
        public void TestValidaCartaoTrue()
        {
            var service = new CartaoService();
            var cartao = new Cartao("4111111111111111");

            service.Valida(cartao);

            Assert.IsTrue(cartao.Valido);
        }
    }
}
