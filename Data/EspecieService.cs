using API_FAUNA.Interfaces;
using API_FAUNA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FAUNA.Data
{
    public class EspecieService : IEspecie, IDisposable
    {
        private readonly FaunaContext context;

        public EspecieService(FaunaContext context)
        {
            this.context = context;
        }
        public void Adicionar(Especie e)
        {
            context.Especies.Add(e);
            context.SaveChanges();
        }

        public void Atualizar(Especie e)
        {
            context.Especies.Update(e);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Especie> GetEspecies()
        {
            return context.Especies.ToList();
        }

        public Especie GetId(int id)
        {
           return context.Especies.FirstOrDefault(e => e.Id == id);
        }

        public void Remover(Especie e)
        {
            context.Especies.Remove(e);
            context.SaveChanges();
        }
    }
}
