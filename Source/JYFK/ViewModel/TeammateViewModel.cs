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
    public class TeammateViewModel : ViewModelBase
    {
        public TeammateViewModel(Control container, IMemoryManager memoryManager) : base(container, memoryManager) { }

        private int addressSpan = 2;

        private int baseAddress = 0x1D4032A;

        private IDictionary<string, object> teammates;

        private ControlManager controlManager = ControlManager.Current;

        protected override IEnumerable<GameEngine.Memory.GameMemoryBase> GetGameMemories()
        {
            return new List<GameMemoryBase>
                {
                    new UShortGameMemory("队友1", this.baseAddress + this.addressSpan * 0, 65535),

                    new UShortGameMemory("队友2", this.baseAddress + this.addressSpan * 1, 65535),

                    new UShortGameMemory("队友3", this.baseAddress + this.addressSpan * 2, 65535),

                    new UShortGameMemory("队友4", this.baseAddress + this.addressSpan * 3, 65535),

                    new UShortGameMemory("队友5", this.baseAddress + this.addressSpan * 4, 65535),
                };
        }

        protected override void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var labelName = string.Format("{0}_lb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateLabel(container, labelName, gameMemory.Description);

                var comboBoxName = string.Format("{0}_ccb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());

                var dataSource = this.GetAllTeammates();
                var selectedItem = dataSource.FirstOrDefault(p => (ushort)p.Value == (ushort)gameMemory.DisplayValue);

                controlManager.CreateComboBox(container, comboBoxName, dataSource, "Key", "Value", selectedItem);
            }
        }

        protected override void SaveViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var comboBoxName = string.Format("{0}_ccb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                gameMemory.DisplayValue = (ushort)controlManager.GetValueFromComboBox(container, comboBoxName);
            }
        }

        private IDictionary<string, object> GetAllTeammates()
        {
            if (this.teammates != null)
            {
                return this.teammates;
            }

            ushort i = 1;
            IDictionary<string, object> dictionary = new Dictionary<string, object>
                    {
                        { "无", (ushort)65535 },
                        { "胡斐", i++ },
                        { "程灵素", i++ },
                        { "苗人凤", i++ },
                        { "阎基", i++ },
                        { "张三丰", i++ },
                        { "灭绝师太", i++ },
                        { "何太冲", i++ },
                        { "唐文亮", i++ },
                        { "张无忌", i++ },
                        { "范遥", i++ },

                        { "杨逍", i++ },
                        { "殷天正", i++ },
                        { "谢逊", i++ },
                        { "韦一笑", i++ },
                        { "金花婆婆", i++ },
                        { "胡青牛", i++ },
                        { "王难姑", i++ },
                        { "成昆", i++ },
                        { "岳不群", i++ },
                        { "莫大", i++ },


                        { "定闲", i++ },
                        { "左冷禅", i++ },
                        { "天门道长", i++ },
                        { "余沧海", i++ },
                        { "蓝凤凰", i++ },
                        { "任我行", i++ },
                        { "东方不败", i++ },
                        { "平一指", i++ },
                        { "田伯光", i++ },
                        { "风清扬", i++ },

                        { "丹青生", i++ },
                        { "秃笔翁", i++ },
                        { "黑白子", i++ },
                        { "黄钟公", i++ },
                        { "令狐冲", i++ },
                        { "林平之", i++ },
                        { "狄云", i++ },
                        { "石破天", i++ },
                        { "龙岛主", i++ },
                        { "木岛主", i++ },

                        { "张三", i++ },
                        { "李四", i++ },
                        { "白万剑", i++ },
                        { "岳老三", i++ },
                        { "薛慕华", i++ },
                        { "丁春秋", i++ },
                        { "阿紫", i++ },
                        { "游坦之", i++ },
                        { "虚竹", i++ },
                        { "乔峰", i++ },
                        

                        { "慕容复", i++ },
                        { "苏星河", i++ },
                        { "段誉", i++ },
                        { "袁承志", i++ },
                        { "郭靖", i++ },
                        { "黄蓉", i++ },
                        { "黄药师", i++ },
                        { "杨过", i++ },
                        { "小龙女", i++ },
                        { "欧阳锋", i++ },

                        { "欧阳克", i++ },
                        { "金轮法王", i++ },
                        { "程英", i++ },
                        { "周伯通", i++ },
                        { "一灯", i++ },
                        { "神算子", i++ },

                        { "裘千仞", i++ },
                        { "丘处机", i++ },
                        { "洪七公", i++ },
                        { "玄慈", i++ },
                        { "洪教主", i++ },
                        { "孔八拉", i++ },
                        { "南贤", i++ },
                        { "北丑", i++ },
                        { "厨师", i++ },
                        { "王语嫣", i++ },
                    };

            this.teammates = dictionary;
            return this.teammates;
        }
    }
}
