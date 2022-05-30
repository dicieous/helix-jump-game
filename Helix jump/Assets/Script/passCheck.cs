using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(2);
        FindObjectOfType<balController>().perfectpass++;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
