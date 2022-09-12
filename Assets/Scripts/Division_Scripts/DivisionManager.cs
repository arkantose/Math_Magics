using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DivisionManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _questionNumberText;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private int _score = 0;
    private int _questionNumber = 1;
    [SerializeField]
    private TextMeshProUGUI _questionText;
    [SerializeField]
    private TextMeshProUGUI[] _numbers = new TextMeshProUGUI[3];
    private int _numberOne;
    private int _numberTwo;
    private double _correctAnswer;
    [SerializeField]
    private bool[] _correctAnswerBool = new bool[3];
    [SerializeField]
    private GameObject _heartImage;
    [SerializeField]
    private AudioClip _heartSpell;
    [SerializeField]
    private MainMenu _mainMenu;
    [SerializeField]
    private AudioClip _intro;
    [SerializeField]
    private GameObject _lovePotion;
    [SerializeField]
    private AudioClip _lovePotionClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(_intro, Camera.main.transform.position);
        _scoreText.text = "Score: " + _score;
        _questionNumberText.text = "Question: " + _questionNumber;

        _numberOne = Random.Range(10, 101);
        _numberTwo = Random.Range(1, 10);
        _correctAnswer = (double)_numberOne / (double)_numberTwo;

        _questionText.text = _numberOne + "    " + _numberTwo; 

        int a = Random.Range(0, 3);

        for (int i = 0; i <= 2; i++)
        {
            if (i == a)
            {
                _numbers[i].text = _correctAnswer.ToString("f2");
                _correctAnswerBool[i] = true;
            }
            else
            {
                _numbers[i].text = (_correctAnswer - Random.Range(-2.0f,2.0f)).ToString("f2");
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckButtonZero()
    {
        if (_questionNumber < 20)
        {
            if (_correctAnswerBool[0] == true)
            {
                _score += 10;
                _scoreText.text = "Score: " + _score;
                _questionNumber++;
                _questionNumberText.text = "Question: " + _questionNumber;
                for (int i = 0; i <= 2; i++)
                {
                    _correctAnswerBool[i] = false;
                }
                Reset();
                StartCoroutine(HeartPoof());
            }
            else
            {
                _score -= 15;
                _scoreText.text = "Score: " + _score;
            }
        }
        else
        {
            StartCoroutine(GameEnds());
        }
    }
    public void CheckButtonOne()
    {
        if (_questionNumber < 20)
        {
            if (_correctAnswerBool[1] == true)
            {
                _score += 10;
                _scoreText.text = "Score: " + _score;
                _questionNumber++;
                _questionNumberText.text = "Question: " + _questionNumber;
                for (int i = 0; i <= 2; i++)
                {
                    _correctAnswerBool[i] = false;
                }
                Reset();
                StartCoroutine(HeartPoof());
            }
            else
            {
                _score -= 15;
                _scoreText.text = "Score: " + _score;
            }
        }
        else
        {
            StartCoroutine(GameEnds());
        }
 
    }
    public void CheckButtonTwo()
    {
        if (_questionNumber < 20)
        {
            if (_correctAnswerBool[2] == true)
            {
                _score += 10;
                _scoreText.text = "Score: " + _score;
                _questionNumber++;
                _questionNumberText.text = "Question: " + _questionNumber;
                for (int i = 0; i <= 2; i++)
                {
                    _correctAnswerBool[i] = false;
                }
                Reset();
                StartCoroutine(HeartPoof());
            }
            else
            {
                _score -= 15;
                _scoreText.text = "Score: " + _score;
            }
        }
        else
        {
            StartCoroutine(GameEnds());
        }

    }
    private IEnumerator GameEnds()
    {
        _lovePotion.SetActive(true);
        AudioSource.PlayClipAtPoint(_lovePotionClip, Camera.main.transform.position);
        yield return new WaitForSeconds(3f);
        LoadingScript.overallScore += _score;
        LoadingScript.gamesPlayed++;
        _mainMenu.FinishedGameScene();
    }
    private IEnumerator HeartPoof()
    {
        var poof = Instantiate(_heartImage, new Vector3(-26f, 7f, 57.32f), new Quaternion(0f,0f,0f,0f));
        AudioSource.PlayClipAtPoint(_heartSpell, Camera.main.transform.position);
        yield return new WaitForSeconds(1.0f);
        Destroy(poof);

    }
    private void Reset()
    {
        _numberOne = Random.Range(10, 101);
        _numberTwo = Random.Range(1, 10);
        _correctAnswer = (double)_numberOne / (double)_numberTwo;

        _questionText.text = _numberOne + "    " + _numberTwo;

        int a = Random.Range(0, 3);

        for (int i = 0; i <= 2; i++)
        {
            if (i == a)
            {
                _numbers[i].text = _correctAnswer.ToString("f2");
                _correctAnswerBool[i] = true;
            }
            else
            {
                _numbers[i].text = (_correctAnswer - Random.Range(-2.0f, 2.0f)).ToString("f2");
            }

        }
    }
    public void ChooseNewGame()
    {

        LoadingScript.sceneToLoad = 1;
        SceneManager.LoadScene(6);
    }
    public void GameScoreScene()
    {

        LoadingScript.sceneToLoad = 5;
        SceneManager.LoadScene(6);
    }

}
