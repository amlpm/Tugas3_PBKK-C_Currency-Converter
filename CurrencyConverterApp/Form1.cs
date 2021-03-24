using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyConverterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            int i = int.Parse(amount.Text);

            if (fromComboBox.SelectedItem == "Rupee" && toComboBox.SelectedItem == "Dollar")
            {
                int conv = i / 103;
                display.Text = "Jumlah yang Dikonvert : " + conv + "\t $";
            }
            if (fromComboBox.SelectedItem == "Dollar" && toComboBox.SelectedItem == "Rupee")
            {
                int conv = i * 103;
                display.Text = "Jumlah yang Dikonvert : " + conv + "\t Rupee";
            }
            if (fromComboBox.SelectedItem == "Rupee" && toComboBox.SelectedItem == "Euro")
            {
                int conv = i / 115;
                display.Text = "Jumlah yang Dikonvert : " + conv + "\t Euro";
            }
            if (fromComboBox.SelectedItem == "Euro" && toComboBox.SelectedItem == "Rupee")
            {
                int conv = i * 115;
                display.Text = "Jumlah yang Dikonvert : " + conv + "\t Rupee";
            }
            if (fromComboBox.SelectedItem == "Dollar" && toComboBox.SelectedItem == "Euro")
            {
                int conv = i / 2;
                display.Text = "Jumlah yang Dikonvert : " + conv + "\t Euro";
            }
            if (fromComboBox.SelectedItem == "Euro" && toComboBox.SelectedItem == "Dollar")
            {
                int conv = i * 2;
                display.Text = "Jumlah yang Dikonvert : " + conv + "\t $";
            }
        }
    }
}
