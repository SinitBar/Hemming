using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    internal class ALayer : NeuronLayer
    {
        double Epsilon;

        double[,] W; // weights matrix of connections of Z-layer to A-layer
        public ALayer (double epsilon = 0.25)
        {
            // here we drop weights matrix because
            // we just took one term out of brackets so we can use
            // formula in FormOutputSignal, not W matrix
            Epsilon = epsilon;
        }

        public override double[] FormOutputSignal(double[] input)
        {
            double[] outputSignal = input;

            do
            {
                input = outputSignal.Clone() as double[];

                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < input.Length; j++)
                        if (i != j)
                            outputSignal[i] += input[j];

                    outputSignal[i] *= (-Epsilon); // take into account negative feedback
                    outputSignal[i] += input[i]; // take into account connection between i and i neuron
                }

                outputSignal = signalConvert(outputSignal);

            } while (!areContainsSame(input, outputSignal));

            return outputSignal;
        }

        /**
         * function signalConvert replaces values <= 0 by zeros
         */
        double[] signalConvert(double[] signal)
        {
            double[] outputSignal = new double[signal.Length];

            for (int i = 0; i < signal.Length; i++)
                outputSignal[i] = signal[i] > 0 ? signal[i] : 0;

            return outputSignal;
        }

        /**
         * function areContainsSame checks if signal1 and signal2 are the same by element values
         */
        bool areContainsSame(double[] signal1, double[] signal2)
        {
            bool containsSame = true;

            for (int i = 0; i < signal1.Length; i++)
                if (signal1[i] != signal2[i])
                    return false;

            return containsSame;
        }
    }
}
