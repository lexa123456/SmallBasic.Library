﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Primitive[] enemies = new Primitive[10];
            GraphicsWindow.Show();
            var P = Shapes.AddRectangle(100, 20);
            Shapes.Move(P, 0, GraphicsWindow.Height - 20);
            GraphicsWindow.MouseMove += () =>
            {
                Shapes.Move(P, GraphicsWindow.MouseX - 50, GraphicsWindow.Height - 20);
            };
            GraphicsWindow.BrushColor = "yellow";
            var S = Shapes.AddEllipse(20, 20);
            int x = 2;
            int y = 2;
            int stepx = 2;
            int stepy = 2;
            Mouse.HideCursor();
            var F=GraphicsWindow.Width /10;
            for(int f=0; f<10; f++)
            {
               enemies[f]=Shapes.AddRectangle(F,20);
                Shapes.Move(enemies[f], f * (F), 0);
            }

            Timer.Interval = 1;
            Timer.Tick += () =>
            {
                Shapes.Move(S, x, y);
                x += stepx;
                y += stepy;
                if (x >= GraphicsWindow.Width - 20)
                {
                    stepx = -stepx;
                }
                //if (y >= GraphicsWindow.Height - 20)
                //{
                //    stepy = -stepy;
                // }
                if (x < 0)
                {
                    stepx = -stepx;
                }
                if (y < 0)
                {
                    stepy = -stepy;
                }
                var mx = GraphicsWindow.MouseX;
                var my = GraphicsWindow.Height - 40;
                if (((x >= mx - 50) && (x <= mx + 50)) && (y >= my))
                {
                    stepy = -stepy;
                }

                if ((x = Shapes.GetLeft(enemies[S])) && (y==Shapes.GetTop( enemies[P])))
                {


                }


                if (y > GraphicsWindow.Height)
                {
                    // Sound.PlayAndWait(" рингтон Sad trombone - Грустный тромбон.mp3");
                    Microsoft.SmallBasic.Library.Program.End();
                   

                }
                
            };
        }
    }
}
