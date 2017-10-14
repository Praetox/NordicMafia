using System;
using System.Collections.Generic;
using System.Text;

namespace NM_UHashFetcher
{
    #region Crc16
    public class Crc16
    {
        const ushort polynomial = 0xA001;
        ushort[] table = new ushort[256];

        public ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return new byte[] { (byte)(crc >> 8), (byte)(crc & 0x00ff) };
        }

        public Crc16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; i++)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; j++)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }
    #endregion
    #region Crc32
    public class Crc32
    {
        uint[] table;

        public uint ComputeChecksum(byte[] bytes)
        {
            uint crc = 0xffffffff;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte index = (byte)(((crc) & 0xff) ^ bytes[i]);
                crc = (uint)((crc >> 8) ^ table[index]);
            }
            return ~crc;
        }

        public string S(string val)
        {
            byte[] bytes = Str2Byte(val);
            string ret = ComputeChecksum(bytes).ToString("x");
            while (ret.Length < 8) ret = "0" + ret;
            return ret;
        }

        public Crc32()
        {
            uint poly = 0xedb88320;
            table = new uint[256];
            uint temp = 0;
            for (uint i = 0; i < table.Length; i++)
            {
                temp = i;
                for (int j = 8; j > 0; j--)
                {
                    if ((temp & 1) == 1)
                    {
                        temp = (uint)((temp >> 1) ^ poly);
                    }
                    else
                    {
                        temp >>= 1;
                    }
                }
                table[i] = temp;
            }
        }

        public static byte[] Str2Byte(string Value)
        {
            byte[] ret = new byte[Value.Length];
            for (int a = 0; a < Value.Length; a++) ret[a] = (byte)Value[a];
            return ret;
        }
    }
    #endregion
}
