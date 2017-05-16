using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreator : MonoBehaviour {
    public GameObject cloud;
    public float minZPos;
    public float maxZPos;

    // Use this for initialization
    void Start () {
        minZPos = -28.5f;
        maxZPos = 59.7f;
        StartCoroutine(CreateRandomCloud());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private IEnumerator CreateRandomCloud()
    {
        Vector3 newPos = transform.position;
        newPos.x = -168.88f;
        newPos.z = UnityEngine.Random.Range(minZPos, maxZPos);
        Instantiate(cloud, newPos, Quaternion.identity);
    
        yield return new WaitForSeconds(UnityEngine.Random.Range(50,100));
        StartCoroutine(CreateRandomCloud());

    }

}
