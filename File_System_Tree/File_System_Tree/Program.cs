using System;

namespace FileSystemTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemTree<FileMetadata> fs = new FileSystemTree<FileMetadata>();

            fs.Add("root/docs", new FileMetadata("docs", true));
            fs.Add("root/docs/resume.pdf", new FileMetadata("resume.pdf", false));
            fs.Add("root/photos", new FileMetadata("photos", true));
            fs.Add("root/photos/vacation.jpg", new FileMetadata("vacation.jpg", false));
            fs.Add("root/photos/family.jpg", new FileMetadata("family.jpg", false));

            Console.WriteLine("All files: " + fs.CountFiles());
            fs.PrintTree();

            Console.WriteLine("\nFull path of vacation.jpg:");
            Console.WriteLine(fs.GetFullPath(new FileMetadata("vacation.jpg", false)));
        }
    }
}