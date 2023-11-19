namespace Lab3.Model;

public class Token
{
    public string Value { get; set; }
    public int Count { get; set; }
    public TokenType Type { get; set; }
    
    public Token() {}
    public Token(string value)
    {
        this.Value = value;
        Count = 1;
    }
}

public enum TokenType
{
    Number, // – числа (десяткові, з плаваючою крапкою, шістнадцяткові),
    String, // – рядкові та символьні константи,
    Char,  // – рядкові та символьні константи,
    PreprocessorDirective, // – директиви препроцесора,
    Comment, // – коментарі,
    ReservedWord, // – зарезервовані слова,
    Operator, // – оператори,
    Delimiter, // – розділові знаки,
    Identifier  //     – ідентифікатори.
}