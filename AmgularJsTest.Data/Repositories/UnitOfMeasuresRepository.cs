using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmgularJsTest.Data.Repositories
{
    public interface IUnitOfMeasuresRepository
    {
        IEnumerable<UnitsOfMeasure> GetAll();
    }

    public class UnitOfMeasuresRepository : BaseRepository, IUnitOfMeasuresRepository
    {
        public IEnumerable<UnitsOfMeasure> GetAll()
        {
            return this.db.UnitsOfMeasures;
        }
    }
}
