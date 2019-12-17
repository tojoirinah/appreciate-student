using DbUp;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Appreciation.Manager.Database
{
    public class Program
    {
        static int Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AppreciationContext"].ConnectionString;
            var scriptsPath = ConfigurationManager.AppSettings["path"];


            Console.WriteLine("Start executing migration scripts...");
            var migrationScriptsPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + scriptsPath;
            var upgrader =
               DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsFromFileSystem(migrationScriptsPath)
                    .LogToConsole()
                    .LogScriptOutput()
                    //  .WithTransaction()
                    .Build();
            var scripts = upgrader.GetScriptsToExecute();

            var doUpdate = false;

            var isUpgradePerformed = true;

            if (scripts != null && scripts.Count > 0)
            {
                Console.WriteLine("Liste des patchs à appliquer :");
                foreach (var script in scripts)
                {
                    Console.WriteLine(script.Name);
                }

                Console.WriteLine();
                Console.WriteLine("Appliquer les patchs ? y or n");

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    doUpdate = true;
                }

                switch (doUpdate)
                {
                    case true:
                        var result = upgrader.PerformUpgrade();

                        if (!result.Successful)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(result.Error);
                            Console.ResetColor();

                            isUpgradePerformed = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Success!");
                            Console.ResetColor();
                        }

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPas de mise à jour demandée !");
                        Console.ResetColor();
                        break;

                }
            }
            else
            {
                Console.WriteLine("Aucun patch trouvé. La base est à jour.");
            }

            ShowSuccess();

#if DEBUG
            Console.WriteLine();
            Console.WriteLine("Appuyer sur ENTREE pour quitter.");

            Console.ReadLine();
#endif

            return isUpgradePerformed ? 0 : -1;
        }

        private static void ShowSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }

        private static int ReturnError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
            return -1;
        }
    }
}
