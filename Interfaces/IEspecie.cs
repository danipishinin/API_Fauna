using API_FAUNA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FAUNA.Interfaces
{
    interface IEspecie
    {
        void Adicionar(Especie e);
        void Atualizar(Especie e);
        void Remover(Especie e);
        IList<Especie> GetEspecies();
        Especie GetId(int id);
    }
}
