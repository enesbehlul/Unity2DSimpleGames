using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{
    // Start is called before the first frame update

    Collider2D box;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            playerHealth playerHealthObject = other.GetComponent<playerHealth>();
            playerHealthObject.makeDead();
        } else 
            Destroy(other.gameObject);
    }
}
