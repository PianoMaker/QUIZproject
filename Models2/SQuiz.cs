using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Models
{
    [DataContract]
    public class SQuiz : Quiz
    {
        readonly int camerton = 220; // hz
        [DataMember] public List<int?> Pitches { get; set; }
        [DataMember] private List<WaveOutEvent> woe = new();
        [DataMember] private List<SignalGenerator> sg = new();

        public SQuiz()
        {
            Question = "Який акорд звучить?";
            sg = new();
            woe = new();
        }

        public SQuiz(List<int?> pitch)
        {
            Question = "Який акорд звучить?";
            Pitches = pitch;
            sg = new();
            woe = new();
            SynthChord();
        }

        private void SynthChord()
        {
            var Frequences = new List<int>();

            double temp, prevfreq = 0, freq;
            foreach (var n in Pitches)
            {
                
                if (n != null)
                {
                    temp = n.Value;
                    freq = camerton * Math.Pow(2, temp / 12);
                    while (freq < prevfreq) freq *= 2;
                    Frequences.Add((int)freq);
                    prevfreq = freq;
                }
            }


            foreach (int i in Frequences)
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("impossible ");
                }
            }
        }


        public void Play()
        {
            if (woe.Count > 0)
            {
                foreach (var woe in woe)
                {
                    woe.Play();
                    Thread.Sleep(1000);
                    woe.Stop();
                }
            }
        }


    }

}
