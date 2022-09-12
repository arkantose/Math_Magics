using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    private bool _menuActive;
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private Slider _sliderMusic;
    [SerializeField]
    private Slider _sliderEffects;
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private AudioClip _gateSound;

    // Finished Game Scene
    [SerializeField]
    private GameObject _mainGame;
    [SerializeField]
    private GameObject _finishedGame;
    [SerializeField]
    private GameObject _finishedGameEffect;
    [SerializeField]
    private GameObject _finishedGameButton;
    [SerializeField]
    private AudioClip _portalMagic;
    [SerializeField]
    private TextMeshProUGUI _endPlayerName;
    [SerializeField]
    private AudioClip _gateOpen;
    [SerializeField]
    private AudioClip _greatJob;
    [SerializeField]
    private AudioSource _fireworksAS;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchMenu();
        }
    }

    public void ReturnToTitle()
    {
 
        LoadingScript.sceneToLoad = 1;
        SceneManager.LoadScene(6);
    }

    public void SwitchMenu()
    {
        if (_menuActive == false)
        {
            _menu.SetActive(true);
            _menuActive = true;

        }
        else
        {
            _menu.SetActive(false);
            _menuActive = false;

        }
    }

    public void AdjustMainVolume()
    {
        _audioMixer.SetFloat("MusicVolume", _sliderMusic.value);
    }

    public void AdjustEffectsVolume()
    {
        _audioMixer.SetFloat("SoundEffectVolume", _sliderEffects.value);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetString("playerName", "");
        PlayerPrefs.SetInt("playerScore", 0);
        Application.Quit();

    }

    public void GateOpen()
    {
        AudioSource.PlayClipAtPoint(_gateSound, Camera.main.transform.position);
    }

    public void FinishedGameScene()
    {
        _fireworksAS.gameObject.SetActive(true);
        _mainGame.SetActive(false);
        _finishedGameEffect.SetActive(true);
        _finishedGame.SetActive(true);
        _endPlayerName.text = "Great Job " + PlayerPrefs.GetString("playerName") + ".";
        AudioSource.PlayClipAtPoint(_greatJob, Camera.main.transform.position);
        AudioSource.PlayClipAtPoint(_portalMagic, Camera.main.transform.position);
        StartCoroutine(SpecialEffect());
    }

    IEnumerator SpecialEffect()
    {
        yield return new WaitForSeconds(4.0f);
        _finishedGameEffect.SetActive(false);
        _finishedGameButton.SetActive(true);

    }

}
