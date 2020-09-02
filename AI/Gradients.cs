using Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    public struct Gradients
    {
        public Z Dz { get; set; }
        public Weights Dw { get; set; }
        public Bias Db { get; set; }

        public Gradients(int layers)
        {
            Dz = new Z(layers);
            Dw = new Weights(layers);
            Db = new Bias(layers);
        }
    }
}
