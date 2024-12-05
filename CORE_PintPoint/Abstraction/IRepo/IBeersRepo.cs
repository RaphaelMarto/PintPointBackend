using Domain_PintPoint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE_PintPoint.Abstraction.IRepo
{
    public interface IBeersRepo
    {
        IEnumerable<Beers> Get();
        Beers Get(int id);
    }
}
