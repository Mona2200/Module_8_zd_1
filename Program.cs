using System;
using System.IO;

namespace ZD1
{
   class Program
   {
      static void Main(string[] args)
      {
         string Path = @"C:\Users\Алёна\Desktop\NewDir";
         DeleteDir(Path);
      }

      static void DeleteDir(string Path)
      {
         if (Directory.Exists(Path))
            try
            {
               string[] dirs = Directory.GetDirectories(Path);

               foreach (string d in dirs)
               {
                  DirectoryInfo NowDir = new DirectoryInfo(d);
                  DeleteDir(d);


                  string[] files = Directory.GetFiles(Path);

                  foreach (string s in files)
                  {
                     DirectoryInfo NowFile = new DirectoryInfo(s);

                     if (DateTime.Now.Subtract(NowFile.LastWriteTime) > TimeSpan.FromMinutes(30))
                     {
                        NowDir.Delete(true);
                     }
                  }

                  if (DateTime.Now.Subtract(NowDir.LastWriteTime) > TimeSpan.FromMinutes(30))
                  {
                     NowDir.Delete(true);
                  }
               }

            }

            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
      }
   }
}
