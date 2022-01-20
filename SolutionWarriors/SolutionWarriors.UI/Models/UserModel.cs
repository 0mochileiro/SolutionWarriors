using SolutionWarriors.Engine.Common;
using SolutionWarriors.Engine.Entitys;
using SolutionWarriors.UI.EntityFramework.Configuration;
using SolutionWarriors.UI.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolutionWarriors.UI.Models
{
    public class UserModel : User
    {
        public (string userName, string userNickname, string userEmail, UserAcessLevel UserAcessLevel) GetCredentials(string userEmail)
        {
            if (string.IsNullOrEmpty(userEmail))
                throw new ArgumentNullException("User email or User password are equal to null.");

            using (var context = new SolutionContext())
            {
                var query = context.User
                    .FirstOrDefault(a => a.UserEmail == userEmail);

                return (query.UserName, query.UserNickname, query.UserEmail, query.UserAcessLevel);
            }
        }

        public UserAuthorized VerifyUser(AccountModel login)
        {
            if (string.IsNullOrEmpty(login.UserEmail) && string.IsNullOrEmpty(login.UserPassword))
                throw new ArgumentNullException("User email and User password are equal to null.");

            if (string.IsNullOrEmpty(login.UserPassword) || string.IsNullOrEmpty(login.UserEmail))
                throw new ArgumentNullException("User email or User password are equal to null.");

            using (var context = new SolutionContext())
            {
                var user = context.User
                    .FirstOrDefault(a => a.UserEmail == login.UserEmail);

                if (user == null)
                    return UserAuthorized.NotFound;

                var userAuthorized = new Account().VerifyPasswordHash(login.UserPassword, user.UserPasswordHash, user.UserPasswordSalt);

                if (!userAuthorized)
                    return UserAuthorized.Unauthorized;

                return UserAuthorized.Authorized;
            }
        }

        public void RegisterUser(AccountModel account)
        {
            if (string.IsNullOrEmpty(account.UserName) || string.IsNullOrEmpty(account.UserEmail) ||
                string.IsNullOrEmpty(account.UserNickname) || string.IsNullOrEmpty(account.UserPassword))

                throw new ArgumentNullException("Invalid data to create a new user.");

            (byte[] hash, byte[] salt) = new Account().GenerateHMACSHA512Hash(account.UserPassword);

            using (var context = new SolutionContext())
            {
                context.Add(new UserModel
                {
                    UserName = account.UserName,
                    UserEmail = account.UserEmail,
                    UserNickname = account.UserNickname,
                    UserAcessLevel = account.UserAcessLevel,
                    UserPasswordHash = hash,
                    UserPasswordSalt = salt,
                    UserRegisterDate = DateTime.Now,
                    UserLastUpdate = DateTime.Now,
                });

                context.SaveChanges();
            }
        }

        public void UpdateUser(AccountModel user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.UserEmail) ||
                string.IsNullOrEmpty(user.UserNickname))

                throw new ArgumentNullException("Invalid data to update the user.");

            using (var context = new SolutionContext())
            {
                var userUpdate = context.User
                    .FirstOrDefault(a => a.UserId == user.UserId);

                userUpdate.UserName = user.UserName;

                userUpdate.UserNickname = user.UserNickname;

                userUpdate.UserEmail = user.UserEmail;

                UserAcessLevel = user.UserAcessLevel;

                userUpdate.UserLastUpdate = DateTime.Now;

                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var context = new SolutionContext())
            {
                context.Remove(new UserModel
                {
                    UserId = id
                });

                context.SaveChanges();
            }
        }

        public List<UserModel> GetUser()
        {
            using (var context = new SolutionContext())
            {
                return context.User.ToList();
            }
        }

        public UserModel GetUser(int id)
        {
            using (var context = new SolutionContext())
            {
                var user = context.User
                    .FirstOrDefault(a => a.UserId == id);

                return user;
            }
        }

    }
}
