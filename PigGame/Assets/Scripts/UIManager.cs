using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hearts;
    [SerializeField] private Text _healthScore;
    [SerializeField] private Text _qteText;

    void Start()
    {
    }
    void Update()
    {
    }
    public void HealthUpdate(int heartNumber)
    {
        _hearts[heartNumber].gameObject.SetActive(false);  
    }
    public void QTEUpdate(char letter)
    {
        _qteText.text = $"{letter}".ToUpper();
    }
}
