using System;
using System.Runtime.InteropServices;

class Card
{
    public enum suit
    {
        hearts,
        diamonds,
        clubs,
        spades
    }

    private suit _Suit;
    protected int _Value;
    protected bool Flipped;

    public int Value
    {
        get { return _Value; }
        set { _Value = value; }
    }
    private ConsoleColor _Colour;
    private string suits = "♥♦♣♠";
    public char _SuitSymbol { get { return suits[(int)_Suit]; } }
    public string StrCard { get { return "A23456789TJQK"[_Value - 1].ToString() + _SuitSymbol.ToString(); } }

    public Card()
    {
    }

    public Card(suit s, int V)
    {
        _Suit = s;
        _Value = V;
        _Colour = (_Suit == suit.hearts || _Suit == suit.diamonds) ? ConsoleColor.Red : ConsoleColor.Black;
        Flipped = false;
    }

    public void Flip()
    {
        Flipped = !Flipped;
    }

    public virtual void Display(int x, int y, ConsoleColor PackColour)
    {
        if (Flipped)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = _Colour;
            Console.WriteLine(StrCard + "    ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("      ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("      ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("      ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("    " + StrCard);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            // displays reverse of cards
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = PackColour;
            Console.WriteLine("|XXXX|");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("|XXXX|");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("|XXXX|");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("|XXXX|");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("|XXXX|");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}