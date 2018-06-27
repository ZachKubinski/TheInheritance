using BoxProblem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Repositories
{
    public class BoxInventoryRepository
    {
        private ApplicationDbContext dbContext;

        public BoxInventoryRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }

        public void AddBox(BoxInventory toAdd)
        {
            dbContext.Boxes.Add(toAdd);
            dbContext.SaveChanges();
        }

        public void SaveEdit(BoxInventory toSave)
        {
            dbContext.Entry(toSave).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void DeleteBox(BoxInventory toDelete)
        {
            dbContext.Boxes.Remove(toDelete);
            dbContext.SaveChanges();
        }

    }
}
