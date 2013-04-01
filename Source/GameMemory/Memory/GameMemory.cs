using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Memory
{
    public abstract class GameMemory<TDisplayValue>
    {
        public GameMemory(string description, int memoryAddress)
        {
            this.Description = description;
            this.MemoryAddress = memoryAddress;
            this.DisplayValue = default(TDisplayValue);
        }

        public string Description { get; set; }
        
        public int MemoryAddress { get; protected set; }

        public ushort Value { get; set; }

        public TDisplayValue DisplayValue { get; set; }

        public int DisplayOrder { get; set; }

        public IDictionary<string, object> Properties { get; set; }

        protected abstract TDisplayValue ToDisplayValue(ushort value);

        protected abstract ushort ToValue(TDisplayValue displayValue);

        public virtual void LoadFromMemory()
        {
            this.Value = 1;
            this.DisplayValue = this.ToDisplayValue(this.Value);
        }

        public virtual void SaveToMemory()
        {
            this.DisplayValue = default(TDisplayValue);
            this.Value = this.ToValue(this.DisplayValue);
        }
    }
}
