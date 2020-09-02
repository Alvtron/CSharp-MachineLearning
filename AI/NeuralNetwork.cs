using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Library;

namespace AI
{
    public class NeuralNetwork
    {
        private bool _printInfo;

        private IActivator Activator { get; set; }

        private Neurons Neurons { get; set; }

        private Z Z { get; set; }

        private Weights Weights { get; set; }

        private Bias Bias { get; set; }

        public int Layers { get; private set; }

        public Dataset Dataset { get; private set; }

        public TrainingResult TrainingResult = new TrainingResult();

        public double LearningRate { get; }
        public int Iterations { get; }

        public NeuralNetwork(IActivator activator, double learningRate = 0.7, int iterations = 1, bool printInfo = false)
        {
            Activator = activator;
            LearningRate = learningRate;
            Iterations = iterations;
            _printInfo = printInfo;
        }

        private void Forward(Matrix input)
        {
            Neurons[0] = new Matrix(input.Data);
            
            for (var layer = 1; layer < Layers; layer++)
            {
                Z[layer] = Matrix.Dot(Weights[layer], Neurons[layer - 1]) + Bias[layer];
                Neurons[layer] = Z[layer].Transform(Activator.Function);
            }
        }

        private Gradients Backward(Sample sample)
        {
            var gradients = new Gradients(Layers);

            gradients.Dz[Layers - 1] = Neurons[Layers - 1] - sample.Output;
            gradients.Dw[Layers - 1] = Matrix.Dot(gradients.Dz[Layers - 1], Neurons[Layers - 2].Transpose);
            gradients.Db[Layers - 1] = gradients.Dz[Layers - 1];

            for (var layer = Layers - 2; layer > 0; layer--)
            {
                gradients.Dz[layer] = Matrix.Dot(Weights[layer + 1].Transpose, gradients.Dz[layer + 1]) * Z[layer].Transform(Activator.Derivative);
                gradients.Dw[layer] = Matrix.Dot(gradients.Dz[layer], Neurons[layer - 1].Transpose);
                gradients.Db[layer] = gradients.Dz[layer];
            }

            return gradients;
        }

        private void Adjust(Gradients gradients)
        {
            for (var layer = 1; layer < Layers; layer++)
            {
                var dw = gradients.Dw[layer] * LearningRate;
                Weights[layer] = Weights[layer] + dw;
                var db = gradients.Db[layer] * LearningRate;
                Bias[layer] = Bias[layer] + db;
            }
        }

        public void CreateNetwork(Dataset dataset, int layers = 3)
        {
            if (dataset == null || dataset.Count == 0)
                throw new InvalidOperationException("Training set is empty.");
            if (dataset.Features == 0 || dataset.Classes == 0)
                throw new InvalidOperationException("Training set is empty.");
            if (layers < 3)
                throw new InvalidOperationException("Invalid layer size. Must be at least 3.");

            Dataset = dataset;
            Layers = layers;
            Neurons = new Neurons(layers);
            Z = new Z(layers);
            Weights = new Weights(layers);
            Bias = new Bias(layers);

            var numberONeuronsList = new int[layers];
            numberONeuronsList[0] = Dataset.Features;
            for (var l = 1; l < layers - 1; l++)
            {
                numberONeuronsList[l] = NumberOfHiddenNeurons(Dataset.Samples, numberONeuronsList[0], Dataset.Classes, 2);
            }
            numberONeuronsList[layers - 1] = Dataset.Classes;

            if (numberONeuronsList.Any(neurons => neurons < 1))
                throw new InvalidOperationException("Not enough training data or too many layers!");

            for (var l = 1; l < Layers; l++)
            {
                Weights[l] = CreateWeights(numberONeuronsList[l], numberONeuronsList[l - 1]);
                Bias[l] = CreateBias(numberONeuronsList[l]);
            }
        }

        public void Train()
        {
            for (var iteration = 0; iteration < Iterations; iteration++)
            {
                foreach (var sample in Dataset)
                {
                    Forward(sample.Input);
                    var gradients = Backward(sample);

                    Debug.WriteLineIf(_printInfo, $"{Neurons[Layers - 1]} =? {sample.Output}");
                    TrainingResult.History.Add(Matrix.Similarity(Neurons[Layers - 1], sample.Output));

                    Adjust(gradients);
                }
            }
        }

        // W[n] = N[l] x N[l-1] matrix
        private Matrix CreateWeights(int nodesInLayer, int nodesInPreviousLayer)
        {
            return Matrix.Random(nodesInLayer, nodesInPreviousLayer, - (1.0 / Math.Sqrt(nodesInLayer)), 1.0 / Math.Sqrt(nodesInLayer), 0, null);
        }

        // B[n] = N[l] x 1
        private Matrix CreateBias(int nodesInLayer)
        {
            return Matrix.Constant(nodesInLayer, 1, 1.0);
        }

        public Matrix Solve(double[] input)
        {
            Forward(new Matrix(input, Matrix.Orientation.Column));
            return Neurons[Layers - 1];
        }

        private static int NumberOfHiddenNeurons(int numberOfSamples, int numberOfInputNeurons, int numberOfOutputNeurons, double alpha)
            => (int)Math.Ceiling(numberOfSamples / (alpha * (numberOfInputNeurons + numberOfOutputNeurons)));

        public string NetworkInfo()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("\nNeuron sizes: -----------------------------");
            stringBuilder.AppendLine($"Number of samples:       {Dataset.Samples}");
            stringBuilder.AppendLine($"inputs:                  {Dataset.Features}");
            stringBuilder.AppendLine($"outputs:                 {Dataset.Classes}");
            stringBuilder.AppendLine("\nMatrix dimensions: ------------------------");
            stringBuilder.AppendLine($"Input:                   {Dataset.Features}x{Dataset.Classes}");
            for (var i = 1; i < Layers; i++)
            {
                stringBuilder.AppendLine($"Weight[{i}]:               {Weights[i].Rows}x{Weights[i].Columns}");
                stringBuilder.AppendLine($"Bias[{i}]:                 {Bias[i].Rows}x{Bias[i].Columns}");
            }
            stringBuilder.AppendLine($"Output:                  {Dataset.Classes}x{Dataset.Classes}");

            return stringBuilder.ToString();
        }
    }
}
