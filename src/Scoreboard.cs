namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Scoreboard
    {
        private List<Person> participants;

        public Scoreboard()
        {
            this.participants = new List<Person>();
        }

        internal int MinInTop5()
        {
            if (this.participants.Count > 0)
            {
                return new List<Person>(this.participants).Last().Score;
            }
            
            return -1;
        }

        /// <exception cref="IOException">An I/O error occurred. </exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="ArgumentOutOfRangeException">The number of characters in the next line of characters is greater than <see cref="F:System.Int32.MaxValue" />.</exception>
        internal void Add(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            this.participants.Add(new Person(name, score));
            this.participants.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));
            this.participants = this.participants.Take(5).ToList();
        }

        internal void Show()
        {
            Console.WriteLine("Scoreboard:");
            foreach (var p in this.participants)
            {
                Console.WriteLine(this.participants.IndexOf(p) + 1 + ". " + p.Name + " --> " + p.Score + " cells");
            }

            Console.WriteLine();
        }

        internal int Count()
        {
            return this.participants.Count();
        }
    }
}
