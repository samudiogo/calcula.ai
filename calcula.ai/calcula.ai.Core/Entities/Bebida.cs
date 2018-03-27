using System;

namespace calcula.ai.Core.Entities
{
    public class Bebida
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Ml { get; set; }
        public decimal Preco { get; set; }

        public decimal PrecoPorMl => Preco / Ml;
        

        public decimal MlTotalNoOrcamento(decimal montante)
        {
            return (montante / Preco) * Ml;
        }

        public override string ToString() => $"Bebida: Nome: {Nome}, {Ml}ml, Preço: R${Preco:C}";
    }
}