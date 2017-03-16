using System;
using RoboGeneral6000._NeuralNet.Layers;
using System.Diagnostics;

namespace RoboGeneral6000._NeuralNet
{
    public class NeuralNet
    {
        public int fitness;

        private int hidCount;
        private AbsLayer[] hidLayers;
        public AbsLayer inputLayer;
        public int hidSize;
        public int inSize =  40;
        public AbsLayer outputLayer;
        public int outSize = 3;
        private Random gen;
        private double act = 0.75; //Activation threshold

        public NeuralNet()
        {
            gen = new Random();
            hidCount = 5;
            hidLayers = new AbsLayer[hidCount];
            for (int x = 0; x < hidCount; x++)
            {
                hidLayers[x] = new Layer(gen, act);
                if(x>0)
                {
                    hidLayers[x - 1].NextLayer = hidLayers[x];
                }
            }

            inputLayer = new Layer(inSize, gen, act);
            outputLayer = new OutputLayer(outSize);
        }

        public NeuralNet(NeuralNet _orig)
        {
            hidCount = _orig.hidCount;
            hidSize = _orig.hidSize;
            inSize = _orig.inSize;
            outSize = _orig.outSize;
            gen = _orig.gen;
            act = _orig.act;
            inputLayer = new Layer((Layer)_orig.inputLayer);
            outputLayer = new OutputLayer((OutputLayer)_orig.outputLayer);
            hidLayers = new AbsLayer[hidCount];
            for(int x=0;x<hidCount;x++)
            {
                hidLayers[x] = new Layer((Layer)_orig.hidLayers[x]);
                if (x > 0)
                {
                    hidLayers[x - 1].NextLayer = hidLayers[x];
                }
            }
        }

        public NeuralNet(int _hidCount, int _hidSize, int _inSize, int _outSize, double _act)
        {
            act = _act;
            hidSize = _hidSize;
            gen = new Random();
            hidCount = _hidCount;
            outSize = _outSize;
            inSize = _inSize;
            hidLayers = new AbsLayer[_hidCount];
            for(int x=0; x<hidCount;x++)
            {
                hidLayers[x] = new Layer(_hidSize, gen, act);
                if (x > 0)
                {
                    hidLayers[x - 1].NextLayer = hidLayers[x];
                }
            }
            inputLayer = new Layer(inSize, gen, act);
            outputLayer = new OutputLayer(outSize);
        }

        public double[] ProcessInput(double[] _input)
        {
            inputLayer.ProcessLayer(_input);
            return ((OutputLayer)outputLayer).GetValues();
        }

        public int EdgeCount()
        {
            return hidSize * hidSize * hidCount + inSize*hidSize;
        }

        public void UpdateEdge(int pos, double newVal)
        {
            if(pos<inSize*hidSize)
            {
                inputLayer.weights[pos / inSize][pos % inSize] = newVal;
            } else
            {
                int next = pos - inSize * hidSize;
                int layer = next / (hidSize*hidSize);
                int weights = next - layer * hidSize;
                hidLayers[layer].weights[next / hidSize][next % hidSize] = newVal;
            }

        }


        public double getEdge(int pos)
        {
            if (pos < inSize * hidSize)
            {
                return inputLayer.weights[pos / inSize][pos % inSize];
            }
            else
            {
                int next = pos - inSize * hidSize;
                int layer = next / (hidSize * hidSize);
                int weights = next - layer * hidSize;
                return hidLayers[layer].weights[next / hidSize][next % hidSize];
            }

        }

        public void PrintNet()
        {
            //string result = null;
            for (int layer = 0; layer < hidCount; layer++)
            {
                Debug.WriteLine("Layer " + layer.ToString());
                hidLayers[layer].PrintEdgeLayer();
            }

        }

    }
}
