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
         {

            try
            {
               string[] dirs = Directory.GetDirectories(Path);

               foreach (string d in dirs)
               {
                  DirectoryInfo NowDir = new DirectoryInfo(d);

                  if (DateTime.Now.Subtract(NowDir.LastWriteTime) > TimeSpan.FromMinutes(30))
                     NowDir.Delete(true);
                  else
                     DeleteDir(d);


                  string[] files = Directory.GetFiles(Path);

                  foreach (string s in files)
                  {
                     FileInfo NowFile = new FileInfo(s);

                     if (DateTime.Now.Subtract(NowFile.LastWriteTime) > TimeSpan.FromMinutes(30))
                     {
                        NowFile.Delete();
                     }
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
}
