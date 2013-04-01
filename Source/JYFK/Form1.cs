using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using GameEngine;
using GameEngine.Memory;
using GameEngine.ViewModel;

namespace JYFK
{
    public partial class Form1 : Form
    {
        private Process _gameProcess;
        private GameViewModel _gameViewModel;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.GetGameProcess() == null)
            {
                MessageBox.Show("找不到游戏进程");
                return;
            }

            var propertyViewModel = this._gameViewModel.Property;
            var type = propertyViewModel.GetType();
            foreach (var property in type.GetProperties())
            {
                if (property.GetCustomAttributes(typeof(DescriptionAttribute), false).Count() > 0)
                {
                    if (property.PropertyType == typeof(bool))
                    {
                        bool value = ((CheckBox)this.panel_Property.Controls[string.Format("cb_Property{0}", property.Name)]).Checked;
                        property.SetValue(propertyViewModel, value, null);
                    }
                    else
                    {
                        int value;
                        if (
                            !Int32.TryParse(
                                this.panel_Property.Controls[string.Format("tb_Property{0}", property.Name)].Text,
                                out value))
                        {
                            value = 0;
                        }

                        value = value > 255 ? 255 : value;

                        property.SetValue(propertyViewModel, value, null);
                    }
                }
            }

            this._gameViewModel.SaveToMemory();
            this.InitDisplayControls();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (this.GetGameProcess() == null)
            {
                MessageBox.Show("找不到游戏进程");
                return;
            }

            if (this._gameProcess == null)
            {
                this._gameProcess = this.GetGameProcess();
                this._gameViewModel = new GameViewModel(this._gameProcess.Handle);
            }

            this.InitDisplayControls();
            this.btn_Save.Enabled = true;
        }

        private void InitDisplayControls()
        {
            this._gameViewModel.LoadFromMemory();
            this.InitPropertyPanel();
        }

        private void InitPropertyPanel()
        {
            this.panel_Property.Controls.Clear();
            var propertyViewModel = this._gameViewModel.Property;
            var type = propertyViewModel.GetType();
            int index = 0;
            foreach (var property in type.GetProperties())
            {
                if (property.GetCustomAttributes(typeof(DescriptionAttribute), false).Count() > 0)
                {
                    var description = ((DescriptionAttribute)property.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
                    var value = property.GetValue(propertyViewModel, null);
                    var label = new Label();
                    label.Name = string.Format("lb_Property{0}" , property.Name);
                    label.Text = string.Format("{0}：", description);
                    label.Top = index * 30;
                    label.Width = 50;
                    if (property.PropertyType == typeof(bool))
                    {
                        var checkBox = new CheckBox();
                        checkBox.Name = string.Format("cb_Property{0}", property.Name);
                        checkBox.Checked = (bool)value;
                        checkBox.Left = 50;
                        checkBox.Top = index * 30;
                        this.panel_Property.Controls.Add(label);
                        this.panel_Property.Controls.Add(checkBox);
                    }
                    else
                    {
                        var textBox = new TextBox();
                        textBox.Name = string.Format("tb_Property{0}", property.Name);
                        textBox.Text = value.ToString();
                        textBox.Left = 50;
                        textBox.Top = index * 30;
                        this.panel_Property.Controls.Add(label);
                        this.panel_Property.Controls.Add(textBox);
                    }

                    index++;
                }
            }
        }

        Process GetGameProcess()
        {
            string processName = "kys_ori";
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            return process;
        }
    }
}
