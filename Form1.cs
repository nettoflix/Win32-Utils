using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
namespace testAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
            //MemoryUtils.SendKeyToWindow("RiotWindowClass", MemoryUtils.VK_A);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IntPtr hWnd = MemoryUtils.FindWindow("Qt5QWindowOwnDCIcon", null);
            //MemoryUtils.ShowWindow(hWnd, 3);
            //MemoryUtils.SetForegroundWindow(hWnd);
            //int result = MemoryUtils.SendKeyToWindow("Qt5QWindowOwnDCIcon", MemoryUtils.VK_Q);
            IntPtr hWnd = MemoryUtils.FindWindow("RiotWindowClass", null);
            MemoryUtils.ShowWindow(hWnd, 3);
            MemoryUtils.SetForegroundWindow(hWnd);

            int result = MemoryUtils.SendKeyToWindow("RiotWindowClass", MemoryUtils.VK_D);
            Thread.Sleep(500);
            MemoryUtils.Input[] kb_inputs = new MemoryUtils.Input[]
            {
                new MemoryUtils.Input
                {
                    type = (int)MemoryUtils.InputType.Keyboard,
                    u = new MemoryUtils.InputUnion
                    {
                        ki = new MemoryUtils.KeyboardInput
                        {
                            wVk = 0, //wVk would be the virtual key code but it is being ignore because the Scancode flag is set
                            wScan = 0x11, // W -- that's the hardware key code
                            dwFlags = (uint)(MemoryUtils.KeyEventF.KeyDown | MemoryUtils.KeyEventF.Scancode),
                            dwExtraInfo = MemoryUtils.GetMessageExtraInfo()
                        }
                    }
                },
                new MemoryUtils.Input
                {
                    type = (int)MemoryUtils.InputType.Keyboard,
                    u = new MemoryUtils.InputUnion
                    {
                        ki = new MemoryUtils.KeyboardInput
                        {
                            wVk = 0,
                            wScan = 0x11, // W
                            dwFlags = (uint)(MemoryUtils.KeyEventF.KeyUp | MemoryUtils.KeyEventF.Scancode),
                            dwExtraInfo = MemoryUtils.GetMessageExtraInfo()
                        }
                    }
                }
            };
                MemoryUtils.SendInput((uint)kb_inputs.Length, kb_inputs, Marshal.SizeOf(typeof(MemoryUtils.Input)));
            //MOUSE 
            MemoryUtils.Input[] ms_inputs = new MemoryUtils.Input[]
            {
                new MemoryUtils.Input
                {
                    type = (int) MemoryUtils.InputType.Mouse,
                    u = new MemoryUtils.InputUnion
                    {
                        mi = new MemoryUtils.MouseInput
                        {
                            dx = 300,
                            dy = 100,
                            dwFlags = (uint)(MemoryUtils.MouseEventF.Move | MemoryUtils.MouseEventF.RightDown),
                            dwExtraInfo = MemoryUtils.GetMessageExtraInfo()
                        }
                    }
                },
                new MemoryUtils.Input
                {
                    type = (int) MemoryUtils.InputType.Mouse,
                    u = new MemoryUtils.InputUnion
                    {
                        mi = new MemoryUtils.MouseInput
                        {
                            dwFlags = (uint)MemoryUtils.MouseEventF.RightUp,
                            dwExtraInfo = MemoryUtils.GetMessageExtraInfo()
                        }
                    }
                }
            };
            MemoryUtils.SendInput((uint)ms_inputs.Length, ms_inputs, Marshal.SizeOf(typeof(MemoryUtils.Input)));
        }



    }
}
