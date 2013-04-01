using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    internal class PropertyMemory : MemoryBase
    {
        public static PropertyMemory Current;

        static PropertyMemory()
        {
            Current = new PropertyMemory();
        }

        public override int BaseAddress
        {
            get { return 0x01D403BE; }
        }

        public int AddressSpan
        {
            get
            {
                return 2;
            }
        }

        public int Attack
        {
            get { return this.BaseAddress + this.AddressSpan * 0; }
        }

        public int Defence
        {
            get { return this.BaseAddress + this.AddressSpan * 2; }
        }

        public int Dodge 
        {
            get { return this.BaseAddress + this.AddressSpan * 1; }
        }

        public int Treatment
        {
            get { return this.BaseAddress + this.AddressSpan * 3; }
        }

        public int Poison
        {
            get { return this.BaseAddress + this.AddressSpan * 4; }
        }

        public int Detoxify
        {
            get { return this.BaseAddress + this.AddressSpan * 5; }
        }

        public int Antitoxic
        {
            get { return this.BaseAddress + this.AddressSpan * 6; }
        }

        public int Palm
        {
            get { return this.BaseAddress + this.AddressSpan * 7; }
        }

        public int Sword
        {
            get { return this.BaseAddress + this.AddressSpan * 8; }
        }

        public int Knife
        {
            get { return this.BaseAddress + this.AddressSpan * 9; }
        }

        public int Special
        {
            get { return this.BaseAddress + this.AddressSpan * 10; }
        }

        public int Hidden
        {
            get { return this.BaseAddress + this.AddressSpan * 11; }
        }

        public int Quality
        {
            get { return this.BaseAddress + this.AddressSpan * 13; }
        }

        public int LeftAndRight
        {
            get { return this.BaseAddress + this.AddressSpan * 15; }
        }

        public int Reputation
        {
            get { return this.BaseAddress + this.AddressSpan * 16; }
        }

        public int Intelligence
        {
            get
            {
                return this.BaseAddress + this.AddressSpan * 17;
            }
        }
    }
}
