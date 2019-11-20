using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{   
    int oldDistance;
    int currentDistance;
    int roadCounter = 0;
    public distanceCalculator dc;
    public UnityEngine.UI.Text coinText;
    public int coinAmount = 0;
    public Rigidbody2D carRB;
    public float carTorque = 10;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float movement;
    public UnityEngine.UI.Image image;
    public float speed = 100;
    public float fuel = 1;
    public float fuelConsumption = 0.1f;
    public makeDead md;
    float mapLength;
    public GameObject rightSideObject, leftSideObject;
    public GameObject[] roads;
    
    bool groundedBack = true;
    bool groundedFront = true;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheckBack;
    public Transform groundCheckFront;

    // Start is called before the first frame update
    void Start()
    {
        mapLength = rightSideObject.transform.position.x - leftSideObject.transform.position.x;
        print(mapLength);
    }

    // Update is called once per frame
    void Update()
    {   
        oldDistance = Mathf.RoundToInt(dc.distanceTravelled);
        movement = Input.GetAxis("Horizontal");
        image.fillAmount = fuel;
        if (oldDistance % 55 == 0 && currentDistance != oldDistance){
            Instantiate(roads[Random.Range(0,5)], new Vector3((5+roadCounter++)*mapLength, 1.2f, 0), Quaternion.identity);     

        } 
        currentDistance = Mathf.RoundToInt(dc.distanceTravelled);       
    }

    float counter = 0;
    private void FixedUpdate() {
       
        groundedBack = Physics2D.OverlapCircle(groundCheckBack.position, groundCheckRadius, groundLayer);
        groundedFront = Physics2D.OverlapCircle(groundCheckFront.position, groundCheckRadius, groundLayer);
        if (fuel > 0 && !md.dead) {
            backTire.AddTorque(-movement*speed*Time.fixedDeltaTime);
            frontTire.AddTorque(-movement*speed*Time.fixedDeltaTime); 
            fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
            counter = this.transform.GetChild(0).transform.rotation.z;
            /* if(!groundedBack && !groundedFront && movement > 0){
                print(counter);
                counter += 2;
                this.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, counter+this.transform.GetChild(0).transform.rotation.z);
                print(this.transform.GetChild(0).name);
            }
            else if(!groundedBack && !groundedFront && movement < 0){
                print(counter);
                counter += 2;
                this.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, counter-this.transform.GetChild(0).transform.rotation.z);
                print(this.transform.GetChild(0).name);
            }  */
        }
    }
}