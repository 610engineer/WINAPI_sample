using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace API_sample
{
    class StructFunc
    {
        //構造体 クラス宣言
        [StructLayout(LayoutKind.Sequential)]
        public class SystemTime
        {
            public Int16 wYear;
            public Int16 wMonth;
            public Int16 wDayOfWeek;
            public Int16 wDay;
            public Int16 wHour;
            public Int16 wMinute;
            public Int16 wSecond;
            public Int16 wMilliseconds;
        }

        [DllImport("kernel32.dll")]
        private extern static void GetSystemTime(SystemTime systemTime);

        [DllImport("kernel32.dll")]
        private extern static void SetSystemTime(SystemTime systemTime);

        public static String GetTime()
        {
            SystemTime st = new SystemTime();
            GetSystemTime(st);
            String current = string.Format("{0:d}-{1:d}-{2:d}", st.wYear, st.wMonth, st.wDay);
            return current;
        }
        public static String SetTime()
        {
            SystemTime st = new SystemTime();
            st.wDay = 1;
            st.wMonth = 1;
            st.wHour = 0;
            st.wMinute = 0;
            st.wSecond = 0;
            st.wYear = 2022;
            SetSystemTime(st);
            String time = string.Format("{0:d}-{1:d}-{2:d}-{3:d}-{4:d}", st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute);
            return time;
        }

        //構造体　構造体宣言
        public struct SystemT
        {
            public Int16 wYear;
            public Int16 wMonth;
            public Int16 wDayOfWeek;
            public Int16 wDay;
            public Int16 wHour;
            public Int16 wMinute;
            public Int16 wSecond;
            public Int16 wMilliseconds;
        }

        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime")]
        private extern static void GetSystemT([Out]IntPtr systemT);


        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime")]
        private extern static void SetSystemT(IntPtr systemT);

        public static String GetT()
        {
            //構造体のメモリを確保
            SystemT st = new SystemT();

            //GetSystemTime()APIに与えるポインタを宣言し、構造体のメモリサイズを与える
            IntPtr stPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(st));

            //GetSystemTを呼び出す
            GetSystemT(stPtr);

            //実態データにアクセスができないので、Marshal.PrtToStructure()でstPtrのデータをstにコピーする
            st = (SystemT)Marshal.PtrToStructure(stPtr, st.GetType());

            String currentT = string.Format("{0:d}-{1:d}-{2:d}", st.wYear, st.wMonth, st.wDay);

            //確保したメモリを解放
            Marshal.FreeCoTaskMem(stPtr);

            return currentT;
        }

        public static String SetT()
        {
            SystemT st = new SystemT();
            st.wDay = 2;
            st.wMonth = 2;
            st.wHour = 1;
            st.wMinute = 1;
            st.wSecond = 1;
            st.wYear = 2023;

            //GetSystemTime()APIに与えるポインタを宣言し、構造体のメモリサイズを与える
            IntPtr stPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(st));

            //st構造体のデータをメモリ確保したstPtrにコピーする
            Marshal.StructureToPtr(st, stPtr, false);

            //設定した構造体をSetSystemTに渡す
            SetSystemT(stPtr);

             String time = string.Format("{0:d}-{1:d}-{2:d}-{3:d}-{4:d}", st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute);

            //確保したメモリを解放
            Marshal.FreeCoTaskMem(stPtr);
            return time;
        }
    }
}
