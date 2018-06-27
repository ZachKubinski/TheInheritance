using BoxProblem.Data;
using BoxProblem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Services
{
    public class BoxInventoryService
    {
        private BoxInventoryRepository repository;

        public BoxInventoryService(ApplicationDbContext context)
        {
            repository = new BoxInventoryRepository(context);
        }

        public BoxInventory GetBoxById(int? id)
        {
            return repository.GetBoxById(id);
        }

        public List<BoxInventory> GetAllBoxes()
        {
            return repository.GetAllBoxes();
        }

        public void AddBox(BoxInventory toAdd)
        {
            repository.AddBox(toAdd);
        }

        public void SaveEdit(BoxInventory toSave)
        {
            repository.SaveEdit(toSave);
        }

        public void DeleteBox(BoxInventory toDelete)
        {
            repository.DeleteBox(toDelete);
        }
    }
}
