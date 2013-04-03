using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public class SkillModuleManager : GameModuleManagerBase
    {
        private int _addressSpan = 2;

        private IEnumerable<GameMemoryBase> _gameMemories;

        public SkillModuleManager(IMemoryManager memoryManager) : base(memoryManager)
        {
        }

        public override IEnumerable<GameMemoryBase> GameMemories
        {
            get
            {
                if (this._gameMemories == null)
                {
                    this.InitGameMemories();
                }

                return this._gameMemories;
            }
        }

        protected void InitGameMemories()
        {
            this._gameMemories = new List<GameMemoryBase>
                {
                    new UShortGameMemory("武功1", this.BaseAddress + this._addressSpan * 0, 99),

                    new UShortGameMemory("武功2", this.BaseAddress + this._addressSpan * 1, 99),

                    new UShortGameMemory("武功3", this.BaseAddress + this._addressSpan * 2, 99),

                    new UShortGameMemory("武功4", this.BaseAddress + this._addressSpan * 3, 99),

                    new UShortGameMemory("武功5", this.BaseAddress + this._addressSpan * 4, 99),

                    new UShortGameMemory("武功6", this.BaseAddress + this._addressSpan * 5, 99),

                    new UShortGameMemory("武功7", this.BaseAddress + this._addressSpan * 6, 99),

                    new UShortGameMemory("武功8", this.BaseAddress + this._addressSpan * 7, 99),

                    new UShortGameMemory("武功9", this.BaseAddress + this._addressSpan * 8, 99),

                    new UShortGameMemory("武功10", this.BaseAddress + this._addressSpan * 9, 99),
                };

            foreach (var gameMemory in this._gameMemories)
            {
                ushort i = 0;
                gameMemory.Properties = new Dictionary<string, object>
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
            }
        }

        protected override int BaseAddress
        {
            get
            {
                return 0x1D403E6;
            }
        }
    }
}
