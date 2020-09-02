using Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    public class Neurons
    {
        private Matrix[] Data { get; set; }

        public int Count => Data.Length;

        public Neurons(int layers)
        {
            Data = new Matrix[layers];
        }

        public Matrix this[int layer]
        {
            get => Data[layer];
            set => Data[layer] = value;
        }
    }
}
