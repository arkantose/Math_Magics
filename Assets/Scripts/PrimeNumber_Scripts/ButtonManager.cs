using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Image[] _primeNotPrimeImage = new Image[5];
    [SerializeField]
    private TextMeshProUGUI[] _primeNotPrimeText = new TextMeshProUGUI[5];
    private int _primeOrNotPrime;
    [SerializeField]
    private List<int> _primeNumbers;
    [SerializeField]
    private List<int> _compositeNumbers;
    Vector3 _positionOfImages;
    [SerializeField]
    private TextMeshProUGUI _score;
    [SerializeField]
    public TextMeshProUGUI rightOrWrong;
    public int score;
    public Button nextProblem;
    [SerializeField]
    private GameObject _fireworks;
    [SerializeField]
    private AudioSource _fireworksAS;
    private int _questionNumber = 1;
    [SerializeField]
    private MainMenu _mainMenu;
    [SerializeField]
    private AudioClip _introClip;


   
    void Start()
    {
        AudioSource.PlayClipAtPoint(_introClip, Camera.main.transform.position);
        rightOrWrong.text = "Question Number: " + _questionNumber;
       for (int i = 0; i <= 4; i++)
        {
            if (_primeNotPrimeText[0])
            {
                int prime = Random.Range(0, _primeNumbers.Count);
                string v = _primeNumbers[prime].ToString();
                _primeNotPrimeText[0].text = v;
               
            }
            string m = _compositeNumbers[Random.Range(0, _compositeNumbers.Count)].ToString();
            _primeNotPrimeText[i].text = m;
        }
 
        for (int i = 0; i <= 4; i++)
        {
            _positionOfImages = new Vector3(Random.Range(-289f, -83f), Random.Range(-130f, 14f));
            _primeNotPrimeImage[i].rectTransform.localPosition = _positionOfImages;
        }
    }

  
    public void FireworksOn()
    {
        _fireworks.SetActive(true);
        _fireworksAS.gameObject.SetActive(true);
    }

    public void FireworksOff()
    {
        _fireworks.SetActive(false);
        _fireworksAS.gameObject.SetActive(false);
    }
    public void ShuffleNumbers()
    {
        if (_questionNumber < 20)
        {
            _questionNumber++;
            rightOrWrong.text = "Question Number: " + _questionNumber;
            for (int i = 0; i <= 4; i++)
            {
                if (_primeNotPrimeText[0])
                {
                    int prime = Random.Range(0, _primeNumbers.Count);
                    string v = _primeNumbers[prime].ToString();
                    _primeNotPrimeText[0].text = v;
                
                }
                string m = _compositeNumbers[Random.Range(0, _compositeNumbers.Count)].ToString();
                _primeNotPrimeText[i].text = m;
            }
        }
        else
        {
            LoadingScript.overallScore += score;
            LoadingScript.gamesPlayed++;
            _mainMenu.FinishedGameScene();
        }

    }
 
    public void ShufflePositions()
    {
        if (_questionNumber < 20)
        {
            for (int i = 0; i <= 4; i++)
            {
                _positionOfImages = new Vector3(Random.Range(-289f, -83f), Random.Range(-130f, 14f));
                _primeNotPrimeImage[i].rectTransform.localPosition = _positionOfImages;

            }
        }
        else
            return;

    }

    public void IncreaseScore()
    {
        score += 10;
        _score.text = "Score:" + score.ToString();
    }

    public void DecreaseScore()
    {
        score -= 15;
        _score.text = "Score:" + score.ToString();
    }

    public void TurnOffNextProblem()
    {
        nextProblem.gameObject.SetActive(false);
    }

    public void EndGameResults()
    {
        LoadingScript.sceneToLoad = 5;
        SceneManager.LoadScene(6);
    }

}
