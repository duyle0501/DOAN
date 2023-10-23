namespace ShopAoQuan.Models
{
    [Serializable]
    public class ShoppingCartViewModel
    {
        int ProductID { get; set; }
        public TDanhMucSp Product { get; set; }
        public int Quantity { get; set; }
    }
}
