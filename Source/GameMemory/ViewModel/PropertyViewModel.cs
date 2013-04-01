using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;
using System.ComponentModel;
using System.Reflection;

namespace GameEngine.ViewModel
{
    public class PropertyViewModel : ViewModelBase
    {
        private PropertyMemory _propertyMemory;
        private Win32ApiHelper _win32Helper;

        [Description("攻击")]
        public int Attack
        {
            get;
            set;
        }

        [Description("防御")]
        public int Defence
        {
            get;
            set;
        }

        [Description("轻功")]
        public int Dodge
        {
            get;
            set;
        }

        [Description("医疗")]
        public int Treatment
        {
            get;
            set;
        }

        [Description("用毒")]
        public int Poison
        {
            get;
            set;
        }

        [Description("解毒")]
        public int Detoxify
        {
            get;
            set;
        }

        [Description("抗毒")]
        public int Antitoxic
        {
            get;
            set;
        }

        [Description("拳掌")]
        public int Palm
        {
            get;
            set;
        }

        [Description("御剑")]
        public int Sword
        {
            get;
            set;
        }

        [Description("耍刀")]
        public int Knife
        {
            get;
            set;
        }

        [Description("特殊")]
        public int Special
        {
            get;
            set;
        }

        [Description("暗器")]
        public int Hidden
        {
            get;
            set;
        }

        [Description("品德")]
        public int Quality { get; set; }

        [Description("资质")]
        public int Intelligence { get; set; }

        [Description("左右")]
        public bool LeftAndRight { get; set; }

        [Description("声望")]
        public int Reputation { get; set; }

        internal PropertyViewModel(PropertyMemory propertyMemory, Win32ApiHelper win32Helper)
        {
            if (propertyMemory == null || win32Helper == null)
            {
                throw new ArgumentNullException();
            }

            this._propertyMemory = propertyMemory;
            this._win32Helper = win32Helper;
        }

        public override void LoadFromMemory()
        {
            this.Attack = this._win32Helper.ReadProcessMemory(this._propertyMemory.Attack);
            this.Defence = this._win32Helper.ReadProcessMemory(this._propertyMemory.Defence);
            this.Dodge = this._win32Helper.ReadProcessMemory(this._propertyMemory.Dodge);
            this.Treatment = this._win32Helper.ReadProcessMemory(this._propertyMemory.Treatment);
            this.Poison = this._win32Helper.ReadProcessMemory(this._propertyMemory.Poison);
            this.Detoxify = this._win32Helper.ReadProcessMemory(this._propertyMemory.Detoxify);
            this.Antitoxic = this._win32Helper.ReadProcessMemory(this._propertyMemory.Antitoxic);
            this.Palm = this._win32Helper.ReadProcessMemory(this._propertyMemory.Palm);
            this.Sword = this._win32Helper.ReadProcessMemory(this._propertyMemory.Sword);
            this.Knife = this._win32Helper.ReadProcessMemory(this._propertyMemory.Knife);
            this.Special = this._win32Helper.ReadProcessMemory(this._propertyMemory.Special);
            this.Hidden = this._win32Helper.ReadProcessMemory(this._propertyMemory.Hidden);
            this.LeftAndRight = Convert.ToBoolean(this._win32Helper.ReadProcessMemory(this._propertyMemory.LeftAndRight));
            this.Intelligence = this._win32Helper.ReadProcessMemory(this._propertyMemory.Intelligence);
            this.Quality = this._win32Helper.ReadProcessMemory(this._propertyMemory.Quality);
            this.Reputation = this._win32Helper.ReadProcessMemory(this._propertyMemory.Reputation);
        }

        public override void SaveToMemory()
        {
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Attack, this.Attack);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Defence, this.Defence);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Dodge, this.Dodge);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Treatment, this.Treatment);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Poison, this.Poison);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Detoxify, this.Detoxify);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Antitoxic, this.Antitoxic);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Palm, this.Palm);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Sword, this.Sword);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Knife, this.Knife);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Special, this.Special);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Hidden, this.Hidden);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.LeftAndRight, Convert.ToInt32(this.LeftAndRight));
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Intelligence, this.Intelligence);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Quality, this.Quality);
            this._win32Helper.WriteProcessMemory(this._propertyMemory.Reputation, this.Reputation);
        }
    }
}
