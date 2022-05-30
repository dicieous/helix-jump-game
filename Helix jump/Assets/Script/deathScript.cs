using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void hitDeathPart()
    {
        GameManager.singleton.RestartLevel();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
