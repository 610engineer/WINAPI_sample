using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace API_sample
{
    //文字列DLL
    class StringFunc
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private extern static int GetCurrentDirectory(int nBufferLength,
           [Out] StringBuilder lpPathName);
        public static String SetCurrentDirectory()
        {
            //現在のディレクトリの文字列を取得するためのメモリを確保
            StringBuilder buff = new StringBuilder(255);

            //buffに現在のディレクトリの文字列を代入
            GetCurrentDirectory(buff.Capacity, buff);

            //StringBuilderをStringに変換してディレクトリの文字列を返す
            return buff.ToString();

        }

    }
}
