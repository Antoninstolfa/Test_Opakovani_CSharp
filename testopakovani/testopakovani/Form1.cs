using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace testopakovani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                OpenFileDialog otevirac = new OpenFileDialog();
                List<string> vstup = new List<string>();
                if (otevirac.ShowDialog() == DialogResult.OK)
                {
                    StreamReader ctenar = new StreamReader(otevirac.FileName, Encoding.GetEncoding("windows-1250"));
                    int a = 0;
                    while (!ctenar.EndOfStream)
                    {
                        vstup.Add(ctenar.ReadLine());
                        listBox1.Items.Add(vstup[a]);
                        a++;
                    }
                    ctenar.Close();
                    StreamWriter zapisovac = new StreamWriter(otevirac.FileName, false);
                    double soucet = 0, pocitadlo = vstup.Count(), prumer = 0;
                    for (int i = 0; i < vstup.Count(); i++)
                    {
                        string[] operatory = vstup[i].Split(' ');
                        int cislo1 = Convert.ToInt32(operatory[0]);
                        char operand = Convert.ToChar(operatory[1]);
                        int cislo2 = Convert.ToInt32(operatory[2]);
                        double vysledek;
                        switch (operand)
                        {
                            case '+':
                                {
                                    vysledek = cislo1 + cislo2;
                                    soucet += vysledek;
                                    zapisovac.WriteLine(vstup[i] + " " + vysledek);
                                    break;
                                }
                            case '-':
                                {
                                    vysledek = cislo1 - cislo2;
                                    soucet += vysledek;
                                    zapisovac.WriteLine(vstup[i] + " " + vysledek);
                                    break;
                                }
                            case '*':
                                {
                                    vysledek = cislo1 * cislo2;
                                    soucet += vysledek;
                                    zapisovac.WriteLine(vstup[i] + " " + vysledek);
                                    break;
                                }
                            case '/':
                                {
                                    vysledek = cislo1 / cislo2;
                                    soucet += vysledek;
                                    zapisovac.WriteLine(vstup[i] + " " + vysledek);
                                    break;
                                }
                        }
                    }
                    zapisovac.Close();
                    StreamReader ctenar2 = new StreamReader(otevirac.FileName);
                    while (!ctenar2.EndOfStream)
                    {
                        listBox2.Items.Add(ctenar2.ReadLine());
                    }
                    ctenar2.Close();
                    prumer = soucet / pocitadlo;
                    FileStream tok = new FileStream("prumer.dat", FileMode.OpenOrCreate, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(tok);
                    bw.Write(prumer);
                    label4.Text = prumer.ToString();
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gold;
            button1.BackColor = Color.Gray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.LawnGreen;
            button1.BackColor = Color.Black;
        }
    }
}
