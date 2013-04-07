using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameEngine;
using GameEngine.Memory;
using System.Drawing;

namespace JYFK.ViewModel
{
    public class GoodsViewModel : ViewModelBase
    {
        public GoodsViewModel(Control container, IMemoryManager memoryManager) : base(container, memoryManager) { }

        private int addressSpan = 4;

        private int baseAddress = 0x6018078;

        private int maxBaseAddress = 0x6018398;

        private ControlManager controlManager = ControlManager.Current;

        private IDictionary<ushort, string> goodsDictionary;

        private IEnumerable<GameMemoryBase> decotateGameMemories;

        private List<int> emptyAddress;

        protected override IEnumerable<GameMemoryBase> GetGameMemories()
        {
            var gameMemories = new List<TupleUShortGameMemory>();
            var goodsDictionary = this.GetGoodsDictionary();
            this.emptyAddress = new List<int>();

            var bytes = this.maxBaseAddress - this.baseAddress + 2 ;
            byte[] value = new byte[bytes];
            this.memoryManager.ReadProcessMemory(this.baseAddress, value, bytes);

            for (var i = 0; i < bytes; i += 4)
            {
                var key = BitConverter.ToUInt16(value, i);

                if (goodsDictionary.ContainsKey(key))
                {
                    var desctiption = goodsDictionary[key];
                    gameMemories.Add(new TupleUShortGameMemory(desctiption, this.baseAddress + i, 999));
                }
                else
                {
                    this.emptyAddress.Add(this.baseAddress + i);
                }
            }

            return gameMemories;
        }

        protected override void LoadGameMemories(IEnumerable<GameMemoryBase> gameMemories)
        {
            gameMemories = this.GetGameMemories();
            base.LoadGameMemories(gameMemories);
            this.decotateGameMemories = this.DecorateGameMemories(gameMemories);
        }

        protected override void SaveGameMemories(IEnumerable<GameMemoryBase> gameMemories)
        {
            base.SaveGameMemories(this.decotateGameMemories);
        }

        protected override void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            this.container.Controls.Clear();

            foreach (var gameMemory in this.decotateGameMemories)
            {
                var labelName = string.Format("{0}_lb_{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateLabel(container, labelName, gameMemory.Description);

                var tuple = gameMemory.DisplayValue as Tuple<ushort, ushort>;

                var textBoxName = string.Format("{0}_tb_{1}", container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateTextBox(container, textBoxName, tuple.Item2.ToString());
            }
        }

        protected override void SaveViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in this.decotateGameMemories)
            {
                var textBoxName = string.Format("{0}_tb_{1}", container.Name, gameMemory.MemoryAddress.ToString());

                ushort dispayValue;

                UInt16.TryParse(controlManager.GetValueFromTextBox(container, textBoxName), out dispayValue);

                var tuple = gameMemory.DisplayValue as Tuple<ushort, ushort>;

                gameMemory.DisplayValue = Tuple.Create(tuple.Item1, dispayValue);
            }
        }

        protected IEnumerable<GameMemoryBase> DecorateGameMemories(IEnumerable<GameMemoryBase> gameMemories)
        {
            var list = new List<GameMemoryBase>(gameMemories);
            var index = 0;

            foreach (var noGoods in goodsDictionary.Select(p => p.Value).Except(gameMemories.Select(p => p.Description)))
            {
                var memory = new TupleUShortGameMemory(noGoods, this.emptyAddress[index++], 999);
                var key = goodsDictionary.First(p => p.Value == noGoods).Key;
                memory.DisplayValue = Tuple.Create(key, (ushort)0);
                list.Add(memory);
            }

            list = (from p in list
                   join q in this.goodsDictionary on p.Description equals q.Value
                   orderby q.Key
                   select p).ToList();
                  
            return list;
        }

        private IDictionary<ushort, string> GetGoodsDictionary()
        {
            if (this.goodsDictionary != null)
            {
                return this.goodsDictionary;
            }

            var dictionary = new Dictionary<ushort, string>();
            var goodsNames = this.GetGoodNames();

            for (var i = 0; i < goodsNames.Length; i++)
            {
                dictionary.Add((ushort)i, goodsNames[i]);
            }

            this.goodsDictionary = dictionary;
            return this.goodsDictionary;
        }

        private string[] GetGoodNames()
        {
            return new[] 
            {
                "康倍特",
                "精气丸",
                "白岚氏鸡精",
                "小还丹",
                "玉洞黑石丹",
                "玉真散",
                "三黄宝腊丸",
                "玉灵散",
                "天香断续胶",
                "黑玉断续膏",

                "金牛运功散",
                "人参",
                "白云熊胆丸",
                "九花玉露丸",
                "九转灵宝丸",
                "田七鲨胆散",
                "九转熊蛇丸",
                "无常丹",
                "镇心理气丸",
                "生生造化丹",

                "天王保命丹",
                "宝济丸",
                "黄连解毒丸",
                "天心解毒丹",
                "回阳玉龙膏",
                "牛黄血竭丹",
                "六阳正气丹",
                "朱睛冰蟾",
                "茯苓首乌丸",
                "千年灵芝",

                "蛇胆",
                "五宝花蜜酒",
                "腊八粥",
                "大蟠桃",
                "千年人参",
                "天山雪莲",
                "通犀地龙丸",
                "千年冰虫",
                "莽牯朱蛤",
                "紫霞秘笈",

                "小无相功",
                "十八泥偶",
                "神照经",
                "易筋经",
                "洗髓经",
                "梯云纵心法",
                "神行百变",
                "凌波微步",
                "子午针炙经",
                "华陀内昭图",

                "胡青牛医书",
                "五毒秘传",
                "毒经",
                "药王神篇",
                "铁掌拳谱",
                "七伤拳谱",
                "天山六阳掌",
                "玄冥神掌",
                "太极拳经",
                "龙象般若功",

                "太玄经",
                "黯然销魂掌",
                "降龙十八掌",
                "北冥神功",
                "吸星大法",
                "神木王鼎",
                "六脉神剑谱",
                "松峰剑谱",
                "泰山十八盘",
                "回峰落雁剑法",

                "七星剑谱",
                "两仪剑法",
                "金蛇秘笈",
                "玉女素心剑法",
                "苗家剑法",
                "太极剑法",
                "达摩剑法",
                "玄铁剑法",
                "辟邪剑法",
                "独孤九剑",

                "血刀经",
                "火焰刀法",
                "反两仪刀法",
                "狂风刀法",
                "胡家刀法",
                "霹雳刀法",
                "毒龙鞭法",
                "黄沙万里鞭法",
                "满天花雨",
                "霹雳秘笈",

                "含沙射影",
                "左右互搏术",
                "乾坤大挪移",
                "葵花宝典",
                "九阴真经",
                "九阳真经",
                "飞蝗石",
                "金钱镖",
                "飞刀",
                "菩提子",

                "金蛇锥",
                "霹雳弹",
                "毒蒺藜",
                "玉蜂针",
                "冰魄银针",
                "黑血神针",
                "玄铁剑",
                "君子剑",
                "淑女剑",
                "倚天剑",

                "金蛇剑",
                "凝碧剑",
                "血龙剑",
                "白虹剑",
                "周公剑",
                "血刀",
                "冷月宝刀",
                "屠龙刀",
                "绿波香露刀",
                "霹雳狂刀",

                "软猬甲",
                "金丝背心",
                "乌蚕衣",
                "鳄皮护甲",
                "玉蜂浆",
                "黑木令牌",
                "梨花酒",
                "翡翠杯",
                "七宝指环",
                "神仙美女图",
                "大燕传国玉玺",
                "大燕皇帝世袭图表",
                "赏善罚恶令",
                "两页胡家刀法",
                "断肠草",
                "闯王军刀",
                "玄冰碧火酒",
                "苗人凤眼毒解药",
                "羊羔坐臀",
                "小牛腰子",
                "小猪耳朵",
                "獐腿肉",
                "兔肉",
                "神杖",
                "飞狐外传",
                "雪山飞狐",
                "连城诀",
                "天龙八部",
                "射雕英雄传",
                "白马啸西风",
                "鹿鼎记",
                "笑傲江湖",
                "书剑恩仇记",
                "神雕侠侣",
                "侠客行",
                "倚天屠龙记",
                "碧血剑",
                "鸳鸯刀",
                "七心海棠",
                "可兰经",
                "唐诗选辑",
                "红钥匙",
                "橙钥匙",
                "黄钥匙",
                "绿钥匙",
                "蓝钥匙",
                "紫钥匙",
                "铁钥匙",
                "铜钥匙",
                "银钥匙",
                "金钥匙",
                "药材",
                "硝石",
                "一朵蓝花",
                "银两",
                "闯王藏宝图",
                "玉笛谁家听落梅",
                "广陵散琴曲",
                "刘仲甫呕血棋谱",
                "张旭率意帖",
                "溪山行旅图",
                "一撮金毛",
                "罗盘",
                "带头大哥书信",
                "鸳鸯手帕",
                "林震南遗言",
                "智慧果",
                "鸳刀",
                "鸯刀",
                "武林大会帖",
                "明教铁焰令",
                "成昆人头",
                "真武剑",
                "金盆洗手请帖",
                "烧刀子酒",
                "铁铲",
                "槟榔",
                "皮衣", 
            };
        }
    }
}
