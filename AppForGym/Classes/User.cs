using AppForGym.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForGym.Classes
{
    public class User
    {
        public static readonly List<string> Tariffs = new List<string>() { "5 дней", "10 дней", "Месяц", "3 месяца", "6 месяцев", "Год" };

        public static int increment = UserDB.GetUsers().Count;
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public DateTime LastPayment { get; set; }

        public int TariffIndex { get; set; }

        private int _daysLeft;

        public int DaysLeft
        {
            get
            {
                TimeSpan duration;

                switch (TariffIndex)
                {
                    case 0:
                        duration = LastPayment.AddDays(5).Subtract(DateTime.Now);
                        _daysLeft = duration.Days;
                        break;

                    case 1:
                        duration = LastPayment.AddDays(10).Subtract(DateTime.Now);
                        _daysLeft = duration.Days;
                        break;

                    case 2:
                        duration = LastPayment.AddMonths(1).Subtract(DateTime.Now);
                        _daysLeft = duration.Days;
                        break;

                    case 3:
                        duration = LastPayment.AddMonths(3).Subtract(DateTime.Now);
                        _daysLeft = duration.Days;
                        break;

                    case 4:
                        duration = LastPayment.AddMonths(6).Subtract(DateTime.Now);
                        _daysLeft = duration.Days;
                        break;

                    case 5:
                        duration = LastPayment.AddYears(1).Subtract(DateTime.Now);
                        _daysLeft = duration.Days;
                        break;

                    default:
                        break;
                }

                if (_daysLeft < 0)
                {
                    return 0;
                }

                return _daysLeft;
            }
            private set
            {
                _daysLeft = value;
            }
        }

        public List<DateTime> MarkDates { get; set; }

        public User() { }

        public User(int id, string surname, string name, string patronymic, DateTime lastPay, int tariffId, List<DateTime> markDates)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
            TariffIndex = tariffId;
            MarkDates = markDates;
        }

        public User(string surname, string name, string patronymic, DateTime lastPay, int tariffId, List<DateTime> markDates)
        {
            Id = increment;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
            TariffIndex = tariffId;
            MarkDates = markDates;
        }

        public User(int id, string surname, string name, string patronymic, DateTime lastPay)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
        }

        public User(int id, string surname, string name, string patronymic, DateTime lastPay, int tariffId)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
            TariffIndex = tariffId;
        }

        public User(string surname, string name, string patronymic, DateTime lastPay, int tariffId)
        {
            Id = increment;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            LastPayment = lastPay;
            TariffIndex = tariffId;
        }

    }
}
