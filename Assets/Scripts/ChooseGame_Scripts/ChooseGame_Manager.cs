using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseGame_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _pickGame;
    public void LoadPrimeNumbers()
    {
        LoadingScript.sceneToLoad = 2;
        SceneManager.LoadScene(6);
    }

    public void LoadMultiplication()
    {
        LoadingScript.sceneToLoad = 3;
        SceneManager.LoadScene(6);
    }

    public void LoadDivision()
    {
        LoadingScript.sceneToLoad = 4;
        SceneManager.LoadScene(6);
    }

    private void Start()
    {
        AudioSource.PlayClipAtPoint(_pickGame, Camera.main.transform.position);
    }

}
