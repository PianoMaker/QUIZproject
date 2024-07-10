using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Models
{
    public class SQuiz : Quiz
    {
        public List<int?> Chord { get; set; }

        private List<WaveOutEvent> woe;
        private List<SignalGenerator> sg;

        public SQuiz() 
        {
            Question = "Який акорд звучить?";
            
        }

        public SQuiz(List<int> freq)
        {
            Question = "Який акорд звучить?";
            sg = new();
            woe = new();
            foreach (int i in freq)
            {
                var synth = new SignalGenerator
                {
                    Frequency = i,
                    Gain = 1,
                    Type = SignalGeneratorType.Sin
                };                
                sg.Add(synth);
                var wav = new WaveOutEvent();
                wav.Init(synth);
                woe.Add(wav);
            }

        }

        public void Play()
        {
            if (woe.Count > 0)
            {
                foreach (var woe in woe) { woe.Play(); }
            }
        }


    }

}
