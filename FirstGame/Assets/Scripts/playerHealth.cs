using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{	
	public float fullHealth;
	float currentHealth;
	public GameObject deathFx;

    public AudioClip playerHurt;

	playerController controlMovement;

    AudioSource playerAS;
    public AudioClip playerDeath;
    //HUD variables
    public Slider healthSlider;
    public Image damageScreen;

    public Text gameOverScreen;
    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
    float smoothColor = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth; 
        controlMovement = GetComponent<playerController>();

        //HUD initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        damaged = false;

        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged){
            damageScreen.color = damagedColor;
        } else {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage(float damage){
    	if(damage <= 0) return;
    	currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.Play();

        //playerAS.PlayOneShot(playerHurt);

        healthSlider.value = currentHealth;
        damaged = true;
    	if(currentHealth <= 0){
    		makeDead();
    	}
    }
    public void addHealth(float healthAmount){
        currentHealth += healthAmount;
        if(currentHealth > fullHealth)
            currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }
    public void makeDead(){
        AudioSource.PlayClipAtPoint(playerDeath, transform.position);
    	Instantiate(deathFx, transform.position, transform.rotation);
    	Destroy(gameObject);
        damageScreen.color = damagedColor;
        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
    }
}
