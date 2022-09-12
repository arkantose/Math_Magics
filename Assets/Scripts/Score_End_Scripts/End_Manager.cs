using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class End_Manager : MonoBehaviour
{
    [SerializeField]
    AudioClip _introClip;
    [SerializeField]
    private TextMeshProUGUI _playerName;
    [SerializeField]
    private TextMeshProUGUI _playerGames;
    [SerializeField]
    private TextMeshProUGUI _playerScore;

    // Start is called before the first frame update
    void Start()
    {

        AudioSource.PlayClipAtPoint(_introClip, Camera.main.transform.position);
        _playerName.text = PlayerPrefs.GetString("playerName");
        _playerGames.text = "Games Played: " + LoadingScript.gamesPlayed.ToString();
        _playerScore.text = "Player Score: " + LoadingScript.overallScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
