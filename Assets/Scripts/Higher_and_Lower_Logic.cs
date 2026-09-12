using UnityEngine;

public class Higher_and_Lower_Logic : MonoBehaviour
{
    public GameObject[] firstCard = new GameObject[52];
    public GameObject[] secondCard = new GameObject[52];
    public GameObject table;
    public int firstNumber;
    public int secondNumber;
    public bool firstCardDiamonds = false;
    public bool secondCardDiamonds = false;
    public bool firstCardClubs = false;
    public bool secondCardClubs = false;
    public bool firstCardSpades = false;
    public bool secondCardSpades = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        table = GameObject.Find("Table");
        firstCard[0] = GameObject.Find("1_Of_Hearts_0");
        firstCard[1] = GameObject.Find("2_Of_Hearts_0");
        firstCard[2] = GameObject.Find("3_Of_Hearts_0");
        firstCard[3] = GameObject.Find("4_Of_Hearts_0");
        firstCard[4] = GameObject.Find("5_Of_Hearts_0");
        firstCard[5] = GameObject.Find("6_Of_Hearts_0");
        firstCard[6] = GameObject.Find("7_Of_Hearts_0");
        firstCard[7] = GameObject.Find("8_Of_Hearts_0");
        firstCard[8] = GameObject.Find("9_Of_Hearts_0");
        firstCard[9] = GameObject.Find("10_Of_Hearts_0");
        firstCard[10] = GameObject.Find("Jack_Of_Hearts_0");
        firstCard[11] = GameObject.Find("Queen_Of_Hearts_0");
        firstCard[12] = GameObject.Find("King_Of_Hearts_0");
        firstCard[13] = GameObject.Find("1_Of_Clubs_0");
        firstCard[14] = GameObject.Find("2_Of_Clubs_0");
        firstCard[15] = GameObject.Find("3_Of_Clubs_0");
        firstCard[16] = GameObject.Find("4_Of_Clubs_0");
        firstCard[17] = GameObject.Find("5_Of_Clubs_0");
        firstCard[18] = GameObject.Find("6_Of_Clubs_0");
        firstCard[19] = GameObject.Find("7_Of_Clubs_0");
        firstCard[20] = GameObject.Find("8_Of_Clubs_0");
        firstCard[21] = GameObject.Find("9_Of_Clubs_0");
        firstCard[22] = GameObject.Find("10_Of_Clubs_0");
        firstCard[23] = GameObject.Find("Jack_Of_Clubs_0");
        firstCard[24] = GameObject.Find("Queen_Of_Clubs_0");
        firstCard[25] = GameObject.Find("King_Of_Clubs_0");
        firstCard[26] = GameObject.Find("1_Of_Spades_0");
        firstCard[27] = GameObject.Find("2_Of_Spades_0");
        firstCard[28] = GameObject.Find("3_Of_Spades_0");
        firstCard[29] = GameObject.Find("4_Of_Spades_0");
        firstCard[30] = GameObject.Find("5_Of_Spades_0");
        firstCard[31] = GameObject.Find("6_Of_Spades_0");
        firstCard[32] = GameObject.Find("7_Of_Spades_0");
        firstCard[33] = GameObject.Find("8_Of_Spades_0");
        firstCard[34] = GameObject.Find("9_Of_Spades_0");
        firstCard[35] = GameObject.Find("10_Of_Spades_0");
        firstCard[36] = GameObject.Find("Jack_Of_Spades_0");
        firstCard[37] = GameObject.Find("Queen_Of_Spades_0");
        firstCard[38] = GameObject.Find("King_Of_Spades_0");
        firstCard[39] = GameObject.Find("1_Of_Monds_0");
        firstCard[40] = GameObject.Find("2_Of_Monds_0");
        firstCard[41] = GameObject.Find("3_Of_Monds_0");
        firstCard[42] = GameObject.Find("4_Of_Monds_0");
        firstCard[43] = GameObject.Find("5_Of_Monds_0");
        firstCard[44] = GameObject.Find("6_Of_Monds_0");
        firstCard[45] = GameObject.Find("7_Of_Monds_0");
        firstCard[46] = GameObject.Find("8_Of_Monds_0");
        firstCard[47] = GameObject.Find("9_Of_Monds_0");
        firstCard[48] = GameObject.Find("10_Of_Monds_0");
        firstCard[49] = GameObject.Find("Jack_Of_Monds_0");
        firstCard[50] = GameObject.Find("Queen_Of_Monds_0");
        firstCard[51] = GameObject.Find("King_Of_Monds_0");
        secondCard[0] = GameObject.Find("1_Of_Hearts_1");
        secondCard[1] = GameObject.Find("2_Of_Hearts_1");
        secondCard[2] = GameObject.Find("3_Of_Hearts_1");
        secondCard[3] = GameObject.Find("4_Of_Hearts_1");
        secondCard[4] = GameObject.Find("5_Of_Hearts_1");
        secondCard[5] = GameObject.Find("6_Of_Hearts_1");
        secondCard[6] = GameObject.Find("7_Of_Hearts_1");
        secondCard[7] = GameObject.Find("8_Of_Hearts_1");
        secondCard[8] = GameObject.Find("9_Of_Hearts_1");
        secondCard[9] = GameObject.Find("10_Of_Hearts_1");
        secondCard[10] = GameObject.Find("Jack_Of_Hearts_1");
        secondCard[11] = GameObject.Find("Queen_Of_Hearts_1");
        secondCard[12] = GameObject.Find("King_Of_Hearts_1");
        secondCard[13] = GameObject.Find("1_Of_Clubs_1");
        secondCard[14] = GameObject.Find("2_Of_Clubs_1");
        secondCard[15] = GameObject.Find("3_Of_Clubs_1");
        secondCard[16] = GameObject.Find("4_Of_Clubs_1");
        secondCard[17] = GameObject.Find("5_Of_Clubs_1");
        secondCard[18] = GameObject.Find("6_Of_Clubs_1");
        secondCard[19] = GameObject.Find("7_Of_Clubs_1");
        secondCard[20] = GameObject.Find("8_Of_Clubs_1");
        secondCard[21] = GameObject.Find("9_Of_Clubs_1");
        secondCard[22] = GameObject.Find("10_Of_Clubs_1");
        secondCard[23] = GameObject.Find("Jack_Of_Clubs_1");
        secondCard[24] = GameObject.Find("Queen_Of_Clubs_1");
        secondCard[25] = GameObject.Find("King_Of_Clubs_1");
        secondCard[26] = GameObject.Find("1_Of_Spades_1");
        secondCard[27] = GameObject.Find("2_Of_Spades_1");
        secondCard[28] = GameObject.Find("3_Of_Spades_1");
        secondCard[29] = GameObject.Find("4_Of_Spades_1");
        secondCard[30] = GameObject.Find("5_Of_Spades_1");
        secondCard[31] = GameObject.Find("6_Of_Spades_1");
        secondCard[32] = GameObject.Find("7_Of_Spades_1");
        secondCard[33] = GameObject.Find("8_Of_Spades_1");
        secondCard[34] = GameObject.Find("9_Of_Spades_1");
        secondCard[35] = GameObject.Find("10_Of_Spades_1");
        secondCard[36] = GameObject.Find("Jack_Of_Spades_1");
        secondCard[37] = GameObject.Find("Queen_Of_Spades_1");
        secondCard[38] = GameObject.Find("King_Of_Spades_1");
        secondCard[39] = GameObject.Find("1_Of_Monds_1");
        secondCard[40] = GameObject.Find("2_Of_Monds_1");
        secondCard[41] = GameObject.Find("3_Of_Monds_1");
        secondCard[42] = GameObject.Find("4_Of_Monds_1");
        secondCard[43] = GameObject.Find("5_Of_Monds_1");
        secondCard[44] = GameObject.Find("6_Of_Monds_1");
        secondCard[45] = GameObject.Find("7_Of_Monds_1");
        secondCard[46] = GameObject.Find("8_Of_Monds_1");
        secondCard[47] = GameObject.Find("9_Of_Monds_1");
        secondCard[48] = GameObject.Find("10_Of_Monds_1");
        secondCard[49] = GameObject.Find("Jack_Of_Monds_1");
        secondCard[50] = GameObject.Find("Queen_Of_Monds_1");
        secondCard[51] = GameObject.Find("King_Of_Monds_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject RandomCard()
    {
        firstCardDiamonds = false;
        firstCardClubs = false;
        firstCardSpades = false;
        secondCardDiamonds = false;
        secondCardClubs = false;
        secondCardSpades = false;
        int randomIndex = 0;
        randomIndex = Random.Range(0, firstCard.Length);
        Debug.Log("Random Index: " + randomIndex);
        firstNumber = randomIndex + 1;
        return firstCard[randomIndex];
    }
    public int GetFirstNumber()
    {
        if (firstNumber > 39)
        {
            firstNumber -= 39;
            firstCardDiamonds = true;
            return firstNumber;
        }
        else if (firstNumber > 26)
        {
            firstNumber -= 26;
            firstCardSpades = true;
            return firstNumber;
        }
        else if (firstNumber > 13)
        {
            firstNumber -= 13;
            firstCardClubs = true;
            return firstNumber;
        }
        else
        {
            return firstNumber;
        }
    }
    public GameObject RandomCard2()
    {
        int randomIndex2 = 0;
        randomIndex2 = Random.Range(0, secondCard.Length);
        Debug.Log("Random Index: " + randomIndex2);
        secondNumber = randomIndex2 + 1;
        return secondCard[randomIndex2];
    }
    public int GetSecondNumber()
    {
        if (secondNumber > 39)
        {
            secondNumber -= 39;
            secondCardDiamonds = true;
            return secondNumber;
        }
        else if (secondNumber > 26)
        {
            secondNumber -= 26;
            secondCardSpades = true;
            return secondNumber;
        }
        else if (secondNumber > 13)
        {
            secondNumber -= 13;
            secondCardClubs = true;
            return secondNumber;
        }
        else
        {
            return secondNumber;
        }
    }
    public bool GetFirstCardDiamonds()
    {
        return firstCardDiamonds;
    }
    public bool GetSecondCardDiamonds()
    {
        return secondCardDiamonds;
    }
    public bool GetFirstCardClubs()
    {
        return firstCardClubs;
    }
    public bool GetSecondCardClubs()
    {
        return secondCardClubs;
    }
    public bool GetFirstCardSpades()
    {
        return firstCardSpades;
    }
    public bool GetSecondCardSpades()
    {
        return secondCardSpades;
    }

    public int CompareCards()
    {
        if (firstNumber > secondNumber)
        {
            return 1;
        }
        else if (firstNumber == secondNumber)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}
