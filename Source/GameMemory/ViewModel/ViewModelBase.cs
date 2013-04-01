using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.ViewModel
{
    public abstract class ViewModelBase
    {
        public abstract void LoadFromMemory();
        public abstract void SaveToMemory();
    }
}
