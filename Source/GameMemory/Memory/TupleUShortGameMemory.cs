using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public class TupleUShortGameMemory : GameMemoryBase
    {
        private ushort maxValue;

        public TupleUShortGameMemory(string description, int memoryAddress, ushort maxValue) : base(description, memoryAddress, typeof(Tuple<ushort, ushort>), 4)
        {
            this.maxValue = maxValue;
        }

        protected override object ToDisplayValue(byte[] value)
        {
            var first = BitConverter.ToUInt16(value, 0);
            var last = BitConverter.ToUInt16(value, 2);

            return Tuple.Create(first, last);
        }

        protected override byte[] ToValue(object displayValue)
        {
            var value = displayValue as Tuple<ushort, ushort>;

            if (value == null)
            {
                return BitConverter.GetBytes(0xff00);
            }

            var item2 = value.Item2 > maxValue ? maxValue : value.Item2;

            if (item2 == 0)
            {
                return BitConverter.GetBytes(0xff00);
            }

            return BitConverter.GetBytes(value.Item1 + (item2 << 16));
        }
    }
}
