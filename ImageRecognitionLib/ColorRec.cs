using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageRecognitionLib
{
    public class ColorRec
    {
        [DllImport("user32.dll")] //取设备场景
        private static extern IntPtr GetDC(IntPtr hwnd); //返回设备场景句柄

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll")] //取指定点颜色
        private static extern int GetPixel(IntPtr hdc, Point p);

        public static Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            Point p = new Point(x, y);
            int pixel = GetPixel(hdc, p);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int) (pixel & 0x000000FF),
                (int) (pixel & 0x0000FF00) >> 8,
                (int) (pixel & 0x00FF0000) >> 16);
            return color;
        }
    }
}