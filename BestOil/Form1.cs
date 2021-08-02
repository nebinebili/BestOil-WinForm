using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Cafe cafe;


        private void Form1_Load(object sender, EventArgs e)
        {
            cafe = new Cafe();
            List<Oil> oils = new List<Oil>
            {
                new Oil("AI-92",1),
                new Oil("AI-95",1.40),
                new Oil("AI-98",1.55)
            };
            guna2ComboBox1.Items.AddRange(oils.ToArray());
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{(guna2ComboBox1.SelectedItem as Oil)?.Price}");
            gtB_price.Text = stringBuilder.ToString();
        }

        private void gRB_litr_CheckedChanged(object sender, EventArgs e)
        {
           
                if (gRB_litr.Checked) { 
                    gTB_litr.Enabled = true;
                    gtB_quantity.Enabled = false;
                    gtB_quantity.Text = string.Empty;
                    lbl_oilprice.Text = string.Empty;
                }
                else if (grB_sum.Checked)
                {
                    gtB_quantity.Enabled = true;
                    gTB_litr.Enabled = false;
                    gTB_litr.Text = string.Empty;
                    lbl_oilprice.Text = string.Empty;
                }
            
        }

        

        private void gTB_litr_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gtB_price.Text)) MessageBox.Show("Benzin secin");
            if (string.IsNullOrEmpty(gTB_litr.Text)) { 
                lbl_oilprice.Text = string.Empty;
                if (string.IsNullOrEmpty(lbl_kafeprice.Text)) lbl_allprice.Text = string.Empty;
                else  lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString(); 
            }
            bool regex=Regex.IsMatch(gTB_litr.Text, @"^*[0-9\.]+$");
            if (regex)
            {
                if (!string.IsNullOrEmpty(gtB_price.Text))
                {
                    var temp = Convert.ToDouble(gtB_price.Text) * Convert.ToDouble(gTB_litr.Text);
                    lbl_oilprice.Text = temp.ToString();
                    if (string.IsNullOrEmpty(lbl_kafeprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_oilprice.Text).ToString();
                    else  lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
                }
            }
            else gTB_litr.Text = string.Empty;
            
        }

        private void gtB_quantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gtB_price.Text)) MessageBox.Show("Benzin secin");
            if (string.IsNullOrEmpty(gtB_quantity.Text))
            {
                lbl_oilprice.Text = string.Empty;
                if (string.IsNullOrEmpty(lbl_kafeprice.Text)) lbl_allprice.Text = string.Empty;
                else lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
            }
            bool regex = Regex.IsMatch(gtB_quantity.Text, @"^*[0-9\.]+$");
            if (regex && Convert.ToDouble(gtB_quantity.Text) >=Convert.ToDouble(gtB_price.Text))
            {
                if (!string.IsNullOrEmpty(gtB_price.Text))
                {
                    lbl_oilprice.Text = gtB_quantity.Text;
                    if (string.IsNullOrEmpty(lbl_kafeprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_oilprice.Text).ToString();
                    else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
                }
            }
            else gtB_quantity.Text = string.Empty;
        }

        private void checkbox_hotdog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_hotdog.Checked) hotdog_count.Enabled = true;
            else { hotdog_count.Enabled = false; hotdog_count.Text = string.Empty; }
            if (chechbox_hamburger.Checked) hamburger_count.Enabled = true;
            else { hamburger_count.Enabled = false; hamburger_count.Text = string.Empty; }
            if (chechbox_kartof.Checked) kartof_count.Enabled = true;
            else { kartof_count.Enabled = false; kartof_count.Text = string.Empty; }
            if (chechbox_cola.Checked) cola_count.Enabled = true;
            else { cola_count.Enabled = false; cola_count.Text = string.Empty; }
        }

        private void hotdog_count_TextChanged(object sender, EventArgs e)
        {
  
           bool regex = Regex.IsMatch(hotdog_count.Text, @"^*[0-9]+$");
           if (!regex) hotdog_count.Text = string.Empty;
            if (string.IsNullOrEmpty(hotdog_count.Text))
            {
                lbl_kafeprice.Text = (Convert.ToDouble(lbl_kafeprice.Text) - cafe.HotdogPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
                cafe.HotdogPrice = 0;
            }
            else
            {
                cafe.HotdogPrice = Convert.ToDouble(hotdog_count.Text) * Convert.ToDouble(hotdog_price.Text);
                lbl_kafeprice.Text = (cafe.HotdogPrice + cafe.HamburgerPrice + cafe.ColaPrice + cafe.KartofPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
            }
            
        }

        private void hamburger_count_TextChanged(object sender, EventArgs e)
        {
            bool regex = Regex.IsMatch(hamburger_count.Text, @"^*[0-9]+$");
            if (!regex) hamburger_count.Text = string.Empty;
            if (string.IsNullOrEmpty(hamburger_count.Text))
            {
                lbl_kafeprice.Text = (Convert.ToDouble(lbl_kafeprice.Text) - cafe.HamburgerPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
                cafe.HamburgerPrice = 0;
            }
            else
            {
                cafe.HamburgerPrice = Convert.ToDouble(hamburger_count.Text) * Convert.ToDouble(hamburger_price.Text);
                lbl_kafeprice.Text = (cafe.HotdogPrice + cafe.HamburgerPrice + cafe.ColaPrice + cafe.KartofPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
            }
        }

        private void kartof_count_TextChanged(object sender, EventArgs e)
        {
            bool regex = Regex.IsMatch(kartof_count.Text, @"^*[0-9]+$");
            if (!regex) kartof_count.Text = string.Empty;
            if (string.IsNullOrEmpty(kartof_count.Text))
            {
                lbl_kafeprice.Text = (Convert.ToDouble(lbl_kafeprice.Text) - cafe.KartofPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
                cafe.KartofPrice = 0;
            }
            else
            {
                cafe.KartofPrice = Convert.ToDouble(kartof_count.Text) * Convert.ToDouble(kartof_price.Text);
                lbl_kafeprice.Text = (cafe.HotdogPrice + cafe.HamburgerPrice + cafe.ColaPrice + cafe.KartofPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
            }
        }

        private void cola_count_TextChanged(object sender, EventArgs e)
        {
            bool regex = Regex.IsMatch(cola_count.Text, @"^*[0-9]+$");
            if (!regex) cola_count.Text = string.Empty;
            if (string.IsNullOrEmpty(cola_count.Text))
            {
                lbl_kafeprice.Text = (Convert.ToDouble(lbl_kafeprice.Text) - cafe.ColaPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
                cafe.ColaPrice = 0;
            }
            else
            {
                cafe.ColaPrice = Convert.ToDouble(cola_count.Text) * Convert.ToDouble(cola_price.Text);
                lbl_kafeprice.Text = (cafe.HotdogPrice + cafe.HamburgerPrice + cafe.ColaPrice + cafe.KartofPrice).ToString();
                if (string.IsNullOrEmpty(lbl_oilprice.Text)) lbl_allprice.Text = Convert.ToDouble(lbl_kafeprice.Text).ToString();
                else lbl_allprice.Text = (Convert.ToDouble(lbl_oilprice.Text) + Convert.ToDouble(lbl_kafeprice.Text)).ToString();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_allprice.Text)|| Convert.ToDouble(lbl_allprice.Text) == 0)
            {
                MessageBox.Show("Məlumatları doldurun");
            }
         
            else MessageBox.Show("Təsdiq olundu!");
        }
    }
}
