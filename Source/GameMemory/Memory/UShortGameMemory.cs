using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class UShortGameMemory : GameMemoryBase
    {
        private ushort _maxValue;

        public UShortGameMemory(string description, int memoryAddress, ushort maxValue)
            : base(description, memoryAddress, typeof(ushort), 2)
        {
            this._maxValue = maxValue;
        }

        protected override object ToDisplayValue(byte[] value)
        {
            return BitConverter.ToUInt16(value, 0);
        }

        protected override byte[] ToValue(object displayValue)
        {
            var value = displayValue as Nullable<ushort>;

            return value.HasValue ? BitConverter.GetBytes(value.Value > this._maxValue ? this._maxValue : value.Value) : BitConverter.GetBytes(0);
        }
    }
}
