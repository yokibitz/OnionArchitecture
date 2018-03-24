﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Data;
using OA.Repo;

namespace OA.Service
{
    public class UserProfileService : IUserProfileService
    {
        private IRepository<UserProfile> userProfileRepository;

        public UserProfileService(IRepository<UserProfile> userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        public UserProfile GetUserProfile(long id)
        {
            return userProfileRepository.Get(id);
        }
    }
}
