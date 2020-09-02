using System;
using System.Collections.Generic;
using System.Diagnostics;
using Library;
using AI;
using AI.TrainingSamples;
using System.Linq;

namespace Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TrainNetwork();
        }

        public static void TrainNetwork()
        {
            var randomNumberGenerator = new Random(0);
            var activationFunction = Activators.Sigmoid;
            var learningRate = 0.01;
            var iterations = 100;
            var showDebugInfo = true;

            var neuralNetwork = new NeuralNetwork(activationFunction, learningRate, iterations, showDebugInfo);

            Debug.WriteLine("Generating training data...");

            var inputs = new double[][]
            {
                new double[] { 0.0, 0.0 },
                new double[] { 0.0, 1.0 },
                new double[] { 1.0, 0.0 },
                new double[] { 1.0, 1.0 },
                new double[] { 0.0, 0.0 },
                new double[] { 0.0, 1.0 },
                new double[] { 1.0, 0.0 },
                new double[] { 1.0, 1.0 },
                new double[] { 0.0, 0.0 },
                new double[] { 0.0, 1.0 },
                new double[] { 1.0, 0.0 },
                new double[] { 1.0, 1.0 },
                new double[] { 0.0, 0.0 },
                new double[] { 0.0, 1.0 },
                new double[] { 1.0, 0.0 },
                new double[] { 1.0, 1.0 },
                new double[] { 0.0, 0.0 },
                new double[] { 0.0, 1.0 },
                new double[] { 1.0, 0.0 },
                new double[] { 1.0, 1.0 }
            };

            var outputs = new double[]
            {
                0.0,
                1.0,
                1.0,
                0.0,
                0.0,
                1.0,
                1.0,
                0.0,
                0.0,
                1.0,
                1.0,
                0.0,
                0.0,
                1.0,
                1.0,
                0.0,
                0.0,
                1.0,
                1.0,
                0.0
            };

            inputs = inputs.Shuffle(new Random(0)).ToArray();
            outputs = outputs.Shuffle(new Random(0)).ToArray();

            var Dataset = new Dataset(2, 1);

            for (var index = 0; index < inputs.Length; index++)
            {
                Dataset.Add(inputs[index], outputs[index]);
            }

            //var traningSetSize = 300;
            //var characters = Alphabet.All.Values.ToArray();
            //for (var index = 0; index < traningSetSize; index++)
            //{
            //    var character = characters.Random(randomNumberGenerator);
            //    trainingSet.Add(character.Serialized, character.MapValue);
            //}

            Debug.WriteLine("Creating network...");

            neuralNetwork.CreateNetwork(Dataset, 5);

            Debug.WriteLine(neuralNetwork.NetworkInfo());

            Debug.WriteLine("Training...");

            neuralNetwork.Train();

            Debug.WriteLine($"Accuracy: {neuralNetwork.TrainingResult.History.LastOrDefault().ToString()}");
            Debug.WriteLine($"Accuracy (average): {neuralNetwork.TrainingResult.History.Average().ToString()}");


            //var testCharacter = Alphabet.All.Random();

            //Debug.WriteLine($"Guessing '{testCharacter.Value.Letter}' (value: {testCharacter.Value.MapValue})...");

            //var guess = neuralNetwork.Solve(testCharacter.Value.Serialized);

            //Debug.WriteLine($"Guessed: {guess}. Correct answer: {testCharacter.Value.MapValue}");

            var testValue = inputs.Random();

            Debug.WriteLine($"Guessing '[{testValue[0]}, {testValue[1]}]'");

            var guess = neuralNetwork.Solve(testValue);

            Debug.WriteLine($"Guessed: {guess}.");
        }
    }
}
