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
            Console.WriteLine("Book Id" + "\t" + "Book Name" + "\t" + "Book Author" + "\t" + "Issue date" + "\t" + "Expiary Return date");
            while (sr.Peek() > 0)
            {
                
                string line =sr.ReadLine();
                if(line != "")
                {
                    string[] vs = line.Split(',');  
                    int id=int.Parse(vs[0]);
                    if (id == sid)
                    {
                        Console.WriteLine(vs[2] + "\t" + vs[3] + "\t" + vs[4] + "\t" + vs[5]+"\t"+vs[6]);
                        userid = int.Parse(vs[0]);
                        username = vs[1];
                    }

                }
                Console.WriteLine("Student id: {0}", userid);
                Console.WriteLine("Student Name: {0}", username);
            }
            sr.Dispose();
            fileStream.Dispose();
            sr.Close();
            fileStream.Close();



        }
        

    }
}
