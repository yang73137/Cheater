using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public class SkillLevelModuleManager : GameModuleManagerBase
    {
        private int _addressSpan = 2;

        private IEnumerable<GameMemoryBase> _gameMemories;

        public SkillLevelModuleManager(IMemoryManager memoryManager)
            : base(memoryManager)
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
                    new UShortGameMemory("武功1", this.BaseAddress + this._addressSpan * 0, 999),

                    new UShortGameMemory("武功2", this.BaseAddress + this._addressSpan * 1, 999),

                    new UShortGameMemory("武功3", this.BaseAddress + this._addressSpan * 2, 999),

                    new UShortGameMemory("武功4", this.BaseAddress + this._addressSpan * 3, 999),

                    new UShortGameMemory("武功5", this.BaseAddress + this._addressSpan * 4, 999),

                    new UShortGameMemory("武功6", this.BaseAddress + this._addressSpan * 5, 999),

                    new UShortGameMemory("武功7", this.BaseAddress + this._addressSpan * 6, 999),

                    new UShortGameMemory("武功8", this.BaseAddress + this._addressSpan * 7, 999),

                    new UShortGameMemory("武功9", this.BaseAddress + this._addressSpan * 8, 999),

                    new UShortGameMemory("武功10", this.BaseAddress + this._addressSpan * 9, 999),
                };
        }

        protected override int BaseAddress
        {
            get
            {
                return 0x1D403FA;
            }
        }
    }
}
