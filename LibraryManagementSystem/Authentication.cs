using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryManagementSystem
{
    public class Authentication
    {
        public void loginAs()
        {
            loginmenu:
            Console.WriteLine("*********************************************************************");
            Console.WriteLine(" Lonin As Librarian Press 1                      *");
            Console.WriteLine(" Login As Student Press   2                     *            ");

            Console.WriteLine(" Exit 3                      *");

            Console.WriteLine("*********************************************************************");
            int user=Convert.ToInt32(Console.ReadLine());
            switch (user)
            {
                case 1:
                    Console.WriteLine("Enter User Id: ");
                    int userid=Convert.ToInt32(Console.ReadLine());

                    if (auth(userid, "admin"))
                    {
                        mainmenu:
                        mainMenu();
                        Adminstrator adminstrator = new Adminstrator();
                        int choise = Convert.ToInt32(Console.ReadLine());
                        switch (choise)
                        {
                            case 1:
                                adminstrator.ShowAllBooks();
                                goto mainmenu;
                           case 2:
                                adminstrator.Borrowers();
                                goto mainmenu;
                            case 3:
                                adminstrator.AddNewBook();
                                goto mainmenu;
                            case 4:
                                adminstrator.DeleteBook();
                                goto mainmenu;
                            case 5:
                                adminstrator.ToIssueBook();
                                goto mainmenu;
                            case 6:
                                adminstrator.ReturnBook();
                                goto mainmenu;
                            case 7:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid Choise ");
                                goto mainmenu;





                            
                        }
                    }
                    else
                    {
                        Console.WriteLine(" this id Doesn't Exists ...");
                        Console.WriteLine(" tyr Again...");
                        goto loginmenu;

                    }
                    break;

                case 2:
                    User user1 = new User();
                    Console.WriteLine("Enter User Id: ");
                    int userid2 = Convert.ToInt32(Console.ReadLine());

                    if (auth(userid2, "student"))
                    {
                        stumenu:
                        Console.WriteLine("*****************************");
                        Console.WriteLine("To See Borrow Details Press 1: ");
                        Console.WriteLine("To Exit Press               2: ");
                        int choise2 = Convert.ToInt32(Console.ReadLine());
                        switch (choise2)
                        {
                            case 1:
                                user1.TrackMyBook(userid2);
                                goto stumenu;
                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine(" Invailed choise");
                                Console.WriteLine("try Again");
                                goto stumenu;


                        }


                    }

                        break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" bad Input ");
                    Console.WriteLine("try Again");
                    goto loginmenu;

            }
                        

        }
        public void mainMenu()
        {
            Console.WriteLine("***************** Main Menu *****************");
            Console.WriteLine("To Show All Books Press-          : 1");
            Console.WriteLine("To Show All Borrowed  Books Press-: 2");
            Console.WriteLine("To Add New  Books Press-          : 3");
            Console.WriteLine("To Delete A  Books Press -        : 4");
           
            Console.WriteLine("To Issue A Books Press -          : 5");
            Console.WriteLine("To Return A Books Press -         : 6");
            Console.WriteLine("for Logout 7");
            Console.WriteLine("*****************           *****************");

        }
        public bool auth(int userid,string type)
        {
            FileStream fileStream=new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\auth.txt", FileMode.Open,FileAccess.Read);
            StreamReader CheckUser=new StreamReader(fileStream);
            bool status = false;

            while (CheckUser.Peek() > 0)
            {
                string line=CheckUser.ReadLine();
                if (line != "")
                {
                    string[] mydata=line.Split(',');
                    if (int.Parse(mydata[0]) == userid && type == mydata[2])
                    {
                        status= true;
                        break;
                    }
                    
                }
            }
            
            
            
            return true;
        }
    }
}
