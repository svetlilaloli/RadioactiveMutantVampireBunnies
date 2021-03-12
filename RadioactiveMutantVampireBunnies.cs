using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main()
        {
            string[] lairSize = Console.ReadLine().Split();
            int rows = int.Parse(lairSize[0]);
            int cols = int.Parse(lairSize[1]);
            char[][] lair = new char[rows][];
            string commands;
            int[] playerPosition;
            bool dies = false;
            bool escapes = false;

            // read the initial state of the lair from the console
            for (int i = 0; i < rows; i++)
            {
                lair[i] = Console.ReadLine().ToCharArray();
            }

            commands = Console.ReadLine();
            playerPosition = Start(lair);

            for (int i = 0; i < commands.Length && dies != true && escapes != true; i++)
            {

                lair[playerPosition[0]][playerPosition[1]] = '.';

                switch (commands[i])
                {
                    case 'L':
                        if (playerPosition[1] - 1 >= 0)
                        {
                            playerPosition[1] -= 1;
                            Move(playerPosition, ref lair, ref dies);
                        }
                        else
                        {
                            escapes = true;
                        }
                        break;
                    case 'R':
                        if (playerPosition[1] + 1 < cols)
                        {
                            playerPosition[1] += 1;
                            Move(playerPosition, ref lair, ref dies);
                        }
                        else
                        {
                            escapes = true;
                        }
                        break;
                    case 'U':
                        if (playerPosition[0] - 1 >= 0)
                        {
                            playerPosition[0] -= 1;
                            Move(playerPosition, ref lair, ref dies);
                        }
                        else
                        {
                            escapes = true;
                        }
                        break;
                    case 'D':
                        if (playerPosition[0] + 1 < rows)
                        {
                            playerPosition[0] += 1;
                            Move(playerPosition, ref lair, ref dies);
                        }
                        else
                        {
                            escapes = true;
                        }
                        break;
                    default:
                        break;
                }
                lair = BunniesSpread(lair, ref dies);
            }

            PrintLair(lair);
            if (dies)
            {
                Console.WriteLine("dead: {0} {1}", playerPosition[0], playerPosition[1]);
            }
            else if (escapes)
            {
                Console.WriteLine("won: {0} {1}", playerPosition[0], playerPosition[1]);
            }
        }
        private static int[] Start(char[][] lair)
        {
            int fieldSize = lair.Length;
            int[] startPosition = new int[2];

            for (int i = 0; i < fieldSize; i++)
            {
                if (lair[i].Contains('P'))
                {
                    startPosition[0] = i;
                    startPosition[1] = Array.IndexOf(lair[i], 'P');
                }
            }
            return startPosition;
        }
        private static void Move(int[] position, ref char[][] lair, ref bool dies)
        {
            if (lair[position[0]][position[1]] == '.')
            {
                lair[position[0]][position[1]] = 'P';
            }
            else if (lair[position[0]][position[1]] == 'B')
            {
                dies = true;
            }
        }
        private static char[][] BunniesSpread(char[][] lair, ref bool dies)
        {
            int rows = lair.Length;
            int cols = lair[0].Length;
            char[][] newLair = CreateLair(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // if no bunny has spread at this position, copy the cell from the original lair
                    if (newLair[i][j] == 0)
                    {
                        newLair[i][j] = lair[i][j];
                    }
                    // if there is a bunny in this cell, spread it to  the neighboring cells 
                    if (lair[i][j] == 'B')
                    {
                        if (j < cols - 1)
                        {
                            if (lair[i][j + 1] == '.')
                            {
                                newLair[i][j + 1] = 'B';
                            }
                            else if (lair[i][j + 1] == 'P')
                            {
                                dies = true;
                            }
                        }
                        if (i < rows - 1)
                        {
                            if (lair[i + 1][j] == '.')
                            {
                                newLair[i + 1][j] = 'B';
                            }
                            else if (lair[i + 1][j] == 'P')
                            {
                                dies = true;
                            }
                        }
                        if (j > 0)
                        {
                            if (lair[i][j - 1] == '.')
                            {
                                newLair[i][j - 1] = 'B';
                            }
                            else if (lair[i][j - 1] == 'P')
                            {
                                dies = true;
                            }
                        }
                        if (i > 0)
                        {
                            if (lair[i - 1][j] == '.')
                            {
                                newLair[i - 1][j] = 'B';
                            }
                            else if (lair[i - 1][j] == 'P')
                            {
                                dies = true;
                            }
                        }
                    }
                }
            }
            return newLair;
        }
        private static char[][] CreateLair(int rows, int cols)
        {
            char[][] lair = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                lair[i] = new char[cols];
            }
            return lair;
        }
        private static void PrintLair(char[][] lair)
        {
            int rows = lair.Length;

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", lair[i]));
            }
        }
    }
}
