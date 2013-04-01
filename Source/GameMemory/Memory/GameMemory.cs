using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public abstract class GameMemory
    {
        public GameMemory(string description, int memoryAddress, Type displayValue)
        {
            this.Description = description;
            this.MemoryAddress = memoryAddress;
            this.DisplayType = DisplayType;
        }

        public string Description { get; set; }
        
        public int MemoryAddress { get; protected set; }

        public Type DisplayType { get; protected set; }

        public byte[] Value { get; set; }

        public object DisplayValue { get; set; }

        public int DisplayOrder { get; set; }

        public IDictionary<string, object> Properties { get; set; }

        protected abstract object ToDisplayValue(byte[] value);

        protected abstract byte[] ToValue(object displayValue);

        public abstract void LoadFromMemory(IMemoryManager memoryManager);

        public abstract void SaveToMemory(IMemoryManager memoryManager);
    }
}
