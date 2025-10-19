using System;
using System.Collections.Generic;
using System.Numerics;

namespace Bai4
{
    public class Phanso
    {
        private int tu, mau;

        public Phanso(int t = 0, int m = 1)
        {
            if (m == 0) throw new ArgumentException("Mẫu số không được bằng 0");
            tu = t;
            mau = m;
            fix();
        }

        private void fix()
        {
            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }
            int gcd = (int)BigInteger.GreatestCommonDivisor(tu, mau);
            tu /= gcd;
            mau /= gcd;
        }

        public void Print()
        {
            if (mau == 1)
                Console.WriteLine(tu);
            else
                Console.WriteLine($"{tu}/{mau}");
        }

        public static Phanso operator +(Phanso a, Phanso b)
        {
            return new Phanso(a.tu * b.mau + b.tu * a.mau, a.mau * b.mau);
        }

        public static Phanso operator -(Phanso a, Phanso b)
        {
            return new Phanso(a.tu * b.mau - b.tu * a.mau, a.mau * b.mau);
        }

        public static Phanso operator *(Phanso a, Phanso b)
        {
            return new Phanso(a.tu * b.tu, a.mau * b.mau);
        }

        public static Phanso operator /(Phanso a, Phanso b)
        {
            if (b.tu == 0) throw new DivideByZeroException("Không thể chia cho 0");
            return new Phanso(a.tu * b.mau, a.mau * b.tu);
        }

        public static bool operator >(Phanso a, Phanso b)
        {
            return a.tu * b.mau > b.tu * a.mau;
        }

        public static bool operator <(Phanso a, Phanso b)
        {
            return a.tu * b.mau < b.tu * a.mau;
        }
    }

    public class Handler
    {
        private List<Phanso> data = new();

        public void Nhap()
        {
            Console.Write("Nhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Phân số thứ {i + 1} ---");
                Console.Write("Nhập tử: ");
                int tu = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Nhập mẫu: ");
                int mau = int.Parse(Console.ReadLine() ?? "1");
                data.Add(new Phanso(tu, mau));
            }
        }

        public void FindMax()
        {
            Phanso mx = data[0];
            foreach (var f in data)
            {
                if (f > mx) mx = f;
            }
            Console.Write("Phân số lớn nhất: ");
            mx.Print();
        }

        public void SortAsc()
        {
            data.Sort((a, b) => a < b ? -1 : a > b ? 1 : 0);
        }

        public void Xuat()
        {
            Console.WriteLine("Danh sách phân số:");
            foreach (var x in data)
                x.Print();
        }

        public List<Phanso> GetData() => data;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Handler h = new Handler();
            h.Nhap();

            Console.WriteLine("\n--- Danh sách ban đầu ---");
            h.Xuat();

            h.FindMax();

            Console.WriteLine("\n--- Danh sách sau khi sắp xếp tăng dần ---");
            h.SortAsc();
            h.Xuat();

            // Test thêm hai phân số
            Console.WriteLine("\n--- Thử các phép toán giữa hai phân số ---");
            var data = h.GetData();
            if (data.Count >= 2)
            {
                Phanso a = data[0];
                Phanso b = data[1];

                Console.Write("a + b = "); (a + b).Print();
                Console.Write("a - b = "); (a - b).Print();
                Console.Write("a * b = "); (a * b).Print();
                Console.Write("a / b = "); (a / b).Print();
            }
        }
    }
}
