using API_FAUNA.Interfaces;
using API_FAUNA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FAUNA.Data
{
    public class EspecieEntity : IEspecie, IDisposable
    {
        private FaunaContext context;

        public EspecieEntity()
        {
            this.context = new FaunaContext();
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

        public IList<Especie> Especies()
        {
            return context.Especies.ToList();
        }

        public void Remover(Especie e)
        {
            context.Especies.Remove(e);
            context.SaveChanges();
        }
    }
}
