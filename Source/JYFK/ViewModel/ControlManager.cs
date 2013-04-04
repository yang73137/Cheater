using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace JYFK.ViewModel
{
    public class ControlManager
    {
        public static ControlManager Current;

        static ControlManager()
        {
            Current = new ControlManager();
        }

        private ControlManager() { }

        public void CreateLabel(Control container, string controlName, string text)
        {
            var label = container.Controls[controlName] as Label;

            if (label == null)
            {
                label = new Label();
                label.Name = controlName;
                label.Text = string.Format("{0}：", text);
                label.Width = 80;
                label.TextAlign = ContentAlignment.MiddleRight;
                container.Controls.Add(label);
            }
        }

        public void CreateTextBox(Control container, string controlName, string text)
        {
            var textBox = container.Controls[controlName] as TextBox;

            if (textBox == null)
            {
                textBox = new TextBox();
                textBox.Name = controlName;
                textBox.Height = 23;
                container.Controls.Add(textBox);
            }

            textBox.Text = text;
        }

        public void CreateCheckBox(Control container, string controlName, bool isChecked)
        {
            var checkBox = container.Controls[controlName] as CheckBox;

            if (checkBox == null)
            {
                checkBox = new CheckBox();
                checkBox.Name = controlName;
                checkBox.Height = 23;
                checkBox.Width = 100;
                checkBox.Cursor = Cursors.Hand;
                container.Controls.Add(checkBox);
            }

            checkBox.Checked = isChecked;
        }

        public void CreateComboBox(Control container, string controlName, IDictionary<string, object> dataSource, string displayMember, string valueMamber, object selectedItem)
        {
            var comboBox = container.Controls[controlName] as ComboBox;

            if (comboBox == null)
            {
                comboBox = new ComboBox();
                comboBox.Name = controlName;
                comboBox.Width = 100;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                container.Controls.Add(comboBox);

                comboBox.DataSource = dataSource.ToList();
                comboBox.DisplayMember = displayMember;
                comboBox.ValueMember = valueMamber;
            }

            comboBox.SelectedItem = selectedItem;
        }

        public string GetValueFromTextBox(Control container, string controlName)
        {
            var control = container.Controls[controlName] as TextBox;
            return control == null ? null : control.Text; 
        }

        public bool GetValueFromCheckBox(Control container, string controlName)
        {
            var control = container.Controls[controlName] as CheckBox;
            return control == null ? false : control.Checked;
        }

        public object GetValueFromComboBox(Control container, string controlName)
        {
            var control = container.Controls[controlName] as ComboBox;
            return control == null ? null : control.SelectedValue;
        }
    }
}
