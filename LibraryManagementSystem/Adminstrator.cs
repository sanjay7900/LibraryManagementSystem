using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LibraryManagementSystem
{
    public class Adminstrator
    {
        private Boolean CheckAvilablity(int bookid)
        {
            Boolean status=false;
            FileStream fs = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs); 
            string[] data=sr.ReadToEnd().Split('\n');
            sr.Dispose();
            sr.Close();     
            fs.Close();
            FileStream update = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt",FileMode.Open, FileAccess.Write);
            StreamWriter updatedata = new StreamWriter(update);
            foreach(string line in data)
            {
                
                if (line != "") {
                    string[] lines = line.Split(',');
                    int cbid=int.Parse(lines[0]);
                    if (cbid== bookid)
                {
                    int quantity=Convert.ToInt32(lines[lines.Length-1]);
                    if (quantity > 0)
                    {
                        quantity-=1;
                        status=true;
                        updatedata.WriteLine(lines[0]+","+lines[1]+","+lines[2]+","+lines[3]+","+lines[4]+","+quantity);
                    }
                    else
                    {
                        status = false;
                        
                    }
                    

                }
                else
                {
                    updatedata.WriteLine(line); 
                }
                }
            }
            updatedata.Dispose(); 
            update.Dispose();
            updatedata.Close(); 
            update.Close(); 


            return status;
        }
        private void IncreaseAvilablity(int bookid)
        {
           
            FileStream fs = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string[] data = sr.ReadToEnd().Split('\n');
            sr.Dispose();
            sr.Close();
            fs.Close();
            FileStream update = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt", FileMode.Open, FileAccess.Write);
            StreamWriter updatedata = new StreamWriter(update);
            foreach (string line in data)
            {
                if (line != "")
                {
                    string[] lines = line.Split(',');
                    int cbid = int.Parse(lines[0]);
                    if (cbid == bookid)
                    {
                        int quantity = Convert.ToInt32(lines[lines.Length - 2]);
                        int avilable = Convert.ToInt32(lines[lines.Length - 1]);
                        if (avilable < quantity)
                        {
                            avilable += 1;

                            updatedata.WriteLine(lines[0] + "," + lines[1] + "," + lines[2] + "," + lines[3] + "," + lines[4] + "," + avilable);
                        }
                        else
                        {
                            updatedata.WriteLine(lines[0] + "," + lines[1] + "," + lines[2] + "," + lines[3] + "," + lines[4] + "," + avilable);



                        }


                    }
                    else
                    {
                        updatedata.WriteLine(line);
                    }
                }
            }

            updatedata.Dispose();
            update.Dispose();
            updatedata.Close();
            update.Close();
        }
        public void DeleteBook()
        {
            FileStream deleteto = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt", FileMode.Open, FileAccess.Read);
            StreamReader Oldfile = new StreamReader(deleteto);
            FileStream makeNew = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\temp.txt", FileMode.Create, FileAccess.Write);
            StreamWriter Newfile = new StreamWriter(makeNew);
            string[] str = Oldfile.ReadToEnd().Split('\n');   
            Console.WriteLine(str[0]); 
            Console.WriteLine(str[1]);
            Console.WriteLine("\n********************************************\n Please  Enter The Book Id Which Book You Want Delete ...");
            int bookid=Convert.ToInt32(Console.ReadLine());

            for(int i= 0; i < str.Length; i++)
            {
                if (str[i] != "")
                {
                    string[] deleteline = str[i].Split(',');
                    int changeStringIdToInt = int.Parse(deleteline[0]);
                    if (changeStringIdToInt == bookid)
                    {
                        Console.WriteLine(" Book Deleted which is having id {0}", bookid);

                    }
                    else
                    {
                        Newfile.Write(str[i]);
                    }
                }
            }
        // Newfile.WriteLine("yes i from delete");
            Newfile.Dispose();
            Oldfile.Dispose();  
            
            Newfile.Close();
            Oldfile.Close();
            makeNew.Close();    
            Oldfile.Close();
            FileInfo willbidelete = new FileInfo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt");
            willbidelete.Delete();
           
            FileInfo copythis = new FileInfo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\temp.txt");
            FileInfo copyto = new FileInfo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt");
            copythis.CopyTo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt");
            copythis.Delete();  





        }
        public void AddNewBook()
        {

            FileStream Addnew = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt", FileMode.Append, FileAccess.Write);
            StreamWriter Addbook = new StreamWriter(Addnew);

            Console.Write("          Enter The Book Id");
            int id=Convert.ToInt32(Console.ReadLine());

            Console.Write("          Enter The Book name");
            string bookname =Console.ReadLine();

            Console.Write("          Enter The Book Author Name");
            string BookAuthorName = Console.ReadLine();

            Console.Write("          Enter The Book Publish Date Please Enter in this Format dd-mm-yy ok");
            string publishdate = Console.ReadLine();

            Console.Write("          Enter The Book Quantity");
            int Quantity = Convert.ToInt32(Console.ReadLine());
            int avilable = Quantity;

            Addbook.Write(id+","+bookname+","+BookAuthorName+","+publishdate+","+Quantity+","+avilable+"\n");
            Console.WriteLine("Book Added SuccessFully ...");
            Addbook.Dispose();
            Addbook.Close();
            Addnew.Dispose();
            Addnew.Close();


           


        }
        public void ShowAllBooks()
        {
            FileStream ReadAllBook = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\book.txt.txt", FileMode.Open, FileAccess.Read);
            StreamReader Reading = new StreamReader(ReadAllBook);
            Console.WriteLine("Book ID " + "\t|" + "Book Name" + "\t|" + "Book Author" + "\t|" + "Publish Date" + "\t|" + "Quantity"+"\t|"+"Availabile");
            while(Reading.Peek() > 0)
            {
               string line = Reading.ReadLine();  
                
                if(line != "")
                {
                    string[] data=line.Split(',');
                    Console.WriteLine();

                       
                    Console.WriteLine(data[0]+"\t\t "+data[1]+"\t\t "+data[2]+"\t\t "+data[3]+"\t\t "+data[4]+"\t\t "+data[5]);
                }
                else
                {
                    Console.WriteLine();

                }
                


            }
            ReadAllBook.Dispose();
            Reading.Dispose();
            ReadAllBook.Close();
            Reading.Close();

        }
        public void Borrowers()

        {

            FileStream BorrowFile = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt", FileMode.Open, FileAccess.Read);
            StreamReader BorrowDetails = new StreamReader(BorrowFile);
            Console.WriteLine("|Student ID"+"\t|"+"Student Name"+"\t|"+"Book ID"+"\t|"+"Book Name"+"\t|"+"Book Author"+"\t|"+"Issue Date"+"\t|"+"Return Date");
            while (BorrowDetails.Peek() > 0)
            {
                string line = BorrowDetails.ReadLine();
                if (line != "")
                {
                    string[] borrowList = line.Split(',');
                    Console.WriteLine();
                    Console.Write("\t");
                    Console.Write(borrowList[0] + "\t " + borrowList[1] + "\t " + borrowList[2] + "\t\t " + borrowList[3] + " \t " + borrowList[4] + " \t\t " + borrowList[5] + " \t " + borrowList[6]);
                    Console.WriteLine();


                }
                else
                {
                    Console.WriteLine();

                }
                
               



            }
            BorrowFile.Dispose();
            BorrowDetails.Dispose();

            BorrowFile.Close();
            BorrowDetails.Close();
        }
        public void ToIssueBook()
        {
        
            FileStream issuAbook = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt",FileMode.Append,FileAccess.Write);


            StreamWriter issues = new StreamWriter(issuAbook);

        start:
            Console.WriteLine(" First of All You Have TO Ckeck Availablity Present or not\n Please Enter The BooK Id ...");
            int bookid=Convert.ToInt32(Console.ReadLine()); 
            if (CheckAvilablity(bookid))
            {
                Console.WriteLine("Avilable !  contineue...");

            }
            else
            {
                Console.WriteLine("not Available ... ") ;
                goto start; 
            }

            Console.Write("          Enter the Student Id: ");
            int sid = Convert.ToInt32(Console.ReadLine());
            

            
            Console.Write("          Enter the Student Name: ");
            string sname = Console.ReadLine();


            Console.Write("          Enter the Book Id: ");
            int bid = Convert.ToInt32(Console.ReadLine());

            Console.Write("          Enter the  Book Name: ");
            string bname = Console.ReadLine();

            Console.Write("          Enter the Book Author Name Id: ");
            string auname=Console.ReadLine();   

            Console.Write("          Enter the Issue Date: ");
            string isuuedate=Console.ReadLine();


            Console.Write("          Enter the Return Date: ");
            string rdate=Console.ReadLine();    
            if(sid != 0 && sname != "" && bname != "" && bid != 0 && auname != "" && isuuedate != "" && rdate != "")
            {
                issues.WriteLine();
                issues.Write(sid + "," + sname + "," + bid + "," + bname + "," + auname + "," + isuuedate + "," + rdate);
                Console.WriteLine(" Do you Want One more if yes ");
                Console.WriteLine("Enter 1  for yes Enter 0 for Quit");
                int onemore = Convert.ToInt32(Console.ReadLine());
                if(onemore == 1)
                {
                    goto start;
                }
                

            }
            else
            {
                Console.WriteLine("Opps you did't Fill All Data Row ");
                Console.WriteLine(" Please TryAgain...");
                goto start;
            }
            
            issues.Dispose();
            issuAbook.Dispose();
            issues.Close();
            issuAbook.Close();




        }
        public void ReturnBook()
        {
            upper:
            FileStream ReturnAbook = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt", FileMode.Open, FileAccess.Read);
            StreamReader Returnbook = new StreamReader(ReturnAbook);

            FileStream tempReturn = new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\tempissueBooks.txt", FileMode.Create, FileAccess.Write);
            StreamWriter tempwriet = new StreamWriter(tempReturn);
            dofillall:
            Console.Write("Enter Student id who Is Returning the Book ");
            int sid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student name who Is Returning the Book ");
            string sname = Console.ReadLine();
            Console.Write("Enter book id which is about to return ");
            int bid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Book Name which is about to return ");
            string bname = Console.ReadLine();

            while (Returnbook.Peek() > 0)
            {
                string line = Returnbook.ReadLine();
                if (line != "")
                {
                    string[] aboutToreturnList=line.Split(',');
                    if (bid != -1 && bname != "" && sid != -1 && sname != "")
                    {
                        if (Convert.ToInt32(aboutToreturnList[0]) == sid && aboutToreturnList[1] == sname && Convert.ToInt32(aboutToreturnList[2]) == bid && aboutToreturnList[3] == bname)
                        {
                            IncreaseAvilablity(bid);

                            Console.WriteLine("SuccessFull Returning");



                        }
                        else
                        {
                            tempwriet.WriteLine(aboutToreturnList[0]+","+aboutToreturnList[1]+","+aboutToreturnList[2]+","+aboutToreturnList[3]+","+aboutToreturnList[4]+","+aboutToreturnList[5]+","+aboutToreturnList[6]);

                        }
                    }
                    else
                    {
                        Console.WriteLine("oops You didn't fill All options");
                        Console.WriteLine("Try Again");
                        goto dofillall;
                    }
                }

            }
            tempwriet.Dispose();
            tempwriet.Close();
            tempReturn.Close();
            Returnbook.Dispose();   
            Returnbook.Close();
            ReturnAbook.Close();
            

            
            FileInfo removefile = new FileInfo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt");
            removefile.Delete();

            FileInfo copythis = new FileInfo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\tempissueBooks.txt");
            FileInfo copyto = new FileInfo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt");
            copythis.CopyTo(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt");
            
           
            copythis.Delete();
            Console.WriteLine(" Do you have One More For Returning  if yes");
            Console.WriteLine("  Press 1 for Onr More Time ");
            Console.WriteLine(" Press 0 for Quit ");
            int goupper = Convert.ToInt32(Console.ReadLine());
            if (goupper == 1)
            {
                goto upper;
            }


        }




    }
   
}
