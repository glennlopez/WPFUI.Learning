using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalcultor
{

    /// <summary>
    /// Basic Calculator Form
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// Defaukt Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Clear Methods
        /// <summary>
        /// Clears user input text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCE_Click(object sender, EventArgs e)
        {
            this.UserInputText.Text = "";
            FocusInputText();
        }
        
        /// <summary>
        /// Deletes character in the input text area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
                return;
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);
        }
        #endregion

        #region Calculator Operators
        private void BtnDiv_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            CalculateEquasion();
        }
        #endregion

        #region Calculator Numbers
        private void BtnPeriod_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Focuses the users input to textarea
        /// </summary>
        private void FocusInputText()
        {
            this.UserInputText.Focus();
        }


        private void CalculateEquasion()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts defined string to Userinput text
        /// </summary>
        /// <param name="insertable"></param>
        private void InsertTextValue(string insertable)
        {
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, insertable);
        }
        #endregion

      
    }
}
