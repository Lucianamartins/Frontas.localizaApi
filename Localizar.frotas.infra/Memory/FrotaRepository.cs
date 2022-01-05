using Localizar.frotas.infra.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Localizar.frotas.infra.Memory
{
    public class FrotaRepository : IveiculoRepository
    {
        private readonly FrotaContext dbContext;

        public FrotaRepository(FrotaContext dbContext) => this.dbContext = dbContext;
        public void Add(Veiculo veiculo)
        {
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();
        }

        public void Delete(Veiculo veiculo)
        {
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => dbContext.Veiculos.ToListAsync().Result;

        public Veiculo GetById(Guid Id) => dbContext.Veiculos.SingleOrDefaultAsync().Result;

        public void Update(Veiculo veiculo)
        {
            dbContext.Entry(veiculo).State = EntityState.Modified;
             dbContext.SaveChanges();
        }
    }
}
