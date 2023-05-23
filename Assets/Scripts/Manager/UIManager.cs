using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject quizCanvasObj;

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Slider hpBar;

    public void SetCoinText(int amount)
    {
        coinText.text = amount.ToString("D3");
    }    

    public void SetHpBar(int hp)
    {
        hpBar.value = hp / 100f;
    }
}
