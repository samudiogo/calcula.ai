using System;
using System.Collections.Generic;
using calcula.ai.Core.Entities;
using NUnit.Framework;


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
            var litrao = new Bebida
            {
                Id = Guid.NewGuid(),
                Ml = 1000,
                Nome = "Antartica Litrão",
                Preco = 9.0m
            };

            var boa = new Bebida
            {
                Id = Guid.NewGuid(),
                Ml = 600,
                Nome = "boa da diretoria",
                Preco = 7.5m
            };


            var cracudinha = new Bebida
            {
                Id = Guid.NewGuid(),
                Ml = 355,
                Nome = "cracudinha",
                Preco = 2.69m
            };

            var naCarteira = 40m;
            
            listaBebida.Add(litrao);
            listaBebida.Add(boa);
            listaBebida.Add(cracudinha);

            //Boa: 4 boas no total de 2400,00 ml
            //Litrao: 3 litroes no total de 3000,ml
            //cracudinha: 11 latas no total de 3959 ml
            var melhorEscolha = new
            {
                TotalMl = 0f,                
                Bebida = new Bebida()                
            };
            foreach (var bebida in listaBebida)
            {
                if(bebida.MlTotalNoOrcamento(naCarteira) > melhorEscolha.TotalMl)
                    melhorEscolha = new
                    {
                        TotalMl = bebida.MlTotalNoOrcamento(naCarteira),
                        Bebida = bebida
                    };
            }
            
            Assert.That(melhorEscolha.Bebida.Nome, Is.EqualTo(cracudinha.Nome));
        }
    }
}
