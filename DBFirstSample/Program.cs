using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;
                
                Console.WriteLine("All blogs in database order by name: ");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.ReadKey();
            }

        }
    }
}
