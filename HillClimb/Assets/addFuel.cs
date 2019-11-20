using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFuel : MonoBehaviour
{
    public carController cc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        cc.fuel = 100;
        Destroy(gameObject);
    }
}
