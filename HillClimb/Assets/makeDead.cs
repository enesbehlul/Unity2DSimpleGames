using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeDead : MonoBehaviour
{
    public bool dead = false;
    public UnityEngine.UI.Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")){
            gameOverText.gameObject.SetActive(true);
            dead = true;
        }
    }
}
