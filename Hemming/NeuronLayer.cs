using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace Hemming
{
    /**
     * class NeuronLayer represents a layer of neurons and realizes interfaces of forming
     * input and output signals
     */
    internal abstract class NeuronLayer: IInputNeuronSignal, IOutputNeuronSignal
    {
        /**
         * FormInputSignal forms input signal for the layer taking input data
         */
        public virtual double[] FormInputSignal(double[] input)
        {
            return input;
        }

        /**
         * FormOutputSignal forms output signal for the layer taking input signal
         * this functions is function of activation
         */
        public virtual double[] FormOutputSignal(double[] input)
        {
            return input;
        }

        /**
         * GetOutputSignal is used when there is no need in intermadiate results
         */
        public double[] GetOutputSignal(int[,] inputSignal)
        {
            return FormOutputSignal(FormInputSignal(Converters.toDoubleArray(inputSignal)));
        }

    }
}
