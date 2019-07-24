using System;
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
            DeleteTextValue();
            FocusInputText();
        }
        #endregion

        #region Calculator Operators
        private void BtnDiv_Click(object sender, EventArgs e)
        {
            InsertTextValue("/");
            FocusInputText();
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            InsertTextValue("*");
            FocusInputText();
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            InsertTextValue("-");
            FocusInputText();
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            InsertTextValue("+");
            FocusInputText();
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            CalculateEquasion();
            FocusInputText();
        }
        #endregion

        #region Calculator Numbers
        private void BtnPeriod_Click(object sender, EventArgs e)
        {
            InsertTextValue(".");
            FocusInputText();
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            InsertTextValue("0");
            FocusInputText();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            InsertTextValue("1");
            FocusInputText();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            InsertTextValue("2");
            FocusInputText();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            InsertTextValue("3");
            FocusInputText();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            InsertTextValue("4");
            FocusInputText();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            InsertTextValue("5");
            FocusInputText();
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            InsertTextValue("6");
            FocusInputText();
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            InsertTextValue("7");
            FocusInputText();
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            InsertTextValue("8");
            FocusInputText();
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            InsertTextValue("9");
            FocusInputText();
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
            //TODO: finish helper

            FocusInputText();
        }

        /// <summary>
        /// Inserts defined string to Userinput text
        /// </summary>
        /// <param name="insertable"></param>
        private void InsertTextValue(string insertable)
        {
            // remember selection start
            var selectionStart = this.UserInputText.SelectionStart;

            // set new text
            this.UserInputText.Text = this.UserInputText.Text.Insert(this.UserInputText.SelectionStart, insertable);

            // restore selection start position + length of the valje we inserted
            this.UserInputText.SelectionStart = selectionStart + insertable.Length;

            // set selection length to 0
            this.UserInputText.SelectionLength = 0;
        }

        /// <summary>
        /// Removes char from defined string
        /// </summary>
        private void DeleteTextValue()
        {
            // Sanity Check: no value to delete => do nothing
            if (this.UserInputText.Text.Length < this.UserInputText.SelectionStart + 1)
                return;

            // remember selection start
            var selectionStart = this.UserInputText.SelectionStart;

            // delete the char
            this.UserInputText.Text = this.UserInputText.Text.Remove(this.UserInputText.SelectionStart, 1);

            // restore selection start position + length of the valje we inserted
            this.UserInputText.SelectionStart = selectionStart;

            // set selection length to 0
            this.UserInputText.SelectionLength = 0;
        }
        #endregion


    }
}
