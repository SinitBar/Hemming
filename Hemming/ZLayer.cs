using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    internal class ZLayer : NeuronLayer
    {
        double Epsilon;
        double[,] W; // weights matrix of connections of S-layer to Z-layer
        double k1; // constant parametr // k1 = 1 / (amount of S-neurons + 1)

        public ZLayer(int amountOfSNeurons, List<int[,]> samples, double epsilon = 0.25, double k1 = 0) // 1/4 = 0.25, n = 4 by default
        {
            int rowCount = amountOfSNeurons;
            int columnCount = samples.Count;

            if (k1 == 0)
                this.k1 = 1d / (amountOfSNeurons + 1);
            else
                this.k1 = k1;

            if (this.k1 <= 0)
                throw new ArgumentOutOfRangeException("Constant parametr k1 should be positive");

            Epsilon = epsilon;

            if (Epsilon < 0 || Epsilon > 1d / columnCount)
                throw new ArgumentOutOfRangeException("Epsilon should satisfy the condition: " + 
                    "0 < Epsilon <= 1/n (where n is amount of reference samples)");

            fillW(rowCount, columnCount, samples);
        }

        void fillW(int rowCount, int columnCount, List<int[,]> samples)
        {
            W = new double[rowCount, columnCount];

            int samplesColumnCount = samples[0].GetLength(1);

            // every sample goes as a column and every element of it is divided by 2
            // j column of W is sample[j]
            // sample is int[,] so it's indexes are counted like i = i / samplesColumnCount
            // and j = i % samplesColumnCount
            for (int j = 0; j < columnCount; j++)
                for (int i = 0; i < rowCount; i++)
                    W[i, j] = (double)(samples[j]
                        [i / samplesColumnCount, i % samplesColumnCount]) / 2d;
        }

        public override double[] FormInputSignal(double[] input)
        {
            double[] ZInputSignal = new double[W.GetLength(1)];
            double ZNeuronsOffset = ((double)W.GetLength(0)) / 2;
            for (int k = 0; k < ZInputSignal.Length; k++)
            {
                ZInputSignal[k] = ZNeuronsOffset;
                for (int i = 0; i < W.GetLength(0); i++)
                    ZInputSignal[k] += W[i, k] * input[i];
            }

            return ZInputSignal;
        }

        public override double[] FormOutputSignal(double[] input)
        {
            double Umax = 1d / k1;

            double[] ZOutputSignal = new double[W.GetLength(1)];

            for (int i = 0; i < W.GetLength(1); i++)
            {
                if (input[i] <= 0)
                    ZOutputSignal[i] = 0;
                else if (input[i] > Umax)
                    ZOutputSignal[i] = Umax;
                else
                    ZOutputSignal[i] = input[i] * k1;
            }

            return ZOutputSignal;
        }
    }
}
