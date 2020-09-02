using System;
using System.Collections.Generic;

namespace AI
{
    public static class Activators
    {
        public static Activator Linear => new Activator
        {
            Function = LinearFunction,
            Derivative = LinearDerivative
        };

        public static Activator BinaryStep => new Activator
        {
            Function = BinaryStepFunction
        };


        public static Activator Logistic => new Activator
        {
            Function = LogisticFunction,
            Derivative = LogisticDerivative
        };

        public static Activator InverseTangent => new Activator
        {
            Function = InverseTangentFunction,
            Derivative = InverseTangentDerivative
        };

        public static Activator HyperbolicTangent => new Activator
        {
            Function = HyperbolicTangentFunction,
            Derivative = HyperbolicTangentDerivative
        };

        public static Activator ReLU => new Activator
        {
            Function = ReLUFunction,
            Derivative = ReLUDerivative
        };

        public static Activator LeakyReLU => new Activator
        {
            Function = LeakyReLUFunction,
            Derivative = LeakyReLUDerivative
        };

        public static Activator Sigmoid => new Activator
        {
            Function = SigmoidFunction,
            Derivative = SigmoidDerivative
        };

        public static Activator SoftPlus => new Activator
        {
            Function = SoftPlusFunction,
            Derivative = SoftPlusDerivative
        };

        public static Activator BentIdentity => new Activator
        {
            Function = BentIdentityFunction,
            Derivative = BentIdentityDerivative
        };

        public static Activator Sinusoid => new Activator
        {
            Function = SinusoidFunction,
            Derivative = SinusoidDerivative
        };

        public static Activator Sinc => new Activator
        {
            Function = SincFunction,
            Derivative = SincDerivative
        };

        public static Activator Gaussian => new Activator
        {
            Function = GaussianFunction,
            Derivative = GaussianDerivative
        };

        public static Activator BipolarSigmoid => new Activator
        {
            Function = BipolarSigmoidFunction,
            Derivative = BipolarSigmoidDerivative
        };

        private static readonly Func<double, double> LinearFunction = x => x;
        private static readonly Func<double, double> LinearDerivative = x => x;

        private static readonly Func<double, double> BinaryStepFunction = x => x < 0 ? 0 : 1;

        private static readonly Func<double, double> LogisticFunction = x => 1 / (1 + Math.Pow(Math.E, -x));
        private static readonly Func<double, double> LogisticDerivative = x => LogisticFunction(x) * (1 - LogisticFunction(x));

        private static readonly Func<double, double> InverseTangentFunction = x => Math.Atan(x);
        private static readonly Func<double, double> InverseTangentDerivative = x => 1 / Math.Pow(x, 2) + 1;

        private static readonly Func<double, double> HyperbolicTangentFunction = Math.Tanh;
        private static readonly Func<double, double> HyperbolicTangentDerivative = x => 1 - Math.Pow(Math.Tanh(x), 2);

        private static readonly Func<double, double> ReLUFunction = x => Math.Max(0, x);
        private static readonly Func<double, double> ReLUDerivative = x => x < 0 ? 0 : 1;

        private static readonly Func<double, double> LeakyReLUFunction = x => x > 0 ? x : 0.01 * x;
        private static readonly Func<double, double> LeakyReLUDerivative = x => x > 0 ? 1 : 0.01;

        private static readonly Func<double, double> SigmoidFunction = x => 1 / (1 + Math.Exp(-x));
        private static readonly Func<double, double> SigmoidDerivative = x => SigmoidFunction(x) * (1 - SigmoidFunction(x));

        private static readonly Func<double, double> SoftPlusFunction = x => Math.Log(Math.Exp(x) + 1);
        private static readonly Func<double, double> SoftPlusDerivative = x => LogisticFunction(x);

        private static readonly Func<double, double> BentIdentityFunction = x => ((Math.Sqrt(Math.Pow(x, 2) + 1) - 1) / 2) + x;
        private static readonly Func<double, double> BentIdentityDerivative = x => (x / (2 * Math.Sqrt(Math.Pow(x, 2) + 1))) + 1;

        private static readonly Func<double, double> SinusoidFunction = x => Math.Sin(x);
        private static readonly Func<double, double> SinusoidDerivative = x => Math.Cos(x);

        private static readonly Func<double, double> SincFunction = x => x == 0 ? 1 : Math.Sin(x) / x;
        private static readonly Func<double, double> SincDerivative = x => x == 0 ? 0 : (Math.Cos(x) / x) - (Math.Sin(x) / Math.Pow(x, 2));

        private static readonly Func<double, double> GaussianFunction = x => Math.Pow(Math.E, Math.Pow(-x, 2));
        private static readonly Func<double, double> GaussianDerivative = x => -2 * x * Math.Pow(Math.E, Math.Pow(-x, 2));

        private static readonly Func<double, double> BipolarSigmoidFunction = x => (1 - Math.Exp(-x)) / (1 + Math.Exp(-x));
        private static readonly Func<double, double> BipolarSigmoidDerivative = x => 0.5 * (1 + BipolarSigmoidFunction(x)) * (1 - BipolarSigmoidFunction(x));
    }
}
