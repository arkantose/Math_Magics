using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class LoadingManager : MonoBehaviour
{



    [SerializeField]
    Slider _progressBar;
    [SerializeField]
    private TextMeshProUGUI _loadText;
    public float progressValue;


    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel());
    }


    // Update is called once per frame
   IEnumerator LoadLevel()
    {
        AsyncOperation asyncload = SceneManager.LoadSceneAsync(LoadingScript.sceneToLoad);

        while (!asyncload.isDone)
        {
            _progressBar.value = asyncload.progress;
            _loadText.text = asyncload.progress.ToString();
            yield return null;

        }

    }


}
