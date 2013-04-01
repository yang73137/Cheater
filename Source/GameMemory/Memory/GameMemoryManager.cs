using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class GameMemoryManager
    {
        private IMemoryManager _memoryManager;
        private IEnumerable<object> _gameMemories;

        public IEnumerable<object> GameMemories
        {
            get 
            {
                return this._gameMemories;
            }
        }

        public GameMemoryManager(IMemoryManager memoryManager)
        {
            this._memoryManager = memoryManager;
            this._gameMemories = this.GetGameMemories();
        }

        public virtual IEnumerable<object> GetGameMemories()
        {
            return Enumerable.Empty<object>();
        }

        public virtual void SaveToMemory()
        {
        }
        
    }
}
