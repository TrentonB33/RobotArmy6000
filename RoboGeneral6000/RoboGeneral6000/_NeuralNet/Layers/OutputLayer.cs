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
