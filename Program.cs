using System.Text;

Hangman hangman = new Hangman();
hangman.Draw();

class Hangman
{   
    private int Life;
    private string? Word;
    private StringBuilder revWord = new StringBuilder("*");

    public Hangman()
    {
        Life = 5;
        GetWord();
    }
    public void GetWord()//how to do letters only?
    {
        while (true)
        {
            Console.WriteLine("Player A: Please type in a word:");
            string? word = Console.ReadLine();
            if (word != null && word.Length > 0)
            {
                Word = word;
                for(int i=1;i<word.Length;i++)
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
        string head = "  -  \n/   \\\n\\   /\n  -  \n";
        string neck = "  |  \n  |  \n";
        string arm = "-- --\n";
        string body = "  |  \n  |  \n";
        string leg = "/   \\\n";

        string[] lines = {head, neck, arm, body, leg};

        Console.WriteLine(revWord.ToString());

        if (IsRevealed())
        {
            Console.WriteLine("You Win, player B!");
        }
        else if (IsDead())
        {
            Console.WriteLine("Hangman is dead. Game over, player B!");
        }
        else
        {
            for(int i=1; i<=Life; i++)
                {
                    Console.Write(lines[i-1]);
                }
        }
    }
}
