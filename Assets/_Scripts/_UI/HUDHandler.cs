using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUDHandler : MonoBehaviour
{
    public static HUDHandler Instance;
    
    [Header("Scene Name")]
    [SerializeField] string sceneName = "MainMenu";

    [Header("GameOver")]
    [SerializeField] GameObject gameOver;
    [SerializeField] Button _btnBackGO;
    [SerializeField] Button _btnRestartGO;

    [Header("YouWin")]
    [SerializeField] Button _btnBackYW;
    [SerializeField] Button _btnRestartYW;

    [Header("Pause")]
    [SerializeField] GameObject goPause;
    [SerializeField] Button _btnBackP;
    [SerializeField] Button _btnRestartP;

    [Header("Score")]
    [SerializeField]
    float score = 0;

    [SerializeField]
    TextMeshProUGUI showScore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Handler(gameOver, false);
        Handler(goPause, false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Handler(goPause, true);
            Time.timeScale = 0;
        }
    }

    private void OnEnable()
    {
        _btnBackGO.onClick.AddListener(OnBack);
        _btnBackYW.onClick.AddListener(OnBack);
        _btnBackP.onClick.AddListener(OnBack);
        _btnRestartGO.onClick.AddListener(OnRestart);
        _btnRestartYW.onClick.AddListener(OnRestart);
        _btnRestartP.onClick.AddListener(OnRestart);
    }

    private void OnDisable()
    {
        _btnBackGO.onClick.RemoveListener(OnBack);
        _btnBackYW.onClick.RemoveListener(OnBack);
        _btnRestartGO.onClick.RemoveListener(OnRestart);
        _btnRestartYW.onClick.RemoveListener(OnRestart);
    }

    private void Handler(GameObject go, bool isActive)
    {
        go.gameObject.SetActive(isActive);
    }

    private void OnBack()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGameOver()
    {
        Handler(gameOver, true);
        Time.timeScale = 0;
    }

    public void UpdateScore()
    {
        score += 1;
        showScore.text = score.ToString();
    }
}
