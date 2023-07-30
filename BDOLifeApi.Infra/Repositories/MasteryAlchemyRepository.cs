using BDOLife.Core.Entities;
using BDOLife.Core.Interfaces;
using BDOLife.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOLife.Infra.Repositories
{
    public class MasteryAlchemyRepository : Repository<MasteryAlchemy>, IMasteryAlchemyRepository
    {
        public MasteryAlchemyRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
