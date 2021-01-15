using System;
using System.IO;
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
        public Model.User User { get; }
    /// <summary>
    /// Создание Котроллера.
    /// </summary>
    /// <param name="user">Пользователь.</param>
        public UserController(string userName, string GenderName,DateTime birthDay, double weight, double height)
        {
            // TODO: Проверка
            var gender = new Model.Gender(GenderName);
            User = new Model.User(userName, gender, birthDay, weight, height); 
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is Model.User user)
                {
                    User = user;
                }
                // TODO: Что делать, если пользователь не найден?
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>ПОльзователь.</returns>
       
    }
}
