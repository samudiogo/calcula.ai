using NUnit.Framework;
using System;
using calcula.ai.Core.Entities;
using calcula.ai.Core.UserCases;
using System.Collections.Generic;
using System.Linq;
namespace calcula.ai.Core.Tests
{
    /// <summary>
    /// Pego meu aplicativo "calcula.ai", digito o valor da bebida, a quantidade de ml,
    /// o valor que pretendo gastar. Quando eu clicar em calcular, 
    /// o aplicativo irá sugerir qual bebida está oferecendo a maior quantidade ml pelo menor preço.
    /// https://github.com/samudiogo/calcula.ai/issues/6
    /// </summary>
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CenarioOndeACracrudinhaGanha()
        {

            var listaBebida = new List<Bebida>();
            var litrao = new Bebida { Id = Guid.NewGuid(), Ml = 1000m, Nome = "Antartica Litrão", Preco = 9.0m };
            var boa = new Bebida { Id = Guid.NewGuid(), Ml = 600m, Nome = "boa da diretoria", Preco = 7.5m };
            var latinha = new Bebida { Id = Guid.NewGuid(), Ml = 350, Nome = "latinha", Preco = 2.99m };
            var latao = new Bebida { Id = Guid.NewGuid(), Ml = 473, Nome = "latão", Preco = 3.99m };
            var cracudinha = new Bebida { Id = Guid.NewGuid(), Ml = 269, Nome = "cracudinha", Preco = 1.67m };

            var naCarteira = 40m;

            listaBebida.Add(litrao);
            listaBebida.Add(boa);
            listaBebida.Add(cracudinha);
            listaBebida.Add(latinha);
            listaBebida.Add(latao);

            //Boa: 4 boas no total de 2400,00 ml
            //Litrao: 3 litroes no total de 3000,ml
            //cracudinha: 11 latas no total de 3959 ml
            var sut = new ComparaBebida();
            var result = sut.ListaMelhorEscolha(listaBebida, naCarteira).ToList();
            Assert.That(result.First().Value.Bebida.Nome, Is.EqualTo(cracudinha.Nome));

            TestContext.Out.WriteLine($"Fui no Guanabara comprar cerveja, tenho R$ {naCarteira} na carteira.. Qual é a sugestão de compra?");
            foreach (var melhorEscolha in result)
            {
                TestContext.Out.WriteLine($"{melhorEscolha.Key} - {melhorEscolha.Value}");
            }
        }
    }
}
