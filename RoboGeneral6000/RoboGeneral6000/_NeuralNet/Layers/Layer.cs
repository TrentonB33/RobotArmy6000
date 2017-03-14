using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeneral6000._NeuralNet.Layers
{
    class Layer : AbsLayer
    {
        public Layer()
        {
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

        public Layer(Random _gen)
        {
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

        public Layer(int _size, Random _gen)
        {
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
