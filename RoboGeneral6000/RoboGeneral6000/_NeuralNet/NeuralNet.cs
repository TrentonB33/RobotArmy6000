using System;
using RoboGeneral6000._NeuralNet.Layers;

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
        private double act = 0.75;

        public NeuralNet()
        {
            gen = new Random();
            hidCount = 5;
            hidLayers = new AbsLayer[hidCount];
            for (int x = 0; x < hidCount; x++)
            {
                hidLayers[x] = new Layer(gen, act);
            }

            inputLayer = new Layer(inSize, gen, act);
            outputLayer = new OutputLayer(outSize);
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
            }
            inputLayer = new Layer(inSize, gen, act);
            outputLayer = new OutputLayer(outSize);
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

    }
}
