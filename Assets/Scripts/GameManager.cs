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

    bool isGameOver = false, isSelecting, isShowing;
    public bool IsGameOver
    {
        get { return isGameOver; }
        set { isGameOver = value; }
    }
    public bool IsSelecting { get { return isSelecting; } }
    public bool IsShowing { get { return isShowing; } }
    public void SetSelectingState(bool _isSelecting)
    {
        isSelecting = _isSelecting;
        isShowing = !_isSelecting;
        Debug.Log("게임 매니저 isSelecting : " + isSelecting + " isShowing : " + isShowing);
    }
}
