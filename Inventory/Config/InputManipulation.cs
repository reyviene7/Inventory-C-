using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Inventory.Config
{
    public class InputManipulation
    {
        public static void InputTextBoxPassword(TextBox txt)
        {
            txt.UseSystemPasswordChar = true;
        }
        public static void InputTextBoxNormal(TextBox txt)
        {
            txt.UseSystemPasswordChar = false;
        }

        //Enabled

        public static void InputTextEnabled(TextBox txt)
        {
            txt.Enabled = true;
        }
        public static void ComboBoxEnabled(ComboBox cmb)
        {
            cmb.Enabled = true;
        }

        public static void DatePickEnabled(DateTimePicker dtp)
        {
            dtp.Enabled = true;
        }

        public static void ListViewEnabled(ListView lst)
        {
            lst.Enabled = true;
        }

        public static void ButtonEnabled(Button bnt)
        {
            bnt.Enabled = true;
        }

        public static void RadioButtonEnabled(RadioButton bnt)
        {
            bnt.Enabled = true;
        }

        public static void MasterTextEnabled(MaskedTextBox bnt)
        {
            bnt.Enabled = true;
        }

        //Disabled

        public static void InputTextDisabled(TextBox txt)
        {
            txt.Enabled = false;
        }
        public static void ComboBoxDisabled(ComboBox cmb)
        {
            cmb.Enabled = false;
        }

        public static void DatePickDisabled(DateTimePicker dtp)
        {
            dtp.Enabled = false;
        }

        public static void ListViewDisabled(ListView lst)
        {
            lst.Enabled = false;
        }

        public static void ButtonDisabled(Button bnt)
        {
            bnt.Enabled = false;
        }

        public static void RadioButtonDisabled(RadioButton bnt)
        {
            bnt.Enabled = false;
        }

        public static void MasterTextDisabled(MaskedTextBox bnt)
        {
            bnt.Enabled = false;
        }

        //Clear
        public static void RadioButtonClear(RadioButton rd)
        {
            rd.Checked = false;
        }

        public static void InputTextBoxClear(TextBox txt)
        {
            txt.Clear();

        }
        public static void ComboBoxClear(ComboBox cmb)
        {
            cmb.Text = "";
            cmb.DataBindings.Clear();
        }
        public static void DatePickClear(DateTimePicker dtp)
        {
            dtp.Text = "";
        }
        public static void ListViewClear(ListView lst)
        {
            lst.Clear();
        }
        public static void DataGridViewClear(DataGridView dp)
        {
            dp.DataBindings.Clear();
        }

        public static void MaskedTextBoxClear(MaskedTextBox txt)
        {
            txt.Clear();
        }

        //FOCUS
        public static void InputTextBoxFocus(TextBox txt)
        {
            txt.Focus();
        }
        public static void ComboBoxFocus(ComboBox cmb)
        {
            cmb.Focus();
        }
        public static void DatePickFocus(DateTimePicker dtp)
        {
            dtp.Focus();
        }
        public static void ListViewFocus(ListView lst)
        {
            lst.Focus();
        }
        public static void MaskedTextBoxFocus(MaskedTextBox lst)
        {
            lst.Focus();
        }
        public static void ButtonFocus(Button bnt)
        {
            bnt.Focus();
        }

        //TRIM
        public static string MaskedTextBoxTrim(MaskedTextBox txt)
        {
            return txt.Text.Trim(' ');
        }
        public static string InputTextBoxTrim(TextBox txt)
        {
            return txt.Text.Trim(' ');
        }
        public static string ComboBoxTrim(ComboBox txt)
        {
            return txt.Text.Trim(' ');
        }
        public static string ListBoxTrim(ListBox txt)
        {
            return txt.Text.Trim(' ');
        }
        public static string LabelTrim(Label txt)
        {
            return txt.Text.Trim(' ');
        }

        public static void InputEmpLeave(TextBox input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputEmpLeave(TextBox input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputEmpLeave(ComboBox input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }
        public static void InputEmpLeave(ComboBox input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputEmpLeave(TextBox input, DateTimePicker inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputEmpLeave(ComboBox input, DateTimePicker inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputEmpLeave(DateTimePicker input, Button inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                PopupNotification.PopUpMessages(0, inpmsg + Messages.ErrorInputEmpty, title);
                input.Focus();
                input.BackColor = Color.Yellow;
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(TextBox input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(TextEdit input, TextEdit inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }


        public static void InputBoxLeave(TextEdit input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }
        public static void InputBoxLeave(ComboBox input, Button inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {

                input.BackColor = Color.White;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.Focus();
            }
        }
        public static void InputBoxLeave(TextBox input, DateTimePicker inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(TextBox input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(ComboBox input, DateTimePicker inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(DateTimePicker input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Value = DateTime.Now.Date;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(DateTimePicker input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Value = DateTime.Now.Date;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }
        public static void InputBoxLeave(DateTimePicker input, SimpleButton inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Value = DateTime.Now.Date;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(ComboBox input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(ComboBox input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                var mpt = input.Text.Trim(' ');
                input.BackColor = Color.White;
                input.Text = mpt.ToTitleCase(TitleCase.All);
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(DateTimePicker input, DateTimePicker inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Value = DateTime.Now.Date;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {

                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(DateTimePicker input, Button inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Value = DateTime.Now.Date;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {

                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(TextBox input, Button inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {

                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(TextEdit input, SimpleButton inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {

                inputNext.Focus();
            }
        }

        public static void InputBoxLeave(Button input, Button inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                inputNext.Focus();
            }
        }

        public static void DetectIntLeave(TextBox txt)
        {
            var input = txt.Text;
            float parseValue;
            if (!float.TryParse(input, out parseValue))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txt.Focus();
                txt.BackColor = Color.Yellow;
            }
            else
            {
                txt.BackColor = Color.White;
            }
        }

        public static void DetectIntLeave(ComboBox txt)
        {
            var input = txt.Text;
            float parseValue;
            if (!float.TryParse(input, out parseValue))
            {
                PopupNotification.PopUpMessages(0, "Non-numeric entry detected!", "INVALID ENTRY");
                txt.Focus();
                txt.BackColor = Color.Yellow;
            }
            else
            {
                txt.BackColor = Color.White;
            }
        }

        public static void InputCaseLeave(TextBox input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputCaseLeave(ComboBox input, Button inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.Focus();
            }
        }

        public static void InputCaseLeave(ComboBox input, TextBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        public static void InputCaseLeave(TextBox input, ComboBox inputNext, string inpmsg, string title)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }

        internal static void InputCaseLeave(ComboBox input, ComboBox inputNext, string v, string titleInventory)
        {
            var inp = input.Text.Length;
            if (inp == 0)
            {
                input.Text = Messages.AssignDefault;
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
            else
            {
                input.BackColor = Color.White;
                inputNext.BackColor = Color.Yellow;
                inputNext.Focus();
            }
        }
    }
}
