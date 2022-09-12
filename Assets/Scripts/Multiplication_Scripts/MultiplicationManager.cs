using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MultiplicationManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _problemText;
    [SerializeField] 
    private TMP_InputField _input;
    private int _firstNumber;
    private int _secondNumber;
    private int _answer;
    private int _playerAnswer;
    private string _playerAnswerString;
    [SerializeField]
    private FireballSpell _whoWon;
    [SerializeField]
    private TextMeshProUGUI _gameScore;
    private int _score;
    private int _problemNumber = 1;
    [SerializeField]
    private MainMenu _mainMenu;
    public AudioClip intro;
    [SerializeField]
    private GameObject _playerWinsExplosion;
    [SerializeField]
    private GameObject _playerLosesExplosion;
    [SerializeField]
    private AudioClip _explosion;
    [SerializeField]
    private TextMeshProUGUI _questionNumber;

    void Start()
    {
        _questionNumber.text = "Question: " + _problemNumber;
        _firstNumber = Random.Range(0, 200);
        _secondNumber = Random.Range(0, 100);

        _problemText.text = _firstNumber.ToString() + " x " + _secondNumber.ToString();

        _answer = _firstNumber * _secondNumber;
        _playerAnswerString = _answer.ToString();

        AudioSource.PlayClipAtPoint(intro, Camera.main.transform.position);
    }

   
    void Update()
    {
        
    }

    public void CheckProblem()
    {
        _problemNumber++;
        _questionNumber.text = "Question: " + _problemNumber;
        if (_problemNumber < 20)
        {
            if (_input.text == _playerAnswerString)
            {
                _whoWon.CastleSpell();
                NewProblem();
                _score += 10;
                _gameScore.text = "Score: " + _score.ToString();
            }
            else
            {
                _whoWon.DragonSpell();

                _score -= 15;
                _gameScore.text = "Score: " + _score.ToString();
            }
        }
        else
        {
            LoadingScript.overallScore += _score;
            LoadingScript.gamesPlayed++;
            StartCoroutine(GameFinishes());
        }
           
    }
    IEnumerator GameFinishes()
    {
        if(_score > 0)
        {
            _playerWinsExplosion.SetActive(true);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            _playerWinsExplosion.SetActive(false);
        }
        else
        {
            _playerLosesExplosion.SetActive(true);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(_explosion, Camera.main.transform.position);
            _playerLosesExplosion.SetActive(false);
        }
        yield return new WaitForSeconds(2.0f);
        _mainMenu.FinishedGameScene();
    }
    public void NewProblem()
    {
        _firstNumber = Random.Range(0, 200);
        _secondNumber = Random.Range(0, 100);

        _problemText.text = _firstNumber.ToString() + " x " + _secondNumber.ToString();

        _answer = _firstNumber * _secondNumber;
        _playerAnswerString = _answer.ToString();
        _input.text = "";
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
