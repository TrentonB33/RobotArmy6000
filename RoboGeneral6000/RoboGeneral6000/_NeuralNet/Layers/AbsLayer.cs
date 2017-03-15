﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeneral6000._NeuralNet.Layers
{
    public abstract class AbsLayer
    {
        protected double[] values;
        public double[][] weights;
        public int valCount;
        public double act;

        protected AbsLayer NextLayer;


        public virtual void ProcessLayer(double[] _input)
        {
            values = _input;
            double[] output = WeightValues();
            NextLayer.ProcessLayer(output);

        }

        protected double[] WeightValues()
        {
            double sum;
            double[] output = new double[valCount];
            for(int x = 0;x<valCount;x++)
            {
                for(int y=0; y<valCount;y++)
                {
                    sum = 0;
                    for(int z = 0; z<weights[y].Length; z++)
                    {
                        sum += values[x] * weights[y][z];
                    }
                    output[x] = sum;
                }
            }
            return output;
        }

    }
}
