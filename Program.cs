using System.Text;

Hangman hangman = new Hangman();

do{
    hangman.GetLetter();
    hangman.Draw();
} while (!hangman.IsDead() && !hangman.IsRevealed());

class Hangman
{   
    private int Life;
    private string Word="";
    private StringBuilder revWord = new StringBuilder();
    private List<string> Lines;
    public Hangman()
    {
        Life = 5;
        string Head = "  -  \n/   \\\n\\   /\n  -  \n";
        string Neck = "  |  \n";
        string Arm = "-- --\n";
        string Body = "  |  \n  |  \n";
        string Leg = "/   \\\n";
        Lines = new List<string> {Head, Neck, Arm, Body, Leg};
        GetWord();
    }
    public void GetWord()//how to do letters only?
    {
        while (true)
        {
            Console.WriteLine("Player A: Please type in a word:");
            string word;
            ConsoleKeyInfo cfi;
            StringBuilder wordSB = new StringBuilder();

            while (true)
            {
                cfi = Console.ReadKey(true);
                if (cfi.Key == ConsoleKey.Enter) break;
                else wordSB.Append(cfi.KeyChar);
            }

            word = wordSB.ToString();

            if (word != null && word.Length > 0)
            {
                Word = word;
                for(int i=0;i<word.Length;i++)
                {
                    revWord.Append("*");
                }
                break;
            }
            else
            {
                Console.WriteLine("Your input is invalid.\n");
            }
        }
    }
    public bool IsDead()
    {
        return Life < 1;
    }
    public bool IsRevealed()
    {
        return !revWord.ToString().Contains("*");
    }
    public void Draw()
    {
        Console.WriteLine(revWord.ToString());

        if (IsRevealed()) Console.WriteLine("You Win, player B!");
        else if (IsDead()) Console.WriteLine("Hangman is dead. Game over, player B!");
        else
        {
            for(int i=0; i<Life; i++)
                {
                    Console.Write(Lines[i]);
                }
        }
    }
    public void GetLetter()
    {
        ConsoleKeyInfo cki;
        Char letter = '*';

        Console.WriteLine("Player B: Please input a letter");
        do{
            cki = Console.ReadKey();
            if (cki.Key != ConsoleKey.Enter) 
            {
                letter = cki.KeyChar;
                Console.WriteLine();
            }
        } while (cki.Key == ConsoleKey.Enter);

        int i = 0;
        bool found = false;
        do{
            i = Word.IndexOf(letter, i);
            if (i != -1)
            {
                found = true;
                revWord[i] = letter;
                i++;
            }
            else
            {
                if (!found) Life -= 1;
            }
        } while (i != -1);
    }
}
