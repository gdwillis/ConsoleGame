using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;
using System.Threading;

namespace ConsoleRPG
{

    // * Implement the "Falling Rocks" game in the text console. A small dwarf stays at the bottom of the
    // screen and can move left and right (by the arrows keys). A number of rocks of different sizes and
    // forms constantly fall down and you need to avoid a crash.
    // Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density.
    // The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
    // Implement collision detection and scoring system.


    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    

    class Program
    {
        static void Main(string[] args)
        {
              
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowWidth = Constants.WINDOW_WIDTH;
            Console.WindowHeight = Constants.WINDOW_HEIGHT; 
            Console.BufferWidth = Constants.WINDOW_WIDTH;
            Console.BufferHeight = Constants.WINDOW_HEIGHT;

            //
            //  copy the buffer from its original position (0, 0) to (0, 24). MoveBufferArea
            //  does NOT reposition the cursor, which will prevent the cursor from wrapping
            //  to a new line when the buffer's width is filled.

            //return map;
             GameState.Start();
     
        }

    }
}