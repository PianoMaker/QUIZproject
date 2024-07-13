using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZproject_server
{
    public partial class QserialTest : Form
    {
        List<Quiz> mh_questions = new List<Quiz>();
        
        public QserialTest()
        {
            InitializeComponent();

        }

        private void btLoad_Click(object sender, EventArgs e)
        {

        }

        private void LoadQuizBase(string path)
        {
            var bytes = File.ReadAllBytes(path);
            DeserializeQuizBase(bytes);
            Load_mh_questions();
        }

        private void DeserializeQuizBase(byte[] data)
        {

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Quiz>));
                mh_questions = (List<Quiz>)serializer.ReadObject(memoryStream)!;
            }
        }

        private void Load_mh_questions()
        {
            listBox1.Items.Clear();            
            foreach (var q in mh_questions)
                listBox1.Items.Add(q.Question);
        }
    }


}
