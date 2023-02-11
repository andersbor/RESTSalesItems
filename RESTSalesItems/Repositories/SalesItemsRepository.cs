using RESTSalesItems.Models;

namespace RESTSalesItems.Repositories
{
    public class SalesItemsRepository
    {
        private static int _nextId = 1;
        private static readonly List<SalesItem> _salesItems = new() {
           new SalesItem() {Id = _nextId++, Description = "Book", Price=19, SellerPhone="12345678", SellerEmail="anbo@zealand.dk" },
           new SalesItem() {Id = _nextId++, Description = "Phone", Price=1999, SellerPhone="12345678", SellerEmail="anbo@zealand.dk" },
           new SalesItem() {Id = _nextId++, Description = "Laptop", Price=2999, SellerPhone="11112222", SellerEmail="donald@disney.dk" },
           new SalesItem() {Id = _nextId++, Description = "Table", Price=199, SellerPhone="56565656", SellerEmail="mother@home.com" },
           new SalesItem() {Id = _nextId++, Description = "Chair", Price=99, SellerPhone="11112222", SellerEmail="donald@disney.dk" },
           new SalesItem() {Id = _nextId++, Description = "Cup", Price=9, SellerPhone="12345678", SellerEmail="anbo@zealand.dk" },
        };

        public IEnumerable<SalesItem> Get(string? description, int? maxPrice, string? sellerEmail, string? order_by = null)
        {
            IEnumerable<SalesItem> items = new List<SalesItem>(_salesItems);
            if (description != null)
            {
                items = items.Where(s => s.Description != null && s.Description.Contains(description));
            }
            if (maxPrice != null)
            {
                items = items.Where(s => s.Price <= maxPrice);
            }
            if (sellerEmail != null)
            {
                items = items.Where(s => s.SellerEmail == sellerEmail);
            }
            if (order_by != null)
            {
                switch (order_by.ToLower())
                {
                    case "price":
                        return _salesItems.OrderBy(s => s.Price).ToList();
                    case "description":
                        return _salesItems.OrderBy(s => s.Description).ToList();
                    case "seller":
                        return _salesItems.OrderBy(s => s.SellerEmail).ToList();
                    case "phone":
                        return _salesItems.OrderBy(s => s.SellerPhone).ToList();
                    default:
                        return _salesItems;
                }
            }
            return items;
        }

        public SalesItem Add(SalesItem salesItem)
        {
            salesItem.Id = _nextId++;
            _salesItems.Add(salesItem);
            return salesItem;
        }

        public SalesItem? Delete(int id)
        {
            SalesItem? item = _salesItems.Find(salesItem => salesItem.Id == id);
            if (item == null) return null;
            _salesItems.Remove(item);
            return item;
        }
    }
}
