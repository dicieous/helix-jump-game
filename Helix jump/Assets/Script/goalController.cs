using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.singleton.NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
