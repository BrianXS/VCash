namespace API.Entities.Administrative
{
    public class UserBranch
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}