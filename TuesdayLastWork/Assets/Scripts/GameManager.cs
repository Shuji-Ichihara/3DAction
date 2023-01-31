using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private GameObject _startZone = null;
    [SerializeField]
    private GameObject _goalZone = null;
    [SerializeField]
    private GameObject _gameOver = null;

    public GameObject StartZone => _startZone;
    public GameObject GoalZone => _goalZone;
    public GameObject GameOver => _gameOver;

    public bool IsClear { get; set; } = false;
    public bool IsOver { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        if (true == IsOver) { IsOver = false; }
        else if (true == IsClear) { IsClear = false; }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScreen();
        GameEnd();
    }

    private void ChangeScreen()
    {
        if (true == IsOver)
        {
            // 後に追記
        }
        else if (true == IsClear)
        {
            SceneManager.LoadSceneAsync("ClearScene");
        }
    }

    private void GameEnd()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;    //ゲームプレイ終了
#else
            Application.Quit(); //ゲームプレイ終了
#endif
        }

    }
}
