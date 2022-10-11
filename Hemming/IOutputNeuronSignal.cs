using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    /**
     * interface IOutputNeuronSignal represents tools of output signal processing
     */
    internal interface IOutputNeuronSignal
    {
        /**
         * function FormOutputSignal forms output signal from input signal
         */
        public abstract double[] FormOutputSignal(double[] input);
    }
}
