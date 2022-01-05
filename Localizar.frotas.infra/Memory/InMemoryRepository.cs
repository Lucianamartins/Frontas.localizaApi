using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localizar.frotas.infra.Memory
{
    public class InMemoryRepository : IveiculoRepository
    {
        private readonly IList<Veiculo> entities = new List<Veiculo>();
        public void Add(Veiculo veiculo)
        {
            entities.Add(veiculo);
        }

        public void Delete(Veiculo veiculo) => entities.Remove(veiculo);

        public IEnumerable<Veiculo> GetAll() => entities.ToList();

        public Veiculo GetById(Guid Id) => entities.SingleOrDefault(c => c.Id == Id);

        public void Update(Veiculo veiculo)
        {
            entities.Remove(GetById(veiculo.Id));
            entities.Add(veiculo);
        }
    }
}
