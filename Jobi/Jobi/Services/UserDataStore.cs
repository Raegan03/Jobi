using Jobi.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Jobi.Helpers
{
    public class UserDataStore
    {
        public bool IsUserRegistered => User.Nickname != null;
        public User User { get; private set; }

        private readonly string _userDataPath;

        public UserDataStore()
        {
            _userDataPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "user.json");

            User = new User();
            if(File.Exists(_userDataPath))
            {
                var userJson = File.ReadAllText(_userDataPath);
                User = JsonConvert.DeserializeObject<User>(userJson);
            }
        }

        public void RegisterUser(User user)
        {
            User = user;
            SaveUser();
        }

        public void FlushUser()
        {
            User = new User();
            SaveUser();
        }

        private void SaveUser()
        {
            var userJson = JsonConvert.SerializeObject(User);
            File.WriteAllText(_userDataPath, userJson);
        }
    }
}
