using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    public class Activator : IActivator
    {
        public Func<double, double> Function { get; set; }
        public Func<double, double> Derivative { get; set; }
    }
}
