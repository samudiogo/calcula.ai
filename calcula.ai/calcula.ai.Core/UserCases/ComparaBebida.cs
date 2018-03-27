using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using calcula.ai.Core.Entities;

namespace calcula.ai.Core.UserCases
{
    public class ComparaBebida
    {

        public static int ContaQuantidadeBebidaPorMontante(decimal preco, decimal montante)
        {
            return int.Parse(Math.Floor(montante / preco).ToString(CultureInfo.InvariantCulture));
        }

        public Dictionary<int, MelhorEscolha> ListaMelhorEscolha(IEnumerable<Bebida> listaBebida, decimal montante)
        {
            var count = 1;
            return listaBebida?.Select(m => new MelhorEscolha
            {
                Montante = montante,
                Bebida = m
            }).OrderByDescending(m => m.TotalMl).ToDictionary(k => count++, v => v);
        }

        public class MelhorEscolha
        {
            public decimal TotalMl => TotalBebidas * Bebida.Ml;
            public decimal TotalBebidas => !Montante.HasValue ? Bebida.Preco : Math.Floor((decimal)(Montante / Bebida.Preco));
            public decimal? Montante { get; set; }

            public decimal? Troco => !Montante.HasValue ? null : Montante - TotalBebidas * Bebida?.Preco;

            public Bebida Bebida { get; set; }

            public override string ToString() => $"Melhor bebida: {TotalMl:F}ml, " +
                                                 $"=>: {Bebida}, Quante: {TotalBebidas} unidade(s)" +
                                                 $"Troco: R${Troco:C}";
        }
    }
}