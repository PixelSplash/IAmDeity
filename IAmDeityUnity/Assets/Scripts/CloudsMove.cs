using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour {
    public int speed;
    public float maxZPos = 169.54f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        if (transform.position.z > maxZPos)
        {
            Destroy(transform.gameObject);
        }
    }
}
