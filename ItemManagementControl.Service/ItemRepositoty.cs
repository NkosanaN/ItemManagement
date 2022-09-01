using ItemManagementControl.Model;
using ItemManagementControl.Service.Data;
using ItemManagementControl.Service.Repositoty.IRepository;

namespace ItemManagementControl.Service
{
    public class ItemRepositoty : IItemRepositoty
    {
        private readonly ShopContext _shopContext;

        public ItemRepositoty(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void DeleteItem(Item model)
        {
            _shopContext.Remove(model);
        }

        public List<Item> GetItemList()
        {
           return _shopContext.Items.ToList();
        }

        public void InsertItem(Item item)
        {
            _shopContext.Items.Add(item);
        }

        public Item GetItemById(int id)
        {
          return  _shopContext.Items.Find(id);
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }

        public void UpdateItem(Item item)
        {
           _shopContext.Update(item);
        }
    }
}