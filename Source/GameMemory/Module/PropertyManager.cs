using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public class PropertyManager : GameModuleManagerBase
    {
        private int _addressSpan = 2;

        public PropertyManager(IntPtr hProcess, IMemoryManager memoryManager)
            : base(hProcess, memoryManager)
        {   
        }

        protected override void InitGameMemories()
        {
            this.GameMemories = new List<GameMemory>
                {
                    new Max999GameMemory("等级", this.BaseAddress + this._addressSpan * 0),

                    new Max999GameMemory("经验", this.BaseAddress + this._addressSpan * 1), 

                    new Max999GameMemory("当前生命", this.BaseAddress + this._addressSpan * 2), 

                    new Max999GameMemory("生命", this.BaseAddress + this._addressSpan * 3), 

                    new Max999GameMemory("当前内力", this.BaseAddress + this._addressSpan * 17), 

                    new Max999GameMemory("内力", this.BaseAddress + this._addressSpan * 18), 

                    new Max100GameMemory("攻击", this.BaseAddress + this._addressSpan * 19), 

                    new Max100GameMemory("防御", this.BaseAddress + this._addressSpan * 21), 

                    new Max100GameMemory("轻功", this.BaseAddress + this._addressSpan * 20), 

                    new Max100GameMemory("医疗", this.BaseAddress + this._addressSpan * 22), 

                    new Max100GameMemory("用毒", this.BaseAddress + this._addressSpan * 23), 

                    new Max100GameMemory("解毒", this.BaseAddress + this._addressSpan * 24), 

                    new Max100GameMemory("抗毒", this.BaseAddress + this._addressSpan * 25), 

                    new Max100GameMemory("拳掌", this.BaseAddress + this._addressSpan * 26), 

                    new Max100GameMemory("御剑", this.BaseAddress + this._addressSpan * 27), 

                    new Max100GameMemory("耍刀", this.BaseAddress + this._addressSpan * 28), 

                    new Max100GameMemory("特殊", this.BaseAddress + this._addressSpan * 29), 

                    new Max100GameMemory("暗器", this.BaseAddress + this._addressSpan * 30),

                    new BoolGameMemory("左右", this.BaseAddress + this._addressSpan * 3), 

                    new Max999GameMemory("声望", this.BaseAddress + this._addressSpan * 0), 

                    new Max999GameMemory("资质", this.BaseAddress + this._addressSpan * 0)
                };
        }

        protected override int BaseAddress
        {
            get
            {
                return 0x1D40386;
            }
        }
    }
}
