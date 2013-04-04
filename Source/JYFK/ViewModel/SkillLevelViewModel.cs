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
    public class SkillLevelViewModel : ViewModelBase
    {
        public SkillLevelViewModel(Control container, IMemoryManager memoryManager) : base(container, memoryManager) { }

        private int addressSpan = 2;

        private int baseAddress = 0x1D403FA;

        private ControlManager controlManager = ControlManager.Current;

        protected override IEnumerable<GameEngine.Memory.GameMemoryBase> GetGameMemories()
        {
            return new List<GameMemoryBase>
                {
                    new UShortGameMemory("武功1", this.baseAddress + this.addressSpan * 0, 999),

                    new UShortGameMemory("武功2", this.baseAddress + this.addressSpan * 1, 999),

                    new UShortGameMemory("武功3", this.baseAddress + this.addressSpan * 2, 999),

                    new UShortGameMemory("武功4", this.baseAddress + this.addressSpan * 3, 999),

                    new UShortGameMemory("武功5", this.baseAddress + this.addressSpan * 4, 999),

                    new UShortGameMemory("武功6", this.baseAddress + this.addressSpan * 5, 999),

                    new UShortGameMemory("武功7", this.baseAddress + this.addressSpan * 6, 999),

                    new UShortGameMemory("武功8", this.baseAddress + this.addressSpan * 7, 999),

                    new UShortGameMemory("武功9", this.baseAddress + this.addressSpan * 8, 999),

                    new UShortGameMemory("武功10", this.baseAddress + this.addressSpan * 9, 999),
                };
        }

        protected override void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var labelName = string.Format("{0}_lb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateLabel(container, labelName, gameMemory.Description);

                var comboBoxName = string.Format("{0}_ccb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());

                var dataSource = this.GetAllSkillLevels();

                var value = (ushort)gameMemory.DisplayValue / (ushort)100;

                var selectedItem = dataSource.First(p => (ushort)p.Value == value);

                controlManager.CreateComboBox(container, comboBoxName, dataSource, "Key", "Value", selectedItem);
            }
        }

        protected override void SaveViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var comboBoxName = string.Format("{0}_ccb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                gameMemory.DisplayValue = (ushort)((ushort)controlManager.GetValueFromComboBox(container, comboBoxName) * 101);
            }
        }

        private IDictionary<string, object> GetAllSkillLevels()
        {
            ushort i = 0;
            IDictionary<string, object> dictionary = new Dictionary<string, object>
                    {
                        { "1级", i++ },
                        { "2级", i++ },
                        { "3级", i++ },
                        { "4级", i++ },
                        { "5级", i++ },
                        { "6级", i++ },
                        { "7级", i++ },
                        { "8级", i++ },
                        { "9级", i++ },
                        { "10级", i++ },
                    };

            return dictionary;
        }
    }
}
