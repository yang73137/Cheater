using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class BoolGameMemory : GameMemory
    {
        public BoolGameMemory(string description, int memoryAddress) : base(description, memoryAddress, typeof(bool))
        {
        }

        protected override object ToDisplayValue(byte[] value)
        {
            return BitConverter.ToBoolean(value, 0);
        }

        protected override byte[] ToValue(object displayValue)
        {
            return BitConverter.GetBytes((bool)displayValue);
        }

        public override void LoadFromMemory(IMemoryManager memoryManager)
        {
            memoryManager.ReadProcessMemory(this.MemoryAddress, this.Value, 2); 
        }

        public override void SaveToMemory(IMemoryManager memoryManager)
        {
            memoryManager.WriteProcessMemory(this.MemoryAddress, this.Value, 2); 
        }
    }
}
