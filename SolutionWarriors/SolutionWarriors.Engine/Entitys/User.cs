using System;

namespace SolutionWarriors.Engine.Entitys
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public int UserAcessLevel { get; set; }
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
}
