using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class UIHandler : MonoBehaviour
{
    [Header("Scene Name")]
    [SerializeField] string sceneName = "Gameplay";

    [Header("Buttons")]
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnOptions;
    [SerializeField] private Button _btnHTP;
    [SerializeField] private Button _btnHTPClose;
    [SerializeField] private Button _btnOptClose;

    [Header("GameObjects")]
    [SerializeField] private GameObject _goHTP;
    [SerializeField] private GameObject _goOptions;

    [Header("InputField")]
    [SerializeField] public TMP_InputField _iFieldGST;
    [SerializeField] public TMP_InputField _iFieldEST;

    private void Awake()
    {
        ValidateIF();
    }

    void Start()
    {
        BtnHandler(_btnPlay, true);
        BtnHandler(_btnOptions, true);
        BtnHandler(_btnHTP, true);
        BtnHandler(_btnOptClose, false);
        BtnHandler(_btnHTPClose, false);

        GoHandler(_goHTP, false);
        GoHandler(_goOptions, false);
    }

    private void OnEnable()
    {
        _btnPlay.onClick.AddListener(OnPlay);
        _btnOptions.onClick.AddListener(OnOptions);
        _btnHTP.onClick.AddListener(OnHTP);
        _btnOptClose.onClick.AddListener(OnBack);
        _btnHTPClose.onClick.AddListener(OnBack);
    }

    private void OnDisable()
    {
        _btnPlay.onClick.RemoveListener(OnPlay);
        _btnOptions.onClick.RemoveListener(OnOptions);
        _btnHTP.onClick.RemoveListener(OnHTP);
        _btnOptClose.onClick.RemoveListener(OnBack);
        _btnHTPClose.onClick.RemoveListener(OnBack);
    }

    private void OnPlay()
    {
        float gstDefault = 180;
        float estDefault = 3;

        if (_iFieldGST.text != "") { PlayerPrefs.SetFloat("GameSessionTime", float.Parse(_iFieldGST.text)); }
        else { PlayerPrefs.SetFloat("GameSessionTime", gstDefault); }

        if (_iFieldEST.text != "") { PlayerPrefs.SetFloat("EnemySpawnTime", float.Parse(_iFieldEST.text)); }
        else { PlayerPrefs.SetFloat("EnemySpawnTime", estDefault); }

        SceneManager.LoadScene(sceneName);
    }

    private void BtnHandler(Button btn, bool isActive)
    {
        btn.gameObject.SetActive(isActive);
    }

    private void GoHandler(GameObject go, bool isActive)
    {
        go.gameObject.SetActive(isActive);
    }

    private void OnOptions()
    {
        BtnHandler(_btnPlay, false);
        BtnHandler(_btnOptions, false);
        BtnHandler(_btnHTP, false);
        BtnHandler(_btnOptClose, true);
        BtnHandler(_btnHTPClose, false);

        GoHandler(_goOptions, true);
    }

    private void OnBack()
    {
        BtnHandler(_btnPlay, true);
        BtnHandler(_btnOptions, true);
        BtnHandler(_btnHTP, true);
        BtnHandler(_btnOptClose, false);
        BtnHandler(_btnHTPClose, false);

        GoHandler(_goHTP, false);
        GoHandler(_goOptions, false);
    }

    private void OnHTP()
    {
        BtnHandler(_btnPlay, false);
        BtnHandler(_btnOptions, false);
        BtnHandler(_btnHTP, false);
        BtnHandler(_btnOptClose, false);
        BtnHandler(_btnHTPClose, true);

        GoHandler(_goHTP, true);
    }

    public void ValidateIF()
    {
        _iFieldGST.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        _iFieldEST.characterValidation = TMP_InputField.CharacterValidation.Decimal;
    }
}