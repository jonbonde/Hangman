using System;
using System.Threading;

class Hangman
{
    static void Main()
    {
        string[] messages =
        {
            @" _    _          _   _  _____ __  __          _   _ 
| |  | |   /\   | \ | |/ ____|  \/  |   /\   | \ | |
| |__| |  /  \  |  \| | |  __| \  / |  /  \  |  \| |
|  __  | / /\ \ | . ` | | |_ | |\/| | / /\ \ | . ` |
| |  | |/ ____ \| |\  | |__| | |  | |/ ____ \| |\  |
|_|  |_/_/    \_\_| \_|\_____|_|  |_/_/    \_\_| \_|",
            @"  _____          __  __ ______    ______      ________ _____  
 / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
| |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
| | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
| |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
 \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\",
            @"  ____           _         _                    _ 
 / ___|_ __ __ _| |_ _   _| | ___ _ __ ___ _ __| |
| |  _| '__/ _` | __| | | | |/ _ \ '__/ _ \ '__| |
| |_| | | | (_| | |_| |_| | |  __/ | |  __/ |  |_|
 \____|_|  \__,_|\__|\__,_|_|\___|_|  \___|_|  (_)"
        };
        string[] counting =
        {
            @" __ 
/_ |
 | |
 | |
 | |
 |_|", @" ___  
|__ \ 
   ) |
  / / 
 / /_ 
|____|", @" ____  
|___ \ 
  __) |
 |__ < 
 ___) |
|____/", @" _  _   
| || |
| || |_
|__   _|
   | |
   |_| ", @" _____ 
| ____|
| |__  
|___ \ 
 ___) |
|____/ "
        };

        bool gameOver = false;

        string startWord = "skinke";
        char[] maskStartWord = new string('-', startWord.Length).ToCharArray();
        string guessedCharacter = "";
        string usedCharacter = "";

        int guessingTries = startWord.Length * 2;
        int violations = 0;

        Console.CursorVisible = false;

        for (int i = counting.Length; i > 0; i--)
        {
            Console.WriteLine(messages[0]);
            Console.WriteLine(counting[i - 1]);
            Thread.Sleep(1000);
            Console.Clear();
        }

        while (!gameOver)
        {
            Console.WriteLine("Gjett ordet; {0}", new string (maskStartWord));
            Console.WriteLine("Brukte bokstaver: {0}", usedCharacter);
            Console.WriteLine("Du har {0} forsøk igjen", guessingTries);
            Console.WriteLine();
            Console.Write("Ditt neste gjett?: ");

            guessedCharacter = Console.ReadLine();
            usedCharacter += guessedCharacter[0] + ", ";

            if(guessedCharacter.Length>1)
            {
                if(violations >= 1)
                {
                    guessingTries--;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDu kan bare skrive en bokstav!");
                Console.WriteLine("Du vil miste flere forsøk hvis du fortsetter å jukse");
                Thread.Sleep(3000);
                Console.ResetColor();

                violations++;
            }

            if (startWord.Contains(guessedCharacter[0].ToString()))
            {
                for (int i = 0; i < startWord.Length; i++)
                {
                    if (startWord[i] == guessedCharacter[0])
                    {
                        maskStartWord[i] = guessedCharacter[0];
                    }
                }
            }

            guessingTries--;

            Console.Clear();

            if (guessingTries == 0)
            {
                gameOver = true;
                Console.WriteLine(messages[1]);
            }
            else if (!(new string(maskStartWord).Contains("-")))
            {
                gameOver = true;
                Console.WriteLine(messages[2]);
            }
        }
        Thread.Sleep(10000);
    }
}
