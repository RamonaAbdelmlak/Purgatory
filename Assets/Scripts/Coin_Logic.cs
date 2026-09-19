using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Coin_Logic : MonoBehaviour
{
    public GameObject coinCount;
    public TextMeshProUGUI coinCountTmp;
    public float coinAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCount = GameObject.Find("Coin Count");
        coinCountTmp = coinCount.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinAmount <= 0)
        {
            coinAmount = 0;
            coinCountTmp.text = coinAmount.ToString();
        }
    }
    public void UpdateCoin(float value)
    {
        coinAmount += value;
        coinCountTmp.text = coinAmount.ToString();
        Debug.Log(coinAmount);
    }
}
