using Currency_Conversion_App;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CurencyConverterDynamic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label7.Text = "";
            getCurrencyList();
        }
        public void getCurrencyList()
        {
            APIRequester currencyListRequest = new APIRequester("https://free.currconv.com/api/v7/currencies?apiKey=253e086647d6374c27c6");
            CurrencyList currencyList = CurrencyList.Deserialize(currencyListRequest.SendAndGetResponse());

            CurrencyData[] datas = currencyList.ToArray();
            foreach (CurrencyData currency in datas)
            {
                fromComboBox.Items.Add(currency.id);
                toComboBox.Items.Add(currency.id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amount.Text))
            {
                label7.Text = "Insert a number.";
                label7.ForeColor = Color.Red;
            }
            else
            {
                if (string.IsNullOrEmpty(fromComboBox.Text) || string.IsNullOrEmpty(toComboBox.Text))
                {
                    label7.Text = "One or two of the currencies are still empty.";
                    label7.ForeColor = Color.Red;
                }
                else
                {
                    double input = Convert.ToDouble(amount.Text);
                    double rate = ExchangeRate(fromComboBox.Text, toComboBox.Text, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                    input = input * rate;

                    label7.Text = Convert.ToString(input);
                    label7.ForeColor = Color.Black;
                }
            }
        }

        private void convertButton_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(amount.Text))
            {
                label7.Text = "Masukkan Jumlah!";
                label7.ForeColor = Color.Red;
            }
            else
            {
                if (string.IsNullOrEmpty(fromComboBox.Text) || string.IsNullOrEmpty(toComboBox.Text))
                {
                    label7.Text = "Pilih Mata Uang!";
                    label7.ForeColor = Color.Red;
                }
                else
                {
                    double input = Convert.ToDouble(amount.Text);
                    double rate = ExchangeRate(fromComboBox.Text, toComboBox.Text, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));
                    input = input * rate;

                    label7.Text = Convert.ToString(input);
                    label7.ForeColor = Color.Black;
                }
            }
        }

        public static double ExchangeRate(string from, string to, string date)
        {
            string url;
            url = "https://free.currencyconverterapi.com/api/v6/" + "convert?q=" + from + "_" + to + "&compact=y&date=" + date + "&apiKey=253e086647d6374c27c6";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string jsonString;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            return JObject.Parse(jsonString).First.First["val"].First.ToObject<double>();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
