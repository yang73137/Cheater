using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class Max100GameMemory : GameMemory
    {
        public Max100GameMemory(string description, int memoryAddress)
            : base(description, memoryAddress, typeof(ushort))
        {
        }

        protected override object ToDisplayValue(byte[] value)
        {
            return BitConverter.ToUInt16(value, 0);
        }

        protected override byte[] ToValue(object displayValue)
        {
            ushort value = Convert.ToUInt16(displayValue);
            value = value > (ushort)100 ? (ushort)100 : value;
            return BitConverter.GetBytes(value);
        }

        public override void LoadFromMemory(IMemoryManager memoryManager)
        {
            memoryManager.ReadProcessMemory(this.MemoryAddress, this.Value, 2);
            this.DisplayValue = this.ToDisplayValue(this.Value);
        }

        public override void SaveToMemory(IMemoryManager memoryManager)
        {
            this.Value = this.ToValue(this.DisplayValue);
            memoryManager.ReadProcessMemory(this.MemoryAddress, this.Value, 2);
        }
    }
}
