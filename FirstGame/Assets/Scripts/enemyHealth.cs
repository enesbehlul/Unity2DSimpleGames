using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    //sound for die
    public AudioClip deathKnell;
	public float enemyMaxHealth;

	float currentHealth;

    public GameObject enemyDeathFX;

    public Slider enemySlider;
    
    //to create heart object
    public bool drops;
    public GameObject theDrop;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = enemyMaxHealth;
        enemySlider.value = currentHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void addDamage(float damage){
        enemySlider.gameObject.SetActive(true);
    	currentHealth -= damage;
        enemySlider.value = currentHealth;
    	if(currentHealth <= 0) makeDead();
    }

    void makeDead(){
    	Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathKnell, transform.position);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if(drops){
            Instantiate(theDrop, transform.position, transform.rotation);
        }
        if (gameObject.transform.parent != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
