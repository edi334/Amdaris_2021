namespace OnlineBookStore.Domain
{
    public class PriceOffer : Entity<int>
    {       
        public decimal NewPrice { get; set; }

        public string PromotionalText { get; set; }         
       
        public Book Book { get; }
    }
}
