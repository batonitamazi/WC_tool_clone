using System.Text;

namespace CCWC.Helpers;

public static class Helpers
{
    public static void FileReader(string action, string Path)
    {
        try
        {
            switch (action)
            {
                case "-c":
                    Console.WriteLine($"  {ByteCount(Path)} {Path}");
                    break;
                case "-l":
                    Console.WriteLine($"  {LineCount(Path)} {Path}");
                    break;
                case "-w":
                    Console.WriteLine($"  {WordCounter(Path)} {Path}");
                    break;
                case "-m":
                    Console.WriteLine($" {CharacterCounter(Path)} {Path}");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }

    public static void FileReader(string path)
    {
        Console.WriteLine($"  {LineCount(path)} {WordCounter(path)} {ByteCount(path)} {path}");
    }

    public static void FileReaderFromStdin(string action, string input)
    {
        switch (action)
        {
            case "-c":
                long byteCount = Encoding.UTF8.GetByteCount(input);
                Console.WriteLine($"  {byteCount}");
                break;
            case "-l":
                long lineCount = input.Split('\n').Length - 1;
                Console.WriteLine($"  {lineCount}");
                break;
            case "-w":
                long wordCount = input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"  {wordCount}");
                break;
            case "-m":
                int charCount = input.EnumerateRunes().Count();
                Console.WriteLine($"  {charCount}");
                break;
        }
    }

    private static long WordCounter(string path)
    {
        string[] lines = File.ReadAllLines(path);
        long wordsCount = 0;
        foreach (string line in lines)
        {
            wordsCount += WordCounterByLine(line);
        }

        return wordsCount;
    }

    private static long WordCounterByLine(string line)
    {
        char[] delimiters = new char[] { ' ', '\t', '\r', '\n' };
        long words = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        return words;
    }

    private static long ByteCount(string Path)
    {
        return new FileInfo(Path).Length;
    }

    private static long LineCount(string Path)
    {
        return File.ReadLines(Path).Count();
    }

    private static long CharacterCounter(string Path)
    {
        byte[] bytes = File.ReadAllBytes(Path);
        string content = Encoding.UTF8.GetString(bytes);
        int count = content.EnumerateRunes().Count();
        return count;
    }
}