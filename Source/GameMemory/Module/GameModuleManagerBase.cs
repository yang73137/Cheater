using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public abstract class GameModuleManagerBase
    {
        private IMemoryManager _memoryManager;

        public GameModuleManagerBase(IMemoryManager memoryManager)
        {
            this._memoryManager = memoryManager;
        }

        public abstract IEnumerable<GameMemoryBase> GameMemories { get; }

        protected abstract int BaseAddress { get; }

        public void LoadFromMemory()
        {
            if (this.GameMemories != null)
            {
                foreach (var gameMemory in this.GameMemories)
                {
                    gameMemory.LoadFromMemory(this._memoryManager);
                }
            }
        }

        public void SaveToMemory()
        {
            if (this.GameMemories != null)
            {
                foreach (var gameMemory in this.GameMemories)
                {
                    gameMemory.SaveToMemory(this._memoryManager);
                }
            }
        }
    }
}
