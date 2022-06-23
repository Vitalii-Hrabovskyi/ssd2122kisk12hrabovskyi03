using System;
using System.IO;

namespace DPPS
{
    public class ContextForParser : IContext
    {
        public ContextForParser(double x)
        {
            _x = x;
        }

        double _x;

        public double CallFunction(string name, double[] arguments)
        {
            throw new NotImplementedException();
        }

        public double ResolveVariable(string name)
        {
            switch (name)
            {
                case "pi": return Math.PI;
                case "x": return _x;
            }

            throw new InvalidDataException($"Unknown variable: '{name}'");
        }
    }
}
