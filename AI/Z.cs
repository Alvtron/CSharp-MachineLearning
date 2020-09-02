using Library;

namespace AI
{
    public class Z
    {
        private Matrix[] Data { get; set; }

        public int Count => Data.Length;

        public Z(int layers)
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
