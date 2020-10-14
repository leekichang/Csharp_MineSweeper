using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MineSweeper
{
    class GAME
    {
        public bool End;
        public int LeftMine, LeftNode;
        public MAP AnswerMap,PlayingMap;
        public GAME()
        {
            AnswerMap = new MAP(5, 5, 5);
            PlayingMap = new MAP(5, 5, 5);
            LeftMine = AnswerMap.NumberOfMine;
            LeftNode = AnswerMap.XSize * AnswerMap.YSize - LeftMine;
            End = false;
        }
        public void CreateGame()
        {
            AnswerMap.DigMine();
            AnswerMap.CheckNearBy();
        }
        public void Play()
        {
            while(End == false)
            {
                PlayingMap.Render();
                Console.WriteLine("남은 지뢰 개수: " + LeftMine + "남은 노드 개수" + LeftNode);
                AnswerMap.Render();
                Console.WriteLine("X좌표를 입력하세요.");
                int X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Y좌표를 입력하세요.");
                int Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("명령을 입력하세요.(C는 클릭 F는 깃발, ?는 임시 표기 입니다.)");
                string C = Console.ReadLine();
                Click(X, Y, C);
                if(LeftNode == 0)
                {
                    Console.WriteLine("Congraturations!");
                    return;
                }
                Console.Clear();
            }
        }
        public void Click(int X, int Y, string C)
        {
            if (X < 1 || X > PlayingMap.XSize || Y < 1 || Y > PlayingMap.YSize)
            {
                return;
            }
            else
            {
                switch (C)
                {
                    case ("C"):
                        if (PlayingMap.MAP_[Y][X].Contents == "-" || PlayingMap.MAP_[Y][X].Contents == "?")
                        {
                            if (AnswerMap.MAP_[Y][X].Contents != "*")
                            {
                                PlayingMap.MAP_[Y][X].Contents = Convert.ToString(AnswerMap.MAP_[Y][X].NearMine);
                                LeftNode -= 1;
                                if (PlayingMap.MAP_[Y][X].Contents == "0")
                                {
                                    for (int y = -1; y <= 1; y++)
                                    {
                                        for (int x = -1; x <= 1; x++)
                                        {
                                            if (PlayingMap.MAP_[Y + y][X + x].Contents == "-" || PlayingMap.MAP_[Y][X].Contents == "?")
                                            {
                                                Click(X + x, Y + y, "C");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                End = true;
                            }
                        }
                        break;

                    case ("c"):
                        if (PlayingMap.MAP_[Y][X].Contents == "-" || PlayingMap.MAP_[Y][X].Contents == "?")
                        {
                            if (AnswerMap.MAP_[Y][X].Contents != "*")
                            {
                                PlayingMap.MAP_[Y][X].Contents = Convert.ToString(AnswerMap.MAP_[Y][X].NearMine);
                                LeftNode -= 1;
                                if (PlayingMap.MAP_[Y][X].Contents == "0")
                                {
                                    for (int y = -1; y <= 1; y++)
                                    {
                                        for (int x = -1; x <= 1; x++)
                                        {
                                            if (PlayingMap.MAP_[Y + y][X + x].Contents == "-" || PlayingMap.MAP_[Y][X].Contents == "?")
                                            {
                                                Click(X + x, Y + y, "C");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                End = true;
                            }
                        }
                        break;

                    case ("F"):
                        if (PlayingMap.MAP_[Y][X].Contents == "-")
                        {
                            PlayingMap.MAP_[Y][X].Contents = "F";
                            LeftMine -= 1;
                        }
                        else if (PlayingMap.MAP_[Y][X].Contents == "F")
                        {
                            PlayingMap.MAP_[Y][X].Contents = "-";
                            LeftMine += 1;
                        }
                        break;
                    case ("f"):
                        if (PlayingMap.MAP_[Y][X].Contents == "-")
                        {
                            PlayingMap.MAP_[Y][X].Contents = "F";
                            LeftMine -= 1;
                        }
                        else if (PlayingMap.MAP_[Y][X].Contents == "F")
                        {
                            PlayingMap.MAP_[Y][X].Contents = "-";
                            LeftMine += 1;
                        }
                        break;
                    case ("?"):
                        if (PlayingMap.MAP_[Y][X].Contents == "-" || PlayingMap.MAP_[Y][X].Contents == "F")
                        {
                            PlayingMap.MAP_[Y][X].Contents = "?";
                        }
                        else if(PlayingMap.MAP_[Y][X].Contents == "?")
                        {
                            PlayingMap.MAP_[Y][X].Contents = "-";
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }
    }
}
