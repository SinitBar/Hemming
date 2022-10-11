using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    internal class YLayer : NeuronLayer
    {
        public override double[] FormOutputSignal(double[] input)
        {
            double[] output = new double[input.Length];

            for(int i = 0; i < input.Length; i++)
                output[i] = input[i] > 0 ? 1 : 0;

            return output;
        }
    }
}
