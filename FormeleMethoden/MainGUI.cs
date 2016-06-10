using Eindopdracht.NDFAAndDFA;
using Eindopdracht.ReguliereExpressie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eindopdracht
{
    public partial class MainGUI : Form
    {
        private NDFA<char> _outputNDFA = null;
        private string output;

        public MainGUI()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "")
                return;
            if (vanExpressie.Checked)
            {
                try
                {
                    Expressie expressie = new Expressie(InputBox.Text);
                    _outputNDFA = expressie.ToNDFA();

                    if (ToDFA.Checked)
                    {
                        OutputBox.Text = _outputNDFA.ToDFA().ToString();
                    }
                    if (ToNDFA.Checked)
                    {
                        OutputBox.Text = _outputNDFA.ToString();
                    }
                    if (ToReguliereGrammatica.Checked)
                    {
                        OutputBox.Text = _outputNDFA.ToReguliereGrammatica().ToString();
                    }

                    output = "digraph finite_state_machine {\n";
                    foreach (var t in _outputNDFA._eindToestanden)
                    {
                        output += "node [shape = doublecircle]; " + t + " ;\n";
                    }
                    output += "node [shape = circle];\n";
                    foreach (var t in _outputNDFA._toestanden)
                    {
                        output += t._name + " -> " + t._voglendeToestand.Item1 + " [label=\"" + t._voglendeToestand.Item2.ToString() + "\"];" + "\n";
                    }
                    output += "}";

                    //output = InputBox.Text + "\r" + OutputBox.Text;                   
                }
                catch (Exception exception)
                {
                    OutputBox.Text += "Het is niet gelukt\n" + exception.ToString();
                }
            }
            else if (vanDFA.Checked)
            {
                NDFA<char> ndfa = new NDFA<char>();
                for (int x = 0; x < InputBox.Lines.Count(); x++)
                {
                    string temp = InputBox.Lines[x];
                    if (temp.StartsWith("begin"))
                        ndfa._startSymbolen.Add(temp.Last().ToString());
                    else if (temp.StartsWith("eind"))
                        ndfa._eindToestanden.Add(temp.Last().ToString());
                    else ndfa._toestanden.Add(Toestand<char>.CreateToestand(temp));
                    foreach (var t in ndfa._toestanden)
                    {
                        ndfa._invoerSymbolen.Add(t._voglendeToestand.Item2);
                    }
                }
                if (ToDFA.Checked)
                {
                    OutputBox.Text = ndfa.ToDFA().ToString();
                }
                if (ToNDFA.Checked)
                {
                    OutputBox.Text = ndfa.ToString();
                }
                if (ToReguliereGrammatica.Checked)
                {
                    OutputBox.Text = ndfa.ToReguliereGrammatica().ToString();
                }
                _outputNDFA = ndfa;
            }
            else if (vanGrammatica.Checked)
            {

            }
           
        }
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ToDFA_EnabledChanged(object sender, EventArgs e)
        {
            
        }

        private void ToDFA_CheckedChanged(object sender, EventArgs e)
        {
            btnMinimaliseer.Enabled = !btnMinimaliseer.Enabled;
            
            //button1.Visible = !button1.Visible;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            InputBox.Text = OutputBox.Text = "";
            _outputNDFA = null;
        }

        private void btnMinimaliseer_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (InputBox.Text == "")
                return;
            if (_outputNDFA == null)
            {
                Expressie expressie = new Expressie(InputBox.Text);
                _outputNDFA = expressie.ToNDFA();
            }
            OutputBox.Text = _outputNDFA.ToDFA().Minimalize().ToString();
        }

        private void btnOpslaan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Directory.Exists("C:\\Avans\\Jaar 3\\Periode 4\\Formele methoden\\Eindopdracht"))
                Directory.CreateDirectory("C:\\Avans\\Jaar 3\\Periode 4\\Formele methoden\\Eindopdracht");

            File.WriteAllText(@"C:\\Avans\\Jaar 3\\Periode 4\\Formele methoden\\Eindopdracht\\" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + ".txt", output);

        }

        private void btnOpslaanAls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;
                File.WriteAllText(name, output);
            }
        }

        private void btnSluiten_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string text = File.ReadAllText(openFileDialog1.FileName);
                    string[] split = text.Split('\r');
                }
                catch (IOException)
                {

                }
            }
        }

        private void btnTestDFA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vanDFA.Checked = true;
            InputBox.Text = "00a\n01b\n12a\n11b\n20a\n23b\n34a\n32b\n45a\n43b\n50a\n53b\nbegin 0\neind 4";
        }

        private void btnGrafiek_Click(object sender, EventArgs e)
        {
            try
            {
                //Convert to byte stream
                Image image = Graphviz.RenderImage(output, "dot", "png");
                peGraph.Image = image;
                //using (Image image = Image.FromStream(new MemoryStream(images)))
                //{
                //    image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
                //}
            }
            catch (Exception ex)
            {
                //TODO:Impelement exception handling
            }
        }
    }
}
