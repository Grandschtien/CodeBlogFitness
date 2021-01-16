using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{ 
/// <summary>
/// Контроллер пользователя.
/// </summary>
    public class UserController
    {
    /// <summary>
    /// Пользователь.
    /// </summary>
        public List<Model.User> Users { get; }
        public Model.User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

    /// <summary>
    /// Создание Котроллера.
    /// </summary>
    /// <param name="user">Пользователь.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersDate();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new Model.User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохранненый список пользователей.
        /// </summary>
        /// <returns>Коллекцию пользователей.</returns>
        private List<Model.User> GetUsersDate()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (fs.Length > 0 && formatter.Deserialize(fs) is List<Model.User> users)
                {
                    return users;
                }
                else
                {
                    return new List<Model.User>();
                }
            }
           
        }

        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            // TODO: Проверка

            CurrentUser.Gender = new Model.Gender(genderName);
            CurrentUser.BirthDate = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
       
    }
}
