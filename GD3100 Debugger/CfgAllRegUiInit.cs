using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD3100Debugger
{
    public class CfgAllRegUiInit
    {
        static string[] UV_TH_string = {
            "10.0V",
            "10.5V",
            "11.0V",
            "11.5V",
            "12.0V",
            "12.5V",
            "13.0V",
            "13.5V"};
        static string[] OC_TH_string = {
            "0.25V",
            "0.50V",
            "0.75V",
            "1.00V",
            "1.25V",
            "1.50V",
            "1.75V",
            "2.00V"};
        static string[] OC_FILT_string = {
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
        public static void Condig1Init(System.Windows.Forms.ComboBox[] boxs)
        {
            for (int i = 0; i < 7; i++)
            {
                boxs[i].Items.AddRange(UV_TH_string);
            }
            for (int i = 7; i < 14; i++)
            {
                boxs[i].Items.AddRange(OC_TH_string);
            }
            for (int i = 14; i < 21; i++)
            {
                boxs[i].Items.AddRange(OC_FILT_string);
            }
        }
        public static void Condig2Init(System.Windows.Forms.ComboBox[] boxs)
        {
            for (int i = 0; i < 7; i++)
            {
                boxs[i].Items.AddRange(string_2LTOV);
            }
            for (int i = 7; i < 14; i++)
            {
                boxs[i].Items.AddRange(string_SCTH);
            }
            for (int i = 14; i < 21; i++)
            {
                boxs[i].Items.AddRange(string_SCFILT);
            }
        }
    }
}
