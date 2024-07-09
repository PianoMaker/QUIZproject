using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZproject
{
    public partial class QuizEditForm : Form
    {
        //private enum Subject { Musichistory, Solfegio }

        public string Question { get; set; }

        public List<string> Answers { get; set; }
        public List<int?> Chord { get; set; }

        string[] notes =
        {
            "",
            "a",
            "ais/b",
            "h",
            "c",
            "cis/des",
            "d",
            "dis/es",
            "e",
            "f",
            "fis",
            "g",
            "gis/as"
        };

        private List<int?> pitches;

        public QuizEditForm(Subject subj)
        {
            InitializeComponent();
            if (subj == Subject.Musichistory) panel1.Visible = false;

            foreach (string s in notes)
            {
                cb1.Items.Add(s);
                cb2.Items.Add(s);
                cb3.Items.Add(s);
                cb4.Items.Add(s);
                cb5.Items.Add(s);
            }
            pitches = new List<int?>()
            { null, null, null, null, null };
        }

   

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pitches[0] = cb1.SelectedIndex;
        }
        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pitches[1] = cb2.SelectedIndex;
        }
        private void cb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            pitches[2] = cb3.SelectedIndex;
        }
        private void cb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            pitches[3] = cb4.SelectedIndex;
        }
        private void cb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            pitches[4] = cb5.SelectedIndex;
        }

        private void SaveChord()
        {
            double temp, prevfreq = 0, freq;
            foreach (var n in pitches)
            {

                if (n != null)
                {
                    temp = n.Value;
                    freq = Math.Pow(2, temp / 12);
                    while (freq < prevfreq) freq *= 2;
                    Chord.Add((int)freq);
                    prevfreq = freq;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChord();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Question = textBox1.Text;
        }
    }
}
