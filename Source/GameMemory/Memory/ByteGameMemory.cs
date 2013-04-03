using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class ByteGameMemory : GameMemoryBase
    {
        public ByteGameMemory(string description, int memoryAddress, byte maxValue)
            : base(description, memoryAddress, typeof(byte), 1)
        {
        }

        protected override object ToDisplayValue(byte[] value)
        {
            return value[0];
        }

        protected override byte[] ToValue(object displayValue)
        {
            Nullable<byte> value = displayValue as Nullable<byte>;

            return value.HasValue ? new byte[] { value.Value } : new byte[] { 0 };
        }
    }
}
