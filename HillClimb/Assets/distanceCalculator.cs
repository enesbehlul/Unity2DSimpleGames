using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceCalculator : MonoBehaviour
{
    //gidilen yolu hesaplama
    public float distanceTravelled = 1;
    Vector3 lastPosition;
    public UnityEngine.UI.Text distanceText;

    

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x>lastPosition.x){
            distanceTravelled += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;
            distanceText.text = Mathf.RoundToInt(distanceTravelled)+"";
        }
    }
}
