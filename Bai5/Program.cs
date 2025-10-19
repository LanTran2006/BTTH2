using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai5
{
    class Estate
    {
        public string address { get; set; }
        public float area { get; set; }
        public float price { get; set; }

        public virtual void nhap()
        {
            Console.Write("Địa điểm: ");
            address = Console.ReadLine() ?? "";

            Console.Write("Giá bán (VND): ");
            price = float.Parse(Console.ReadLine() ?? "0");

            Console.Write("Diện tích (m2): ");
            area = float.Parse(Console.ReadLine() ?? "0");
        }

        public virtual void xuat()
        {
            Console.WriteLine($"Địa điểm: {address}, Giá: {price} VND, Diện tích: {area} m2");
        }
    }

    class Townhouse : Estate
    {
        public int year { get; set; }
        public int floorNums { get; set; }

        public override void nhap()
        {
            base.nhap();
            Console.Write("Năm xây dựng: ");
            year = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Số tầng: ");
            floorNums = int.Parse(Console.ReadLine() ?? "0");
        }

        public override void xuat()
        {
            Console.WriteLine($"[Nhà phố] Địa điểm: {address}, Giá: {price} VND, Diện tích: {area} m2, Năm XD: {year}, Số tầng: {floorNums}");
        }
    }

    class Apartment : Estate
    {
        public int floor { get; set; }

        public override void nhap()
        {
            base.nhap();
            Console.Write("Tầng: ");
            floor = int.Parse(Console.ReadLine() ?? "0");
        }

        public override void xuat()
        {
            Console.WriteLine($"[Chung cư] Địa điểm: {address}, Giá: {price} VND, Diện tích: {area} m2, Tầng: {floor}");
        }
    }

    class Management
    {
        private List<Estate> data = new();

        public void nhap()
        {
            Console.Write("Nhập số lượng bất động sản: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nNhập loại (0: Khu đất, 1: Nhà phố, 2: Chung cư): ");
                int type = int.Parse(Console.ReadLine() ?? "0");

                Estate tmp;
                if (type == 1)
                    tmp = new Townhouse();
                else if (type == 2)
                    tmp = new Apartment();
                else
                    tmp = new Estate();

                tmp.nhap();
                data.Add(tmp);
            }
        }

        public void xuat()
        {
            Console.WriteLine("\n--- DANH SÁCH BẤT ĐỘNG SẢN ---");
            foreach (Estate x in data)
                x.xuat();
        }

        public void totalPrice()
        {
            float apartment = 0, townhouse = 0, estate = 0;

            foreach (Estate x in data)
            {
                if (x is Apartment) apartment += x.price;
                else if (x is Townhouse) townhouse += x.price;
                else estate += x.price;
            }

            Console.WriteLine("\n--- TỔNG GIÁ BÁN ---");
            Console.WriteLine($"Khu đất: {estate} VND");
            Console.WriteLine($"Nhà phố: {townhouse} VND");
            Console.WriteLine($"Chung cư: {apartment} VND");
        }

        public void xuatDanhSachDieuKien()
        {
            Console.WriteLine("\n--- DANH SÁCH THEO ĐIỀU KIỆN ---");

            foreach (Estate x in data)
            {
                if ((x is Estate && !(x is Townhouse) && !(x is Apartment) && x.area > 100) ||
                    (x is Townhouse t && t.area > 60 && t.year >= 2019))
                {
                    x.xuat();
                }
            }
        }

        public void search()
        {
            Console.Write("\nNhập địa điểm cần tìm: ");
            string s = Console.ReadLine() ?? "";

            Console.Write("Nhập giá tối đa (VND): ");
            float price = float.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhập diện tích tối thiểu (m2): ");
            float area = float.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("\n--- KẾT QUẢ TÌM KIẾM ---");

            foreach (Estate x in data)
            {
                if ((x is Townhouse || x is Apartment) &&
                    x.price <= price &&
                    x.area >= area &&
                    x.address.Contains(s, StringComparison.OrdinalIgnoreCase))
                {
                    x.xuat();
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Management mgmt = new Management();

            while (true)
            {
                Console.WriteLine("\n========= MENU =========");
                Console.WriteLine("1. Nhập danh sách");
                Console.WriteLine("2. Xuất danh sách");
                Console.WriteLine("3. Tính tổng giá bán từng loại");
                Console.WriteLine("4. Xuất danh sách theo điều kiện");
                Console.WriteLine("5. Tìm kiếm Nhà phố / Chung cư");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");

                int choice = int.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        mgmt.nhap();
                        break;
                    case 2:
                        mgmt.xuat();
                        break;
                    case 3:
                        mgmt.totalPrice();
                        break;
                    case 4:
                        mgmt.xuatDanhSachDieuKien();
                        break;
                    case 5:
                        mgmt.search();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}
