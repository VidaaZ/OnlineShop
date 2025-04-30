namespace Domain.Entity.UserInfo
{
    public class SellerInfo
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }

}
