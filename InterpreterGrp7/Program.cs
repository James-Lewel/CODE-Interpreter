using System;
using System.IO;
using System.Threading;

namespace InterpreterGrp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(" > ");

                var input = Console.ReadLine().Split(' ');

                if (!CheckCommand(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" > [Error] : '" + input[0] + "' is an invalid command. Type 'help'.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" >");
                }
            }

            Console.ReadLine();
        }

        static bool CheckCommand(string[] args)
        {
            // Get base directory
            var basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            // Get sample programs directory
            var samplePath = basePath + "\\Sample Programs";
            
            // Checks listed commands
            switch (args[0].ToLower())
            {
                case "start":
                    {
                        try
                        {
                            if (!args[1].Contains(".txt"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" > [Error] : Specify a file type.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" > [Usage] : start [<file_name><file_type>].  Type 'start -help'.");
                                Console.WriteLine(" >");
                                return true;
                            }
                            else if (args[1] == "-help")
                            {
                                Console.WriteLine(" > [Usage] : start [<file_name><file_type>]. Type 'start -help'.");
                                Console.WriteLine(" >");
                                return true;
                            }


                            var programPath = samplePath + '\\' + args[1];

                            try
                            {
                                Console.WriteLine();
                                foreach (string line in System.IO.File.ReadLines(programPath.ToString()))
                                {
                                    Console.WriteLine(line);
                                }
                                Console.WriteLine();
                            }
                            catch (FileNotFoundException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" > [Error] : File does not exist. in '" + programPath + "'");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" >");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" > [Error] : Specify a file name.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" > [Usage] : start [<file_name>.txt].  Type 'start -help'.");
                            Console.WriteLine(" >");

                        }

                        return true;
                    }

                case "create":
                    {
                        try
                        {
                            var fileName = args[1];
                            var filePath = samplePath + '\\' + fileName;

                            if (!fileName.Contains(".txt"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" > [Error] : Specify a file type.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" > [Usage] : create [<file_name><file_type>].  Type 'create -help'.");
                                Console.WriteLine(" >");
                                return true;
                            }

                            if (File.Exists(filePath))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" > [Error] : File already exist.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" >");
                            }
                            else
                            {
                                Console.WriteLine(" > [Created] : " + fileName);
                                Console.WriteLine(" >");
                                using (StreamWriter streamWriter = File.CreateText(filePath))
                                {
                                    streamWriter.WriteLine("Test");
                                }
                            }
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" > [Error] : Specify a file name.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" > [Usage] : delete [<file_name>.txt].  Type 'delete -help'.");
                            Console.WriteLine(" >");
                        }

                        return true;
                    }

                case "read":
                    {

                        return true;
                    }

                case "update":
                    {

                        return true;
                    }

                case "delete":
                    {
                        try
                        {
                            var fileName = args[1];
                            var filePath = samplePath + '\\' + fileName;

                            if (!fileName.Contains(".txt"))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" > [Error] : Specify a file type.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" > [Usage] : delete [<file_name><file_type>].  Type 'delete -help'.");
                                Console.WriteLine(" >");
                                return true;
                            }

                            if (File.Exists(filePath))
                            {
                                Console.WriteLine(" > [Deleted] : " + fileName);
                                Console.WriteLine(" >");
                                File.Delete(filePath);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(" > [Error] : File does not exist.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" >");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" > [Error] : Specify a file name.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" > [Usage] : delete [<file_name>.txt].  Type 'delete -help'.");
                            Console.WriteLine(" >");
                        }

                        return true;
                    }


                case "help":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" > [Commands] :");
                        Console.WriteLine(" > \t- start [<file_name>.txt] \t - \tStarts the program");
                        Console.WriteLine(" > \t- cls \t\t\t\t - \tClears terminal");
                        Console.WriteLine(" > \t- exit \t\t\t\t - \tExits the program");
                        Console.WriteLine(" > Note: Type '-help' after the command for further information.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" >");
                        return true;
                    }

                case "clear":
                    {
                        Console.Clear();
                        return true;
                    }

                case "exit":
                    {
                        Console.WriteLine(" >");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" > [Exiting] .");

                        for (int i = 0; i < 3; i++)
                        {
                            Thread.Sleep(1000);
                            Console.Write(" .");
                        }

                        Environment.Exit(0);
                        break;
                    }
            }

            // If args is invalid
            return false;
        }
    }
}
