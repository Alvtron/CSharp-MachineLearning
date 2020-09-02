using Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    public class Weights
    {
        private Matrix[] Data { get; set; }

        public int Count => Data.Length;

        public Weights(int layers)
        {
            Data = new Matrix[layers - 1];
        }

        public Matrix this[int layer]
        {
            get => Data[layer - 1];
            set => Data[layer - 1] = value;
        }
    }
}
