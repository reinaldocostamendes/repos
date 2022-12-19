using NUnit.Framework;
using Projeto.Shared;

namespace UnitTestPadrao
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestarIdadeMaior18()
        {
            bool resultado = Helper.VerificaIdadadeDeRisco(18);
           Assert.IsTrue(resultado);
            Assert.Pass();
        }
        [Test]
     
        public void TestarNomerisco()
        {
            bool resultado = Helper.VerificaNomeDeReisco("Rui");
            Assert.IsTrue(resultado);
            Assert.Pass();
        }
    }
}