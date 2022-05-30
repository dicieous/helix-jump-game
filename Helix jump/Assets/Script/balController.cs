using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balController : MonoBehaviour
{
    public Rigidbody rb;
    public float impulseForce = 3f;
    public bool doubleCollision;
    private Vector3 startPos;
    public int perfectpass = 0;
    public bool isSuperSpeedActive;
    // Start is called before the first frame update

    private void Awake()
    {
        startPos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (doubleCollision)
        {
            return;
        }

        if (isSuperSpeedActive)
        {
            if (!collision.transform.GetComponent<goalController>())
            {
                Destroy(collision.transform.parent.gameObject, 0.3f);
            }
        }else{
            //Reset Level Functionality
            deathScript DeathScript = collision.transform.GetComponent<deathScript>();
            if (DeathScript)
            {
                DeathScript.hitDeathPart();
            }
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up* impulseForce, ForceMode.Impulse);
        doubleCollision = true;
        Invoke("AllowCollision", 0.2f);

        perfectpass = 0;
        isSuperSpeedActive = false;
    }

    private void AllowCollision()
    {
        doubleCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    private void Update()
    {
        if(perfectpass>=3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        }
    }
}
