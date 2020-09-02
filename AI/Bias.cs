using Library;

namespace AI
{
    public class Bias
    {
        private Matrix[] Data { get; set; }

        public int Count => Data.Length;

        public Bias(int layers)
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
