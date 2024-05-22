using System;

class Deck
{
    private Card[] _cards = new Card[54];

    private int _PositionInPack;
    private int _DeckSize;
    public ConsoleColor DeckColour { get; set; }


    public Card[] Cards
    {
        get { return _cards; }
        set { _cards = value; }
    }

    static Random r = new Random();



    public Deck(bool IncludeJokers, ConsoleColor dc)
    {
        // loads deck with cards ordered.
        DeckColour = dc;
        _PositionInPack = 0;
        foreach (Card.suit s in Enum.GetValues(typeof(Card.suit)))
        {
            for (int i = 1; i <= 13; i++)
            {
                Card C = new Card(s, i);
                _cards[_PositionInPack] = C;
                _PositionInPack++;
            }
        }
        // ADD jOKERS if required
        if (IncludeJokers)
        {
            Joker J1 = new Joker();
            Joker J2 = new Joker();
            Cards[52] = J1;
            Cards[53] = J2;
            _DeckSize = 54;
        }
        else
        {
            _DeckSize = 52;
        }

        _PositionInPack = 0; //return to first card position
    }



    public void Shuffle()
    {
        // shuffles deck
        for (int n = _DeckSize - 1; n > 0; n--)
        {
            int k = r.Next(n + 1);
            Card temp = _cards[n];
            _cards[n] = _cards[k];
            _cards[k] = temp;
        }
    }

    public void DisplayAllCards(int xpos, int ypos)
    {

        for (int i = 0; i < _DeckSize; i++)
        {

            if (i % 15 == 0 && i > 12)
            {
                ypos = ypos + 6;
            }
            Cards[i].Display((i % 15) * 2 + xpos, ypos, DeckColour);
            System.Threading.Thread.Sleep(100);
        }
    }

    public Card DrawCard()
    {
        _PositionInPack++;
        return _PositionInPack <= _DeckSize ? _cards[_PositionInPack - 1] : null;
    }

}

