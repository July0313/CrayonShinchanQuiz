using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject quizPanel;
    [SerializeField] GameObject resultPanel;
    bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        { 
            isGameOver = value;
            if (isGameOver)
            {
                // PanelOnOff(false);
            }
        }
    }

    private void Start()
    {
        // PanelOnOff(true);
        Reload();
    }


    public void PanelOnOff(bool quizPanelOn)
    {
        quizPanel.SetActive(quizPanelOn);
        resultPanel.SetActive(!quizPanelOn);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // PanelOnOff(true);
    }
}
