using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();//create List container

            //create data to store in List
            bool aBoolean = true;
            char aCharacter = '$';
            int anInteger = 34567;
            string aString = "hello";

            //use List insert methods
            list.InsertAtFront(aBoolean);
            list.Display();
            list.InsertAtFront(aCharacter);
            list.Display();
            list.InsertAtBack(anInteger);
            list.Display();
            list.InsertAtBack(aString);
            list.Display();

            //remove data from list and display after each removal
            try
            {
                object removedObject = list.RemoveFromFront();
                Console.WriteLine($"{removedObject} removed");
                list.Display();

                removedObject = list.RemoveFromFront();
                Console.WriteLine($"{removedObject} removed");
                list.Display();

                removedObject = list.RemoveFromBack();
                Console.WriteLine($"{removedObject} removed");
                list.Display();

                removedObject = list.RemoveFromBack();
                Console.WriteLine($"removed");
                list.Display();
            }
            catch(EmptyListException emptyListException)
            {
                Console.Error.WriteLine($"\n{emptyListException}");
            }
        }
    }
}
