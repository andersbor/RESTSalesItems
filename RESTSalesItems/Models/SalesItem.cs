using System.ComponentModel.DataAnnotations;

namespace RESTSalesItems.Models
{
    public class SalesItem
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? SellerEmail { get; set; }
        public string? SellerPhone { get; set; }
        public long Time { get; set; }
        public string? PictureUrl { get; set; }
        public override string ToString()
        {
            return Id + " " + Description + " " + Price + " " + SellerEmail + " " + SellerPhone + " " + PictureUrl;
        }
    }
}