using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bytes_Conversion_Routine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsNumeric Function
        static bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }	

        public string FormatSize(long amt, int rounding)
        {
            try
            {

         
     

            if (amt >= Math.Pow(2, 80)) return Math.Round(amt / Math.Pow(2, 80), rounding).ToString() + " YB"; //yettabyte
            if (amt >= Math.Pow(2, 70)) return Math.Round(amt / Math.Pow(2, 70), rounding).ToString() + " ZB"; //zettabyte
            if (amt >= Math.Pow(2, 60)) return Math.Round(amt / Math.Pow(2, 60), rounding).ToString() + " EB"; //exabyte
            if (amt >= Math.Pow(2, 50)) return Math.Round(amt / Math.Pow(2, 50), rounding).ToString() + " PB"; //petabyte
            if (amt >= Math.Pow(2, 40)) return Math.Round(amt / Math.Pow(2, 40), rounding).ToString() + " TB"; //terabyte
            if (amt >= Math.Pow(2, 30)) return Math.Round(amt / Math.Pow(2, 30), rounding).ToString() + " GB"; //gigabyte
            if (amt >= Math.Pow(2, 20)) return Math.Round(amt / Math.Pow(2, 20), rounding).ToString() + " MB"; //megabyte
            if (amt >= Math.Pow(2, 10)) return Math.Round(amt / Math.Pow(2, 10), rounding).ToString() + " KB"; //kilobyte
        }
            catch (Exception)
            {                                
                throw;
            }
            return amt.ToString() + " Bytes"; //byte
        }	

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            textBox2.Text = FormatSize(long.Parse(textBox1.Text), 3);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            while ((textBox1.Text.Length > 0) & (IsNumeric(textBox1.Text) == false))
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    textBox1.Select(textBox1.Text.Length, 0);
                   
                }
            }
            if (textBox1.Text.Length > 0)
                textBox2.Text = FormatSize(long.Parse(textBox1.Text), 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }
    }
}