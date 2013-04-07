using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using GameEngine;
using JYFK.ViewModel;

namespace JYFK
{
    public partial class Form1 : Form
    {
        private Process gameProcess;

        private IEnumerable<ViewModelBase> viewModels;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.GetGameProcess() == null)
            {
                MessageBox.Show("找不到游戏进程");
                return;
            }

            this.SaveViewModels();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            if (this.GetGameProcess() == null)
            {
                MessageBox.Show("找不到游戏进程");
                return;
            }

            this.InitViewModels();

            this.btn_Save.Enabled = true;
            this.btn_Save.Cursor = Cursors.Hand;
        }

        private void InitViewModels()
        {
            if (this.gameProcess == null)
            {
                this.gameProcess = this.GetGameProcess();
                IMemoryManager memoryManager = new Win32ApiHelper(this.gameProcess.Handle);

                this.viewModels = new ViewModelBase[] {
                    new PropertyViewModel(this.panel_Property, memoryManager),
                    new SkillViewModel(this.panel_Skill, memoryManager),
                    new SkillLevelViewModel(this.panel_SkillLevel, memoryManager),
                    new TeammateViewModel(this.panel_Teammate, memoryManager),
                    new GoodsViewModel(this.panel_Goods, memoryManager)
                };
            }

            this.LoadViewModels();
        }

        private void LoadViewModels()
        {
            foreach (var viewModel in this.viewModels)
            {
                viewModel.Load();
            }
        }

        private void SaveViewModels()
        {
            foreach (var viewModel in this.viewModels)
            {
                viewModel.Save();
            }

            this.LoadViewModels();
        }
        
        Process GetGameProcess()
        {
            string processName = "kys_ori";
            Process process = Process.GetProcessesByName(processName).FirstOrDefault();
            return process;
        }
    }
}
