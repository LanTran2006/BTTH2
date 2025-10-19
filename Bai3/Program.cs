using System;
using System.Collections.Generic;

namespace Bai3
{
    public class Matrix
    {
        private List<List<int>> grid = new();
        public int row, col;

        public Matrix(int n, int m)
        {
            row = n; 
            col = m;
            for (int i = 0; i < n; i++)
            {
                List<int> tmp = new();
                for (int j = 0; j < m; j++)
                    tmp.Add(0);
                grid.Add(tmp);
            }
        }

        private static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        public void Input()
        {
            Console.WriteLine("Nhập các phần tử của ma trận:");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"[{i},{j}]: ");
                    grid[i][j] = int.Parse(Console.ReadLine() ?? "0");
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("\nMa trận:");
            foreach (var r in grid)
            {
                foreach (var c in r)
                    Console.Write($"{c,5}");
                Console.WriteLine();
            }
        }

        public void Find(int x)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i][j] == x)
                    {
                        Console.WriteLine($"Phần tử {x} xuất hiện tại vị trí hàng {i}, cột {j}");
                        return;
                    }
                }
            }
            Console.WriteLine($"Không tìm thấy phần tử {x} trong ma trận.");
        }

        public void DisplayPrimes()
        {
            Console.WriteLine("\nCác phần tử là số nguyên tố:");
            bool found = false;
            foreach (var r in grid)
            {
                foreach (var c in r)
                {
                    if (IsPrime(c))
                    {
                        Console.Write($"{c,5}");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("Không có số nguyên tố nào trong ma trận.");
            else
                Console.WriteLine();
        }

        public void FindRowWithMostPrimes()
        {
            int mx = 0;
            int res = -1;
            for (int i = 0; i < row; i++)
            {
                int cnt = 0;
                for (int j = 0; j < col; j++)
                {
                    if (IsPrime(grid[i][j])) cnt++;
                }
                if (cnt > mx)
                {
                    mx = cnt;
                    res = i;
                }
            }
            if (res == -1)
                Console.WriteLine("Không có hàng nào chứa số nguyên tố.");
            else
                Console.WriteLine($"Hàng có nhiều số nguyên tố nhất là hàng {res} với {mx} số nguyên tố.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Nhập số hàng: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập số cột: ");
            int m = int.Parse(Console.ReadLine() ?? "0");

            Matrix matrix = new Matrix(n, m);

            matrix.Input();
            matrix.Display();

            Console.Write("\nNhập giá trị cần tìm: ");
            int x = int.Parse(Console.ReadLine() ?? "0");
            matrix.Find(x);

            matrix.DisplayPrimes();
            matrix.FindRowWithMostPrimes();

            
        }
    }
}
