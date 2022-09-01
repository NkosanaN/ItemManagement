using ItemManagementControl.Model;

namespace ItemManagementControl.Service.Repositoty.IRepository
{
    public interface IItemRepositoty
    {
        void InsertItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
        Item GetItemById(int id);
        List<Item> GetItemList();
        void Save();
    }
}
