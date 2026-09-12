using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class Character_Interaction : MonoBehaviour
{
    public GameObject interactText;
    public GameObject higherText;
    public GameObject lowerText;
    public GameObject winText;
    public GameObject drawText;
    public GameObject loseText;
    public GameObject enemyHand;
    public GameObject rockHand;
    public GameObject paperHand;
    public GameObject scissorsHand;
    public GameObject rRock;
    public GameObject qPaper;
    public GameObject fScissors;
    public GameObject rRockEnemy;
    public GameObject qPaperEnemy;
    public GameObject fScissorsEnemy;
    public TextMeshProUGUI rRockTmp;
    public TextMeshProUGUI qPaperTmp;
    public TextMeshProUGUI fScissorsTmp;
    public TextMeshProUGUI winTmp;
    public TextMeshProUGUI drawTmp;
    public TextMeshProUGUI loseTmp;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI higherTmp;
    public TextMeshProUGUI lowerTmp;
    public GameObject table;
    public GameObject table2;
    public Character_Movement characterMovement;
    public GameObject h_L_Interact;
    public GameObject RPS_RR_Interact;
    public RPS_RR_Logic RPS_RR_Logic;
    public Higher_and_Lower_Logic higherAndLowerLogic;
    public bool RPS_RR_Interactable = false;
    public bool h_L_Interactable = false;
    public bool nextStepH_L = false;
    public bool nextStepRPS_RR = false;
    public int firstNumber;
    public int secondNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rockHand = GameObject.Find("Hand_Rock_0");
        paperHand = GameObject.Find("Hand_paper_0");
        scissorsHand = GameObject.Find("Hand_scissors_0");
        rRock = GameObject.Find("R - Rock");
        qPaper = GameObject.Find("Q - Paper");
        fScissors = GameObject.Find("F - Scissors");
        rRockEnemy = GameObject.Find("Hand_Rock_1");
        qPaperEnemy = GameObject.Find("Hand_paper_1");
        fScissorsEnemy = GameObject.Find("Hand_Scissors_1");
        rRockTmp = rRock.GetComponent<TextMeshProUGUI>();
        qPaperTmp = qPaper.GetComponent<TextMeshProUGUI>();
        fScissorsTmp = fScissors.GetComponent<TextMeshProUGUI>();
        winText = GameObject.Find("Win Text");
        winTmp = winText.GetComponent<TextMeshProUGUI>();
        drawText = GameObject.Find("Draw Text");
        drawTmp = drawText.GetComponent<TextMeshProUGUI>();
        loseText = GameObject.Find("Lose Text");
        loseTmp = loseText.GetComponent<TextMeshProUGUI>();
        h_L_Interact = GameObject.Find("H_L Interact");
        higherAndLowerLogic = h_L_Interact.GetComponent<Higher_and_Lower_Logic>();
        interactText = GameObject.Find("Interact Text");
        tmp = interactText.GetComponent<TextMeshProUGUI>();
        higherText = GameObject.Find("Q - Higher");
        higherTmp = higherText.GetComponent<TextMeshProUGUI>();
        lowerText = GameObject.Find("R - Lower");
        lowerTmp = lowerText.GetComponent<TextMeshProUGUI>();
        RPS_RR_Interact = GameObject.Find("RPS_RR_Interact");
        RPS_RR_Logic = RPS_RR_Interact.GetComponent<RPS_RR_Logic>();
        table = GameObject.Find("Table");
        table2 = GameObject.Find("Table2");
        characterMovement = GetComponent<Character_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "H_L Interact")
        {
            tmp.enabled = true;
            h_L_Interactable = true;
        }
        if (collision.gameObject.tag == "RPS_RR Interact")
        {
            tmp.enabled = true;
            RPS_RR_Interactable = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "H_L Interact")
        {
            tmp.enabled = false;
            h_L_Interactable = false;
        }
        if (collision.gameObject.tag == "RPS_RR Interact")
        {
            tmp.enabled = false;
            RPS_RR_Interactable = false;
        }
    }
    void OnInteract(InputValue value)
    {
        if (h_L_Interactable)
        {
            firstNumber = 0;
            secondNumber = 0;
            table.GetComponent<SpriteRenderer>().enabled = true;
            higherTmp.enabled = true;
            lowerTmp.enabled = true;
            tmp.enabled = false;
            characterMovement.canMove = false;
            higherAndLowerLogic.RandomCard().GetComponent<SpriteRenderer>().enabled = true;
            firstNumber = higherAndLowerLogic.GetFirstNumber();
            nextStepH_L = true;
        }
        if (RPS_RR_Interactable)
        {
            tmp.GetComponent<TextMeshProUGUI>().enabled = false;
            rRockTmp.enabled = true;
            qPaperTmp.enabled = true;
            fScissorsTmp.enabled = true;
            rockHand.GetComponent<SpriteRenderer>().enabled = true;
            paperHand.GetComponent<SpriteRenderer>().enabled = true;
            scissorsHand.GetComponent<SpriteRenderer>().enabled = true;
            table2.GetComponent<SpriteRenderer>().enabled = true;
            characterMovement.canMove = false;
            nextStepRPS_RR = true;
        }
    }
    void OnQ(InputValue value)
    {
        if (nextStepH_L)
        {
            higherTmp.enabled = false;
            lowerTmp.enabled = false;
            higherAndLowerLogic.RandomCard2().GetComponent<SpriteRenderer>().enabled = true;
            secondNumber = higherAndLowerLogic.GetSecondNumber();
            if (higherAndLowerLogic.CompareCards() == -1)
            {
                winTmp.enabled = true;
            }
            else if (higherAndLowerLogic.CompareCards() == 0)
            {
                drawTmp.enabled = true;
            }
            else
            {
                loseTmp.enabled = true;
            }
            StartCoroutine(CloseH_LMenu());
        }
        if (nextStepRPS_RR)
        {
            rRockTmp.enabled = false;
            qPaperTmp.enabled = false;
            fScissorsTmp.enabled = false;
            rockHand.GetComponent<SpriteRenderer>().enabled = false;
            scissorsHand.GetComponent<SpriteRenderer>().enabled = false;
            enemyHand = RPS_RR_Logic.EnemyHand();
            enemyHand.GetComponent<SpriteRenderer>().enabled = true;
            if (enemyHand == rRockEnemy)
            {
                winTmp.enabled = true;
            }
            else if (enemyHand == qPaperEnemy)
            {
                drawTmp.enabled = true;
            }
            else
            {
                loseTmp.enabled = true;
            }
            StartCoroutine(CloseRPC_RRMenu());
        }
    }
    void OnR(InputValue value)
    {
        if (nextStepH_L)
        {
            higherTmp.enabled = false;
            lowerTmp.enabled = false;
            higherAndLowerLogic.RandomCard2().GetComponent<SpriteRenderer>().enabled = true;
            secondNumber = higherAndLowerLogic.GetSecondNumber();
            if (higherAndLowerLogic.CompareCards() == 1)
            {
                winTmp.enabled = true;
            }
            else if (higherAndLowerLogic.CompareCards() == 0)
            {
                drawTmp.enabled = true;
            }
            else
            {
                loseTmp.enabled = true;
            }
            StartCoroutine(CloseH_LMenu());
        }
        if (nextStepRPS_RR)
        {
            rRockTmp.enabled = false;
            qPaperTmp.enabled = false;
            fScissorsTmp.enabled = false;
            paperHand.GetComponent<SpriteRenderer>().enabled = false;
            scissorsHand.GetComponent<SpriteRenderer>().enabled = false;
            enemyHand = RPS_RR_Logic.EnemyHand();
            enemyHand.GetComponent<SpriteRenderer>().enabled = true;
            if (enemyHand == rRockEnemy)
            {
                drawTmp.enabled = true;
            }
            else if (enemyHand == qPaperEnemy)
            {
                loseTmp.enabled = true;
            }
            else
            {
                winTmp.enabled = true;
            }
            StartCoroutine(CloseRPC_RRMenu());
        }
    }
    public void OnF(InputValue value)
    {
        if (nextStepRPS_RR)
        {
            rRockTmp.enabled = false;
            qPaperTmp.enabled = false;
            fScissorsTmp.enabled = false;
            rockHand.GetComponent<SpriteRenderer>().enabled = false;
            paperHand.GetComponent<SpriteRenderer>().enabled = false;
            enemyHand = RPS_RR_Logic.EnemyHand();
            enemyHand.GetComponent<SpriteRenderer>().enabled = true;
            if (enemyHand == rRockEnemy)
            {
                loseTmp.enabled = true;
            }
            else if (enemyHand == qPaperEnemy)
            {
                winTmp.enabled = true;
            }
            else
            {
                drawTmp.enabled = true;
            }
            StartCoroutine(CloseRPC_RRMenu());
        }
    }
    public IEnumerator CloseH_LMenu(){
        yield return new WaitForSeconds(3f);
        winTmp.enabled = false;
        drawTmp.enabled = false;
        loseTmp.enabled = false;
        table.GetComponent<SpriteRenderer>().enabled = false;
        higherTmp.enabled = false;
        lowerTmp.enabled = false;
        if (higherAndLowerLogic.GetFirstCardClubs())
        {
            firstNumber += 13;
        }
        else if (higherAndLowerLogic.GetFirstCardSpades())
        {
            firstNumber += 26;
        }
        else if (higherAndLowerLogic.GetFirstCardDiamonds())
        {
            firstNumber += 39;
        }
        else
        {
            Debug.Log("sigh");
        }
        Debug.Log("First Number: " + firstNumber);
        higherAndLowerLogic.firstCard[firstNumber - 1].GetComponent<SpriteRenderer>().enabled = false;
        if (higherAndLowerLogic.GetSecondCardClubs())
        {
            secondNumber += 13;
        }
        else if (higherAndLowerLogic.GetSecondCardSpades())
        {
            secondNumber += 26;
        }
        else if (higherAndLowerLogic.GetSecondCardDiamonds())
        {
            secondNumber += 39;
        }
        else
        {
            Debug.Log("sigh");
        }
        Debug.Log("Second Number: " + secondNumber);
        higherAndLowerLogic.secondCard[secondNumber - 1].GetComponent<SpriteRenderer>().enabled = false;
        characterMovement.canMove = true;
        nextStepH_L = false;
    }
    public IEnumerator CloseRPC_RRMenu()
    {
        yield return new WaitForSeconds(3f);
        winTmp.enabled = false;
        drawTmp.enabled = false;
        loseTmp.enabled = false;
        table2.GetComponent<SpriteRenderer>().enabled = false;
        rockHand.GetComponent<SpriteRenderer>().enabled = false;
        paperHand.GetComponent<SpriteRenderer>().enabled = false;
        scissorsHand.GetComponent<SpriteRenderer>().enabled = false;
        enemyHand.GetComponent<SpriteRenderer>().enabled = false;
        characterMovement.canMove = true;
        nextStepRPS_RR = false;
    }
}
