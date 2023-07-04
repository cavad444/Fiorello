using Fiorello.Core.Entities;
using Fiorello.Core.Repositories;
using Fiorello.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext context) : base(context)
        {

        }
    }
}
