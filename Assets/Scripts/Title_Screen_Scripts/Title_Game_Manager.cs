using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Title_Game_Manager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _screenName;
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private AudioClip _audioClip;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position);
    }
    public void InputFieldName()
    {
        PlayerPrefs.SetString("playerName", _screenName.text);
        LoadingScript.sceneToLoad = 1;
        SceneManager.LoadScene(6);
    }


}
