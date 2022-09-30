//Console.WriteLine("WordGame");
class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        StreamReader reader = new StreamReader("./Words.txt");
        Dictionary<string, string> wordToDescription = new Dictionary<string, string>();
        List<string> words = new List<string>();

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] splitted = line.Split(',');
            wordToDescription.Add(splitted[0], splitted[1]);
            words.Add(splitted[0]);
        }
        reader.Close();
        string playerWord = words[rnd.Next(words.Count)];
        char[] wordChar = playerWord.ToCharArray();
        
        for(int i = 0; i < playerWord.Length; i++)
        {
            Console.Write("*");
            wordChar[i] = '*';
        }

        string description = wordToDescription[playerWord];
        Console.WriteLine(" - " + description);
        
        while ( wordChar.Count(s => s == '*') != 0 )
        {
            Console.WriteLine("Введите букву");
            char letter = char.Parse(Console.ReadLine());

            for (int i = 0; i < playerWord.Length; i++)
            {
                if (playerWord[i] == letter)
                {
                    wordChar[i] = letter;
                }
            }
            Console.WriteLine(string.Join("", wordChar));
        }
        
        Console.WriteLine("Вы победили");
    }
}