using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Data;
using OA.Repo;

namespace OA.Service
{
    public class UserService : IUserService
    {
        private IRepository<User> userRepository;
        private IRepository<UserProfile> userProfileRepository;

        public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            var userProfile = userProfileRepository.Get(id);
            userProfileRepository.Remove(userProfile);
            var user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }
    }
}
