using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGame : MonoBehaviour
{
    [SerializeField] private MiniGame_1 _miniGame_1;
    [SerializeField] private GameObject _miniGame_1_eventTrigger;

    public bool miniGame_1_end = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEndMiniGame(miniGame_1_end, _miniGame_1_eventTrigger);
    }
    private void CheckEndMiniGame(bool val, GameObject eventTrigger)
    {
        if (val == true)
        {
            Destroy(eventTrigger);
        }
    }
}
