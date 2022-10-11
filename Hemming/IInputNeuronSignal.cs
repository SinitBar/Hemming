using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    /**
     * interface IInputNeuronSignal represents tools of input signal processing
     */
    internal interface IInputNeuronSignal
    {
        /**
         * function FormInputSignal forms input signal from input data
         */
        public abstract double[] FormInputSignal(double[] input);
    }
}
