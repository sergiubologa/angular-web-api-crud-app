using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmgularJsTest.Data.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetAll();
        Item GetById(int id);
        void Update(Item item);
        void Add(Item item);
        void Delete(Item item);
        int Count(int id);
    }

    public class ItemsRespository : BaseRepository, IItemsRepository
    {
        public IEnumerable<Item> GetAll()
        {
            return this.db.Items;
        }

        public Item GetById(int id)
        {
            return this.db.Items.FirstOrDefault(item => item.id == id);
        }

        public void Update(Item item)
        {
            this.db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Item item)
        {
            this.db.Items.Add(item);
            this.db.SaveChanges();
        }

        public void Delete(Item item)
        {
            if (item != null)
            {
                this.db.Items.Remove(item);
                this.db.SaveChanges();
            }
        }

        public int Count(int id)
        {
            return this.db.Items.Count(x => x.id == id);
        }
    }
}
