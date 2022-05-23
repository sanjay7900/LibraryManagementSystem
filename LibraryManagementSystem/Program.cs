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
            //string datee = "12-05-2005";
            //string date1 = "12-20-2005";
            //DateTime maindate = DateTime.Parse(datee);
            //DateTime maindate1 = DateTime.Parse(date1);
            //Console.WriteLine(maindate1.Day-maindate.Day);

                
            Console.ReadKey();

        }
    }
}
