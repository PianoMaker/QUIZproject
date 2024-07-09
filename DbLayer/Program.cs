
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace DbLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start project from Elf_Games point!");


            // Команда створення міграції:
            // Add-Migration InitialMigration (на цей момент бази не повинно існувати! Команди Ensure Created() та EnsureDeleted() вимкнути!;)
            // запускати з DbLayer, подбати щоб там був appsettings.json
            // Команда для внесення змін:
            // Add-Migration [яка-небудь інша назва]
            // Команда оновити базу:
            // Update-Database
        }
    }
}
