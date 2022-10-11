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
     * class Converters contains functions to convert one type of container with data to another
     */
    static internal class Converters
    {
        /**
         * function toMatrix converts int[,] array to double[] going first by rows,
         * next by columns
         */
        public static double[] toDoubleArray(int[,] input)
        {
            int rowsAmount = input.GetLength(0);
            int columnsAmount = input.GetLength(1);
            double[]letter = new double[rowsAmount * columnsAmount];

            for (int i = 0; i < rowsAmount; i++)
                for (int j = 0; j < columnsAmount; j++)
                    letter[i * columnsAmount + j] = input[i, j];

            return letter;
        }

        /**
         * function toIntTwoDimensionalArray converts double[] to int[,] array 
         * by element to element place
         */
        public static int[,] toIntTwoDimensionalArray(double[] letterColumn, 
            int rowsAmount, int columnsAmount)
        {
            int[,] let = new int[rowsAmount, columnsAmount];
            for (int i = 0; i < rowsAmount; i++)
            {
                for (int j = 0; j < columnsAmount; j++)
                    let[i, j] = (int)letterColumn[i * columnsAmount + j];
            }
            return let;
        }
    }
}
