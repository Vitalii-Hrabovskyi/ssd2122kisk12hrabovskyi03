using System;

namespace DPPS.CommandsResolvers
{
    public static class HelpResolver
    {
        public static void GetHelpInfo()
        {
            Console.WriteLine("-sf, --seqfile - SF location");
            Console.WriteLine("-s, --sequence - sequence formula when file not provided");
            Console.WriteLine("-n, --number - sequence elements quantity to generate");
            Console.WriteLine("-h, --help - user help");
            Console.WriteLine("-v, --version - tool version");
            Console.WriteLine("stop - exit from program");
        }
    }
}
