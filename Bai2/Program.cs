using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Nhap duong dan thu muc: ");
        string path = Console.ReadLine() ?? "";

        if (!Directory.Exists(path))
        {
            Console.WriteLine("Thu muc khong ton tai!");
            return;
        }

        Console.WriteLine($"\nDirectory of {path}\n");

        string[] dirs = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);

        foreach (string dir in dirs)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            Console.WriteLine($"{d.LastWriteTime:MM/dd/yyyy hh:mm tt}    <DIR>     {d.Name}");
        }

        foreach (string file in files)
        {
            FileInfo f = new FileInfo(file);
            Console.WriteLine($"{f.LastWriteTime:MM/dd/yyyy hh:mm tt}    {f.Length,10}    {f.Name}");
        }

        Console.WriteLine($"\n{files.Length} File(s) {GetTotalSize(files):N0} bytes");
        Console.WriteLine($"{dirs.Length} Dir(s)\n");
    }

    static long GetTotalSize(string[] files)
    {
        long total = 0;
        foreach (string file in files)
        {
            FileInfo f = new FileInfo(file);
            total += f.Length;
        }
        return total;
    }
}
