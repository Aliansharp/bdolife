using BDOLife.Core.Entities;
using BDOLife.Core.Interfaces;
using BDOLife.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Infra.Repositories
{
    public class MaterialGroupRepository : Repository<MaterialGroup>, IMaterialGroupRepository
    {
        public MaterialGroupRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<MaterialGroup> GetByReference(string reference)
        {
            return await _dataContext.MaterialGroups.SingleOrDefaultAsync(m => m.BDOReference == reference);
        }
    }
}
