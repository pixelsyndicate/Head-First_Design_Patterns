using System;
using System.Collections.Generic;

namespace DesignPuzzleChapterOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var queen = new Queen();
            queen.SetWeapon(new KnifeBehavior());

            var king = new King();
            king.SetWeapon(new BowAndArrowBehavior());

            var knight = new Knight();
            knight.SetWeapon(new SwordBehavior());

            var troll = new Troll();
            troll.SetWeapon(new AxeBehavior());

            var characters = new List<Character> { queen, king, knight, troll };

            foreach (var character in characters)
            {
                Console.WriteLine("Once upon a time there was a " + character.GetType().ToString().Replace("DesignPuzzleChapterOne.", "'") + "' who liked to yell");
                character.Fight();
                Console.WriteLine(" ");
            }
           
            Console.WriteLine(" Click ENTER to close ");
            Console.ReadLine();

        }
    }
}
