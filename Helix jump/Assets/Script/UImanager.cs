using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{

    [SerializeField] private Text bestScore;
    [SerializeField] private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bestScore.text = "BEST- " + GameManager.singleton.bestscore;
        scoreText.text ="Score  " +  GameManager.singleton.score;
    }
}
