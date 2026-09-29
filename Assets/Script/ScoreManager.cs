using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI coinText;


    private int coin = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coin++;

        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        coinText.text = "Coin: " + coin;
    }
    public int GetCoin()
    {
        return coin;
    }
}