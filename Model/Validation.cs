using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace Model
{
    public class Validation
    {
        //public static void onlyNumbers(KeyPressEventArgs e)
        //{
        //    if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
        //    {

        //        e.Handled = true;
        //        return;
        //    }
        //}
        public static bool onlyPriceNumber(string txt)
        {
            int comma = 0;
            foreach (char ch in txt)
            {
                if (!(char.IsNumber(ch)))
                    if (ch == '.' || ch == ',')
                        comma++;
                    else
                        return false;
                if (comma > 1)
                    return false;
            }
            return true;
        }

        public static int onlyDNI(string txt)
        {
            foreach (char ch in txt)
            {
                if (!(char.IsNumber(ch)))
                        return -1;
            }
            if(txt.Length !=8) //el largo debe ser de 8 digitos para que corresponda con DNI
                return -2;
            if (txt[0] == '0')  // no puede iniciar en 0
                return -3;
            return 0;
        }

        public static int onlyCP(string txt)
        {
            foreach (char ch in txt)
            {
                if (!(char.IsNumber(ch)))
                    return -1;
            }
            if (txt.Length <4 || txt.Length>6) //el largo debe ser de 4 entre y 6 digitos
                return -2;
            if (txt[0] == '0')  // no puede iniciar en 0
                return -3;
            return 0;
        }

        public static void onlyLetters(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {

                e.Handled = true;
                return;
            }
        }
        public static bool FilterValidation(ComboBox cboxField, ComboBox cboxMatch, TextBox txtAdvFilter)
        {
            if (cboxField.SelectedIndex == -1 || cboxMatch.SelectedIndex == -1)
            {
                MessageBox.Show("Select Field and Match to filter");
                return false;
            }
            if (cboxField.SelectedItem.ToString() == "Price")
            {
                Validation validacion = new Validation();
                if (string.IsNullOrEmpty(txtAdvFilter.Text))
                {
                    MessageBox.Show("Please select a price to filter");
                    return false;
                }
                else if (!(Validation.onlyPriceNumber(txtAdvFilter.Text)))
                {
                    MessageBox.Show("Only numbers to filter by price");
                    return false;
                }
            }
            return true;
        }

        public static bool mandatoryField(TextBox txtCode, TextBox txtName, TextBox txtPrice)
        {
            bool vacio = false;
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                vacio = true;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                vacio = true;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                vacio = true;
            }
            if (vacio == true)
                return false;
            return true;
        }
    }
}
