using ValidaCartaoTest;
using ValidaCartaoTest.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ValidaCartaoTest.Bandeiras;

namespace Testes
{
    [TestClass]
    public class CartaoTest1
    {
        [TestMethod]
        public void TestInverteNumero()
        {
            var cartao = new Amex();

            var numeroInvertido = cartao.InverteNumero("12345");
            var teste = new List<int>() { 5, 4, 3, 2, 1 };

            CollectionAssert.AreEqual(numeroInvertido, teste);            
        }

        [TestMethod]
        public void TestDobraNumeroes()
        {
            var cartao = new Amex();
            var numeroDobrado = cartao.DobraNumeros(new List<int>() { 1,2,3,4,5 });

            var teste = new List<int>() { 1,4,3,8,5 };

            CollectionAssert.AreEqual(numeroDobrado, teste);
        }

        [TestMethod]
        public void TestValidaCartaoFalse()
        {
            var service = new CartaoService();

            try
            {
                service.ValidaCartao("12345");
                Assert.Fail("no exception thrown");
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is CartaoInvalidoExcepion);
            }
        }

        [TestMethod]
        public void TestValidaCartaoTrue()
        {
            var service = new CartaoService();

            var result = service.ValidaCartao("4111111111111111");
            Assert.IsTrue(result is CartaoBase);
            
        }
    }
}
