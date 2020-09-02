using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Library;

namespace AI
{
    public class Dataset : List<Sample>
    {
        public int Features { get; }
        public int Classes { get; }

        public int Samples => Count;

        public Dataset(int features, int classes)
        {
            Features = features;
            Classes = classes;
        }

        public void Add(IReadOnlyList<double> input, double output)
        {
            var inputMatrix = new Matrix(input, Matrix.Orientation.Column);
            var outputMatrix = new Matrix(output);
            Add(new Sample(inputMatrix, outputMatrix));
        }

        public void Add(IReadOnlyList<double> input, IReadOnlyList<double> output)
        {
            var inputMatrix = new Matrix(input, Matrix.Orientation.Column);
            var outputMatrix = new Matrix(output, Matrix.Orientation.Column);
            Add(new Sample(inputMatrix, outputMatrix));
        }

        public void Add(Matrix input, Matrix output)
        {
            var inputMatrix = new Matrix(input.Data);
            var outputMatrix = new Matrix(output.Data);
            Add(new Sample(inputMatrix, outputMatrix));
        }
    }

    public struct Sample
    {
        // Each column j is an example, and each row i is a feature.
        // Hence, the position (i,j) contains the feature i of the example j.
        public Matrix Input { get; }
        // Each column j represents the correct class of the example j.
        // The column is formed by zeros, and it has a 1 at the row that indicates the class.
        // If we have 6 classes, and the first example corresponds to class 3,
        // the first column of the target matrix will be [0 0 1 0 0 0].
        // If the second example corresponds to class 5, the second column of the target matrix will be: [0 0 0 0 1 0], and so on.
        public Matrix Output { get; }

        public int NumberOfFeatures => Input.Rows;
        public int NumberOfClasses => Output.Columns;

        public Sample(Matrix input, Matrix output)
        {
            Input = new Matrix(input.Data);
            Output = new Matrix(output.Data);
        }
    }
}
