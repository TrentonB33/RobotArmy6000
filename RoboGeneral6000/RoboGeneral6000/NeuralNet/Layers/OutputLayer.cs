using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGeneral6000.NeuralNet.Layers
{
    class OutputLayer : AbsLayer
    {
// private double[] values;


        override public void ProcessLayer(double[] _input)
        {
            values = _input;
        }
    }
}
