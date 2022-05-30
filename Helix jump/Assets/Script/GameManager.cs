using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
     
    public int bestscore;
    public int score;
    public int currStage = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Advertisement.Initialize("4775602");
        if (!singleton)
        {
            singleton = this;
        }else if (singleton!=this)
        {
            Destroy(gameObject);
        }

        bestscore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel()
    {
        Advertisement.Show();

        currStage++;
        FindObjectOfType<balController>().ResetBall();
        FindObjectOfType<helixController>().Loadstage(currStage);

    }

    public void RestartLevel()
    {
        //ads
        Advertisement.Show();

        singleton.score = 0;
        FindObjectOfType<balController>().ResetBall();
        FindObjectOfType<helixController>().Loadstage(currStage);

    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score > bestscore)
        {
            bestscore = score;
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
