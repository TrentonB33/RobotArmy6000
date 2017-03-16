using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RoboGeneral6000._NeuralNet.Layers
{
    class Layer : AbsLayer
    {
        public Layer()
        {
            act = 0.75;
            valCount = 10;
            weights = new double[valCount][];
            for (int x = 0; x < valCount; x++)
            {
                weights[x] = new double[valCount];
                for (int y = 0; y < valCount; y++)
                {
                    weights[x][y] = 0.5;
                }
            }
        }

        public Layer(Random _gen, double _act)
        {
            act = _act;
            valCount = 10;
            weights = new double[valCount][];
            for (int x = 0; x < valCount; x++)
            {
                weights[x] = new double[valCount];
                for (int y = 0; y < valCount; y++)
                {
                    weights[x][y] = _gen.NextDouble();
                }
            }
        }

        public Layer(int _size, Random _gen, double _act)
        {
            act = _act;
            valCount = _size;
            weights = new double[valCount][];
            for (int x = 0; x < valCount; x++)
            {
                weights[x] = new double[valCount];
                for(int y = 0; y<valCount; y++)
                {
                    weights[x][y] = _gen.NextDouble();
                }
            }
        }
    }
}
