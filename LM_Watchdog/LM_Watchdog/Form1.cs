using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LM_Watchdog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region All the standard things
        ///<summary>
        /// Returns system clock in seconds
        ///</summary>
        public static int sTick()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        ///<summary>
        /// Returns how many seconds sTick has passed vl
        ///</summary>
        public static int T2C(int vl)
        {
            int ret = sTick() - vl;
            if (ret < 0) ret += 86400;
            if (ret > 3600) ret = 0;
            return ret;
        }
        /// <summary>
        /// Reads sFile, works with norwegian letters ae oo aa
        /// </summary>
        public static string FileRead(string sFile)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(sFile, Encoding.GetEncoding("iso-8859-1"));
                string ret = sr.ReadToEnd();
                while ((ret.Substring(ret.Length - 1) == "\r") || (ret.Substring(ret.Length - 1) == "\n"))
                    ret = ret.Substring(0, ret.Length - 1);
                sr.Close(); sr.Dispose(); return ret;
            }
            catch { return ""; }
        }
        /// <summary>
        /// Writes sVal to sFile, works with norwegian letters ae oo aa
        /// </summary>
        /// <param name="sFile">Target file</param>
        /// <param name="sVal">The string to write</param>
        /// <param name="bAppend">Append instead of overwrite</param>
        public static void FileWrite(string sFile, string sVal, bool bAppend)
        {
            System.IO.FileMode AccessType = System.IO.FileMode.Create;
            if (bAppend) AccessType = System.IO.FileMode.Append;
            System.IO.FileStream fs = new System.IO.FileStream(sFile, AccessType);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"));
            sw.Write(sVal); sw.Close(); sw.Dispose();
        }
        public void FileWrite(string sFile, string sVal)
        {
            FileWrite(sFile, sVal, false);
        }
        #endregion

        private void tMain_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcessesByName("ToxLM");
            if (procs.GetUpperBound(0) != -1)
            {
                gvbList.RowCount = procs.GetUpperBound(0) + 1;
            }
            else
            {
                gvbList.RowCount = 1;
                gvbList[0, 0].Value = "";
                gvbList[0, 0].Value = "";
                gvbList[0, 0].Value = "";
                gvbList[0, 0].Value = "";
            }

            for (int a = 0; a <= procs.GetUpperBound(0); a++)
            {
                string twTitle = procs[a].MainWindowTitle;
                gvbList[0, a].Value = procs[a].MainWindowHandle;
                gvbList[1, a].Value = twTitle.Split('|')[1].Trim();
                long LastAction = T2C(Convert.ToInt32(twTitle.Split('|')[2].Trim()));
                if (LastAction <= 15) gvbList[2, a].Value = "Active";
                if (LastAction > 30) gvbList[2, a].Value = "Crash?";
                if (LastAction > 60)
                {
                    gvbList[2, a].Value = "Killing";
                    //procs[a].Kill();
                    //StartByCommand(CommandByNick(twTitle.Split('|')[1].Trim()));
                }
            }
        }

        private void StartByCommand(string Cmd)
        {
            string Params = Cmd.Substring(Cmd.ToLower().IndexOf("toxlm.exe ") + "toxlm.exe ".Length);
            System.Diagnostics.Process.Start("ToxLM.exe", Params);
        }
        private string CommandByNick(string Nick)
        {
            string sRaw = FileRead("Launcher.bat");
            string[] asRaw = sRaw.Replace("\r", "").Split('\n');
            foreach (string Raw in asRaw)
            {
                if (Raw.Contains("/user " + Nick + " /"))
                {
                    return Raw;
                }
            }
            return "";
        }
    }
}
