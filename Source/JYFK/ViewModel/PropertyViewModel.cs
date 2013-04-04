using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameEngine;
using GameEngine.Memory;
using System.Drawing;

namespace JYFK.ViewModel
{
    public class PropertyViewModel : ViewModelBase
    {
        public PropertyViewModel(Control container, IMemoryManager memoryManager) : base(container, memoryManager) { }

        private int addressSpan = 2;

        private int baseAddress = 0x1D40386;

        private ControlManager controlManager = ControlManager.Current;

        protected override IEnumerable<GameMemoryBase> GetGameMemories()
        {
            return new List<GameMemoryBase>
                {
                    new UShortGameMemory("等级", this.baseAddress + this.addressSpan * 0, 30),
                        
                    new UShortGameMemory("经验", this.baseAddress + this.addressSpan * 1, 65535), 
                       
                    new UShortGameMemory("生命", this.baseAddress + this.addressSpan * 2, 999), 
                       
                    new UShortGameMemory("最大生命", this.baseAddress + this.addressSpan * 3, 999),
 
                    new UShortGameMemory("受伤程度", this.baseAddress + this.addressSpan * 4, 100),

                    new UShortGameMemory("中毒程度", this.baseAddress + this.addressSpan * 5, 100),

                    new UShortGameMemory("体力", this.baseAddress + this.addressSpan * 6, 100),
                       
                    new UShortGameMemory("内力", this.baseAddress + this.addressSpan * 26, 999), 
                        
                    new UShortGameMemory("最大内力", this.baseAddress + this.addressSpan * 27, 999), 
                       
                    new UShortGameMemory("攻击", this.baseAddress + this.addressSpan * 28, 100), 
                        
                    new UShortGameMemory("防御", this.baseAddress + this.addressSpan * 30, 100), 
                        
                    new UShortGameMemory("轻功", this.baseAddress + this.addressSpan * 29, 100), 
                       
                    new UShortGameMemory("医疗", this.baseAddress + this.addressSpan * 31, 100), 
                        
                    new UShortGameMemory("用毒", this.baseAddress + this.addressSpan * 32, 100), 
                       
                    new UShortGameMemory("解毒", this.baseAddress + this.addressSpan * 33, 100), 
                        
                    new UShortGameMemory("抗毒", this.baseAddress + this.addressSpan * 34, 100), 
                        
                    new UShortGameMemory("拳掌", this.baseAddress + this.addressSpan * 35, 100), 
                        
                    new UShortGameMemory("御剑", this.baseAddress + this.addressSpan * 36, 100), 
                        
                    new UShortGameMemory("耍刀", this.baseAddress + this.addressSpan * 37, 100), 
                        
                    new UShortGameMemory("特殊", this.baseAddress + this.addressSpan * 38, 100), 
                        
                    new UShortGameMemory("暗器", this.baseAddress + this.addressSpan * 39, 100),

                    new BoolGameMemory("左右", this.baseAddress + this.addressSpan * 43), 

                    new UShortGameMemory("声望", this.baseAddress + this.addressSpan * 44, 255), 

                    new UShortGameMemory("资质", this.baseAddress + this.addressSpan * 45, 255)
                };
        }

        protected override void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var labelName = string.Format("{0}_lb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateLabel(container, labelName, gameMemory.Description);

                if (gameMemory.DisplayType == typeof(bool))
                {
                    var checkBoxName = string.Format("{0}_cb_{1}", container.Name, gameMemory.MemoryAddress.ToString());
                    controlManager.CreateCheckBox(container, checkBoxName, (bool)gameMemory.DisplayValue);
                }
                else if (gameMemory.DisplayType == typeof(ushort))
                {
                    var textBoxName = string.Format("{0}_tb_{1}", container.Name, gameMemory.MemoryAddress.ToString());
                    controlManager.CreateTextBox(container, textBoxName, gameMemory.DisplayValue.ToString());
                }
            }
        }

        protected override void SaveViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                if (gameMemory.DisplayType == typeof(bool))
                {
                    var checkBoxName = string.Format("{0}_cb_{1}", container.Name, gameMemory.MemoryAddress.ToString());
                    gameMemory.DisplayValue = controlManager.GetValueFromCheckBox(container, checkBoxName);
                }
                else if (gameMemory.DisplayType == typeof(ushort))
                {
                    var textBoxName = string.Format("{0}_tb_{1}", container.Name, gameMemory.MemoryAddress.ToString());

                    ushort dispayValue = 0;

                    UInt16.TryParse(controlManager.GetValueFromTextBox(container, textBoxName), out dispayValue);

                    gameMemory.DisplayValue = dispayValue;
                }
            }
        }
    }
}
