using System.Collections.Generic;
using System.Linq;
using calcula.ai.Core.Entities;

namespace calcula.ai.Core.UserCases
{
    public class ComparaBebida
    {

        public IEnumerable<MelhorEscolha> ListaMelhorEscolha(IEnumerable<Bebida> listaBebida, decimal montante)
        {
            return listaBebida?.Select(m => new MelhorEscolha
            {
                TotalMl = montante / m.Preco * m.Ml,
                Bebida = m
            }).OrderByDescending(m=> m.TotalMl);
        }
        
        public class MelhorEscolha
        {
            public decimal TotalMl { get; set; }
            public Bebida Bebida { get; set; }
        }
    }
}