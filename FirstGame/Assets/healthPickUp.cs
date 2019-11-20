using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickUp : MonoBehaviour
{

    public float healthAmount;
    playerHealth thePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            thePlayerHealth = other.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
