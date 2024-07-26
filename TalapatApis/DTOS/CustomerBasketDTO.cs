namespace TalapatApis.DTOS
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; }
        public List<BasketItemDTO> Items {  get; set; }
    }
}
