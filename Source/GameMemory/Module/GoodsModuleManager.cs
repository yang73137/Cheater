using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Memory;

namespace GameEngine.Module
{
    public class GoodsModuleManager : GameModuleManagerBase
    {
        private int _addressSpan = 1;

        private IEnumerable<GameMemoryBase> _gameMemories;

        public GoodsModuleManager(IMemoryManager memoryManager) : base(memoryManager)
        {
        }

        public override IEnumerable<GameMemoryBase> GameMemories
        {
            get
            {
                if (this._gameMemories == null)
                {
                    this.InitGameMemories();
                }

                return this._gameMemories;
            }
        }

        protected override int BaseAddress
        {
            get
            {
                return 0x608807A;
            }
        }

        protected void InitGameMemories()
        {
            this._gameMemories = new List<GameMemoryBase>
                {
                    new ByteGameMemory("康倍特", this.BaseAddress + this._addressSpan * 0, 99),
                        
                    new ByteGameMemory("精气丸", this.BaseAddress + this._addressSpan * 16, 99), 
                       
                    new ByteGameMemory("白岚氏鸡精", this.BaseAddress + this._addressSpan * 2, 99), 
                       
                    new ByteGameMemory("小还丹", this.BaseAddress + this._addressSpan * 3, 99),
 
                    new ByteGameMemory("玉洞黑石丹", this.BaseAddress + this._addressSpan * 4, 99),

                    new ByteGameMemory("玉真散", this.BaseAddress + this._addressSpan * 5, 99),

                    new ByteGameMemory("三黄宝腊丸", this.BaseAddress + this._addressSpan * 6, 99),
                       
                    new ByteGameMemory("玉灵散", this.BaseAddress + this._addressSpan * 7, 99), 
                        
                    new ByteGameMemory("天香断续胶", this.BaseAddress + this._addressSpan * 8, 99), 
                       
                    new ByteGameMemory("黑玉断续膏", this.BaseAddress + this._addressSpan * 9, 99), 
                    /*    
                    new ByteGameMemory("金牛运功散", this.BaseAddress + this._addressSpan * 99, 99), 
                        
                    new ByteGameMemory("人参", this.BaseAddress + this._addressSpan * 29, 99), 
                       
                    new ByteGameMemory("白云熊胆丸", this.BaseAddress + this._addressSpan * 31, 99), 
                        
                    new ByteGameMemory("九花玉露丸", this.BaseAddress + this._addressSpan * 32, 99), 
                       
                    new ByteGameMemory("九转灵宝丸", this.BaseAddress + this._addressSpan * 33, 99), 
                        
                    new ByteGameMemory("田七鲨胆散", this.BaseAddress + this._addressSpan * 34, 99), 
                        
                    new ByteGameMemory("九转熊蛇丸", this.BaseAddress + this._addressSpan * 35, 99), 
                        
                    new ByteGameMemory("无常丹", this.BaseAddress + this._addressSpan * 36, 99), 
                        
                    new ByteGameMemory("镇心理气丸", this.BaseAddress + this._addressSpan * 37, 99), 
                        
                    new ByteGameMemory("生生造化丹", this.BaseAddress + this._addressSpan * 38, 99), 
                        
                    new ByteGameMemory("天王保命丹", this.BaseAddress + this._addressSpan * 39, 99),

                    new BoolGameMemory("黄连解毒丸", this.BaseAddress + this._addressSpan * 43), 

                    new ByteGameMemory("天心解毒丹", this.BaseAddress + this._addressSpan * 44, 255), 

                    new ByteGameMemory("回阳玉龙膏", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("牛黄血竭丹", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("六阳正气丹", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("朱睛冰蟾", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("茯苓首乌丸", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("千年灵芝", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("蛇胆", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("五宝花蜜酒", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("腊八粥", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("大蟠桃", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("千年人参", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("天山雪莲", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("通犀地龙丸", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("千年冰虫", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("莽牯朱蛤", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("紫霞秘笈", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("小无相功", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("十八泥偶", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("神照经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("易筋经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("洗髓经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("神行百变", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("凌波微步", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("子午针炙经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("华陀内昭图", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("胡青牛医书", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("五毒秘传", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("毒经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("药王神篇", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("铁掌拳谱", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("七伤拳谱", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("天山六阳掌", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玄冥神掌", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("太极拳经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("龙象般若功", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("太玄经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("黯然销魂掌", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("降龙十八掌", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("北冥神功", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("吸星大法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("神木王鼎", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("六脉神剑谱", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("松峰剑谱", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("泰山十八盘", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("回峰落雁剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("七星剑谱", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("两仪剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金蛇秘笈", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玉女素心剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("苗家剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("太极剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("达摩剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玄铁剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("辟邪剑法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("独孤九剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("血刀经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("火焰刀法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("反两仪刀法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("狂风刀法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("胡家刀法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("霹雳刀法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("毒龙鞭法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("黄沙万里鞭法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("满天花雨", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("霹雳秘笈", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("含沙射影", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("左右互搏术", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("乾坤大挪移", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("葵花宝典", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("九阴真经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("九阳真经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("飞蝗石", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金钱镖", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("飞刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("菩提子", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金蛇锥", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("霹雳弹", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("毒蒺藜", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玉蜂针", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("冰魄银针", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("黑血神针", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玄铁剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("君子剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("淑女剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("倚天剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金蛇剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("凝碧剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("血龙剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("白虹剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("周公剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("血刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("冷月宝刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("屠龙刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("绿波香露刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("霹雳狂刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("软猬甲", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金丝背心", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("乌蚕衣", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("鳄皮护甲", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玉蜂浆", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("黑木令牌", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("梨花酒", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("翡翠杯", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("七宝指环", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("神仙美女图", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("大燕传国玉玺", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("大燕皇帝世袭图表", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("赏善罚恶令", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("两页胡家刀法", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("断肠草", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("闯王军刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玄冰碧火酒", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("苗人凤眼毒解药", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("羊羔坐臀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("小牛腰子", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("小猪耳朵", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("獐腿肉", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("兔肉", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("神杖", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("飞狐外传", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("雪山飞狐", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("连城诀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("天龙八部", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("射雕英雄传", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("白马啸西风", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("鹿鼎记", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("笑傲江湖", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("书剑恩仇记", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("神雕侠侣", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("侠客行", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("倚天屠龙记", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("碧血剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("鸳鸯刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("七心海棠", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("可兰经", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("唐诗选辑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("红钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("橙钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("黄钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("绿钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("蓝钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("紫钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("铁钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("铜钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("银钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金钥匙", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("药材", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("硝石", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("一朵蓝花", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("银两", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("闯王藏宝图", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("玉笛谁家听落梅", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("广陵散琴曲", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("刘仲甫呕血棋谱", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("张旭率意帖", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("溪山行旅图", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("一撮金毛", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("罗盘", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("带头大哥书信", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("鸳鸯手帕", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("林震南遗言", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("智慧果", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("鸳刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("鸯刀", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("武林大会帖", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("明教铁焰令", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("成昆人头", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("真武剑", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("金盆洗手请帖", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("烧刀子酒", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("铁铲", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("槟榔", this.BaseAddress + this._addressSpan * 45, 255),

                    new ByteGameMemory("皮衣", this.BaseAddress + this._addressSpan * 45, 255),
                    */
                };
        }
    }
}
