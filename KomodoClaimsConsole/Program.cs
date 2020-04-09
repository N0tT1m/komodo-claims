using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimRepository repo = new ClaimRepository();
            ProgramUI program = new ProgramUI(repo);
            program.Run();
            Console.ReadLine();
        }
    }
}
