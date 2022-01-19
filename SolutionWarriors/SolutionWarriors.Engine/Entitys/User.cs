using System;

namespace SolutionWarriors.Engine.Entitys
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public UserAcessLevel UserAcessLevel { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public DateTime UserRegisterDate { get; set; }
        public DateTime UserLastUpdate { get; set; }
    }

    public enum UserAcessLevel
    {
        Player = 0,
        Administrator = 1,
        Root = 2
    }

    public enum UserAuthorized
    {
        Authorized = 0,
        Unauthorized = 1,
        NotFound = 2
    }
}
