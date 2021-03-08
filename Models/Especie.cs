using API_FAUNA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FAUNA.Models
{
    public class Especie
    {
        public int Id { get; }
        public string NomePopular { get; set; }

        public string NomeCientifico { get; set; }

        public Biomas Bioma { get; set; }

        public string descricao { get; set; }
    }

    
}
