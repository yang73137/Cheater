using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public PropertyViewModel Property { get; protected set; }


        public GameViewModel(IntPtr hProcess)
        {
            Win32ApiHelper helper = new Win32ApiHelper(hProcess);
            this.Property = new PropertyViewModel(PropertyMemory.Current, helper);
        }

        public override void LoadFromMemory()
        {
            this.Property.LoadFromMemory();
        }

        public override void SaveToMemory()
        {
            this.Property.SaveToMemory();
        }
    }
}
