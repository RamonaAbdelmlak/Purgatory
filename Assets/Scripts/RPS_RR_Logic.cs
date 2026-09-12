using UnityEngine;

public class RPS_RR_Logic : MonoBehaviour
{
    public GameObject[] playerHands = new GameObject[3];
    public GameObject[] enemyHands = new GameObject[3];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHands[0] = GameObject.Find("R - Rock");
        playerHands[1] = GameObject.Find("Q - Paper");
        playerHands[2] = GameObject.Find("F - Scissors");
        enemyHands[0] = GameObject.Find("Hand_Rock_1");
        enemyHands[1] = GameObject.Find("Hand_paper_1");
        enemyHands[2] = GameObject.Find("Hand_scissors_1");
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
}
