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
        private ComboBox[] Config1ComboBoxs = new ComboBox[21];
        private ComboBox[] Config2ComboBoxs = new ComboBox[21];
        private ComboBox[] Config3ComboBoxs = new ComboBox[21];
        private ComboBox[] Config4ComboBoxs = new ComboBox[18];
        private ComboBox[] Config5ComboBoxs = new ComboBox[18];
        private ComboBox[] Config6ComboBoxs = new ComboBox[18];

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

            Config1ComboBoxs[0] = comboBox1;
            Config1ComboBoxs[1] = comboBox2;
            Config1ComboBoxs[2] = comboBox3;
            Config1ComboBoxs[3] = comboBox4;
            Config1ComboBoxs[4] = comboBox5;
            Config1ComboBoxs[5] = comboBox6;
            Config1ComboBoxs[6] = comboBox7;
            Config1ComboBoxs[7] = comboBox8;
            Config1ComboBoxs[8] = comboBox9;
            Config1ComboBoxs[9] = comboBox10;
            Config1ComboBoxs[10] = comboBox11;
            Config1ComboBoxs[11] = comboBox12;
            Config1ComboBoxs[12] = comboBox13;
            Config1ComboBoxs[13] = comboBox14;
            Config1ComboBoxs[14] = comboBox15;
            Config1ComboBoxs[15] = comboBox16;
            Config1ComboBoxs[16] = comboBox17;
            Config1ComboBoxs[17] = comboBox18;
            Config1ComboBoxs[18] = comboBox19;
            Config1ComboBoxs[19] = comboBox20;
            Config1ComboBoxs[20] = comboBox21;

            Config2ComboBoxs[0]  = comboBox22;
            Config2ComboBoxs[1]  = comboBox23;
            Config2ComboBoxs[2]  = comboBox24;
            Config2ComboBoxs[3]  = comboBox25;
            Config2ComboBoxs[4]  = comboBox26;
            Config2ComboBoxs[5]  = comboBox27;
            Config2ComboBoxs[6]  = comboBox28;
            Config2ComboBoxs[7]  = comboBox29;
            Config2ComboBoxs[8]  = comboBox30;
            Config2ComboBoxs[9]  = comboBox31;
            Config2ComboBoxs[10] = comboBox32;
            Config2ComboBoxs[11] = comboBox33;
            Config2ComboBoxs[12] = comboBox34;
            Config2ComboBoxs[13] = comboBox35;
            Config2ComboBoxs[14] = comboBox36;
            Config2ComboBoxs[15] = comboBox37;
            Config2ComboBoxs[16] = comboBox38;
            Config2ComboBoxs[17] = comboBox39;
            Config2ComboBoxs[18] = comboBox40;
            Config2ComboBoxs[19] = comboBox41;
            Config2ComboBoxs[20] = comboBox42;

            CfgAllRegUiInit.Condig1Init(Config1ComboBoxs);
            CfgAllRegUiInit.Condig2Init(Config2ComboBoxs);
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
