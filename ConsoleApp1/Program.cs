using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=learn_devexpress;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
                Console.WriteLine($"\tБаза данных: {connection.Database}");
                Console.WriteLine($"\tСервер: {connection.DataSource}");
                Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
                Console.WriteLine($"\tСостояние: {connection.State}");
                Console.WriteLine($"\tWorkstationld: {connection.WorkstationId}");
            }
            Console.WriteLine("Подключение закрыто...");
            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }
    }
}