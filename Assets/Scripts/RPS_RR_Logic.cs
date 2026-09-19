using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;
using TMPro;

public class RPS_RR_Logic : MonoBehaviour
{
    public GameObject[] playerHands = new GameObject[3];
    public GameObject[] enemyHands = new GameObject[3];
    public GameObject player;
    public Character_Interaction character_Interaction_Logic;
    public GameObject gun;
    public SpriteRenderer gunSpriteRenderer;
    public Animator gunAnimator;
    public bool canClose = false;
    public GameObject bang;
    public TextMeshProUGUI bangTmp;
    public GameObject click;
    public TextMeshProUGUI clickTmp;
    public int bullet = 6;
    public Coin_Logic coin_Logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHands[0] = GameObject.Find("R - Rock");
        playerHands[1] = GameObject.Find("Q - Paper");
        playerHands[2] = GameObject.Find("F - Scissors");
        enemyHands[0] = GameObject.Find("Hand_Rock_1");
        enemyHands[1] = GameObject.Find("Hand_paper_1");
        enemyHands[2] = GameObject.Find("Hand_scissors_1");
        player = GameObject.Find("Player");
        character_Interaction_Logic = player.GetComponent<Character_Interaction>();
        coin_Logic = player.GetComponent<Coin_Logic>();
        gun = GameObject.Find("Purgatory_gun_0");
        gunSpriteRenderer = gun.GetComponent<SpriteRenderer>();
        gunAnimator = gun.GetComponent<Animator>();
        bang = GameObject.Find("BANG");
        bangTmp = bang.GetComponent<TextMeshProUGUI>();
        click = GameObject.Find("Click...");
        clickTmp = click.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject EnemyHand()
    {
        int randomIndex = 0;
        randomIndex = Random.Range(0, enemyHands.Length);
        Debug.Log("Random Index: " + randomIndex);
        return enemyHands[randomIndex];
    }
    public void RussianRoulettePartII(int result)
    {
        if (result == 1)
        {
            StartCoroutine(GunAnimationWin());
        }
        if (result == 0)
        {
            canClose = true;
            return;
        }
        if (result == -1)
        {
            StartCoroutine(GunAnimationLoss());
        }
    }
    public IEnumerator GunAnimationWin()
    {
        gunSpriteRenderer.enabled = true;
        character_Interaction_Logic.winTmp.enabled = false;
        character_Interaction_Logic.drawTmp.enabled = false;
        character_Interaction_Logic.loseTmp.enabled = false;
        character_Interaction_Logic.rockHand.GetComponent<SpriteRenderer>().enabled = false;
        character_Interaction_Logic.paperHand.GetComponent<SpriteRenderer>().enabled = false;
        character_Interaction_Logic.scissorsHand.GetComponent<SpriteRenderer>().enabled = false;
        character_Interaction_Logic.enemyHand.GetComponent<SpriteRenderer>().enabled = false;
        gunAnimator.Play("Gun Spin Win");
        yield return new WaitForSeconds(2f);
        int randNum = Random.Range(0,bullet);
        if (randNum == 0)
        {
            Debug.Log("RR Win");
            coin_Logic.UpdateCoin(500f);
            bangTmp.enabled = true;
            canClose = true;
            bullet = 6;
            StartCoroutine(character_Interaction_Logic.CloseRPC_RRMenu());
        }
        else
        {
            bullet--;
            Debug.Log("Click.");
            clickTmp.enabled = true;
            yield return new WaitForSeconds(1f);
            clickTmp.enabled = false;
            character_Interaction_Logic.CloseRPC_RRMenu_Quick();
            character_Interaction_Logic.RussianRoulettePartI();
        }
    }
    public IEnumerator GunAnimationLoss()
    {
        gunSpriteRenderer.enabled = true;
        character_Interaction_Logic.winTmp.enabled = false;
        character_Interaction_Logic.drawTmp.enabled = false;
        character_Interaction_Logic.loseTmp.enabled = false;
        character_Interaction_Logic.rockHand.GetComponent<SpriteRenderer>().enabled = false;
        character_Interaction_Logic.paperHand.GetComponent<SpriteRenderer>().enabled = false;
        character_Interaction_Logic.scissorsHand.GetComponent<SpriteRenderer>().enabled = false;
        character_Interaction_Logic.enemyHand.GetComponent<SpriteRenderer>().enabled = false;
        gunAnimator.Play("Gun Spin Loss");
        yield return new WaitForSeconds(2f);
        int randNum = Random.Range(0,6);
        if (randNum == 0)
        {
            Debug.Log("RR Loss");
            coin_Logic.UpdateCoin(-500f);
            bangTmp.enabled = true;
            canClose = true;
            bullet = 6;
            StartCoroutine(character_Interaction_Logic.CloseRPC_RRMenu());
        }
        else
        {
            bullet--;
            Debug.Log("Click.");
            clickTmp.enabled = true;
            yield return new WaitForSeconds(1f);
            clickTmp.enabled = false;
            character_Interaction_Logic.CloseRPC_RRMenu_Quick();
            character_Interaction_Logic.RussianRoulettePartI();
        }
    }
}
