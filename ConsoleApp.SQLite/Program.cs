using System;

namespace ConsoleApp.SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //db.Blogs.Add(new Blog { UrlCopy = "http://blogs.msdn.com/adonet_Copy" });
                //var count = db.SaveChanges();
                //Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.UrlCopy);
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
