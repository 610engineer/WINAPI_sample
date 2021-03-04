using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace API_sample
{
    public class BasicDll
    {
        //ブザー
        [DllImport("kernel32.dll")]
        private extern static bool Beep(uint dwFreq, uint dwDuration);
        public static void BeepFunc()
        {
            Beep(262, 500);  // ド
            Beep(294, 500);  // レ
            Beep(330, 500);  // ミ
            Beep(349, 500);  // ファ
            Beep(392, 500);  // ソ
            Beep(440, 500);  // ラ
            Beep(494, 500);  // シ
            Beep(523, 500);  // ド
        }

        //ウィンドウのタイトル変更
        [DllImport("user32.dll")]
        private extern static bool SetWindowText(IntPtr hWnd, string lpString);
        public static void SetWindowTitle()
        {
            //起動中のウィンドウハンドルを取得
            IntPtr windowHandle = Process.GetCurrentProcess().MainWindowHandle;

            //ウィンドウタイトルを変更
            SetWindowText(windowHandle, "SetWindowText実行");
        }


        


    }
}
