
using System.Runtime.InteropServices;

namespace ShuDu
{
    internal class MouseOperations
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint data, IntPtr dwExtraInfo);

        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        internal static void DoMouseClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, IntPtr.Zero);
        }
    }
}