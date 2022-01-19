using SolutionWarriors.Engine.Entitys;

namespace SolutionWarriors.UI.Models
{
    public class AccountModel
    {
        public int UserId { get; set; }

        public UserAcessLevel UserAcessLevel { get; set; }

        public UserAuthorized UserAuthorized { get; set; }

        public string UserName { get; set; }

        public string UserNickname { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
    }
}
