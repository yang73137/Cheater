using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class BoolGameMemory : GameMemoryBase
    {
        public BoolGameMemory(string description, int memoryAddress) : base(description, memoryAddress, typeof(bool), 2)
        {
        }

        protected override object ToDisplayValue(byte[] value)
        {
            return BitConverter.ToBoolean(value, 0);
        }

        protected override byte[] ToValue(object displayValue)
        {
            var value = displayValue as Nullable<bool>;
            return BitConverter.GetBytes(value.HasValue ? value.Value : false);
        }
    }
}
