using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localizar.frotas
{
    public interface IveiculoRepository
    {
        Veiculo GetById(Guid id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
    }
}
