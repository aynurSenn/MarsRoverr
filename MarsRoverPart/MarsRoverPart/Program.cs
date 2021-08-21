using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverPart
{
    class Program
    {
        class Rover
        {
            public int x { get; set; }
            public int y { get; set; }
            private int max_satir;
            private int max_sutun;

            public string yon;
            string[] yon_character = { "N", "E", "S", "W" };

            public Rover(string location, int max_satir, int max_sutun)
            {
                string[] loc = location.Split();
                this.x = Int32.Parse(loc[0]);
                this.y = Int32.Parse(loc[1]);
                yon = loc[2];
                this.max_satir = max_satir;
                this.max_sutun = max_sutun;
            }


            public void solaDon()
            {
                int index = Array.IndexOf(yon_character, yon);
                if (index > -1 && index < yon_character.Length)
                {

                    yon = yon_character[(index - 1 + yon_character.Length) % yon_character.Length];
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public void sagaDon()
            {
                int index = Array.IndexOf(yon_character, yon);
                if (index > -1 && index < yon_character.Length)
                {

                    yon = yon_character[(index +1) % yon_character.Length];
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            public void Move() { 

              switch (yon)
              {
                  case "N":
                      if (y < max_satir)
                          y = y + 1;
                      break;

                  case "W":
                      if (x > 0)
                          x = x - 1;
                      break;

                  case "S":
                      if (y > 0)
                          y = y - 1;
                      break;

                  case "E":
                      if (x < max_sutun)
                          x = x + 1;
                      break;
                  default :
                      break;

              }
            
            }
            public void Move(string messages) {
                char [] message = messages.ToCharArray();

                for (int s = 0; s < message.Length;s++ )
                {

                    switch (message[s]) { 
                        case 'L':
                            solaDon();
                            break;

                        case 'R':
                            sagaDon();
                            break;
                        case 'M':
                            Move();
                            break;
                        default:
                            break;
                    
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            string str1 = "5 5";
            string str2 = "1 2 N";
            string str3 = "LMLMLMLMM";
            string str4 = "3 3 E";
            string str5 = "MMRMMRMRRM";

            string[] loca = str1.Split();
            int satir = Int32.Parse(loca[0]);
            int sutun = Int32.Parse(loca[1]);

            Rover rover = new Rover(str2, satir, sutun);
            rover.Move(str3);
            Console.WriteLine(rover.x+" "+rover.y+" "+rover.yon);


             rover = new Rover(str4, satir, sutun);
            rover.Move(str5);
            Console.WriteLine(rover.x + " " + rover.y + " " + rover.yon);
            Console.ReadLine();
           
        }
    }
}
