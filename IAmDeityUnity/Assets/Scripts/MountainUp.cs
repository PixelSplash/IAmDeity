using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainUp : MonoBehaviour {
    public float maxAltitude;
    public float minAltitude;
    public float underAltitude;
    private float altitude;
    public float speed;
    public bool up;

    // Use this for initialization
    void Start () {
        up = true;
        altitude = Random.Range(minAltitude, maxAltitude);

    }
	
	// Update is called once per frame
	void Update () {
        if (up)
        {
            if (transform.position.y < altitude)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
            }
        }else
        {
            if (transform.position.y > underAltitude)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -speed, Space.World);
            }else
            {
                Destroy(transform.gameObject);
            }
            
        }
		
	}

   

}
