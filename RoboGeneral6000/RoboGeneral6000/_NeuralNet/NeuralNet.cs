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
        public int inSize =  40;
        public AbsLayer outputLayer;
        public int outSize = 3;
        private Random gen;

        public NeuralNet()
        {
            gen = new Random();
            hidCount = 5;
            hidLayers = new AbsLayer[hidCount];
            for (int x = 0; x < hidCount; x++)
            {
                hidLayers[x] = new Layer(gen);
            }
            inputLayer = new Layer(inSize, gen);
            outputLayer = new OutputLayer(outSize);
        }

        public NeuralNet(int _hidCount, int _hidSize, int _inSize, int _outSize)
        {
            gen = new Random();
            hidCount = _hidCount;
            hidLayers = new AbsLayer[_hidCount];
            for(int x=0; x<hidCount;x++)
            {
                hidLayers[x] = new Layer(_hidSize, gen);
            }
            inputLayer = new Layer(inSize, gen);
            outputLayer = new OutputLayer(_outSize);
        }

    }
}
