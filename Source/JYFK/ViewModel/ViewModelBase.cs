using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameEngine;
using GameEngine.Memory;

namespace JYFK.ViewModel
{
    public abstract class ViewModelBase
    {
        private IEnumerable<GameMemoryBase> gameMemories;

        protected Control container;

        protected IMemoryManager memoryManager;

        public ViewModelBase(Control container, IMemoryManager memoryManager)
        {
            if (container == null)
            {
                throw new ArgumentNullException();
            }

            this.container = container;
            this.memoryManager = memoryManager;
        }

        protected virtual void LoadGameMemories(IEnumerable<GameMemoryBase> gameMemories)
        {
            if (gameMemories != null)
            {
                foreach (var gameMemory in gameMemories)
                {
                    gameMemory.LoadFromMemory(this.memoryManager);
                }
            }
        }

        protected virtual void SaveGameMemories(IEnumerable<GameMemoryBase> gameMemories)
        {
            if (gameMemories != null)
            {
                foreach (var gameMemory in gameMemories)
                {
                    gameMemory.SaveToMemory(this.memoryManager);
                }
            }
        }

        protected IEnumerable<GameMemoryBase> GameMemories 
        {
            get
            {
                return this.gameMemories ?? (this.gameMemories = this.GetGameMemories());
            }
        }

        protected abstract IEnumerable<GameMemoryBase> GetGameMemories(); 

        protected abstract void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories);

        protected abstract void SaveViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories);

        public void Load()
        {
            this.LoadGameMemories(this.GameMemories);
            this.LoadViewModel(this.container, this.GameMemories);
        }

        public void Save()
        {
            this.SaveViewModel(this.container, this.GameMemories);
            this.SaveGameMemories(this.GameMemories);
        }
    }
}
