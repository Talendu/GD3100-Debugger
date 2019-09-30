using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GD3100Debugger
{
    public class CfgAllRegUiInit
    {
        static string[] string_UV_TH = {
            "10.0V",
            "10.5V",
            "11.0V",
            "11.5V",
            "12.0V",
            "12.5V",
            "13.0V",
            "13.5V"};

        static string[] string_OCTH = {
            "0.25V",
            "0.50V",
            "0.75V",
            "1.00V",
            "1.25V",
            "1.50V",
            "1.75V",
            "2.00V"};

        static string[] string_OCFILT = {
            "0.5μs",
            "1.0μs",
            "1.5μs",
            "2.0μs",
            "2.5μs",
            "3.0μs",
            "3.5μs",
            "4.0μs"};

        static string[] string_2LTOV = {
            "8.91V",
            "9.23V",
            "9.58V",
            "9.96V",
            "10.39V",
            "10.84V",
            "11.35V",
            "11.89V"};

        static string[] string_SCTH = {
            "0.50V",
            "0.75V",
            "1.00V",
            "1.25V",
            "1.50V",
            "2.00V",
            "2.50V",
            "3.00V"};

        static string[] string_SCFILT = {
            "400ns",
            "500ns",
            "600ns",
            "700ns",
            "800ns",
            "900ns",
            "1000ns",
            "1100ns"};

        static string[] string_SEGDRVDLY = {
            "20ns",
            "40ns",
            "60ns",
            "80ns",
            "100ns",
            "120ns",
            "140ns",
            "160ns"};

        static string[] string_SSD_CUR = {
            "0.10A",
            "0.20A",
            "0.30A",
            "0.40A",
            "0.60A",
            "0.80A",
            "1.00A",
            "1.20A"};

        static string[] string_SSDT = {
            "2000ns",
            "3000ns",
            "4000ns",
            "5000ns",
            "6000ns",
            "7000ns",
            "8000ns",
            "9000ns"};

        static string[] string_DESAT_LEB = {
            "400ns",
            "500ns",
            "600ns",
            "700ns",};

        static string[] string_AOUT_SEL = {
            "IGBT Temp",
            "AMUX",
            "VCC",
            "GH Temp",
            "GL Temp",};

        static string[] string_IDESAT = {
            "250μA",
            "500μA",
            "750μA",
            "1000μA",};

        static string[] string_DESAT_TH = {
            "3.00V",
            "4.00V",
            "5.00V",
            "6.00V",
            "7.00V",
            "8.00V",
            "9.00V",
            "10.00V"};


        static string[] string_DEADT = {
            "0.5μs",
            "0.75μs",
            "1.00μs",
            "1.25μs",
            "1.50μs",
            "1.75μs",
            "2.00μs",
            "2.25μs",
            "2.50μs",
            "2.75μs",
            "3.00μs",
            "3.25μs",
            "3.50μs",
            "3.75μs",
            "4.00μs",
            "4.25μs"};

        static string[] string_AOUTCONF = {
            "1/1",
            "1/2",
            "1/4",
            "1/8",
            "1/8",
            "1/8",
            "1/8",
            "1/8"};

        static string[] string_COMERRCONF21 = {
            "1",
            "4",
            "8",
            "16",};

        static string[] string_COMERRCONF0 = {
            "1",
            "4",};


        static string[] string_WDTO = {
            "260μs",
            "500μs",
            "1000μs",
            "2000μs",};

        static string[] string_VGEMONDLY = {
            "400ns",
            "600ns",
            "800ns",
            "1000ns",
            "1200ns",
            "1400ns",
            "1600ns",
            "1800ns",
            "2000ns",
            "2400ns",
            "2800ns",
            "3200ns",
            "3600ns",
            "4000ns",
            "4400ns",
            "4800ns"};

        private static void ComboBoxInit(ComboBox[] boxs)
        {
            foreach (ComboBox box in boxs)
            {
                box.Dock = DockStyle.Fill;
                box.DropDownStyle = ComboBoxStyle.DropDownList;
                box.FormattingEnabled = true;
                box.Size = new System.Drawing.Size(87, 20);
            }
        }


        private static void RadioButtonInit(RadioButton[] btns)
        {
            foreach (RadioButton btn in btns)
            {
                btn.AutoCheck = false;
                btn.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
                btn.Dock = System.Windows.Forms.DockStyle.Fill;
                btn.TabStop = true;
            }
        }

        public static void Mode1Init(TableLayoutPanel panel,EventHandler[] redioClickEvent,
            RadioButton[] btn_AOUT, RadioButton[] btn_SEGDRV,RadioButton[] btn_AMC, RadioButton[] btn_TEMPSNS, RadioButton[] btn_SSD,
            RadioButton[] btn_2LTO,RadioButton[] btn_ACTCLMP, RadioButton[] btn_DESAT, RadioButton[] btn_SCSNS, RadioButton[] btn_OCSNS)
        {

            RadioButtonInit(btn_AOUT);
            RadioButtonInit(btn_SEGDRV);
            RadioButtonInit(btn_AMC);
            RadioButtonInit(btn_TEMPSNS);
            RadioButtonInit(btn_SSD);
            RadioButtonInit(btn_2LTO);
            RadioButtonInit(btn_ACTCLMP);
            RadioButtonInit(btn_DESAT);
            RadioButtonInit(btn_SCSNS);
            RadioButtonInit(btn_OCSNS);


            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(btn_AOUT[i], 1, i + 1);
                btn_AOUT[i].Click += redioClickEvent[0];

                panel.Controls.Add(btn_SEGDRV[i], 2, i + 1);
                btn_SEGDRV[i].Click += redioClickEvent[1];

                panel.Controls.Add(btn_AMC[i], 3, i + 1);
                btn_AMC[i].Click += redioClickEvent[2];

                panel.Controls.Add(btn_TEMPSNS[i], 4, i + 1);
                btn_TEMPSNS[i].Click += redioClickEvent[3];

                panel.Controls.Add(btn_SSD[i], 5, i + 1);
                btn_SSD[i].Click += redioClickEvent[4];

                panel.Controls.Add(btn_2LTO[i], 6, i + 1);
                btn_2LTO[i].Click += redioClickEvent[5];

                panel.Controls.Add(btn_ACTCLMP[i], 7, i + 1);
                btn_ACTCLMP[i].Click += redioClickEvent[6];

                panel.Controls.Add(btn_DESAT[i], 8, i + 1);
                btn_DESAT[i].Click += redioClickEvent[7];

                panel.Controls.Add(btn_SCSNS[i], 9, i + 1);
                btn_SCSNS[i].Click += redioClickEvent[8];

                panel.Controls.Add(btn_OCSNS[i], 10, i + 1);
                btn_OCSNS[i].Click += redioClickEvent[9];
            }
        }
        public static void Mode2Init(TableLayoutPanel panel, EventHandler[] redioClickEvent,
            RadioButton[] btn_FSISOEN, RadioButton[] btn_BIST, RadioButton[] btn_CONFIG_EN, RadioButton[] btn_RESET)
        {

            RadioButtonInit(btn_FSISOEN);
            RadioButtonInit(btn_BIST);
            RadioButtonInit(btn_CONFIG_EN);
            RadioButtonInit(btn_RESET);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(btn_FSISOEN[i], 4, i + 1);
                btn_FSISOEN[i].Click += redioClickEvent[0];

                panel.Controls.Add(btn_BIST[i], 7, i + 1);
                btn_BIST[i].Click += redioClickEvent[1];

                panel.Controls.Add(btn_CONFIG_EN[i], 8, i + 1);
                btn_CONFIG_EN[i].Click += redioClickEvent[2];

                panel.Controls.Add(btn_RESET[i], 9, i + 1);
                btn_RESET[i].Click += redioClickEvent[3];

            }
        }

        public static void Config1Init(TableLayoutPanel panel, EventHandler[] redioClickEvent, EventHandler[] comboSeleteEvent,
            RadioButton[] btn_UV_DIS, ComboBox[] boxs_UV_TH, ComboBox[] boxs_OCTH, ComboBox[] boxs_OCFILT)
        {
            RadioButtonInit(btn_UV_DIS);
            ComboBoxInit(boxs_UV_TH);
            ComboBoxInit(boxs_OCTH);
            ComboBoxInit(boxs_OCFILT);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(btn_UV_DIS[i], 1, i + 1);
                btn_UV_DIS[i].Click += redioClickEvent[0];

                panel.Controls.Add(boxs_UV_TH[i], 2, i + 1);
                boxs_UV_TH[i].SelectedIndexChanged += comboSeleteEvent[0];

                panel.Controls.Add(boxs_OCTH[i], 3, i + 1);
                boxs_OCTH[i].SelectedIndexChanged += comboSeleteEvent[1];

                panel.Controls.Add(boxs_OCFILT[i], 4, i + 1);
                boxs_OCFILT[i].SelectedIndexChanged += comboSeleteEvent[2];
            }

            for (int i = 0; i < 7; i++)
            {
                boxs_UV_TH[i].Items.AddRange(string_UV_TH);
                boxs_OCTH[i].Items.AddRange(string_OCTH);
                boxs_OCFILT[i].Items.AddRange(string_OCFILT);
            }
        }
        public static void Config2Init(TableLayoutPanel panel, EventHandler[] comboSeleteEvent, 
            ComboBox[] boxs_2LTOV, ComboBox[] boxs_SCTH, ComboBox[] boxs_SCFILT)
        {
            ComboBoxInit(boxs_2LTOV);
            ComboBoxInit(boxs_SCTH);
            ComboBoxInit(boxs_SCFILT);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(boxs_2LTOV[i],  2, i+1);
                boxs_2LTOV[i].SelectedIndexChanged += comboSeleteEvent[0];

                panel.Controls.Add(boxs_SCTH[i], 3, i + 1);
                boxs_SCTH[i].SelectedIndexChanged += comboSeleteEvent[1];

                panel.Controls.Add(boxs_SCFILT[i], 4, i + 1);
                boxs_SCFILT[i].SelectedIndexChanged += comboSeleteEvent[2];
            }

            for (int i = 0; i < 7; i++)
            {
                boxs_2LTOV[i].Items.AddRange(string_2LTOV);
                boxs_SCTH[i].Items.AddRange(string_SCTH);
                boxs_SCFILT[i].Items.AddRange(string_SCFILT);
            }
        }
        public static void Config3Init(TableLayoutPanel panel, EventHandler[] comboSeleteEvent, 
            ComboBox[] boxs_SEGDRVDLY, ComboBox[] boxs_SSD_CUR, ComboBox[] boxs_SSDT)
        {
            ComboBoxInit(boxs_SEGDRVDLY);
            ComboBoxInit(boxs_SSD_CUR);
            ComboBoxInit(boxs_SSDT);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(boxs_SEGDRVDLY[i], 2, i + 1);
                boxs_SEGDRVDLY[i].SelectedIndexChanged += comboSeleteEvent[0];

                panel.Controls.Add(boxs_SSD_CUR[i], 3, i + 1);
                boxs_SSD_CUR[i].SelectedIndexChanged += comboSeleteEvent[1];

                panel.Controls.Add(boxs_SSDT[i], 4, i + 1);
                boxs_SSDT[i].SelectedIndexChanged += comboSeleteEvent[2];
            }

            for (int i = 0; i < 7; i++)
            {
                boxs_SEGDRVDLY[i].Items.AddRange(string_SEGDRVDLY);
                boxs_SSD_CUR[i].Items.AddRange(string_SSD_CUR);
                boxs_SSDT[i].Items.AddRange(string_SSDT);
            }
        }
        public static void Config4Init(TableLayoutPanel panel, EventHandler[] comboSeleteEvent,
            ComboBox[] boxs_DESAT_LEB, ComboBox[] boxs_AOUT_SEL, ComboBox[] boxs_IDESAT, ComboBox[] boxs_DESAT_TH)
        {
            ComboBoxInit(boxs_DESAT_LEB);
            ComboBoxInit(boxs_AOUT_SEL);
            ComboBoxInit(boxs_IDESAT);
            ComboBoxInit(boxs_DESAT_TH);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(boxs_DESAT_LEB[i], 1, i + 1);
                boxs_DESAT_LEB[i].SelectedIndexChanged += comboSeleteEvent[0];

                panel.Controls.Add(boxs_AOUT_SEL[i], 2, i + 1);
                boxs_AOUT_SEL[i].SelectedIndexChanged += comboSeleteEvent[1];

                panel.Controls.Add(boxs_IDESAT[i], 3, i + 1);
                boxs_IDESAT[i].SelectedIndexChanged += comboSeleteEvent[2];

                panel.Controls.Add(boxs_DESAT_TH[i], 4, i + 1);
                boxs_DESAT_TH[i].SelectedIndexChanged += comboSeleteEvent[3];
            }

            for (int i = 0; i < 7; i++)
            {
                boxs_DESAT_LEB[i].Items.AddRange(string_DESAT_LEB);
                boxs_AOUT_SEL[i].Items.AddRange(string_AOUT_SEL);
                boxs_IDESAT[i].Items.AddRange(string_IDESAT);
                boxs_DESAT_TH[i].Items.AddRange(string_DESAT_TH);
            }
        }
        public static void Config5Init(TableLayoutPanel panel, EventHandler[] comboSeleteEvent,
            ComboBox[] boxs_DEADT, ComboBox[] boxs_AOUTCONF, ComboBox[] boxs_COMERRCONF21, ComboBox[] boxs_COMERRCONF0)
        {
            ComboBoxInit(boxs_DEADT);
            ComboBoxInit(boxs_AOUTCONF);
            ComboBoxInit(boxs_COMERRCONF21);
            ComboBoxInit(boxs_COMERRCONF0);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(boxs_DEADT[i], 1, i + 1);
                boxs_DEADT[i].SelectedIndexChanged += comboSeleteEvent[0];

                panel.Controls.Add(boxs_AOUTCONF[i], 2, i + 1);
                boxs_AOUTCONF[i].SelectedIndexChanged += comboSeleteEvent[1];

                panel.Controls.Add(boxs_COMERRCONF21[i], 3, i + 1);
                boxs_COMERRCONF21[i].SelectedIndexChanged += comboSeleteEvent[2];

                panel.Controls.Add(boxs_COMERRCONF0[i], 4, i + 1);
                boxs_COMERRCONF0[i].SelectedIndexChanged += comboSeleteEvent[3];
            }

            for (int i = 0; i < 7; i++)
            {
                boxs_DEADT[i].Items.AddRange(string_DEADT);
                boxs_AOUTCONF[i].Items.AddRange(string_AOUTCONF);
                boxs_COMERRCONF21[i].Items.AddRange(string_COMERRCONF21);
                boxs_COMERRCONF0[i].Items.AddRange(string_COMERRCONF0);
            }
        }
        public static void Config6Init(TableLayoutPanel panel, EventHandler[] redioClickEvent, EventHandler[] comboSeleteEvent,
            RadioButton[] btn_INTBFS, ComboBox[] boxs_WDTO, ComboBox[] boxs_VGEMONDLY)
        {
            RadioButtonInit(btn_INTBFS);
            ComboBoxInit(boxs_WDTO);
            ComboBoxInit(boxs_VGEMONDLY);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(btn_INTBFS[i], 1, i + 1);
                btn_INTBFS[i].Click += redioClickEvent[0];

                panel.Controls.Add(boxs_WDTO[i], 5, i + 1);
                boxs_WDTO[i].SelectedIndexChanged += comboSeleteEvent[0];

                panel.Controls.Add(boxs_VGEMONDLY[i], 6, i + 1);
                boxs_VGEMONDLY[i].SelectedIndexChanged += comboSeleteEvent[1];
            }

            for (int i = 0; i < 7; i++)
            {
                boxs_WDTO[i].Items.AddRange(string_WDTO);
                boxs_VGEMONDLY[i].Items.AddRange(string_VGEMONDLY);
            }
        }

        public static void Mask1Init(TableLayoutPanel panel, EventHandler[] redioClickEvent,
            RadioButton[] btn_VCCOVM, RadioButton[] btn_VCCREGUVM, RadioButton[] btn_VSUPOVM, 
            RadioButton[] btn_OTSDM,RadioButton[] btn_OTWM, RadioButton[] btn_CLAMPM)
        {

            RadioButtonInit(btn_VCCOVM);
            RadioButtonInit(btn_VCCREGUVM);
            RadioButtonInit(btn_VSUPOVM);
            RadioButtonInit(btn_OTSDM);
            RadioButtonInit(btn_OTWM);
            RadioButtonInit(btn_CLAMPM);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(btn_VCCOVM[i], 1, i + 1);
                btn_VCCOVM[i].Click += redioClickEvent[0];

                panel.Controls.Add(btn_VCCREGUVM[i], 2, i + 1);
                btn_VCCREGUVM[i].Click += redioClickEvent[1];

                panel.Controls.Add(btn_VSUPOVM[i], 3, i + 1);
                btn_VSUPOVM[i].Click += redioClickEvent[2];

                panel.Controls.Add(btn_OTSDM[i], 5, i + 1);
                btn_OTSDM[i].Click += redioClickEvent[3];

                panel.Controls.Add(btn_OTWM[i], 6, i + 1);
                btn_OTWM[i].Click += redioClickEvent[4];

                panel.Controls.Add(btn_CLAMPM[i], 7, i + 1);
                btn_CLAMPM[i].Click += redioClickEvent[5];
            }
        }

        public static void Mask2Init(TableLayoutPanel panel, EventHandler[] redioClickEvent,
            RadioButton[] btn_DTFLTM, RadioButton[] btn_SPIERRM, RadioButton[] btn_CONFCRCERRM, RadioButton[] btn_VGE_FLTM,
            RadioButton[] btn_WDOG_FLTM, RadioButton[] btn_COMERRM, RadioButton[] btn_VREF_UVM, RadioButton[] btn_VEEM)
        {

            RadioButtonInit(btn_DTFLTM);
            RadioButtonInit(btn_SPIERRM);
            RadioButtonInit(btn_CONFCRCERRM);
            RadioButtonInit(btn_VGE_FLTM);
            RadioButtonInit(btn_WDOG_FLTM);
            RadioButtonInit(btn_COMERRM);
            RadioButtonInit(btn_VREF_UVM);
            RadioButtonInit(btn_VEEM);

            for (int i = 0; i < 7; i++)
            {
                panel.Controls.Add(btn_DTFLTM[i], 3, i + 1);
                btn_DTFLTM[i].Click += redioClickEvent[0];

                panel.Controls.Add(btn_SPIERRM[i], 4, i + 1);
                btn_SPIERRM[i].Click += redioClickEvent[1];

                panel.Controls.Add(btn_CONFCRCERRM[i], 5, i + 1);
                btn_CONFCRCERRM[i].Click += redioClickEvent[2];

                panel.Controls.Add(btn_VGE_FLTM[i], 6, i + 1);
                btn_VGE_FLTM[i].Click += redioClickEvent[3];

                panel.Controls.Add(btn_WDOG_FLTM[i], 7, i + 1);
                btn_WDOG_FLTM[i].Click += redioClickEvent[4];

                panel.Controls.Add(btn_COMERRM[i], 8, i + 1);
                btn_COMERRM[i].Click += redioClickEvent[5];

                panel.Controls.Add(btn_VREF_UVM[i], 9, i + 1);
                btn_VREF_UVM[i].Click += redioClickEvent[6];

                panel.Controls.Add(btn_VEEM[i], 10, i + 1);
                btn_VEEM[i].Click += redioClickEvent[7];
            }
        }
    }
}
