using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ACR122U_NFC_Decode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Return decimal string of HEX UID
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private string DecodeHexToDecimal(string hex)
        {
            // 2b1e08eb
            // 3943177771

            // if input is null OR can not divide into groups of 2 chars
            if (string.IsNullOrEmpty(hex) || hex.Length%2 > 0)
            {
                return string.Empty;
            }

            var decimalOut = "";
            hex = hex.ToUpper();

            for (var i = hex.Length - 1; i > 0; i-=2)
            {
                decimalOut += (hex[i - 1]).ToString() + hex[i].ToString();
            }

            return long.Parse(decimalOut, System.Globalization.NumberStyles.HexNumber).ToString();
        }

        private void UID_TextChanged(object sender, EventArgs e)
        {
            this.CardID.Text = DecodeHexToDecimal(UID.Text);
        }
    }
}
