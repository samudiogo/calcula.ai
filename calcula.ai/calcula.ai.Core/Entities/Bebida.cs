using System;

namespace calcula.ai.Core.Entities
{
    public class Bebida
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Ml { get; set; }
        public decimal Preco { get; set; }

        public decimal PrecoPorMl() => Preco / (decimal) Ml;

        public float MlTotalNoOrcamento(decimal montante)
        {
            return (float) ((montante / Preco) * (decimal) Ml);
        }
    }
}