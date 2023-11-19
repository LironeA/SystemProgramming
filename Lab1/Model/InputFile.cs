using System.IO;
using Lab1.Core;

namespace Lab1.Model;

public class InputFile
{
    public FileStream FileStream { get; set; }
    
    public List<Token> Tokens { get; set; }
    
    public InputFile(string path)
    {
        FileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        Tokens = new List<Token>();
    }
}