using System;

namespace CodeBlogFitnessBL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создание пола.
        /// </summary>
        /// <param name="name">Имя пола</param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя поле не может быть пустым или null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
