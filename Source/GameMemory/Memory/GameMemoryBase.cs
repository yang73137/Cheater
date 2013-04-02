using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public abstract class GameMemoryBase
    {
        public GameMemoryBase(string description, int memoryAddress, Type displayType, int byteSize)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("描述错误");
            }

            if (displayType == null)
            {
                throw new ArgumentException("类型错误");
            }

            this.Description = description;
            this.MemoryAddress = memoryAddress;
            this.DisplayType = displayType;
            this.ByteSize = byteSize;
            this.Value = new byte[byteSize];
        }

        public string Description { get; set; }
        
        public int MemoryAddress { get; protected set; }

        public int ByteSize { get; protected set; }

        public Type DisplayType { get; protected set; }

        public byte[] Value { get; set; }

        public object DisplayValue { get; set; }

        public int DisplayOrder { get; set; }

        public IDictionary<string, object> Properties { get; set; }

        protected abstract object ToDisplayValue(byte[] value);

        protected abstract byte[] ToValue(object displayValue);

        public void LoadFromMemory(IMemoryManager memoryManager)
        {
            memoryManager.ReadProcessMemory(this.MemoryAddress, this.Value, this.ByteSize);
            this.DisplayValue = this.ToDisplayValue(this.Value);
        }

        public void SaveToMemory(IMemoryManager memoryManager)
        {
            this.Value = this.ToValue(this.DisplayValue);
            memoryManager.WriteProcessMemory(this.MemoryAddress, this.Value, this.ByteSize);
        }
    }
}
