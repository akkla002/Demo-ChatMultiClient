using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public class TheUser
    {
        private string userName;
        private string passWord = null;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public TheUser(byte[] buffInput)
        {
            int place = 0, tempSize;
            bool havePwd = BitConverter.ToBoolean(buffInput, place);
            place += 2;
            tempSize = BitConverter.ToInt32(buffInput, place);
            place += 4;
            UserName = Encoding.ASCII.GetString(buffInput, place, tempSize);
            if (havePwd)
            {
                place += tempSize;
                tempSize = BitConverter.ToInt32(buffInput, place);
                place += 4;
                UserName = Encoding.ASCII.GetString(buffInput, place, tempSize);
            }
        }

        public TheUser()
        {
            // TODO: Complete member initialization
        }

        public byte[] ToByteWithPwd()
        {
            byte[] data = new byte[1024];
            int place = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(true), 0, data, place, 2);
            place += 2;
            Buffer.BlockCopy(BitConverter.GetBytes(UserName.Length), 0, data, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(UserName), 0, data, place, UserName.Length);
            place += UserName.Length;
            Buffer.BlockCopy(BitConverter.GetBytes(PassWord.Length), 0, data, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(PassWord), 0, data, place, PassWord.Length);
            place += PassWord.Length;
            return data;
        }
        public byte[] ToByte()
        {
            byte[] data = new byte[1024];
            int place = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(false), 0, data, place, 2);
            place += 2;
            Buffer.BlockCopy(BitConverter.GetBytes(UserName.Length), 0, data, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(UserName), 0, data, place, UserName.Length);
            place += UserName.Length;
            return data;
        }
        public bool CheckInDB()
        {
            return false;
        }
    }
}
