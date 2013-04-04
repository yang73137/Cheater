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
    public class SkillViewModel : ViewModelBase
    {
        public SkillViewModel(Control container, IMemoryManager memoryManager) : base(container, memoryManager) { }

        private int addressSpan = 2;

        private int baseAddress = 0x1D403E6;

        private ControlManager controlManager = ControlManager.Current;

        protected override IEnumerable<GameEngine.Memory.GameMemoryBase> GetGameMemories()
        {
            return new List<GameMemoryBase>
                {
                    new UShortGameMemory("武功1", this.baseAddress + this.addressSpan * 0, 99),

                    new UShortGameMemory("武功2", this.baseAddress + this.addressSpan * 1, 99),

                    new UShortGameMemory("武功3", this.baseAddress + this.addressSpan * 2, 99),

                    new UShortGameMemory("武功4", this.baseAddress + this.addressSpan * 3, 99),

                    new UShortGameMemory("武功5", this.baseAddress + this.addressSpan * 4, 99),

                    new UShortGameMemory("武功6", this.baseAddress + this.addressSpan * 5, 99),

                    new UShortGameMemory("武功7", this.baseAddress + this.addressSpan * 6, 99),

                    new UShortGameMemory("武功8", this.baseAddress + this.addressSpan * 7, 99),

                    new UShortGameMemory("武功9", this.baseAddress + this.addressSpan * 8, 99),

                    new UShortGameMemory("武功10", this.baseAddress + this.addressSpan * 9, 99),
                };
        }

        protected override void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var labelName = string.Format("{0}_lb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateLabel(container, labelName, gameMemory.Description);

                var comboBoxName = string.Format("{0}_ccb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());

                var dataSource = this.GetAllSkills();
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

        private IDictionary<string, object> GetAllSkills()
        {
            ushort i = 0;
            IDictionary<string, object> dictionary = new Dictionary<string, object>
                    {
                        { "无", i++ },
                        { "野球拳", i++ },
                        { "武当长拳", i++ },
                        { "罗汉拳", i++ },
                        { "灵蛇拳", i++ },
                        { "神王毒掌", i++ },
                        { "七伤拳", i++ },
                        { "混元掌", i++ },
                        { "寒冰绵掌", i++ },
                        { "鹰爪功", i++ },
                        { "逍遥掌", i++ },

                        { "铁掌", i++ },
                        { "幻阴指", i++ },
                        { "寒冰神掌", i++ },
                        { "千手如来掌", i++ },
                        { "天山六阳掌", i++ },
                        { "玄冥神掌", i++ },
                        { "冰蚕毒掌", i++ },
                        { "龙象般若功", i++ },
                        { "一阳指", i++ },
                        { "太极拳", i++ },


                        { "空明拳", i++ },
                        { "蛤蟆功", i++ },
                        { "太玄神功", i++ },
                        { "黯然销魂掌", i++ },
                        { "降龙十八掌", i++ },
                        { "葵花神功", i++ },
                        { "化功大法", i++ },
                        { "吸星大法", i++ },
                        { "北冥神功", i++ },
                        { "六脉神剑", i++ },

                        { "躺尸剑法", i++ },
                        { "青城剑法", i++ },
                        { "冰雪剑法", i++ },
                        { "恒山剑法", i++ },
                        { "泰山剑法", i++ },
                        { "衡山剑法", i++ },
                        { "华山剑法", i++ },
                        { "嵩山剑法", i++ },
                        { "全真剑法", i++ },
                        { "峨嵋剑法", i++ },

                        { "武当剑法", i++ },
                        { "万花剑法", i++ },
                        { "泼墨剑法", i++ },
                        { "雪山剑法", i++ },
                        { "泰山十八盘", i++ },
                        { "回峰落雁剑法", i++ },
                        { "两仪剑法", i++ },
                        { "太岳三青峰", i++ },
                        { "玉女素心剑", i++ },
                        { "逍遥剑法", i++ },

                        { "慕容剑法", i++ },
                        { "倚天剑法", i++ },
                        { "七星剑法", i++ },
                        { "金蛇剑法", i++ },
                        { "苗家剑法", i++ },
                        { "玉箫剑法", i++ },
                        { "玄铁剑法", i++ },
                        { "太极剑法", i++ },
                        { "达摩剑法", i++ },
                        { "辟邪剑法", i++ },

                        { "独孤九剑", i++ },
                        { "西瓜刀法", i++ },
                        { "血刀大法", i++ },
                        { "狂风刀法", i++ },
                        { "反两仪刀法", i++ },
                        { "火焰刀法", i++ },
                        { "胡家刀法", i++ },
                        { "霹雳刀法", i++ },
                        { "神龙双钩", i++ },
                        { "大轮杖法", i++ },

                        { "怪异武器", i++ },
                        { "炼石弹", i++ },
                        { "叫化棍法", i++ },
                        { "火焰发射器", i++ },
                        { "鳄鱼剪", i++ },
                        { "大蜘蛛", i++ },
                        { "毒龙鞭法", i++ },
                        { "黄沙万里鞭法", i++ },
                        { "雪怪", i++ },
                        { "判官笔", i++ },

                        { "持棋盘", i++ },
                        { "大剪刀", i++ },
                        { "持瑶琴", i++ },
                        { "大莽蛇", i++ },
                        { "金花杖法", i++ },
                        { "神龙鹿杖", i++ },
                        { "打狗棍法", i++ },
                        { "五轮大法", i++ },
                        { "松风剑法", i++ },
                        { "普通攻击", i++ },

                        { "狮子吼", i++ },
                        { "九阳神功", i++ },
                    };

            return dictionary;
        }
    }
}
