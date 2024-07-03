using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace YOH_Minis_Costing_Calculator
{
    public partial class Form1 : Form
    {
        //declear vereable before methods
        private float resinCost = 1;
        private float timeCost = 1;
        private float consumablesCost = 1;

        private int margin = 50;
        private int VAT = 20;

        public Form1()
        {
            InitializeComponent();
            label7.Text = String.Empty;
            textBox1.Text = resinCost.ToString();
            textBox2.Text = timeCost.ToString();
            textBox3.Text = consumablesCost.ToString();
            textBox4.Text = margin.ToString();
            textBox5.Text = VAT.ToString();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            HandleFloatForm(sender, ref resinCost);
        }
        private float GetPercentage(float val)
        {
            float percent = val + 100f;
            percent /= 100f;
            return percent;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            HandleFloatForm(sender, ref timeCost);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            HandleFloatForm(sender, ref consumablesCost);

        }

        private void HandleFloatForm(object sender, ref float value)
        {

            TextBox text = sender as TextBox;

            string val = text.Text;

            if (!float.TryParse(val, out value))
            {
                //Debug.WriteLine ("the text isn't a float");
                text.Text = string.Empty;
            }
            EstimatePrice();

        }

        private void EstimatePrice()
        {
            float estimatedPrice = 0;
            float baseCost = resinCost + timeCost + consumablesCost;

            //float marginPercent = margin + 100f;
            //marginPercent /= 100f;

            //float VATPercent = VAT + 100f;
            //VATPercent /= 100f;

            // your a twat alun
            // why type it five times 

            float marginPercent = GetPercentage(margin);
            float VATPercent = GetPercentage(VAT);

            estimatedPrice = baseCost * marginPercent * VATPercent;
            label7.Text = estimatedPrice.ToString("£##.##");
        }

        private void HandleIntForm(object sender, ref int value)
        {
            //Convert the "sender" object to the TextBox control, so we can get the value out of it
            TextBox txt = sender as TextBox;

            //Just in case - check to make sure the conversion worked
            if (txt == null) return;

            //Get the text value from the Textbox into a variable that we can use
            string val = txt.Text;

            //we need to check if the value passed into the text box is a number and if so, convert it to a float.
            //Try parse returns a bool representing whether the parsing was a success.
            //If successful it puts the result into the variable after "out" (resinCost)
            if (!int.TryParse(val, out value))
            {
                //Using the ! (not) operator we've determined that the text string can not be turned into a float

                //We have an invalid value for resin cost so set it to zero.
                value = 0;
                //Set the value of the Textbox to an empty string.
                txt.Text = string.Empty;
            }

            EstimatePrice();

            string trimmed = val.TrimStart('0');
            if (!val.Equals(trimmed))
            {
                txt.Text = trimmed;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            HandleIntForm(sender, ref margin);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            HandleIntForm(sender, ref VAT);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}