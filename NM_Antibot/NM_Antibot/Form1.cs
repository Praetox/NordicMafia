using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NM_Antibot
{
    public partial class Form1 : Form
    {
        public static string imgPath = "c:/hget_genbilde_aag.jpeg";

        public struct PixelData
        {
            public byte Blue;
            public byte Green;
            public byte Red;
        }

        public Form1()
        {
            InitializeComponent();
        }
        public long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        private void pBox_MouseDown(object sender, MouseEventArgs e)
        {
            pBox.Load(imgPath); Application.DoEvents();
        }
        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap pic = new Bitmap(imgPath);
            Color col = pic.GetPixel(e.X, e.Y);
            this.Text = col.R + " " + col.G + " " + col.B + " - " + Col2Long(col);
            this.BackColor = col;
        }

        private void pBox_MouseUp(object sender, MouseEventArgs e)
        {
            long Matches = 0;                                                       //Define value to hold matchcount
            pBox.Load(imgPath); Application.DoEvents();                             //Load picture to picturebox
            bool[,] matches = new bool[90, 65];                                     //Define 2d array to hold results
            Color col = (pBox.Image as Bitmap).GetPixel(e.X, e.Y);                  //Get color of the pixel clicked
            Image.FastBitmap img = new Image.FastBitmap(pBox.Image as Bitmap);      //Load picture as FastBitmap
            for (int y = 0; y < 65; y++)                                            //Start Y-loop
            {
                for (int x = 0; x < 90; x++)                                        //Start X-loop
                {
                    Color tcol = img.GetPixel(x, y);                                //Get current color
                    if (CompareColors(tcol, col, 20))                               //If current and selected match
                    {
                        Matches++;                                                  //Increase match count
                        matches[x, y] = true;                                       //Indicate a match
                    }
                    else                                                            //else...
                    {
                        matches[x, y] = false;                                      //Indicate a mismatch
                    }
                }
            }
            img.Release();                                                          //Dispose of the FastBitmap
            Image.FastBitmap rmg = new Image.FastBitmap(pBox.Image as Bitmap);      //Load picture as FastBitmap
            for (int y = 0; y < 65; y++)                                            //Start comparative Y-loop
            {
                for (int x = 0; x < 90; x++)                                        //Start comparative X-loop
                {
                    if (matches[x, y])                                              //If there's a stored match
                    {
                        rmg.SetPixel(x, y, Color.White);                            //Indicate with a white spot
                    }
                }
            }
            rmg.Release();                                                          //Dispose of the FastBitmap
            pBox.Refresh();                                                         //Force the box to refresh image
            MessageBox.Show(Matches + "\r\n" + Col2Long(col));                      //Display results of scan
            Clipboard.SetText(Col2Long(col) + "-" +                                 //Clipboard results of scan
                (Matches - 20) + "-" + (Matches + 20) + "-20");
        }

        private void cmdIdent_Click(object sender, EventArgs e)
        {
            long Tick01 = Tick();                                                   //  *debug* performance timer
            Color[,] col = new Color[90, 65];                                       //Define color array (speedh4x)
            bool[,] matches = new bool[90, 65];                                     //Define bool array for matches
            pBox.Load(imgPath); Application.DoEvents();                             //Load picture to picturebox
            Image.FastBitmap img = new Image.FastBitmap(pBox.Image as Bitmap);      //Load picture as FastBitmap
            long Tick02 = Tick();                                                   //  *debug* performance timer
            for (int y = 0; y < 65; y++)                                            //Start first Y-loop
            {
                for (int x = 0; x < 90; x++)                                        //Start first X-loop
                {
                    col[x,y] = img.GetPixel(x, y);                                  //Get pixelcolor to color array
                }
            }
            Color MaxCol = Color.Black; long CurNum, MaxNum = 0;                    //Define initial values
            for (int cY = 0; cY < 65; cY++)                                         //Start main Y-loop
            {
                for (int cX = 0; cX < 65; cX++)                                     //Start main X-loop
                {
                    CurNum = 0;                                                     //Reset current matches to zero
                    for (int Y = 0; Y < 65; Y++)                                    //Start comparative Y-loop
                    {
                        for (int X = 0; X < 90; X++)                                //Start comparative X-loop
                        {
                            if (CompareColors(col[X, Y], col[cX, cY], 10))          //If match
                            {
                                CurNum++;                                           //Increase matches
                                matches[X, Y] = true;                               //Add match to bool array
                            }
                            else                                                    //else...
                            {
                                matches[X, Y] = false;                              //Add mismatch to bool array
                            }
                        }
                    }
                    if (CurNum>MaxNum)                                              //If this scan exceeds record
                    {
                        MaxNum=CurNum; MaxCol = col[cX,cY];                         //Set new record count and color
                        this.Text = MaxNum + " / " + Col2Long(MaxCol);              //  *debug* display record values
                        this.BackColor = MaxCol;                                    //  *debug* set form background
                    }
                }
            }
            img.Release();                                                          //Dispose the FastBitmap
            long Tick03 = Tick();                                                   //  *debug* performance timer

            ////  From here on, (improved) code from KeyUp sub  ////

            Image.FastBitmap rmg = new Image.FastBitmap(pBox.Image as Bitmap);      //Load picture as FastBitmap
            for (int y = 0; y < 65; y++)                                            //Start comparative Y-loop
            {
                for (int x = 0; x < 90; x++)                                        //Start comparative X-loop
                {
                    if (matches[x, y])                                              //If there's a stored match
                    {
                        rmg.SetPixel(x, y, Color.White);                            //Indicate with a white spot
                    }
                    else                                                            //else...
                    {
                        rmg.SetPixel(x, y, Color.Black);                            //Indicate with a black spot
                    }
                }
            }
            rmg.Release();                                                          //Dispose of the FastBitmap
            pBox.Refresh();                                                         //Force the box to refresh image
            
            MessageBox.Show("" + (Tick02 - Tick01) + "\n" + (Tick03 - Tick02) + 
                            "\n" + (Tick()-Tick03));                                //  *debug* display timer result

        }

        private bool CompareColors(Color Compare, Color CompareTo, long Threshold)
        {
            if (Compare == Color.Black || CompareTo == Color.Black) return false;   //Return false if pitch black
            long RDiff = Compare.R - CompareTo.R; if (RDiff < 0) RDiff = -RDiff;    //Compare reds, make positive
            long GDiff = Compare.G - CompareTo.G; if (GDiff < 0) GDiff = -GDiff;    //Compare greens, make positive
            long BDiff = Compare.B - CompareTo.B; if (BDiff < 0) BDiff = -BDiff;    //Compare blues, make positive
            if (RDiff <= Threshold && GDiff <= Threshold && BDiff <= Threshold)     //If all are below threshold
            {
                return true;                                                        //Return with a match (true)
            }
            else                                                                    //else...
            {
                return false;                                                       //Return with a mismatch (false)
            }
        }

        private void cmdVerify_Click(object sender, EventArgs e)
        {
            string retval = ",";                                                    //Prepare return value
            long cRaw = Countword(tCols.Text, "\r\n");                              //Count ubound of raw-array
            string[] aryTmp, Raw = aSplit(tCols.Text, "\r\n");                      //Define and assign raw-array
            long[] aryColor = new long[cRaw+1], aryMtch = new long[cRaw+1],         //Define holders of long values
                   aryMinV = new long[cRaw+1], aryMaxV = new long[cRaw+1],
                   aryThr = new long[cRaw+1];
            Color thisCol, findCol;                                                 //Define holders of temp. colors

            for (int a = 0; a <= cRaw; a++)                                         //Loop to parse raw-array
            {
                aryTmp = aSplit(Raw[a], "p");                                       //Split raw-array %a
                aryColor[a] = Convert.ToInt32(aryTmp[0]);                           //Assign target color of %a
                aryMinV[a] = Convert.ToInt32(aryTmp[1]);                            //Assign minimum value of %a
                aryMaxV[a] = Convert.ToInt32(aryTmp[2]);                            //Assign maximum value of %a
                aryThr[a] = Convert.ToInt32(aryTmp[3]);                             //Assign color threshold of %a
            }

            pBox.Load(imgPath); Application.DoEvents();                             //Load picture to picturebox
            Image.FastBitmap img = new Image.FastBitmap(pBox.Image as Bitmap);      //Load picture as FastBitmap
            for (int X = 0; X < 90; X++)                                            //Start X loop
            {
                for (int Y = 0; Y < 65; Y++)                                        //Start Y loop
                {
                    thisCol = img.GetPixel(X, Y);                                   //Read color of current pixel
                    for (int a = 0; a <= cRaw; a++)                                 //Scan for supplied targets
                    {
                        findCol = Long2Col(aryColor[a]);                            //Convert target color from long
                        if (CompareColors(thisCol, findCol, aryThr[a]))             //If colors match, add +1 found
                        {
                            aryMtch[a]++;                                           //Add +1 to found pixels
                        }
                    }
                }
            }
            for (int a = 0; a <= cRaw; a++)                                         //Loop to sum up results
            {
                MessageBox.Show("Total found on col #" + a + ": " + aryMtch[a]);    //  *debug* Display matchcount
                if (aryMtch[a] >= aryMinV[a] && aryMtch[a] <= aryMaxV[a])           //If correct number of matches
                {
                    retval += Convert.ToString(a) + ",";                            //Add target-ID to result list
                }
            }
            MessageBox.Show("Found colors: " + retval);                             //  *debug* Display retval
        }

        public static long Col2Long(Color Col)
        {
            return (Col.R * 256 * 256) + (Col.G * 256) + (Col.B * 1);
        }
        public static Color Long2Col(long Col)
        {
            int retR = Convert.ToInt16((Col / 256 / 256));
            int retG = Convert.ToInt16((Col / 256) - (retR * 256));
            int retB = Convert.ToInt16((Col) - (retR * 256 * 256) - (retG * 256));
            return Color.FromArgb(retR, retG, retB);
        }
        public static string Split(string msg, string delim, int part)
        {
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        public static string[] aSplit(string msg, string delim)
        {
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        public static int Countword(string msg, string delim)
        {
            int ret = 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
            }
            return ret;
        }
        public static string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}