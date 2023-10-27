using AppForGym.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForGym.Database
{
    public class UserDB
    {
        private static List<User> users = new List<User>();

        static UserDB()
        {
            users.Add(new User(1, "Биба", "Биба", "Бибачов", DateTime.Parse("20.09.2023"), 1, new List<DateTime> { DateTime.Parse("20.09.2023"), DateTime.Parse("21.09.2023"), DateTime.Parse("22.09.2023") }));
            users.Add(new User(2, "Боба", "Боба", "Бобачов", DateTime.Parse("19.09.2023"), 2, new List<DateTime> { DateTime.Parse("20.09.2023"), DateTime.Parse("21.09.2023"), DateTime.Parse("22.09.2023") }));
            users.Add(new User(3, "Петров", "Петр", "Петрович", DateTime.Parse("18.09.2023"), 2, new List<DateTime> { DateTime.Parse("20.09.2023"), DateTime.Parse("21.09.2023"), DateTime.Parse("22.09.2023") }));
            users.Add(new User(4, "Пупкин", "Василий", "Игорьевич", DateTime.Parse("19.09.2023"), 3, new List<DateTime> { DateTime.Parse("20.09.2023"), DateTime.Parse("21.09.2023"), DateTime.Parse("22.09.2023") }));
        }

        public static List<User> GetUsers()
        {
            return users;
        }

        public static User Add(string surname, string name, string patronymic, DateTime lastPay, int tariffId)
        {
            User newUser = new User(surname, name, patronymic, lastPay, tariffId);
            users.Add(newUser);
            return newUser;
        }

        public static void Delete(int id)
        {
            users.Remove(users[id - 1]);
        }

        public static void Update(int id, string surname, string name, string patronymic, DateTime lastPay, int tariffId)
        {
            users[id - 1] = new User(id, surname, name, patronymic, lastPay, tariffId);
        }


    }
}
