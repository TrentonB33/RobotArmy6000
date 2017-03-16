using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeneral6000._NeuralNet.Layers
{
    class OutputLayer : AbsLayer
    {
        // private double[] values;

        public OutputLayer()
        { 
            valCount = 3;
            weights = new double[valCount][];
            for (int x = 0; x < valCount; x++)
            {
                weights[x] = new double[valCount];
            }
        }

        public OutputLayer(OutputLayer _orig)
        {
            values = (double[])_orig.values.Clone();
            weights = (double[][])_orig.weights.Clone();
            for (int x = 0; x < weights.Length; x++)
            {
                weights[x] = (double[])_orig.weights[x].Clone();
            }
            valCount = _orig.valCount;
            act = _orig.act;

        }

        public OutputLayer(int _size)
        {
            valCount = _size;
            weights = new double[valCount][];
            for (int x = 0; x < valCount; x++)
            {
                weights[x] = new double[valCount];
            }
        }

        override public void ProcessLayer(double[] _input)
        {
            values = _input;
        }
    }
}
