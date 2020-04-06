using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BazaAwionika.Data.Repositories
{
    public class AircraftRepository : RepositoryBase<AircraftModel>, IAircraftRepository
    {
        public AircraftRepository(IDbFactory dbFactory) : base(dbFactory) { }
        
      //  public override IEnumerable<AircraftModel> GetAllWithDependencies()
      //  {
      //      return GetAll().
      //  }
        public AircraftModel GetAircraftByNumber(string aircraftNumber)
        {
            return GetAll().SingleOrDefault(c => c.TailNumber.CompareTo(aircraftNumber) == 0) ?? throw new KeyNotFoundException("asd"); //TODO: dodac locale
        }

        public IEnumerable<AircraftModel> GetAircraftsByStatus(AircraftStatusModel aircraftStatus)
        {
            return GetAll().Where(c => c.AircraftStatusId == aircraftStatus.Id);
        }

        public AircraftModel GetByIdNoTracking(int id)
        {
            return DbContext.Aircraft.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }
        //dbSet.Add(entity);
    }

    

    public interface IAircraftRepository : IRepository<AircraftModel>
    {
        AircraftModel GetAircraftByNumber(string aircraftNumber);


        IEnumerable<AircraftModel> GetAircraftsByStatus(AircraftStatusModel aircraftStatus);

        AircraftModel GetByIdNoTracking(int id);

    }
}
/*
 * public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
 
        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.FirstName == categoryName).FirstOrDefault();
 
            return category;
        }
 
        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }
 
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
 * /*/
