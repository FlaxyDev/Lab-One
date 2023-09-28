using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_One
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        double FunctionOne(double x)
        {
            return Math.Pow(2, x);
        }
        double FunctionTwo(double x)
        {
            return 5 + 2 * x + Math.Pow(x, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Points.Clear();
            this.chart1.Series[3].Points.Clear();

            this.chart2.Series[0].Points.Clear();
            this.chart2.Series[1].Points.Clear();

            double start = Double.Parse(textBox1.Text);
            double end = Double.Parse(textBox2.Text);
            double fOneStar = Double.Parse(textBox4.Text);
            double fTwoStar = Double.Parse(textBox3.Text);


            List<double> functionOneResultList = new List<double>();

            List<double> functionTwoResultList = new List<double>();

            List<bool> functionOneComparison = new List<bool>();

            List<bool> functionTwoComparison = new List<bool>();

            List<double> fOneDivisionFOneStarList = new List<double>();

            List<double> fTwoDivisionFTwoStarList = new List<double>();

            List<double> maxList = new List<double>();
            List<double> minList = new List<double>();

            for (double i = start; i <= end; i += 0.1)
            {
                functionOneResultList.Add(FunctionOne(i));
                functionTwoResultList.Add(FunctionTwo(i));
            }
            for (int i = 0; i < functionOneResultList.Count; i++)
            {
                functionOneComparison.Add(functionOneResultList[i] > fOneStar ? true : false);
                functionTwoComparison.Add(functionTwoResultList[i] > fTwoStar ? true : false);
            }
            for (int i = 0; i < functionOneResultList.Count; i++)
            {
                if (functionOneComparison[i] == true && functionTwoComparison[i] == true)
                {
                    fOneDivisionFOneStarList.Add(functionOneResultList[i] / fOneStar);
                    fTwoDivisionFTwoStarList.Add(functionTwoResultList[i] / fTwoStar);
                }
            }
            for (int i = 0; i < fOneDivisionFOneStarList.Count; i++)
            {
                if (fOneDivisionFOneStarList[i] > fTwoDivisionFTwoStarList[i])
                {
                    maxList.Add(fOneDivisionFOneStarList[i]);
                    minList.Add(fTwoDivisionFTwoStarList[i]);
                }
                else
                {
                    maxList.Add(fTwoDivisionFTwoStarList[i]);
                    minList.Add(fOneDivisionFOneStarList[i]);
                }
            }

            for (int i = 0; i < functionOneResultList.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY(start, functionOneResultList[i]);
                this.chart1.Series[1].Points.AddXY(start, functionTwoResultList[i]);
                this.chart1.Series[2].Points.AddXY(start, fOneStar);
                this.chart1.Series[3].Points.AddXY(start, fTwoStar);
                start += 0.1;
            }
            start = Double.Parse(textBox1.Text);
            for (int i = 0, j = 0; i < functionOneComparison.Count; i++)
            {
                if (functionOneComparison[i] == true && functionTwoComparison[i] == true)
                {
                    this.chart2.Series[0].Points.AddXY(start, fOneDivisionFOneStarList[j]);
                    this.chart2.Series[1].Points.AddXY(start, fTwoDivisionFTwoStarList[j]);
                    j++;
                }
                start += 0.1;
            }
            MessageBox.Show($"Max: {minList.Max()} \nMin: {maxList.Min()}");
        }
    }
}
