﻿using ArchShop.Data;
using ArchShop.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArchShop.DataLayer
{
    public class ProductDataLayer : BaseDataLayer<Product>
    {
        public ProductDataLayer(ArchShopContext context)
            : base(context)
        {
        }

        public async Task<Product?> GetAsync(ProductId productId, CancellationToken cancellationToken)
        {
            return await Entities.Where(p => p.Id == productId).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
