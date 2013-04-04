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

        private int addressSpan = 1;

        private int baseAddress = 0x1D40386;

        private ControlManager controlManager = ControlManager.Current;

        protected override IEnumerable<GameMemoryBase> GetGameMemories()
        {
            return new List<GameMemoryBase>
                {
                    new ByteGameMemory("康倍特", this.baseAddress + this.addressSpan * 0, 99),
                        
                    new ByteGameMemory("精气丸", this.baseAddress + this.addressSpan * 16, 99), 
                       
                    new ByteGameMemory("白岚氏鸡精", this.baseAddress + this.addressSpan * 2, 99), 
                       
                    new ByteGameMemory("小还丹", this.baseAddress + this.addressSpan * 3, 99),
 
                    new ByteGameMemory("玉洞黑石丹", this.baseAddress + this.addressSpan * 4, 99),

                    new ByteGameMemory("玉真散", this.baseAddress + this.addressSpan * 5, 99),

                    new ByteGameMemory("三黄宝腊丸", this.baseAddress + this.addressSpan * 6, 99),
                       
                    new ByteGameMemory("玉灵散", this.baseAddress + this.addressSpan * 7, 99), 
                        
                    new ByteGameMemory("天香断续胶", this.baseAddress + this.addressSpan * 8, 99), 
                       
                    new ByteGameMemory("黑玉断续膏", this.baseAddress + this.addressSpan * 9, 99), 
                   
                    new ByteGameMemory("金牛运功散", this.baseAddress + this.addressSpan * 99, 99), 
                        
                    new ByteGameMemory("人参", this.baseAddress + this.addressSpan * 29, 99), 
                       
                    new ByteGameMemory("白云熊胆丸", this.baseAddress + this.addressSpan * 31, 99), 
                        
                    new ByteGameMemory("九花玉露丸", this.baseAddress + this.addressSpan * 32, 99), 
                       
                    new ByteGameMemory("九转灵宝丸", this.baseAddress + this.addressSpan * 33, 99), 
                        
                    new ByteGameMemory("田七鲨胆散", this.baseAddress + this.addressSpan * 34, 99), 
                        
                    new ByteGameMemory("九转熊蛇丸", this.baseAddress + this.addressSpan * 35, 99), 
                        
                    new ByteGameMemory("无常丹", this.baseAddress + this.addressSpan * 36, 99), 
                        
                    new ByteGameMemory("镇心理气丸", this.baseAddress + this.addressSpan * 37, 99), 
                        
                    new ByteGameMemory("生生造化丹", this.baseAddress + this.addressSpan * 38, 99), 
                        
                    new ByteGameMemory("天王保命丹", this.baseAddress + this.addressSpan * 39, 99),

                    new BoolGameMemory("黄连解毒丸", this.baseAddress + this.addressSpan * 43), 

                    new ByteGameMemory("天心解毒丹", this.baseAddress + this.addressSpan * 44, 255), 

                    new ByteGameMemory("回阳玉龙膏", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("牛黄血竭丹", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("六阳正气丹", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("朱睛冰蟾", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("茯苓首乌丸", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("千年灵芝", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("蛇胆", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("五宝花蜜酒", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("腊八粥", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("大蟠桃", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("千年人参", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("天山雪莲", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("通犀地龙丸", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("千年冰虫", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("莽牯朱蛤", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("紫霞秘笈", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("小无相功", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("十八泥偶", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("神照经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("易筋经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("洗髓经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("神行百变", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("凌波微步", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("子午针炙经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("华陀内昭图", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("胡青牛医书", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("五毒秘传", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("毒经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("药王神篇", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("铁掌拳谱", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("七伤拳谱", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("天山六阳掌", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玄冥神掌", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("太极拳经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("龙象般若功", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("太玄经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("黯然销魂掌", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("降龙十八掌", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("北冥神功", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("吸星大法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("神木王鼎", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("六脉神剑谱", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("松峰剑谱", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("泰山十八盘", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("回峰落雁剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("七星剑谱", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("两仪剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金蛇秘笈", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玉女素心剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("苗家剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("太极剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("达摩剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玄铁剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("辟邪剑法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("独孤九剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("血刀经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("火焰刀法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("反两仪刀法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("狂风刀法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("胡家刀法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("霹雳刀法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("毒龙鞭法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("黄沙万里鞭法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("满天花雨", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("霹雳秘笈", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("含沙射影", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("左右互搏术", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("乾坤大挪移", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("葵花宝典", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("九阴真经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("九阳真经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("飞蝗石", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金钱镖", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("飞刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("菩提子", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金蛇锥", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("霹雳弹", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("毒蒺藜", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玉蜂针", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("冰魄银针", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("黑血神针", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玄铁剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("君子剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("淑女剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("倚天剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金蛇剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("凝碧剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("血龙剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("白虹剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("周公剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("血刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("冷月宝刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("屠龙刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("绿波香露刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("霹雳狂刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("软猬甲", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金丝背心", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("乌蚕衣", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("鳄皮护甲", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玉蜂浆", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("黑木令牌", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("梨花酒", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("翡翠杯", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("七宝指环", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("神仙美女图", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("大燕传国玉玺", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("大燕皇帝世袭图表", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("赏善罚恶令", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("两页胡家刀法", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("断肠草", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("闯王军刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玄冰碧火酒", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("苗人凤眼毒解药", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("羊羔坐臀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("小牛腰子", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("小猪耳朵", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("獐腿肉", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("兔肉", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("神杖", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("飞狐外传", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("雪山飞狐", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("连城诀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("天龙八部", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("射雕英雄传", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("白马啸西风", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("鹿鼎记", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("笑傲江湖", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("书剑恩仇记", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("神雕侠侣", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("侠客行", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("倚天屠龙记", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("碧血剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("鸳鸯刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("七心海棠", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("可兰经", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("唐诗选辑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("红钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("橙钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("黄钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("绿钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("蓝钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("紫钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("铁钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("铜钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("银钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金钥匙", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("药材", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("硝石", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("一朵蓝花", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("银两", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("闯王藏宝图", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("玉笛谁家听落梅", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("广陵散琴曲", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("刘仲甫呕血棋谱", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("张旭率意帖", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("溪山行旅图", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("一撮金毛", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("罗盘", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("带头大哥书信", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("鸳鸯手帕", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("林震南遗言", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("智慧果", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("鸳刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("鸯刀", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("武林大会帖", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("明教铁焰令", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("成昆人头", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("真武剑", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("金盆洗手请帖", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("烧刀子酒", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("铁铲", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("槟榔", this.baseAddress + this.addressSpan * 45, 255),

                    new ByteGameMemory("皮衣", this.baseAddress + this.addressSpan * 45, 255),
                };
        }

        protected override void LoadViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var labelName = string.Format("{0}lb{1}", this.container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateLabel(container, labelName, gameMemory.Description);
                
                var textBoxName = string.Format("{0}tb{1}", container.Name, gameMemory.MemoryAddress.ToString());
                controlManager.CreateTextBox(container, textBoxName, gameMemory.DisplayValue.ToString());
                
            }
        }

        protected override void SaveViewModel(Control container, IEnumerable<GameMemoryBase> gameMemories)
        {
            foreach (var gameMemory in gameMemories)
            {
                var textBoxName = string.Format("{0}tb{1}", container.Name, gameMemory.MemoryAddress.ToString());

                byte dispayValue = 0;

                Byte.TryParse(controlManager.GetValueFromTextBox(container, textBoxName), out dispayValue);

                gameMemory.DisplayValue = dispayValue;
                
            }
        }
    }
}
