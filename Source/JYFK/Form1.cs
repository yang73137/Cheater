using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using GameEngine;

using GameEngine.Module;

namespace JYFK
{
    public partial class Form1 : Form
    {
        private Process _gameProcess;

        private PropertyModuleManager _propertyModuleManager;

        private GoodsModuleManager _goodsModuleManager;

        private SkillModuleManager _skillModuleManager;

        private const string PropertyModuleManagerKey = "Property";

        private const string GoodsModuleManagerKey = "Goods";

        private const string SkillModuleManagerKey = "Skill";

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

            this.SaveAllGameModules();
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
                this._goodsModuleManager = new GoodsModuleManager(new Win32ApiHelper(this._gameProcess.Handle));
                this._skillModuleManager = new SkillModuleManager(new Win32ApiHelper(this._gameProcess.Handle));
            }

            this.btn_Save.Enabled = true;
            this.btn_Save.Cursor = Cursors.Hand;

            this.LoadAllGameModules();
        }

        private void LoadAllGameModules()
        {
            this.LoadGameModule(this.panel_Property, this._propertyModuleManager, PropertyModuleManagerKey);
            this.LoadGameModule(this.panel_Goods, this._goodsModuleManager, GoodsModuleManagerKey);
            this.LoadGameModule(this.panel_Skill, this._skillModuleManager, SkillModuleManagerKey);
        }

        private void LoadGameModule(Control container, GameModuleManagerBase gameModuleManager, string key)
        {
            gameModuleManager.LoadFromMemory();

            foreach (var property in gameModuleManager.GameMemories)
            {
                var lebelName = string.Format("lb_{0}{1}", key, property.MemoryAddress.ToString());
                var label = container.Controls[lebelName] as Label;

                if (label == null)
                {
                    label = new Label();
                    label.Name = lebelName;
                    label.Text = string.Format("{0}：", property.Description);
                    label.Width = 80;
                    label.TextAlign = ContentAlignment.MiddleRight;
                    container.Controls.Add(label);
                }

                if (property.DisplayType == typeof(bool))
                {
                    var checkBoxName = string.Format("cb_{0}{1}", key, property.MemoryAddress.ToString());
                    var checkBox = container.Controls[checkBoxName] as CheckBox;

                    if (checkBox == null)
                    {
                        checkBox = new CheckBox();
                        checkBox.Name = checkBoxName;
                        checkBox.Height = 23;
                        checkBox.Width = 100;
                        checkBox.Cursor = Cursors.Hand;
                        container.Controls.Add(checkBox);
                    }

                    checkBox.Checked = (bool)property.DisplayValue;
                }
                else if (property.DisplayType == typeof(ushort) || property.DisplayType == typeof(byte))
                {
                    if (property.Properties == null)
                    {
                        var textBoxName = string.Format("tb_{0}{1}", key, property.MemoryAddress.ToString());
                        var textBox = container.Controls[textBoxName] as TextBox;

                        if (textBox == null)
                        {
                            textBox = new TextBox();
                            textBox.Name = textBoxName;
                            textBox.Height = 23;
                            container.Controls.Add(textBox);
                        }

                        textBox.Text = property.DisplayValue.ToString();
                    }
                    else
                    {
                        var comboBoxName = string.Format("cbb_{0}{1}", key, property.MemoryAddress.ToString());

                        var comboBox = container.Controls[comboBoxName] as ComboBox;
                        var dataSource = property.Properties.ToList();

                        if (comboBox == null)
                        {
                            comboBox = new ComboBox();

                            comboBox.Name = comboBoxName;
                            comboBox.DataSource = dataSource;
                            comboBox.DisplayMember = "Key";
                            comboBox.ValueMember = "Value";
                            comboBox.Width = 100;
                            container.Controls.Add(comboBox);
                        }

                        if (property.DisplayType == typeof(ushort))
                        {
                            comboBox.SelectedItem =
                                dataSource.First(p => (ushort)p.Value == (ushort)property.DisplayValue);
                        }
                        else if (property.DisplayType == typeof(byte))
                        {
                            comboBox.SelectedItem =
                                dataSource.First(p => (byte)p.Value == (byte)property.DisplayValue);
                        }
                    }
                }
            }
        }

        private void SaveAllGameModules()
        {
            this.SaveGameModule(this.panel_Property, this._propertyModuleManager, PropertyModuleManagerKey);
            this.SaveGameModule(this.panel_Goods, this._goodsModuleManager, GoodsModuleManagerKey);
            this.SaveGameModule(this.panel_Skill, this._skillModuleManager, SkillModuleManagerKey);
        }

        private void SaveGameModule(Control container, GameModuleManagerBase gameModuleManager, string key)
        {
            foreach (var property in gameModuleManager.GameMemories)
            {
                if (property.DisplayType == typeof(bool))
                {
                    var checkBox = container.Controls[string.Format("cb_{0}{1}", key, property.MemoryAddress.ToString())] as CheckBox;
                    property.DisplayValue = checkBox == null ? false : checkBox.Checked;
                }
                else if (property.DisplayType == typeof(ushort))
                {
                    ushort value;

                    if (property.Properties == null)
                    {
                        var textBox = container.Controls[string.Format("tb_{0}{1}", key, property.MemoryAddress.ToString())] as TextBox;
                        if (textBox == null || !UInt16.TryParse(textBox.Text, out value))
                        {
                            value = 0;
                        }
                    }
                    else
                    {
                        var comboBox = container.Controls[string.Format("cbb_{0}{1}", key, property.MemoryAddress.ToString())] as ComboBox;
                        if (comboBox == null || !UInt16.TryParse(comboBox.SelectedValue.ToString(), out value))
                        {
                            value = 0;
                        }
                    }

                    property.DisplayValue = value;
                }
                else if (property.DisplayType == typeof(byte))
                {
                    byte value;

                    if (property.Properties == null)
                    {
                        var textBox = container.Controls[string.Format("tb_{0}{1}", key, property.MemoryAddress.ToString())] as TextBox;
                        if (textBox == null || !Byte.TryParse(textBox.Text, out value))
                        {
                            value = 0;
                        }
                    }
                    else
                    {
                        var comboBox = container.Controls[string.Format("cbb_{0}{1}", key, property.MemoryAddress.ToString())] as ComboBox;
                        if (comboBox == null || !Byte.TryParse(comboBox.SelectedValue.ToString(), out value))
                        {
                            value = 0;
                        }
                    }

                    property.DisplayValue = value;
                }
            }

            gameModuleManager.SaveToMemory();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadAllGameModules();
        }
        
        Process GetGameProcess()
        {
            string processName = "kys_ori";
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            return process;
        }
    }
}
