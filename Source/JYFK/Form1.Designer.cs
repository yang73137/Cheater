﻿namespace JYFK
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.panel_Property = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Goods = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Property = new System.Windows.Forms.TabPage();
            this.tab_Goods = new System.Windows.Forms.TabPage();
            this.tab_Skill = new System.Windows.Forms.TabPage();
            this.panel_SkillLevel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Skill = new System.Windows.Forms.FlowLayoutPanel();
            this.tab_Teammate = new System.Windows.Forms.TabPage();
            this.panel_Teammate = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.tab_Property.SuspendLayout();
            this.tab_Goods.SuspendLayout();
            this.tab_Skill.SuspendLayout();
            this.tab_Teammate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(603, 29);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Load.Location = new System.Drawing.Point(522, 29);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 1;
            this.btn_Load.Text = "读取数据";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Load_Click);
            // 
            // panel_Property
            // 
            this.panel_Property.AutoScroll = true;
            this.panel_Property.Location = new System.Drawing.Point(21, 22);
            this.panel_Property.Name = "panel_Property";
            this.panel_Property.Size = new System.Drawing.Size(600, 400);
            this.panel_Property.TabIndex = 2;
            // 
            // panel_Goods
            // 
            this.panel_Goods.AutoScroll = true;
            this.panel_Goods.Location = new System.Drawing.Point(21, 22);
            this.panel_Goods.Name = "panel_Goods";
            this.panel_Goods.Size = new System.Drawing.Size(600, 400);
            this.panel_Goods.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_Property);
            this.tabControl1.Controls.Add(this.tab_Goods);
            this.tabControl1.Controls.Add(this.tab_Skill);
            this.tabControl1.Controls.Add(this.tab_Teammate);
            this.tabControl1.Location = new System.Drawing.Point(22, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 480);
            this.tabControl1.TabIndex = 4;
            // 
            // tab_Property
            // 
            this.tab_Property.Controls.Add(this.panel_Property);
            this.tab_Property.Location = new System.Drawing.Point(4, 22);
            this.tab_Property.Name = "tab_Property";
            this.tab_Property.Size = new System.Drawing.Size(652, 454);
            this.tab_Property.TabIndex = 0;
            this.tab_Property.Text = "基本属性";
            this.tab_Property.UseVisualStyleBackColor = true;
            // 
            // tab_Goods
            // 
            this.tab_Goods.Controls.Add(this.panel_Goods);
            this.tab_Goods.Location = new System.Drawing.Point(4, 22);
            this.tab_Goods.Name = "tab_Goods";
            this.tab_Goods.Size = new System.Drawing.Size(652, 454);
            this.tab_Goods.TabIndex = 1;
            this.tab_Goods.Text = "物品";
            this.tab_Goods.UseVisualStyleBackColor = true;
            // 
            // tab_Skill
            // 
            this.tab_Skill.Controls.Add(this.panel_SkillLevel);
            this.tab_Skill.Controls.Add(this.panel_Skill);
            this.tab_Skill.Location = new System.Drawing.Point(4, 22);
            this.tab_Skill.Name = "tab_Skill";
            this.tab_Skill.Size = new System.Drawing.Size(652, 454);
            this.tab_Skill.TabIndex = 2;
            this.tab_Skill.Text = "武功";
            this.tab_Skill.UseVisualStyleBackColor = true;
            // 
            // panel_SkillLevel
            // 
            this.panel_SkillLevel.AutoScroll = true;
            this.panel_SkillLevel.Location = new System.Drawing.Point(24, 201);
            this.panel_SkillLevel.Name = "panel_SkillLevel";
            this.panel_SkillLevel.Size = new System.Drawing.Size(600, 160);
            this.panel_SkillLevel.TabIndex = 4;
            // 
            // panel_Skill
            // 
            this.panel_Skill.AutoScroll = true;
            this.panel_Skill.Location = new System.Drawing.Point(24, 21);
            this.panel_Skill.Name = "panel_Skill";
            this.panel_Skill.Size = new System.Drawing.Size(600, 160);
            this.panel_Skill.TabIndex = 3;
            // 
            // tab_Teammate
            // 
            this.tab_Teammate.Controls.Add(this.panel_Teammate);
            this.tab_Teammate.Location = new System.Drawing.Point(4, 22);
            this.tab_Teammate.Name = "tab_Teammate";
            this.tab_Teammate.Size = new System.Drawing.Size(652, 454);
            this.tab_Teammate.TabIndex = 3;
            this.tab_Teammate.Text = "队友";
            this.tab_Teammate.UseVisualStyleBackColor = true;
            // 
            // panel_Teammate
            // 
            this.panel_Teammate.AutoScroll = true;
            this.panel_Teammate.Location = new System.Drawing.Point(24, 21);
            this.panel_Teammate.Name = "panel_Teammate";
            this.panel_Teammate.Size = new System.Drawing.Size(600, 160);
            this.panel_Teammate.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 554);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.btn_Save);
            this.Name = "Form1";
            this.Text = "金庸群侠传复刻版修改器";
            this.tabControl1.ResumeLayout(false);
            this.tab_Property.ResumeLayout(false);
            this.tab_Goods.ResumeLayout(false);
            this.tab_Skill.ResumeLayout(false);
            this.tab_Teammate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.FlowLayoutPanel panel_Goods;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Property;
        private System.Windows.Forms.TabPage tab_Goods;
        private System.Windows.Forms.TabPage tab_Skill;
        private System.Windows.Forms.FlowLayoutPanel panel_Skill;
        private System.Windows.Forms.FlowLayoutPanel panel_Property;
        private System.Windows.Forms.FlowLayoutPanel panel_SkillLevel;
        private System.Windows.Forms.TabPage tab_Teammate;
        private System.Windows.Forms.FlowLayoutPanel panel_Teammate;
    }
}

