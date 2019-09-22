using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GD3100Debugger
{
    public partial class CfgAllRegsForm : Form
    {
        private CheckBox[] ConfigEnCheckBox = new CheckBox[6];

        public CfgAllRegsForm()
        {
            InitializeComponent();
        }
        private void CfgAllRegsForm_Load(object sender, EventArgs e)
        {
            ConfigEnCheckBox[0] = checkBoxHuEn;
            ConfigEnCheckBox[1] = checkBoxHvEn;
            ConfigEnCheckBox[2] = checkBoxHwEn;
            ConfigEnCheckBox[3] = checkBoxLuEn;
            ConfigEnCheckBox[4] = checkBoxLvEn;
            ConfigEnCheckBox[5] = checkBoxLwEn;
        }
        private void CfgAllRegsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void LabelRegBit9_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        private void CheckBoxAllReg_Click(object sender, EventArgs e)
        {
            if (checkBoxAllReg.CheckState.Equals(CheckState.Checked))
            {
                checkBoxHuEn.Checked = true;
                checkBoxLuEn.Checked = true;
                checkBoxHvEn.Checked = true;
                checkBoxLvEn.Checked = true;
                checkBoxHwEn.Checked = true;
                checkBoxLwEn.Checked = true;
            }
            else
            {
                checkBoxHuEn.Checked = false;
                checkBoxLuEn.Checked = false;
                checkBoxHvEn.Checked = false;
                checkBoxLvEn.Checked = false;
                checkBoxHwEn.Checked = false;
                checkBoxLwEn.Checked = false;
            }
        }

        private void CheckBoxEn_CheckedChanged(int index)
        {
            bool allChecked = true;
            
            foreach (CheckBox box in ConfigEnCheckBox)
            {
                if (box.Checked == false)
                {
                    allChecked = false;
                    break;
                }
            }
            checkBoxAllReg.Checked = allChecked;
        }

        private void CheckBoxHuEn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEn_CheckedChanged(0);
        }

        private void CheckBoxHvEn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEn_CheckedChanged(1);
        }

        private void CheckBoxHwEn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEn_CheckedChanged(2);
        }

        private void CheckBoxLuEn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEn_CheckedChanged(3);
        }

        private void CheckBoxLvEn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEn_CheckedChanged(4);
        }

        private void CheckBoxLwEn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxEn_CheckedChanged(5);
        }
    }
}
