using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Space_Invaders_XP
{
    class Program
    {
        static void Main(string[] args)
        {
            //only supports builtin sample map
            int[,] map = new int[6, 6];
            Console.Title = "Timeless 1: Domination";
            Console.WriteLine("Timeless Version 1.0.0 - running on T1 Engine 1.0 (Pre-Alpha Release)");
            Console.WriteLine("3/28/18");
            Console.WriteLine("");
            Thread sampleThread1 = new Thread(new ThreadStart(sample_thread));
            sampleThread1.Start();
            int vo = 0;
            int ho = 0;
            int px = 0;
            int py = 0;
            int health = 100;
            int ammo = 250; 
            //Controls (will switch to gamepad in Alpha 2) - uparrow: move fwd, downarrow: move bkwd, leftarrow: strafe left, 
            //rightarrow: strafe right, W: move camera forward, S: move camera back, A: subtract horizontal angle, 
            //D: add horizontal angle, Space: Fire
            while (true)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                System.ConsoleKeyInfo key = Console.ReadKey();
                //Console.Write(key.Key.ToString() + " Pressed at " + Cursor.Position.ToString() + "\n");
                //Console.Write(key.Key.ToString() + " Pressed" + "\n");
                if (key.Key.ToString() == "W"){
                        if (ho == 0) { py++; }
                        if (ho == 45) { px++; py++; }
                        if (ho == 90) { px++; }
                        if (ho == 135) { px++; py--; }
                        if (ho == 180) { py--; }
                        if (ho == 225) { px--; py--; }
                        if (ho == 270) { px--; }
                        if (ho == 315) { px -= 1; py += 1; }
                }
                if (key.Key.ToString() == "S")
                {
                        if (ho == 0) { py--; }
                        if (ho == 45) { px--; py--; }
                        if (ho == 90) { px--; }
                        if (ho == 135) { px--; py++; }
                        if (ho == 180) { py++; }
                        if (ho == 225) { px++; py++; }
                        if (ho == 270) { px++; }
                        if (ho == 315) { px += 1; py -= 1; }
                }
                if (key.Key.ToString() == "A")
                {
                        if (ho == 0) { px--; }
                        if (ho == 45) { px--; py--; }
                        if (ho == 90) { py--; }
                        if (ho == 135) { py--; px++; }
                        if (ho == 180) { px++; }
                        if (ho == 225) { py++; px++; }
                        if (ho == 270) { py++; }
                        if (ho == 315) { py += 1; px -= 1; }
                }
                if (key.Key.ToString() == "D")
                {
                        if (ho == 0) { px++; }
                        if (ho == 45) { px++; py++; }
                        if (ho == 90) { py++; }
                        if (ho == 135) { py++; px--; }
                        if (ho == 180) { px--; }
                        if (ho == 225) { py--; px--; }
                        if (ho == 270) { py--; }
                        if (ho == 315) { py -= 1; px += 1; }
                }
                if (key.Key.ToString() == "LeftArrow")
                {
                    ho -= 45;
                    if (ho < 0) { ho += 360; }
                }
                if (key.Key.ToString() == "RightArrow")
                {
                    ho+=45;
                    if (ho > 359) { ho -= 360; }
                }
                if (key.Key.ToString() == "DownArrow")
                {
                    vo-=45;
                    if (vo < 0) { vo += 360; }
                }
                if (key.Key.ToString() == "UpArrow")
                {
                    vo+=45;
                    if (vo > 359) { vo -= 360; }
                }
                if (key.Key.ToString() == "Spacebar") {
                    if (ammo > 0) { Console.WriteLine("Weapon Fired!"); ammo --;}
                    if (ammo == 0) { Console.WriteLine("Out of ammo!"); }
                }
                //0 = nothing, 1 = wall, 2 = enemy, 3 = ammo
                //if (map[px, py] == 3)
                //{
                //    Console.WriteLine("Ammo Gained!");
                //    ammo++;
                //}
                //Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("Player Position: (" + px.ToString() + "," + py.ToString() + ")");
                Console.WriteLine("Player Health: " + health.ToString());
                Console.WriteLine("Ammo: " + ammo.ToString());
                Console.WriteLine("Horizontal Camera: " + ho.ToString() + " degrees");
                

                //MessageBox.Show(key.Key.ToString() + " Pressed at " + Cursor.Position.ToString(), "Sample Game Event Loop");
            }
        }
        static void sample_thread()
        {
            while (true)
            {
		        //networking thread to control enemies and refresh screen
                //Console.WriteLine("Hello there from T1 Engine! This is a thread."); //free1 sample
                Thread.Sleep(2000);
            }
        }
        static double GetVersion()
        {
            return 1.0;
        }
        static string VersionInfo()
        {
            return "Alpha Release (Pre-1.0)";
        }
    }
}

