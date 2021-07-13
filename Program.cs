using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            //var startup = new StartUp();
            //startup.SetUp();
            try
            {
                var manager = new PgmManager();
                manager.Run();
            }
            catch //(Exception e)
                  {
                Console.WriteLine("Something went wrong!!");
                //Console.WriteLine(e.Message);
                }
            
        }

    } 
}
