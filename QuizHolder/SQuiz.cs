﻿using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Runtime.Serialization;

namespace QuizHolder
{

    public class SQuiz : TQuiz
    {
        readonly int camerton = 220; // hz

        [DataMember]
        public List<int> Pitches { get; set; }
        private List<WaveOutEvent> woe = new();
        private List<SignalGenerator> sg = new();

        public SQuiz()
        {
            sg = new();
            woe = new();
        }

        public SQuiz(List<int> pitches)
        {
            Pitches = pitches;
            sg = new();
            woe = new();

        }

        public SQuiz(string question, List<string> answers, int correctanswer, List<int> pitches)
            : base(question, answers, correctanswer)
        {
            Question = question;
            Answers = answers;
            Correctanswer = correctanswer;
            Pitches = pitches;
            sg = new();
            woe = new();
            //   SynthChord();
        }

        private void SynthChord()
        {
            var frequences = Frequences();

            foreach (int i in frequences)
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
                    //MessageBox.Show("impossible to synth");
                }
            }
        }

        private List<int> Frequences()
        {
            List<int> freqlist = new();
            var prevfreq = 220;
            foreach (var n in Pitches)
            {
                if (n >= 0)
                {
                    var freq = camerton * Math.Pow(2, (double)n / 12);
                    while (freq < prevfreq) freq *= 2;
                    freqlist.Add((int)freq);
                    prevfreq = (int)freq;
                }
            }
            return freqlist;
        }

        public string GetFrequences()
        {
            string txt = "";
            List<int> temp = Frequences();
            foreach (var n in temp)
                txt += n.ToString() + " ";
            return txt;
        }

        public void Play()
        {
            SynthChord();
            if (woe.Count > 0)
            {
                foreach (var woe in woe)
                    woe.Play();

                Thread.Sleep(1000);

                foreach (var woe in woe)
                    woe.Stop();
            }
        }

        public override object Clone()
        {

            var baseClone = (Quiz)base.Clone();

            return new SQuiz
            {
                Question = baseClone.Question,
                Answers = baseClone.Answers,
                Picture = baseClone.Picture,
                Studentanswer = baseClone.Studentanswer,
                Pitches = this.Pitches
                //Correctanswer не копіюємо, бо пересилаємо клієнту без нього :)
            };

        }
    }
}
