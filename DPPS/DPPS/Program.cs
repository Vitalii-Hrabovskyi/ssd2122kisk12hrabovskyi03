using DPPS.CommandsResolvers;
using System;
using System.Linq;

namespace DPPS
{
    class Program
    {
        static void Main(string[] args)
        {
            Program instanse = new Program();
            instanse.StartProgram();
        }

        public void StartProgram()
        {
            Console.WriteLine(Constants.InputCommand + Environment.NewLine);
            
            while (true)
            {
                try
                {
                    string inputLine = Console.ReadLine();
                    var commands = inputLine.Split(' ');
                    SequenceFileResolver fileResolver = new SequenceFileResolver();

                    if (commands.Length > 1)
                    {
                        if (commands.FirstOrDefault(x => x == "-sf" || x == "--seqfile" || x == "-s" || x == "-sequence") == null)
                        {
                            Console.WriteLine(Constants.EnterSequenseCommand + Environment.NewLine);
                            continue;
                        }

                        if (commands.FirstOrDefault(x => x == "-n" || x == "--number") == null)
                        {
                            Console.WriteLine(Constants.EnterSequenseNumberCommand + Environment.NewLine);
                            continue;
                        }

                        if (commands.FirstOrDefault(x => x == "-sf" || x == "--seqfile") != null 
                            && commands.FirstOrDefault(x => x == "-s" || x == "-sequence") != null)
                        {
                            fileResolver.isGenerateFile = true;
                        }

                        var numberCommand = commands.FirstOrDefault(x => x == "-n" || x == "--number");
                        var numberParameter = commands[Array.IndexOf(commands, numberCommand) + 1];

                        if (!Int32.TryParse(numberParameter, out int res))
                        {
                            Console.WriteLine(Constants.InvalidNumberParameter + Environment.NewLine);
                        }
                        else
                        {
                            fileResolver.NumberOfSequence = res;
                        }
                    }
                 
                    string command = inputLine.Split(' ')[0];
                    switch (command)
                    {
                        case "-sf":
                        case "--seqfile":
                            var fileCommand = commands.FirstOrDefault(x => x == "-sf" || x == "--seqfile");
                            var fileParameter = commands[Array.IndexOf(commands, fileCommand) + 1];

                            fileResolver.LoadFile(fileParameter);
                            fileResolver.CalculateSequenceByMyParser();
                            break;

                        case "-s":
                        case "-sequence":
                            var seqCommand = commands.FirstOrDefault(x => x == "-s" || x == "-sequence");
                            var seqParameter = commands[Array.IndexOf(commands, seqCommand) + 1];
                            
                            fileResolver.Expression = seqParameter;
                            fileResolver.CalculateSequenceByMyParser();
                            break;

                        case "-h":
                        case "--help":
                            HelpResolver.GetHelpInfo();
                            break;

                        case "-v":
                        case "--version":
                            VersionResolver.GetVersion();
                            break;

                        case "stop":
                            return;

                        default:
                            HelpResolver.GetHelpInfo();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }               
            }
        }
    }
}
