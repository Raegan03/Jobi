using Jobi.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Jobi.Helpers
{
    public class UserHelper
    {
        public bool IsUserRegistered => _user.Nickname != null;
        public string UserNickname => _user.Nickname;

        private User _user;
        private readonly string _userDataPath;

        public UserHelper()
        {
            _userDataPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "user.json");

            _user = new User();
            if(File.Exists(_userDataPath))
            {
                var userJson = File.ReadAllText(_userDataPath);
                _user = JsonConvert.DeserializeObject<User>(userJson);
            }
        }

        public void RegisterUser(User user)
        {
            _user = user;
            SaveUser();
        }

        private void SaveUser()
        {
            var userJson = JsonConvert.SerializeObject(_user);
            File.WriteAllText(_userDataPath, userJson);
        }
    }
}
