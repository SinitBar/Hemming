using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemming
{
    /**
     * class HemmingNet represents a structure of Hemming net and
     * realizes the Hemming algorithm in function HemmingAlgorithm
     */
    internal class HemmingNet
    {
        SLayer S_Layer;
        ZLayer Z_Layer;
        ALayer A_Layer;
        YLayer Y_Layer;

        int amountOfSamples;
        int amountOfSignalNeurons;

        double Epsilon;

        List<int[,]> samples;

        public HemmingNet(int amountOfSamples, int amountOfSignalNeurons, List<int[,]> samples, double epsilon)
        {
            this.amountOfSamples = amountOfSamples;
            this.amountOfSignalNeurons = amountOfSignalNeurons;
            S_Layer = new SLayer();
            Z_Layer = new ZLayer(amountOfSignalNeurons, samples, epsilon); // k1 could be set here too
            A_Layer = new ALayer(epsilon);
            Y_Layer = new YLayer();
            this.samples = samples;
            Epsilon = epsilon;
        }

        /**
         * function HemmingAlgorithm returns the list of indexes of samples array 
         * that are like data signal. In main case it should be 1 index. If indexes amount is
         * greater, that means algorithm can't choose between samples
         */
        public List<int> HemmingAlgorithm(int[,] inputSignal)
        {
            double[] input = S_Layer.GetOutputSignal(inputSignal);

            double[] zInput = Z_Layer.FormInputSignal(input);

            // if ZInput has two or more equal maximums, then the answer wouldn't be found
            // return all found sample's indexes that partically match the data signal
            List<int> indexes = getIndexesOfMaxElements(zInput);
            if (indexes.Count > 1)
                return indexes;

            indexes = new List<int>();

            double[] zOutput = Z_Layer.FormOutputSignal(zInput); 

            double[] aInput = zOutput.Clone() as double[];

            // if aInput has one and only one maximum, it is the answer
            indexes = getIndexesOfMaxElements(aInput);
            if (indexes.Count == 1)
                return indexes;

            indexes = new List<int>();

            double[] aOutput = A_Layer.FormOutputSignal(zOutput);

            double[] yOutput = Y_Layer.FormOutputSignal(aOutput);

            for (int i = 0; i < yOutput.Length; i++)
                if (yOutput[i] == 1)
                    indexes.Add(i);

            return indexes;
        }

        /**
         * function getIndexesOfMaxElements returns the list of indexes of elements that are
         * max values in data array
         */
        List<int> getIndexesOfMaxElements(double[] array)
        {
            List<int> indexes = new List<int>();

            if (array.Length > 0)
            {
                double max = array.Max();

                for (int i = 0; i < array.Length; i++)
                    if (max == array[i])
                        indexes.Add(i);
            }

            return indexes;
        }
    }
}
