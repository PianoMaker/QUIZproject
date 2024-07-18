using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Tools
    {
        public static void Readtext(object sender)
        {
            string txt;
            if (sender is Label lbl)
                txt = lbl.Text;
            else if (sender is TextBox tb)
                txt = tb.Text;
            else return;

            if (string.IsNullOrEmpty(txt)) return;

            Task.Run(() =>
            {
                string fullAnswer = txt;
                Form answerForm = new Form();
                answerForm.Text = "Повний текст";
                answerForm.Size = new Size(800, 600);

                Label lblFullAnswer = new Label();
                lblFullAnswer.Dock = DockStyle.Fill;
                lblFullAnswer.Font = new Font("Segoe UI", 12F);
                lblFullAnswer.Text = fullAnswer;
                lblFullAnswer.TextAlign = ContentAlignment.MiddleCenter;
                lblFullAnswer.AutoSize = false;
                answerForm.Controls.Add(lblFullAnswer);
                answerForm.ShowDialog();
            });
        }

    }
}
