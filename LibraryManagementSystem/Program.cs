using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adminstrator adminstrator = new Adminstrator();
            //adminstrator.DeleteBook();
            //adminstrator.AddNewBook();
            //adminstrator.AddNewBook();
              //adminstrator.ShowAllBooks();    
            //adminstrator.Borrowers();
           // adminstrator.ToIssueBook();
           // adminstrator.ReturnBook();  
           Authentication authentication = new Authentication();
            authentication.loginAs();

                
            Console.ReadKey();

        }
    }
}
