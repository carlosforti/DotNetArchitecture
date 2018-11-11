using Solution.App.Model.Enums;

namespace Solution.App.Model.Models
{
    public class SignedInModel
    {
        public long UserId { get; set; }

        public Roles Roles { get; set; }
    }
}
