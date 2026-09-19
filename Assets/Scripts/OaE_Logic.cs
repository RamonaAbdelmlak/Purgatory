using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;
using System.Collections.Generic;

public class OaE_Logic : MonoBehaviour
{
    public List<GameObject> firstDie = new List<GameObject>();
    public List<GameObject> secondDie = new List<GameObject>();
    public GameObject[] firstDieArray = new GameObject[6];
    public GameObject[] secondDieArray = new GameObject[6];
    public GameObject randDieOne;
    public GameObject randDieTwo;
    public Animator randDieOneAnimator;
    public Animator randDieTwoAnimator;
    public SpriteRenderer randDieOneSR;
    public SpriteRenderer randDieTwoSR;
    public GameObject table3;
    public SpriteRenderer table3_SR;
    public GameObject player;
    public GameObject interactText;
    public TextMeshProUGUI tmp;
    public Character_Interaction character_Interaction;
    public Character_Movement characterMovement;
    public GameObject even;
    public GameObject odd;
    public TextMeshProUGUI evenTmp;
    public TextMeshProUGUI oddTmp;
    public GameObject win;
    public TextMeshProUGUI winTmp;
    public GameObject lose;
    public TextMeshProUGUI loseTmp;
    public int firstIndex;
    public int secondIndex;
    public int newFirstIndex;
    public int newSecondIndex;
    public Coin_Logic coin_Logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        table3 = GameObject.Find("table3");
        table3_SR = table3.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        interactText = GameObject.Find("Interact Text");
        tmp = interactText.GetComponent<TextMeshProUGUI>();
        character_Interaction = player.GetComponent<Character_Interaction>();
        characterMovement = player.GetComponent<Character_Movement>();
        coin_Logic = player.GetComponent<Coin_Logic>();
        randDieOne = GameObject.Find("Random Die 1");
        randDieTwo = GameObject.Find("Random Die 2");
        randDieOneAnimator = randDieOne.GetComponent<Animator>();
        randDieTwoAnimator = randDieTwo.GetComponent<Animator>();
        randDieOneSR = randDieOne.GetComponent<SpriteRenderer>();
        randDieTwoSR = randDieTwo.GetComponent<SpriteRenderer>();
        even = GameObject.Find("Q - Even");
        odd = GameObject.Find("R - Odd");
        evenTmp = even.GetComponent<TextMeshProUGUI>();
        oddTmp = odd.GetComponent<TextMeshProUGUI>();
        win = GameObject.Find("Win Text");
        winTmp = win.GetComponent<TextMeshProUGUI>();
        lose = GameObject.Find("Lose Text");
        loseTmp = lose.GetComponent<TextMeshProUGUI>();
        firstDie.Add(GameObject.Find("JL_Dice_1_0"));
        firstDie.Add(GameObject.Find("JL_Dice_2_0"));
        firstDie.Add(GameObject.Find("JL_Dice_3_0"));
        firstDie.Add(GameObject.Find("JL_Dice_4_0"));
        firstDie.Add(GameObject.Find("JL_Dice_5_0"));
        firstDie.Add(GameObject.Find("JL_Dice_6_0"));
        secondDie.Add(GameObject.Find("JL_Dice_1_1"));
        secondDie.Add(GameObject.Find("JL_Dice_2_1"));
        secondDie.Add(GameObject.Find("JL_Dice_3_1"));
        secondDie.Add(GameObject.Find("JL_Dice_4_1"));
        secondDie.Add(GameObject.Find("JL_Dice_5_1"));
        secondDie.Add(GameObject.Find("JL_Dice_6_1"));
        firstDieArray[0] = GameObject.Find("JL_Dice_1_0");
        firstDieArray[1] = GameObject.Find("JL_Dice_2_0");
        firstDieArray[2] = GameObject.Find("JL_Dice_3_0");
        firstDieArray[3] = GameObject.Find("JL_Dice_4_0");
        firstDieArray[4] = GameObject.Find("JL_Dice_5_0");
        firstDieArray[5] = GameObject.Find("JL_Dice_6_0");
        secondDieArray[0] = GameObject.Find("JL_Dice_1_1");
        secondDieArray[1] = GameObject.Find("JL_Dice_2_1");
        secondDieArray[2] = GameObject.Find("JL_Dice_3_1");
        secondDieArray[3] = GameObject.Find("JL_Dice_4_1");
        secondDieArray[4] = GameObject.Find("JL_Dice_5_1");
        secondDieArray[5] = GameObject.Find("JL_Dice_6_1");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OaE_PartI()
    {
        character_Interaction.HideUI();
        character_Interaction.interactable = false;
        character_Interaction.tmp.enabled = false;
        characterMovement.canMove = false;
        table3_SR.enabled = true;
        randDieOneSR.enabled = true;
        randDieTwoSR.enabled = true;
        evenTmp.enabled = true;
        oddTmp.enabled = true;
        character_Interaction.nextStepOaE = true;
    }
    public IEnumerator OaE_PartII(int choice)
    {
        if (choice == 0)
        {
            evenTmp.enabled = false;
            oddTmp.enabled = false;
            randDieOneSR.enabled = false;
            firstIndex = GetFirstNumber();
            if (firstIndex == 0)
            {
                newFirstIndex = firstIndex;
            }
            else
            {
                newFirstIndex = firstIndex - 1;
            }
            firstDieArray[newFirstIndex].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(2f);
            randDieTwoSR.enabled = false;
            secondIndex = GetSecondNumber();
            if (secondIndex == 0)
            {
                newSecondIndex = secondIndex;
            }
            else
            {
                newSecondIndex = secondIndex - 1;
            }
            secondDieArray[newSecondIndex].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("first Index: " + firstIndex);
            Debug.Log("Second Index: " + secondIndex);
            Debug.Log(((firstIndex) + (secondIndex)));
            if (((firstIndex) + (secondIndex)) % 2 == 0)
            {
                winTmp.enabled = true;
                coin_Logic.UpdateCoin(200f);
                StartCoroutine(character_Interaction.CloseOaEMenu());
            }
            else
            {
                loseTmp.enabled = true;
                coin_Logic.UpdateCoin(-200f);
                StartCoroutine(character_Interaction.CloseOaEMenu());
            }
        }
        else
        {
            evenTmp.enabled = false;
            oddTmp.enabled = false;
            randDieOneSR.enabled = false;
            firstIndex = GetFirstNumber();
            if (firstIndex == 0)
            {
                newFirstIndex = firstIndex;
            }
            else
            {
                newFirstIndex = firstIndex - 1;
            }
            firstDieArray[newFirstIndex].GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(2f);
            randDieTwoSR.enabled = false;
            secondIndex = GetSecondNumber();
            if (secondIndex == 0)
            {
                newSecondIndex = secondIndex;
            }
            else
            {
                newSecondIndex = secondIndex - 1;
            }
            secondDieArray[newSecondIndex].GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log(((firstIndex) + (secondIndex)));
            if (((firstIndex) + (secondIndex)) % 2 == 0)
            {
                loseTmp.enabled = true;
                coin_Logic.UpdateCoin(-200f);
                StartCoroutine(character_Interaction.CloseOaEMenu());
            }
            else
            {
                winTmp.enabled = true;
                coin_Logic.UpdateCoin(200f);
                StartCoroutine(character_Interaction.CloseOaEMenu());
            }
        }
    }
    public int GetFirstNumber()
    {
        int randomIndex = 0;
        randomIndex = Random.Range(0, 6);
        return randomIndex;
    }
    public int GetSecondNumber()
    {
        int randomIndex = 0;
        randomIndex = Random.Range(0, 6);
        return randomIndex;
    }
}
