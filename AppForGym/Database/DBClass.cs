using AppForGym.Classes;
using AppForGym.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppForGym.Database
{
    public static class DBClass
    {
        private static string _connectionString = string.Empty;

        public static string ConnectionString { get; set; }

        public static async Task SP_AddClient(string surname, string name, string patronymic, DateTime lastPaymentDate, int idTariff)
        {
            string sqlExpression = "sp_AddClient";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter surnameParam = new SqlParameter
                {
                    ParameterName = "@surname",
                    Value = surname
                };

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };

                SqlParameter patronymicParam = new SqlParameter
                {
                    ParameterName = "@patronymic",
                    Value = patronymic
                };

                SqlParameter lastPaymentDateParam = new SqlParameter
                {
                    ParameterName = "@lastPaymentDate",
                    Value = lastPaymentDate
                };

                SqlParameter idTariffParam = new SqlParameter
                {
                    ParameterName = "@idTariff",
                    Value = idTariff
                };

                command.Parameters.AddRange(new SqlParameter[] { surnameParam, nameParam, patronymicParam, lastPaymentDateParam, idTariffParam });

                command.ExecuteNonQuery();
            }
        }

        public static async Task SP_DeleteClient(int idClient)
        {
            string sqlExpression = "sp_DeleteClient";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter idClientParam = new SqlParameter
                {
                    ParameterName = "@idClient",
                    Value = idClient
                };

                command.Parameters.Add(idClientParam);

                command.ExecuteNonQuery();
            }
        }

        public static async Task SP_UpdateClient(int idClient, string surname, string name, string patronymic, DateTime lastPaymentDate, int idTariff)
        {
            string sqlExpression = "sp_DeleteClient";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter idClientParam = new SqlParameter
                {
                    ParameterName = "@idClient",
                    Value = idClient
                };

                SqlParameter surnameParam = new SqlParameter
                {
                    ParameterName = "@surname",
                    Value = surname
                };

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };

                SqlParameter patronymicParam = new SqlParameter
                {
                    ParameterName = "@patronymic",
                    Value = patronymic
                };

                SqlParameter lastPaymentDateParam = new SqlParameter
                {
                    ParameterName = "@lastPaymentDate",
                    Value = lastPaymentDate
                };

                SqlParameter idTariffParam = new SqlParameter
                {
                    ParameterName = "@idTariff",
                    Value = idTariff
                };

                command.Parameters.AddRange(new SqlParameter[] { idClientParam, surnameParam, nameParam, patronymicParam, lastPaymentDateParam, idTariffParam });

                command.ExecuteNonQuery();
            }
        }

        public static async Task SP_AddMarkDate(int idClient, DateTime markDate )
        {
            string sqlExpression = "sp_AddMarkDate";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter idClientParam = new SqlParameter
                {
                    ParameterName = "@idClient",
                    Value = idClient
                };

                SqlParameter markDateParam = new SqlParameter
                {
                    ParameterName = "@markDate",
                    Value = markDate
                };

                command.Parameters.AddRange(new SqlParameter[] { idClientParam, markDateParam});

                command.ExecuteNonQuery();
            }
        }

        public static async Task SP_AddTariff(string name, int countOfDays, string description)
        {
            string sqlExpression = "sp_AddTariff";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };

                SqlParameter countOfDaysParam = new SqlParameter
                {
                    ParameterName = "@countOfDays",
                    Value = countOfDays
                };

                SqlParameter descriptionParam = new SqlParameter
                {
                    ParameterName = "@description",
                    Value = description
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, countOfDaysParam, descriptionParam });

                command.ExecuteNonQuery();
            }
        }

        public static async Task SP_DeleteTariff(int idTariff)
        {
            string sqlExpression = "sp_DeleteTariff";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                SqlParameter idTariffParam = new SqlParameter
                {
                    ParameterName = "@idTariff",
                    Value = idTariff
                };

                command.Parameters.Add(idTariffParam);

                command.ExecuteNonQuery();
            }
        }

        public static List<Client> GetClientsInfo()
        {
            string sqlExpression = "sp_DeleteTariff";

            List<Client> users = new List<Client>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            users.Add(new Client() { IDClient = reader.GetInt32(0), Surname = reader.GetString(1), Name = reader.GetString(2), Patronymic = reader.GetString(3), LastPaymentDate = reader.GetDateTime(4), MarkDatesCount = reader.GetInt32(5), IDTariff = reader.GetInt32(6) });
                        }
                    }
                }

                return users;
            }
        }

    }
}
