using BDOLife.Core.Entities;
using BDOLife.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Core.Interfaces
{
    public interface IMaterialGroupRepository : IRepository<MaterialGroup>
    {
        Task<MaterialGroup> GetByReference(string reference);
    }
}
