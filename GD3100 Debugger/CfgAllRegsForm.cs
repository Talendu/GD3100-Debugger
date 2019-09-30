using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GD3100Debugger
{
    public partial class CfgAllRegsForm : Form
    {
        public MyDelegate messageToMainFram;
        public MyDelegate messageFromMainFram;

        private UInt32 ChipSelect = 0;

        private readonly int[] RegAddr = new [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 13 };

        private UInt32[] Mode1RegsValue = new UInt32[6];
        private UInt32[] Mode2RegsValue = new UInt32[6];
        private UInt32[] Config1RegsValue = new UInt32[6];
        private UInt32[] Config2RegsValue = new UInt32[6];
        private UInt32[] Config3RegsValue = new UInt32[6];
        private UInt32[] Config4RegsValue = new UInt32[6];
        private UInt32[] Config5RegsValue = new UInt32[6];
        private UInt32[] Config6RegsValue = new UInt32[6];
        private UInt32[] OtThRegsValue = new UInt32[6];
        private UInt32[] OtwThRegsValue = new UInt32[6];
        private UInt32[] Mask1RegsValue = new UInt32[6];
        private UInt32[] Mask2RegsValue = new UInt32[6];

        private CheckBox[] ConfigEnCheckBox = new CheckBox[6];

        private RadioButton[] rb_mode1_AOUT     = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_SEGDRV   = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_AMC      = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_TEMPSNS  = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_SSD      = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_2LTO     = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_ACTCLMP  = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_DESAT    = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_SCSNS    = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode1_OCSNS    = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        
        private RadioButton[] rb_mode2_FSISOEN      = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode2_BIST         = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode2_CONFIG_EN    = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mode2_RESET        = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };

        private RadioButton[] rb_config1_UV_DIS = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private ComboBox[] cb_config1_UV_TH     = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config1_OCTH      = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config1_OCFILT    = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };

        private ComboBox[] cb_config2_2LTOV     = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config2_SCTH      = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config2_SCFILT    = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };

        private ComboBox[] cb_config3_SEGDRVDLY = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config3_SSD_CUR   = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config3_SSDT      = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };

        private ComboBox[] cb_config4_DESAT_LEB = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config4_AOUT_SEL  = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config4_IDESAT    = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config4_DESAT_TH  = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };

        private ComboBox[] cb_config5_DEADT         = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config5_AOUTCONF      = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config5_COMERRCONF21  = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config5_COMERRCONF0   = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };

        private RadioButton[] rb_config6_INTBFS = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private ComboBox[] cb_config6_WDTO      = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };
        private ComboBox[] cb_config6_VGEMONDLY = { new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), new ComboBox(), };

        private MaskedTextBox[] tb_Ot_Otw_Th = new MaskedTextBox[14];

        private RadioButton[] rb_mask1_VCCOVM       = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask1_VCCREGUVM    = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask1_VSUPOVM      = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask1_OTSDM        = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask1_OTWM         = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask1_CLAMPM       = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };

        private RadioButton[] rb_mask2_DTFLTM       = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_SPIERRM      = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_CONFCRCERRM  = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_VGE_FLTM     = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_WDOG_FLTM    = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_COMERRM      = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_VREF_UVM     = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };
        private RadioButton[] rb_mask2_VEEM         = { new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), new RadioButton(), };

        private EventHandler[] rb_mode1_ClickEvent = new EventHandler[10];
        private EventHandler[] rb_mode2_ClickEvent = new EventHandler[4];
        private EventHandler[] rb_config1_ClickEvent = new EventHandler[1];
        private EventHandler[] rb_config6_ClickEvent = new EventHandler[1];
        private EventHandler[] rb_mask1_ClickEvent = new EventHandler[6];
        private EventHandler[] rb_mask2_ClickEvent = new EventHandler[8];

        private EventHandler[] cb_config1_SeleteEvent = new EventHandler[3];
        private EventHandler[] cb_config2_SeleteEvent = new EventHandler[3];
        private EventHandler[] cb_config3_SeleteEvent = new EventHandler[3];
        private EventHandler[] cb_config4_SeleteEvent = new EventHandler[4];
        private EventHandler[] cb_config5_SeleteEvent = new EventHandler[4];
        private EventHandler[] cb_config6_SeleteEvent = new EventHandler[2];

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

            tb_Ot_Otw_Th[0] = textBoxAllOtTh;
            tb_Ot_Otw_Th[1] = textBoxHuOtTh;
            tb_Ot_Otw_Th[2] = textBoxHvOtTh;
            tb_Ot_Otw_Th[3] = textBoxHwOtTh;
            tb_Ot_Otw_Th[4] = textBoxLuOtTh;
            tb_Ot_Otw_Th[5] = textBoxLvOtTh;
            tb_Ot_Otw_Th[6] = textBoxLwOtTh;
            tb_Ot_Otw_Th[7] = textBoxAllOtwTh;
            tb_Ot_Otw_Th[8] = textBoxHuOtwTh;
            tb_Ot_Otw_Th[9] = textBoxHvOtwTh;
            tb_Ot_Otw_Th[10] = textBoxHwOtwTh;
            tb_Ot_Otw_Th[11] = textBoxLuOtwTh;
            tb_Ot_Otw_Th[12] = textBoxLvOtwTh;
            tb_Ot_Otw_Th[13] = textBoxLwOtwTh;



            /* MODE 1 寄存器RadioButton点击回调函数 */
            rb_mode1_ClickEvent[0] = rb_mode1_AOUT_Clicked;
            rb_mode1_ClickEvent[1] = rb_mode1_SEGDRV_Clicked;
            rb_mode1_ClickEvent[2] = rb_mode1_AMC_Clicked;
            rb_mode1_ClickEvent[3] = rb_mode1_TEMPSNS_Clicked;
            rb_mode1_ClickEvent[4] = rb_mode1_SSD_Clicked;
            rb_mode1_ClickEvent[5] = rb_mode1_2LTO_Clicked;
            rb_mode1_ClickEvent[6] = rb_mode1_ACTCLMP_Clicked;
            rb_mode1_ClickEvent[7] = rb_mode1_DESAT_Clicked;
            rb_mode1_ClickEvent[8] = rb_mode1_SCSNS_Clicked;
            rb_mode1_ClickEvent[9] = rb_mode1_OCSNS_Clicked;

            /* MODE 2 寄存器RadioButton点击回调函数 */
            rb_mode2_ClickEvent[0] = rb_mode2_FSISOEN_Clicked;
            rb_mode2_ClickEvent[1] = rb_mode2_BIST_Clicked;
            rb_mode2_ClickEvent[2] = rb_mode2_CONFIG_EN_Clicked;
            rb_mode2_ClickEvent[3] = rb_mode2_RESET_Clicked;

            /* Config 1 寄存器RadioButton点击回调函数 */
            rb_config1_ClickEvent[0] = rb_config1_OCSNS_Clicked;

            /* Config 6 寄存器RadioButton点击回调函数 */
            rb_config6_ClickEvent[0] = rb_config6_INTBFS_Clicked;

            /* Mask 1 寄存器RadioButton点击回调函数 */
            rb_mask1_ClickEvent[0] = rb_mask1_VCCOVM_Clicked;
            rb_mask1_ClickEvent[1] = rb_mask1_VCCREGUVM_Clicked;
            rb_mask1_ClickEvent[2] = rb_mask1_VSUPOVM_Clicked;
            rb_mask1_ClickEvent[3] = rb_mask1_OTSDM_Clicked;
            rb_mask1_ClickEvent[4] = rb_mask1_OTWM_Clicked;
            rb_mask1_ClickEvent[5] = rb_mask1_CLAMPM_Clicked;

            /* Mask 2 寄存器RadioButton点击回调函数 */
            rb_mask2_ClickEvent[0] = rb_mask2_DTFLTM_Clicked;
            rb_mask2_ClickEvent[1] = rb_mask2_SPIERRM_Clicked;
            rb_mask2_ClickEvent[2] = rb_mask2_CONFCRCERRM_Clicked;
            rb_mask2_ClickEvent[3] = rb_mask2_VGE_FLTM_Clicked;
            rb_mask2_ClickEvent[4] = rb_mask2_WDOG_FLTM_Clicked;
            rb_mask2_ClickEvent[5] = rb_mask2_COMERRM_Clicked;
            rb_mask2_ClickEvent[6] = rb_mask2_VREF_UVM_Clicked;
            rb_mask2_ClickEvent[7] = rb_mask2_VEEM_Clicked;

            /* Config 1 寄存器ComboBox点击回调函数 */
            cb_config1_SeleteEvent[0] = cb_config1_UV_TH_Changed;
            cb_config1_SeleteEvent[1] = cb_config1_OCTH_Changed;
            cb_config1_SeleteEvent[2] = cb_config1_OCFILT_Changed;

            /* Config 2 寄存器ComboBox点击回调函数 */
            cb_config2_SeleteEvent[0] = cb_config2_2LTOV_Changed;
            cb_config2_SeleteEvent[1] = cb_config2_SCTH_Changed;
            cb_config2_SeleteEvent[2] = cb_config2_SCFILT_Changed;

            /* Config 3 寄存器ComboBox点击回调函数 */
            cb_config3_SeleteEvent[0] = cb_config3_SEGDRVDLY_Changed;
            cb_config3_SeleteEvent[1] = cb_config3_SSD_CUR_Changed;
            cb_config3_SeleteEvent[2] = cb_config3_SSDT_Changed;

            /* Config 4 寄存器ComboBox点击回调函数 */
            cb_config4_SeleteEvent[0] = cb_config4_DESAT_LEB_Changed;
            cb_config4_SeleteEvent[1] = cb_config4_AOUT_SEL_Changed;
            cb_config4_SeleteEvent[2] = cb_config4_IDESAT_Changed;
            cb_config4_SeleteEvent[3] = cb_config4_DESAT_TH_Changed;

            /* Config 5 寄存器ComboBox点击回调函数 */
            cb_config5_SeleteEvent[0] = cb_config5_DEADT_Changed;
            cb_config5_SeleteEvent[1] = cb_config5_AOUTCONF_Changed;
            cb_config5_SeleteEvent[2] = cb_config5_COMERRCONF21_Changed;
            cb_config5_SeleteEvent[3] = cb_config5_COMERRCONF0_Changed;

            /* Config 6 寄存器ComboBox点击回调函数 */
            cb_config6_SeleteEvent[0] = cb_config6_WDTO_Changed;
            cb_config6_SeleteEvent[1] = cb_config6_VGEMONDLY_Changed;


            /* 初始化各个寄存器设置界面的控件 */
            CfgAllRegUiInit.Mode1Init(tableLayoutPanelMode1, rb_mode1_ClickEvent,
                rb_mode1_AOUT, rb_mode1_SEGDRV, rb_mode1_AMC, rb_mode1_TEMPSNS, rb_mode1_SSD,
                rb_mode1_2LTO, rb_mode1_ACTCLMP, rb_mode1_DESAT, rb_mode1_SCSNS, rb_mode1_OCSNS);
            CfgAllRegUiInit.Mode2Init(tableLayoutPanelMode2, rb_mode2_ClickEvent,
                rb_mode2_FSISOEN, rb_mode2_BIST, rb_mode2_CONFIG_EN, rb_mode2_RESET);
            CfgAllRegUiInit.Config1Init(tableLayoutPanelConfig1, rb_config1_ClickEvent, cb_config1_SeleteEvent, 
                rb_config1_UV_DIS, cb_config1_UV_TH, cb_config1_OCTH, cb_config1_OCFILT);
            CfgAllRegUiInit.Config2Init(tableLayoutPanelConfig2, cb_config2_SeleteEvent,
                cb_config2_2LTOV, cb_config2_SCTH, cb_config2_SCFILT);
            CfgAllRegUiInit.Config3Init(tableLayoutPanelConfig3, cb_config3_SeleteEvent,
                cb_config3_SEGDRVDLY, cb_config3_SSD_CUR, cb_config3_SSDT);
            CfgAllRegUiInit.Config4Init(tableLayoutPanelConfig4, cb_config4_SeleteEvent,
                cb_config4_DESAT_LEB, cb_config4_AOUT_SEL, cb_config4_IDESAT, cb_config4_DESAT_TH);
            CfgAllRegUiInit.Config5Init(tableLayoutPanelConfig5, cb_config5_SeleteEvent,
                cb_config5_DEADT, cb_config5_AOUTCONF, cb_config5_COMERRCONF21, cb_config5_COMERRCONF0);
            CfgAllRegUiInit.Config6Init(tableLayoutPanelConfig6, rb_config6_ClickEvent, cb_config6_SeleteEvent,
                rb_config6_INTBFS, cb_config6_WDTO, cb_config6_VGEMONDLY);
            CfgAllRegUiInit.Mask1Init(tableLayoutPanelMask1, rb_mask1_ClickEvent,
                rb_mask1_VCCOVM, rb_mask1_VCCREGUVM, rb_mask1_VSUPOVM, rb_mask1_OTSDM,
                rb_mask1_OTWM, rb_mask1_CLAMPM);
            CfgAllRegUiInit.Mask2Init(tableLayoutPanelMask2, rb_mask2_ClickEvent,
                rb_mask2_DTFLTM, rb_mask2_SPIERRM, rb_mask2_CONFCRCERRM, rb_mask2_VGE_FLTM,
                rb_mask2_WDOG_FLTM, rb_mask2_COMERRM, rb_mask2_VREF_UVM, rb_mask2_VEEM);

            messageFromMainFram = new MyDelegate(ReceiveFram);
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
                ChipSelect = 0x3f;
            }
            else
            {
                checkBoxHuEn.Checked = false;
                checkBoxLuEn.Checked = false;
                checkBoxHvEn.Checked = false;
                checkBoxLvEn.Checked = false;
                checkBoxHwEn.Checked = false;
                checkBoxLwEn.Checked = false;
                ChipSelect = 0;
            }
        }

        private void CheckBoxEn_CheckedChanged(int index)
        {
            bool allChecked = true;

            if (ConfigEnCheckBox[index].Checked)
            {
                ChipSelect |= (UInt32)1 << index;
            }
            else
            {
                ChipSelect &= ~((UInt32)1 << index);
            }

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

        private void rb_all_clicked(UInt32[] regValue,int regIndex, UInt32 bitsMask, bool isChecked)
        {
            FramLoad Load = new FramLoad();
            Load.RegAddr = RegAddr[regIndex];
            Load.Data = 0xffff;

            for (int i = 0; i < 6; i++)
            {
                if ((ChipSelect & ((UInt32)1 << i)) != 0)
                {
                    if (isChecked)
                    {
                        regValue[i] |= bitsMask;
                    }
                    else
                    {
                        regValue[i] &= ~bitsMask;
                    }
                    if (Load.Data == 0xffff)
                    {
                        Load.Data = regValue[i];
                        Load.ChipSelect = (UInt32)1 << i;
                    }
                    else
                    {
                        if (Load.Data == regValue[i])
                        {
                            Load.ChipSelect |= (UInt32)1 << i;
                        }
                        else
                        {
                            SendFram(Load);
                            Load.ChipSelect = (UInt32)1 << i;
                            Load.Data = regValue[i];
                        }
                    }
                }
            }
            SendFram(Load);
        }

        private void rb_single_clicked(UInt32[] regValue, int deviceIndex, int regIndex, UInt32 bitsMask, bool isChecked)
        {
            FramLoad Load = new FramLoad();
            Load.RegAddr = RegAddr[regIndex];

            if ((ChipSelect & ((UInt32)1 << deviceIndex)) != 0)
            {
                if (isChecked)
                {
                    regValue[deviceIndex] |= bitsMask;
                }
                else
                {
                    regValue[deviceIndex] &= ~bitsMask;
                }
                
                Load.Data = regValue[deviceIndex];
                Load.ChipSelect = (UInt32)1 << deviceIndex;
                SendFram(Load);
            }
        }

        private void rb_clicked(object sender, RadioButton[] radioButtons, UInt32[] regsValue, int regIndex, UInt32 bitMask)
        {
            if (sender == radioButtons[0])
            {
                bool isAllSelect = !radioButtons[0].Checked;
                rb_all_clicked(regsValue, regIndex, bitMask, isAllSelect);
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (sender == radioButtons[i])
                    {
                        bool isAllSelect = !radioButtons[i].Checked;
                        rb_single_clicked(regsValue, i - 1, regIndex, bitMask, isAllSelect);
                    }
                }
            }

        }

        private void rb_mode1_AOUT_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_AOUT;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x200;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_SEGDRV_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_SEGDRV;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x100;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_AMC_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_AMC;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x080;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);

        }
        private void rb_mode1_TEMPSNS_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_TEMPSNS;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x040;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);

        }
        private void rb_mode1_SSD_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_SSD;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x020;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_2LTO_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_2LTO;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x010;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_ACTCLMP_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_ACTCLMP;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x008;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_DESAT_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_DESAT;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x004;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_SCSNS_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_SCSNS;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x002;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode1_OCSNS_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode1_OCSNS;
            UInt32[] regsValue = Mode1RegsValue;
            int regIndex = 0;
            UInt32 bitMask = 0x001;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }

        private void rb_mode2_FSISOEN_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode2_FSISOEN;
            UInt32[] regsValue = Mode2RegsValue;
            int regIndex = 1;
            UInt32 bitMask = 0x040;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode2_BIST_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode2_BIST;
            UInt32[] regsValue = Mode2RegsValue;
            int regIndex = 1;
            UInt32 bitMask = 0x008;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode2_CONFIG_EN_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode2_CONFIG_EN;
            UInt32[] regsValue = Mode2RegsValue;
            int regIndex = 1;
            UInt32 bitMask = 0x004;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mode2_RESET_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mode2_RESET;
            UInt32[] regsValue = Mode2RegsValue;
            int regIndex = 1;
            UInt32 bitMask = 0x002;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }

        private void rb_config1_OCSNS_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_config1_UV_DIS;
            UInt32[] regsValue = Config1RegsValue;
            int regIndex = 2;
            UInt32 bitMask = 0x200;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }

        private void rb_config6_INTBFS_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_config6_INTBFS;
            UInt32[] regsValue = Config6RegsValue;
            int regIndex = 7;
            UInt32 bitMask = 0x200;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }

        private void rb_mask1_VCCOVM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask1_VCCOVM;
            UInt32[] regsValue = Mask1RegsValue;
            int regIndex = 10;
            UInt32 bitMask = 0x200;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask1_VCCREGUVM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask1_VCCREGUVM;
            UInt32[] regsValue = Mask1RegsValue;
            int regIndex = 10;
            UInt32 bitMask = 0x100;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask1_VSUPOVM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask1_VSUPOVM;
            UInt32[] regsValue = Mask1RegsValue;
            int regIndex = 10;
            UInt32 bitMask = 0x080;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask1_OTSDM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask1_OTSDM;
            UInt32[] regsValue = Mask1RegsValue;
            int regIndex = 10;
            UInt32 bitMask = 0x020;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask1_OTWM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask1_OTWM;
            UInt32[] regsValue = Mask1RegsValue;
            int regIndex = 10;
            UInt32 bitMask = 0x010;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask1_CLAMPM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask1_CLAMPM;
            UInt32[] regsValue = Mask1RegsValue;
            int regIndex = 10;
            UInt32 bitMask = 0x008;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }

        private void rb_mask2_DTFLTM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_DTFLTM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x080;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_SPIERRM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_SPIERRM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x040;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_CONFCRCERRM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_CONFCRCERRM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x020;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_VGE_FLTM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_VGE_FLTM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x010;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_WDOG_FLTM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_WDOG_FLTM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x008;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_COMERRM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_COMERRM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x004;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_VREF_UVM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_VREF_UVM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x002;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }
        private void rb_mask2_VEEM_Clicked(object sender, EventArgs e)
        {
            RadioButton[] radioButtons = rb_mask2_VEEM;
            UInt32[] regsValue = Mask2RegsValue;
            int regIndex = 11;
            UInt32 bitMask = 0x001;
            rb_clicked(sender, radioButtons, regsValue, regIndex, bitMask);
        }


        private void cb_all_changed(UInt32[] regValue, int regIndex, UInt32 bitsMask, UInt32 value)
        {
            FramLoad Load = new FramLoad();
            Load.RegAddr = RegAddr[regIndex];
            Load.Data = 0xffff;

            for (int i = 0; i < 6; i++)
            {
                if ((ChipSelect & ((UInt32)1 << i)) != 0)
                {

                    regValue[i] &= ~bitsMask;
                    regValue[i] |= value & bitsMask;
                    if (Load.Data == 0xffff)
                    {
                        Load.Data = regValue[i];
                        Load.ChipSelect = (UInt32)1 << i;
                    }
                    else
                    {
                        if (Load.Data == regValue[i])
                        {
                            Load.ChipSelect |= (UInt32)1 << i;
                        }
                        else
                        {
                            SendFram(Load);
                            Load.ChipSelect = (UInt32)1 << i;
                            Load.Data = regValue[i];
                        }
                    }
                }
            }
            SendFram(Load);
        }
        private void cb_single_changed(UInt32[] regValue, int deviceIndex, int regIndex, UInt32 bitsMask, UInt32 value)
        {
            FramLoad Load = new FramLoad();
            Load.RegAddr = RegAddr[regIndex];

            if ((ChipSelect & ((UInt32)1 << deviceIndex)) != 0)
            {
                regValue[deviceIndex] &= ~bitsMask;
                regValue[deviceIndex] |= value & bitsMask;

                Load.Data = regValue[deviceIndex];
                Load.ChipSelect = (UInt32)1 << deviceIndex;
                SendFram(Load);
            }
        }

        private void cb_changed(object sender, ComboBox[] comboBoxs, UInt32[] regsValue, int regIndex, UInt32 bitMask, int bitShift)
        {
            if (sender == comboBoxs[0])
            {
                int selectedIndex = comboBoxs[0].SelectedIndex;
                UInt32 value = (UInt32)selectedIndex << bitShift;
                cb_all_changed(regsValue, regIndex, bitMask, value);
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (sender == comboBoxs[i])
                    {
                        int selectedIndex = comboBoxs[i].SelectedIndex;
                        UInt32 value = (UInt32)selectedIndex << bitShift;
                        cb_single_changed(regsValue, i - 1, regIndex, bitMask, value);
                    }
                }
            }

        }
        /* Config 1 寄存器回调函数 */
        private void cb_config1_UV_TH_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config1_UV_TH;
            UInt32[] regsValue = Config1RegsValue;
            int regIndex = 2;
            UInt32 bitMask = 0x1c0;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 6);
        }
        private void cb_config1_OCTH_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config1_OCTH;
            UInt32[] regsValue = Config1RegsValue;
            int regIndex = 2;
            UInt32 bitMask = 0x038;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 3);
        }
        private void cb_config1_OCFILT_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config1_OCFILT;
            UInt32[] regsValue = Config1RegsValue;
            int regIndex = 2;
            UInt32 bitMask = 0x007;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 0);
        }

        /* Config 2 寄存器回调函数 */
        private void cb_config2_2LTOV_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config2_2LTOV;
            UInt32[] regsValue = Config2RegsValue;
            int regIndex = 3;
            UInt32 bitMask = 0x1c0;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 6);
        }
        private void cb_config2_SCTH_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config2_SCTH;
            UInt32[] regsValue = Config2RegsValue;
            int regIndex = 3;
            UInt32 bitMask = 0x038;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 3);
        }
        private void cb_config2_SCFILT_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config2_SCFILT;
            UInt32[] regsValue = Config2RegsValue;
            int regIndex = 3;
            UInt32 bitMask = 0x007;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 0);
        }

        /* Config 3 寄存器回调函数 */
        private void cb_config3_SEGDRVDLY_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config3_SEGDRVDLY;
            UInt32[] regsValue = Config3RegsValue;
            int regIndex = 4;
            UInt32 bitMask = 0x1c0;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 6);
        }
        private void cb_config3_SSD_CUR_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config3_SSD_CUR;
            UInt32[] regsValue = Config3RegsValue;
            int regIndex = 4;
            UInt32 bitMask = 0x038;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 3);
        }
        private void cb_config3_SSDT_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config3_SSDT;
            UInt32[] regsValue = Config3RegsValue;
            int regIndex = 4;
            UInt32 bitMask = 0x007;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 0);
        }

        /* Config 4 寄存器回调函数 */
        private void cb_config4_DESAT_LEB_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config4_DESAT_LEB;
            UInt32[] regsValue = Config4RegsValue;
            int regIndex = 5;
            UInt32 bitMask = 0x300;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 8);
        }
        private void cb_config4_AOUT_SEL_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config4_AOUT_SEL;
            UInt32[] regsValue = Config4RegsValue;
            int regIndex = 5;
            UInt32 bitMask = 0x0E0;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 5);
        }
        private void cb_config4_IDESAT_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config4_IDESAT;
            UInt32[] regsValue = Config4RegsValue;
            int regIndex = 5;
            UInt32 bitMask = 0x018;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 3);
        }
        private void cb_config4_DESAT_TH_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config4_DESAT_TH;
            UInt32[] regsValue = Config4RegsValue;
            int regIndex = 5;
            UInt32 bitMask = 0x007;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 0);
        }

        /* Config 5 寄存器回调函数 */
        private void cb_config5_DEADT_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config5_DEADT;
            UInt32[] regsValue = Config5RegsValue;
            int regIndex = 6;
            UInt32 bitMask = 0x3C0;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 6);
        }
        private void cb_config5_AOUTCONF_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config5_AOUTCONF;
            UInt32[] regsValue = Config5RegsValue;
            int regIndex = 6;
            UInt32 bitMask = 0x038;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 3);
        }
        private void cb_config5_COMERRCONF21_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config5_COMERRCONF21;
            UInt32[] regsValue = Config5RegsValue;
            int regIndex = 6;
            UInt32 bitMask = 0x006;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 1);
        }
        private void cb_config5_COMERRCONF0_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config5_COMERRCONF0;
            UInt32[] regsValue = Config5RegsValue;
            int regIndex = 6;
            UInt32 bitMask = 0x001;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 0);
        }

        /* Config 6 寄存器回调函数 */
        private void cb_config6_WDTO_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config6_WDTO;
            UInt32[] regsValue = Config6RegsValue;
            int regIndex = 7;
            UInt32 bitMask = 0x030;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 4);
        }
        private void cb_config6_VGEMONDLY_Changed(object sender, EventArgs e)
        {
            ComboBox[] comboBoxs = cb_config6_VGEMONDLY;
            UInt32[] regsValue = Config6RegsValue;
            int regIndex = 7;
            UInt32 bitMask = 0x00F;
            cb_changed(sender, comboBoxs, regsValue, regIndex, bitMask, 0);
        }

        private void tb_text_Changed(object sender, EventArgs e)
        {
            for (int i = 0; i< 14; i++)
            {
                if (tb_Ot_Otw_Th[i] == sender)
                {
                    int value;
                    if (int.TryParse(tb_Ot_Otw_Th[i].Text, out value))
                    {
                        if (value > 1023)
                        {
                            value = 1023;
                            tb_Ot_Otw_Th[i].Text = value.ToString();
                        }
                    }
                    else
                    {
                        value = 0;
                        tb_Ot_Otw_Th[i].Text = value.ToString();
                    }
                        
                }
            }
        }


        private void SendFram(FramLoad load)
        {
            if (load.ChipSelect == 0)
            {
                return;
            }
            Debug.WriteLine("ChipSelete " + load.ChipSelect.ToString());
            Debug.WriteLine("RegAddr    " + load.RegAddr.ToString());
            Debug.WriteLine("Data       " + Convert.ToString(load.Data, 16));
            messageToMainFram(load);
        }

        private void ReceiveFram(FramLoad load)
        {
            switch (load.RegAddr)
            {
                case (int)GD3100RegDefine.Gd3100_RegAddr.Mode1:

                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Mode2:

                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Config1:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Config2:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Config3:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Config4:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Config5:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Config6:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Mask1:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.Mask2:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.OT_TH:
                    break;
                case (int)GD3100RegDefine.Gd3100_RegAddr.OTW_TH:
                    break;
                default:
                    break;
            }
        }

        private void tb_all_changed(UInt32[] regValue, int regIndex, UInt32 bitsMask, UInt32 value)
        {
            FramLoad Load = new FramLoad();
            Load.RegAddr = RegAddr[regIndex];
            Load.Data = 0xffff;

            for (int i = 0; i < 6; i++)
            {
                if ((ChipSelect & ((UInt32)1 << i)) != 0)
                {

                    regValue[i] &= ~bitsMask;
                    regValue[i] |= value & bitsMask;
                    if (Load.Data == 0xffff)
                    {
                        Load.Data = regValue[i];
                        Load.ChipSelect = (UInt32)1 << i;
                    }
                    else
                    {
                        if (Load.Data == regValue[i])
                        {
                            Load.ChipSelect |= (UInt32)1 << i;
                        }
                        else
                        {
                            SendFram(Load);
                            Load.ChipSelect = 0;
                            Load.Data = regValue[i];
                        }
                    }
                }
            }
            SendFram(Load);
        }
        private void tb_single_changed(UInt32[] regValue, int deviceIndex, int regIndex, UInt32 bitsMask, UInt32 value)
        {
            FramLoad Load = new FramLoad();
            Load.RegAddr = RegAddr[regIndex];

            if ((ChipSelect & ((UInt32)1 << deviceIndex)) != 0)
            {
                regValue[deviceIndex] &= ~bitsMask;
                regValue[deviceIndex] |= value & bitsMask;

                Load.Data = regValue[deviceIndex];
                Load.ChipSelect = (UInt32)1 << deviceIndex;
                SendFram(Load);
            }
        }

        private void tb_changed(object sender, ComboBox[] comboBoxs, UInt32[] regsValue, int regIndex, UInt32 bitMask, int bitShift)
        {
            if (sender == comboBoxs[0])
            {
                int selectedIndex = comboBoxs[0].SelectedIndex;
                UInt32 value = (UInt32)selectedIndex << bitShift;
                cb_all_changed(regsValue, regIndex, bitMask, value);
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (sender == comboBoxs[i])
                    {
                        int selectedIndex = comboBoxs[i].SelectedIndex;
                        UInt32 value = (UInt32)selectedIndex << bitShift;
                        cb_single_changed(regsValue, i - 1, regIndex, bitMask, value);
                    }
                }
            }

        }
        private void tb_Ot_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                if (tb_Ot_Otw_Th[i] == sender)
                {
                    int value;
                    if (int.TryParse(tb_Ot_Otw_Th[i].Text, out value))
                    {
                        if (value > 1023)
                        {
                            value = 1023;
                            tb_Ot_Otw_Th[i].Text = value.ToString();
                        }
                    }
                    else
                    {
                        value = 0;
                        tb_Ot_Otw_Th[i].Text = value.ToString();
                    }


                }
            }
        }

        private void tb_Otw_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < 14; i++)
            {
                if (tb_Ot_Otw_Th[i] == sender)
                {
                    int value;
                    if (int.TryParse(tb_Ot_Otw_Th[i].Text, out value))
                    {
                        if (value > 1023)
                        {
                            value = 1023;
                            tb_Ot_Otw_Th[i].Text = value.ToString();
                        }
                    }
                    else
                    {
                        value = 0;
                        tb_Ot_Otw_Th[i].Text = value.ToString();
                    }

                }
            }
        }

    }
}
