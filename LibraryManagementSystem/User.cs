using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryManagementSystem
{
    public class User
    {
        public void TrackMyBook(int sid)
        {
            int userid=-1;
            string username="";
            FileStream fileStream=new FileStream(@"D:\aspdotnet\CSharpOPPsRepo\LibraryManagementSystem\issueBooks.txt", FileMode.Open,FileAccess.Read);
            StreamReader sr=new StreamReader(fileStream);
            Console.WriteLine(" All Borrowed Detail of A user");
            Console.WriteLine("Book Id" + "\t" + "Book Name" + "\t" + "Book Author" + "\t" + "Issue date" + "\t" + "Expiary Return date"+"\t"+"fee ");
            Adminstrator adminstrator = new Adminstrator();
            int checkFoundOrNot = 0;
            while (sr.Peek() > 0)
            {
                
                string line =sr.ReadLine();
                if(line != "")
                {
                    string[] vs = line.Split(',');  
                    int id=int.Parse(vs[0]);
                    if (id == sid)
                    {
                        Console.Write(vs[2] + "\t" + vs[3] + "\t\t" + vs[4] + "\t\t" + vs[5]+"\t"+vs[6]);
                        string datee = vs[5];
                        string date1 = vs[6];
                        DateTime maindate = DateTime.Parse(datee);
                        DateTime maindate1 = DateTime.Parse(date1);
                        int ids = int.Parse(vs[2]);
                        int day = maindate1.Day - maindate.Day;
                        int fee = adminstrator.ReturnFee(ids);
                        
                        int totalfee=day*fee;

                        Console.WriteLine("\t\t"+totalfee);
                        Console.WriteLine(fee);
                        userid = int.Parse(vs[0]);
                        username = vs[1];
                        checkFoundOrNot = 1;
                    }

                }

               
            }
            if (checkFoundOrNot == 1)
            {
                Console.WriteLine("data Founded :");

                   Console.WriteLine("Student id: {0}", userid);
                Console.WriteLine("Student Name: {0}", username);
            }
            else
            {
                Console.WriteLine("data  Not Founded !!! :");

            }
            sr.Dispose();
            fileStream.Dispose();
            sr.Close();
            fileStream.Close();



        }
        

    }
}
