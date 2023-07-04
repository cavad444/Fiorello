using Fiorello.Core.Entities;
using Fiorello.Core.Repositories;
using Fiorello.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Data.Repositories
{
    public class FlowerRepository : Repository<Flower>, IFlowerRepository
    {
        public FlowerRepository(ShopDbContext context) : base(context)
        {

        }
    }
}
