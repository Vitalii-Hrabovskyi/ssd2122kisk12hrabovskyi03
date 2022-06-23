using System;

namespace DPPS.CommandsResolvers
{
    public static class VersionResolver
    {
        public static void GetVersion()
        {
            Console.WriteLine(Constants.Version);
        }
    }
}
