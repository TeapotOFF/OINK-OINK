using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame_1 : MonoBehaviour
{
    [SerializeField] private GameObject _openDoor;
    [SerializeField] private ChangeGame _changeGame;
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private GameObject _lockPrefab;
    [SerializeField] private GameObject _gameBoard;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Text _textScore;
    [SerializeField] private GameObject _gameTrigger;
    [SerializeField] private GameObject _helpButton;

    private bool _gameIsEnd = false;
    public  static int _gameScore;
    private GameObject _stone;
    private GameObject _lock;
    private bool _playerTrigger = false;
    private Vector2 _forceVector;
    private bool _gameIsStart = false;
    private MiniGameTrigger _miniGameTrigger;
    void Start()
    {
        _miniGameTrigger = _gameTrigger.GetComponent<MiniGameTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        //Начало игры 
        if (_miniGameTrigger != null)
        _playerTrigger = _miniGameTrigger.gameTrigger;
        GetHlep();
        CheckButtonPress();
        CreateNewObject();
        // Рефрешь игры
        CompleteGame();
    }
    public void GetVector()
    {
        Debug.Log(_gameScore);
        _forceVector = _stone.transform.position - Input.mousePosition;
        _stone.GetComponent<Rigidbody2D>().AddForce(_forceVector * 10f, ForceMode2D.Impulse);
    }
    private void MiniGameStart()
    {
        _gameBoard.SetActive(true);
        _gameIsStart = true;
        _stone = Instantiate<GameObject>(_stonePrefab, _canvas.transform);
        _lock = Instantiate<GameObject>(_lockPrefab, _canvas.transform);
    }
    private void MiniGameStop()
    {
        _gameBoard.SetActive(false);
        _gameIsStart = false;
        Destroy(_stone);
        Destroy(_lock);
    }
    private void GetHlep()
    {
        if(_playerTrigger)
        {
            _helpButton.gameObject.SetActive(true);
        }
        else { _helpButton.gameObject.SetActive(false);}
    }
    private void CheckButtonPress()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (_gameIsStart == false))
        {
            if (_playerTrigger)
            {
                MiniGameStart();
            }
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && (_gameIsStart == true))
        {
            MiniGameStop();
        }
    }
    private void CreateNewObject()
    {
        if (_gameIsStart)
        {
            if (_stone == null)
            {
                _textScore.text = _gameScore.ToString();
                _stone = Instantiate<GameObject>(_stonePrefab, _canvas.transform);
            }
        }
    }
    private void CompleteGame()
    {
        if (_gameScore == 3)
        {
            MiniGameStop();
            _gameIsEnd = true;
            _changeGame.miniGame_1_end = _gameIsEnd;
            GameObject closeDoor = GameObject.Find("CloseDoor");
            Destroy(closeDoor);
            _openDoor.SetActive(true);
        }
    }
}
