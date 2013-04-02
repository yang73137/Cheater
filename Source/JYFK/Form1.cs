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
using GameEngine.Module;

namespace JYFK
{
    public partial class Form1 : Form
    {
        private Process _gameProcess;
        private PropertyModuleManager _propertyModuleManager;

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

            foreach (var property in this._propertyModuleManager.GameMemories)
            {
                if (property.DisplayType == typeof(bool))
                {
                    bool value = ((CheckBox)this.panel_Property.Controls[string.Format("cb_Property{0}", property.MemoryAddress.ToString())]).Checked;
                    property.DisplayValue = value;
                }
                else if (property.DisplayType == typeof(ushort))
                {
                    ushort value;
                    if (
                        !UInt16.TryParse(
                            this.panel_Property.Controls[string.Format("tb_Property{0}", property.MemoryAddress.ToString())].Text,
                            out value))
                    {
                        value = 0;
                    }

                    property.DisplayValue = value;
                }
            }

            try
            {
                this._propertyModuleManager.SaveToMemory();
                this.DrawPropertyPanel();
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("修改失败");
            }
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
                this._propertyModuleManager = new PropertyModuleManager(new Win32ApiHelper(this._gameProcess.Handle));
            }

            this.btn_Save.Enabled = true;
            this.btn_Save.Cursor = Cursors.Hand;

            this.DrawPropertyPanel();
        }

        private void DrawPropertyPanel()
        {
            try
            {
                this._propertyModuleManager.LoadFromMemory();
            }
            catch
            {
                MessageBox.Show("读取成功");
            }

            int xIndex = 0;
            int yIndex = 0;

            foreach (var property in this._propertyModuleManager.GameMemories)
            {
                var label = this.panel_Property.Controls[string.Format("lb_Property{0}", property.MemoryAddress.ToString())] as Label;

                if (label == null)
                {
                    label = new Label();
                    label.Name = string.Format("lb_Property{0}", property.MemoryAddress.ToString());
                    label.Text = string.Format("{0}：", property.Description);
                    label.Left = xIndex * 180;
                    label.Top = yIndex * 30;
                    label.Width = 80;
                    label.TextAlign = ContentAlignment.MiddleRight;
                    this.panel_Property.Controls.Add(label);
                }
                
                if (property.DisplayType == typeof(bool))
                {
                    var checkBox = this.panel_Property.Controls[string.Format("cb_Property{0}", property.MemoryAddress.ToString())] as CheckBox;

                    if (checkBox == null)
                    {
                        checkBox = new CheckBox();
                        checkBox.Name = string.Format("cb_Property{0}", property.MemoryAddress.ToString());
                        checkBox.Checked = BitConverter.ToBoolean(property.Value, 0);
                        checkBox.Left = 80 + xIndex * 180;
                        checkBox.Top = yIndex * 30;
                        checkBox.Height = 23;
                        checkBox.Cursor = Cursors.Hand;
                        this.panel_Property.Controls.Add(checkBox);
                    }

                    checkBox.Checked = (bool)property.DisplayValue;
                }
                else if (property.DisplayType == typeof(ushort))
                {
                    var textBox = this.panel_Property.Controls[string.Format("tb_Property{0}", property.MemoryAddress.ToString())] as TextBox;

                    if (textBox == null)
                    {
                        textBox = new TextBox();
                        textBox.Name = string.Format("tb_Property{0}", property.MemoryAddress.ToString());
                        textBox.Left = 80 + xIndex * 180;
                        textBox.Top = yIndex * 30;
                        textBox.Height = 23;
                        this.panel_Property.Controls.Add(textBox);
                    }

                    textBox.Text = property.DisplayValue.ToString();
                }

                yIndex++;

                if (yIndex * 30 >= this.panel_Property.Height)
                {
                    yIndex = 0;
                    xIndex++;
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
