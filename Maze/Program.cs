using System;

namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = 30;
            int height = 25;

            char[,] maze = GenerateMaze(width, height);

            Console.CursorVisible = false;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Console.Write(" " + maze[row, col]);
                }
                Console.WriteLine();
            }
        }

        static Random random = new Random();

        static char[,] GenerateMaze(int width, int height)
        {
            char[,] maze = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    maze[row, col] = '■';
                }
            }

            int startRow = random.Next(height);
            int startCol = random.Next(width);
            GeneratePath(maze, startRow, startCol);

            return maze;
        }

        static void GeneratePath(char[,] maze, int row, int col)
        {
            if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
            {
                return;
            }

            if (maze[col, row] != '■' || maze[col, row] == ' ')
            {
                return;
            }

            maze[row, col] = 'S';

            for (int i = 0; i < 10; i++)
            {
                int direction = random.Next(0, 4);

                switch (direction)
                {
                    case 0:
                        if (maze[row, col + 1] != ' ' && maze[row, col + 1] != 'S')
                        {
                            if (row <= 1 || col <= 1 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
                            {
                                maze[row, col - 1] = ' ';
                                col--;
                            }
                            maze[row, col + 1] = ' ';
                            col++;
                        }
                        break;
                    case 1:
                        if (maze[row, col + 1] != ' ' && maze[row, col + 1] != 'S')
                        {
                            if (row <= 1 || col <= 1 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
                            {
                                maze[row, col + 1] = ' ';
                                col++;
                            }
                            maze[row, col - 1] = ' ';
                            col--;
                        }
                        break;
                    case 2:
                        if (maze[row + 1, col] != ' ' && maze[row, col + 1] != 'S')
                        {
                            if (row <= 1 || col <= 1 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
                            {
                                maze[row - 1, col] = ' ';
                                row--;
                            }
                            maze[row + 1, col] = ' ';
                            row++;
                        }
                        break;
                    case 3:
                        if (maze[row - 1, col] != ' ' && maze[row, col + 1] != 'S')
                        {
                            if (row <= 1 || col <= 1 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
                            {
                                maze[row + 1, col] = ' ';
                                row++;
                            }
                            maze[row - 1, col] = ' ';
                            row--;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}