using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public class PropertyModuleManager : GameModuleManagerBase
    {
        private int _addressSpan = 2;

        private IEnumerable<GameMemoryBase> _gameMemories;

        public PropertyModuleManager(IMemoryManager memoryManager)
            : base(memoryManager)
        {
            this.InitGameMemories();
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
                    new UShortGameMemory("等级", this.BaseAddress + this._addressSpan * 0, 30),
                        
                    new UShortGameMemory("经验", this.BaseAddress + this._addressSpan * 1, 65535), 
                       
                    new UShortGameMemory("生命", this.BaseAddress + this._addressSpan * 2, 999), 
                       
                    new UShortGameMemory("最大生命", this.BaseAddress + this._addressSpan * 3, 999),
 
                    new UShortGameMemory("受伤程度", this.BaseAddress + this._addressSpan * 4, 100),

                    new UShortGameMemory("中毒程度", this.BaseAddress + this._addressSpan * 5, 100),

                    new UShortGameMemory("体力", this.BaseAddress + this._addressSpan * 6, 100),
                       
                    new UShortGameMemory("内力", this.BaseAddress + this._addressSpan * 26, 999), 
                        
                    new UShortGameMemory("最大内力", this.BaseAddress + this._addressSpan * 27, 999), 
                       
                    new UShortGameMemory("攻击", this.BaseAddress + this._addressSpan * 28, 100), 
                        
                    new UShortGameMemory("防御", this.BaseAddress + this._addressSpan * 30, 100), 
                        
                    new UShortGameMemory("轻功", this.BaseAddress + this._addressSpan * 29, 100), 
                       
                    new UShortGameMemory("医疗", this.BaseAddress + this._addressSpan * 31, 100), 
                        
                    new UShortGameMemory("用毒", this.BaseAddress + this._addressSpan * 32, 100), 
                       
                    new UShortGameMemory("解毒", this.BaseAddress + this._addressSpan * 33, 100), 
                        
                    new UShortGameMemory("抗毒", this.BaseAddress + this._addressSpan * 34, 100), 
                        
                    new UShortGameMemory("拳掌", this.BaseAddress + this._addressSpan * 35, 100), 
                        
                    new UShortGameMemory("御剑", this.BaseAddress + this._addressSpan * 36, 100), 
                        
                    new UShortGameMemory("耍刀", this.BaseAddress + this._addressSpan * 37, 100), 
                        
                    new UShortGameMemory("特殊", this.BaseAddress + this._addressSpan * 38, 100), 
                        
                    new UShortGameMemory("暗器", this.BaseAddress + this._addressSpan * 39, 100),

                    new BoolGameMemory("左右", this.BaseAddress + this._addressSpan * 43), 

                    new UShortGameMemory("声望", this.BaseAddress + this._addressSpan * 44, 255), 

                    new UShortGameMemory("资质", this.BaseAddress + this._addressSpan * 45, 255)
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
