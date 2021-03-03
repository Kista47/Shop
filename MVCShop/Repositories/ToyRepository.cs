using Microsoft.EntityFrameworkCore;
using MVCShop.DataBaseEntity;
using MVCShop.DataBaseEntity.Models;
using MVCShop.Filters;
using MVCShop.Models;
using MVCShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Repositories
{
    public class ToyRepository
    {
        private readonly DataBaseContext _db;
        public ToyRepository(DataBaseContext db)
        {
            _db = db;
        }
        public async Task CreateToy(Toy toy)
        {
            await _db.AddAsync(TransformToy(toy)).ConfigureAwait(false);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
        //public async Task<ICollection<Toy>> GetToys(int pageIndex)
        //{
        //    var dbToys = await _db.DbToys.Skip(pageIndex * CatalogeService.MAXTOYSPAGE)
        //                                 .Take(CatalogeService.MAXTOYSPAGE)
        //                                 .OrderBy(dbToy => dbToy.Name)
        //                                 .ToArrayAsync()
        //                                 .ConfigureAwait(false);

        //    return dbToys.Select(dbToy =>
        //    {
        //        return new Toy(dbToy.Id, dbToy.Name, dbToy.Info, dbToy.Price);
        //    }).ToArray();
        //}

        public async Task<ICollection<Toy>> GetToys()
        {
            var dbToys = await _db.DbToys.OrderBy(dbToy => dbToy.Name)
                                         .ToArrayAsync()
                                         .ConfigureAwait(false);
            return dbToys.Select(dbToy =>
            {
                return new Toy(dbToy.Id, dbToy.Name, dbToy.Info, dbToy.Price);
            }).ToArray();
        }

        public async Task<ICollection<Toy>> SearchToys(SearchFilter searchFilter, int pageIndex)
        {
            IQueryable<DbToy> dbToys = _db.DbToys;
            if (searchFilter != null)
            {
                if (!String.IsNullOrEmpty(searchFilter.keyWords))
                    dbToys = dbToys.Where(dbToy => dbToy.Name.Contains(searchFilter.keyWords));
                                                     
            }
            dbToys = dbToys.Skip(pageIndex * CatalogeService.MAXTOYSPAGE)
                           .Take(CatalogeService.MAXTOYSPAGE)
                           .OrderBy(dbToy => dbToy.Name);

            return (await dbToys.ToArrayAsync()).Select(dbToy =>
            {
                return new Toy(dbToy.Id, dbToy.Name, dbToy.Info, dbToy.Price);
            }).ToArray();
        }

        public async Task UpdateToy(Toy toy)
        {
            var dbOldToy = await _db.DbToys.FirstOrDefaultAsync(dbToy => dbToy.Id == toy.Id);
            if (dbOldToy != null)
            {
                DbToy dbNewToy = TransformToy(toy);
                _db.Entry(dbOldToy).CurrentValues.SetValues(dbNewToy);
                await _db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        public async Task<Toy> GetToy(int id)
        {
            var dbToy = await GetDbToy(id).ConfigureAwait(false);
            if (dbToy != null)
            {
                return new Toy(dbToy.Id, dbToy.Name, dbToy.Info, dbToy.Price);
            }
            throw new Exception("DbToy = null");
        }
        private async Task<DbToy> GetDbToy(int id)
        {
            return await _db.DbToys.FirstOrDefaultAsync(dbToy => dbToy.Id == id).ConfigureAwait(false);
        }


        public async Task DeleteToy(int id)
        {
            var dbToy = await GetDbToy(id).ConfigureAwait(false);
            _db.DbToys.Remove(dbToy);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public DbToy TransformToy(Toy toy)
        {
            return new DbToy()
            {
                Id = toy.Id,
                Name = toy.Name,
                Info = toy.Info,
                Price = toy.Price
            };
        }
    }


}
