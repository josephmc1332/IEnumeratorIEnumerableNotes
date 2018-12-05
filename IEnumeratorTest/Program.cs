using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratorTest
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> Teams = new List<string>();

            Teams.Add("Alabama");
            Teams.Add("Clemson");
            Teams.Add("Notre Dame");
            Teams.Add("LSU");
            Teams.Add("Michigan");
            Teams.Add("Georgia");
            Teams.Add("Oklahoma");

            //IEnumerable<string> ienum = Teams;       
            //Top4(ienum);

            IEnumerator<string> enumerator = Teams.GetEnumerator();
            WithEnumerator(enumerator);
            
        }

        public static void Top4(IEnumerable<string> ien)
        {
            //Will loop through the collection, looking at each element and then calls the Else method when item == Michigan.
            //It will successfully complete this task and then break once we have met our condition.
            foreach (var item in ien)
            {
                if(item == "Michigan")
                {
                    Else(ien);
                    break;
                }
                Console.WriteLine(item);

            }
        }
        public static void Else(IEnumerable<string> ien)
        {
            //Because IEnumberable does not track it's cursor's state, it will loop from the beginning of the collection without knowledge of 
            //where we were when the method was called. This is the main difference between IEnumerator and IEnumerable.
            //This requires much less code and is more aesthetic in terms of syntax, but is not efficient if we need to keep track
            //of where we are within the collection. 

            //Remember: IEnumerable inherits from IEnumerator, with the perk being that we have compressed
            //this iterative process into one method. GetEnumerator();
            foreach (var item in ien)
            {
                Console.WriteLine(item);
            }
        }

        public static void WithEnumerator(IEnumerator<string> enumerator)
        {
            //Note that when we are using IEnumerator, we use a while loop as opposed to a foreach loop
            //We are taing a parameter of type IEnumerator and then iterating until we hit outside the top 4
            //Once we do, the Below4 method is called and then receives the collection at the cursor's current state.
            //IEnumerator requires the use of MoveNext to step, and Current to identify the current positiion.
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
                if (enumerator.Current == "LSU")
                {
                    Below4WithEnumerator(enumerator);
                    //Notice there is no need for a break statement since the Below4 method receives the collection at the current position
                    //break;
                }
            }
        }
        public static void Below4WithEnumerator(IEnumerator<string> enumerator)
        {
            //This method receives the collection with knowledge of the current state and finishes the loop.
            Console.WriteLine("Outside top 4:");
            while (enumerator.MoveNext())
            {
                
                Console.WriteLine(enumerator.Current);
            }
        }
            
        
    }
}
