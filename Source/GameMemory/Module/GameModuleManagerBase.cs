using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public abstract class GameModuleManagerBase
    {
        public IEnumerable<GameMemory> GameMemories { get; protected set; }

        private IntPtr _hProcess;

        private IMemoryManager _memoryManager;

        public GameModuleManagerBase(IntPtr hProcess, IMemoryManager memoryManager)
        {
            this._hProcess = hProcess;
            this._memoryManager = memoryManager;
        }

        protected abstract void InitGameMemories();

        protected abstract int BaseAddress { get; }

        public void LoadFromMemory()
        {
            if (this.GameMemories != null)
            {
                foreach (var gameMemory in this.GameMemories)
                {
                    gameMemory.SaveToMemory(this._memoryManager);
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
