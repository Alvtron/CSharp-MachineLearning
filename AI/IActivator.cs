using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    public interface IActivator
    {
        Func<double, double> Function { get; set; }
        Func<double, double> Derivative { get; set; }
    }
}
