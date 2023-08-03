namespace _0802pro1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserProfile { get; set; }

        // 1:N에서 N 관계인 UserModel은 ProductModel을 리스트로 저장
        public List<ProductModel> Products { get; set; }
    }
}
