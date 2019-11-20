using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCoin : MonoBehaviour
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
        if (other.gameObject.name == "Coin5"){
            addCoin(5, other);
        } else if(other.gameObject.name == "Coin25") {
            addCoin(25, other);
        } else if(other.gameObject.name == "Coin100"){
            addCoin(100, other);
        } else if(other.gameObject.name == "Coin500") {
            addCoin(500, other);
        }
    }

    private void addCoin(int amount, Collider2D collider){
        cc.coinAmount += amount;
        cc.coinText.text = cc.coinAmount+"";
        Destroy(collider.gameObject);
    }
}
