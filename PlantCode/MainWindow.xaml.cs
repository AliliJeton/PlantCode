using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using PlantCode;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> lines = new List<string>();
        List<string> states = new List<string>();
        string outputStates = "";
        string plantUML = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFilePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                txtInputPath.Text = ofd.FileName;
            }
        }

        private void btnCreatePlant_Click_1(object sender, RoutedEventArgs e)
        {
            states.Clear();
            try
            {
                txtOutputSource.Text = GetPath.getPath(ref lines, txtInputPath.Text);
            }
            catch (Exception y)
            {
                MessageBox.Show(y.Message);
            }

            try
            {
                string myString = "#CSTA";
                string myStringIF = "IF";
                string myStringTHEN = "THEN";
                string myStringENDREG = "END_REGION";
                string myStringNext = "//NEXTSTATE";
                string myStringENDIF = "END_IF";
                string myStringNextState = ":=";
                string myStringExit = "EXITACTION";
                List<string> oldLines = new List<string>(lines);
                lines = this.lines.ConvertAll(p => p.ToUpper());
                string stateBefore = "";


                for (int i = 0; i < this.lines.Count; i++)
                {
                    if (lines[i].Contains(myString) && !lines[i].Contains(":=") && !lines[i].Contains("="))
                    {
                        string temp = oldLines[i];
                        temp = temp.Substring(0, temp.IndexOf(":"));
                        temp = temp.Substring(temp.IndexOf("a") + 1);
                        stateBefore = temp;
                        states.Add(temp);
                    }
                    if (lines[i].Contains(myStringIF) && lines[i - 1].Contains(myStringNext))
                    {
                        for (int x = i; i < lines.Count; i++)
                        {
                            if ((/*lines[i].Contains(myStringIF) || lines[i].Contains(myStringTHEN) ||*/ lines[i].Contains(myStringNextState)) && !lines[i].Contains(myStringENDIF))
                            {
                                string temp2 = oldLines[i];

                                if (lines[i].Contains(":=") || lines[i].Contains("State.Actual"))
                                {
                                    temp2 = temp2.Replace("#sState.Actual:=", stateBefore + " -down-> ");
                                    temp2 = temp2.Replace("#", "");
                                    temp2 = temp2.Replace("cSta", "");
                                    temp2 = temp2.Substring(0, temp2.IndexOf(";"));
                                }

                                states.Add(temp2);
                            }
                            if (lines[i].Contains(myStringENDREG) || lines[i].Contains(myStringExit))
                            {
                                break;
                            }
                        }
                        //temp = temp.Substring(0, temp.IndexOf(":"));
                        //temp = temp.Substring(temp.IndexOf("a") + 1);
                    }
                }

                states.ForEach(p => outputStates = outputStates + p + System.Environment.NewLine);
                txtOutputSource.Text = outputStates;
            }
            catch (Exception y)
            {
                MessageBox.Show(y.Message);
            }

            txtOutputSource.Text = "";
            txtOutputSource.Text = CreatePlant.createPlant(ref states, txtInputTitle.Text, inputComboBox.Text);
            Clipboard.SetDataObject(txtOutputSource.Text);
            MessageBox.Show("Plant wurde in Zwischenablage kopiert.");

        }


        private void btnClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

            this.DragMove();
        }

        private void txtOutputSource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtInputPath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
