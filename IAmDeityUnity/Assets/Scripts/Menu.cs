using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(OnDes());
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public IEnumerator OnDes()
    {
        yield return new WaitForSeconds(5);
            Destroy(gameObject);
    }
}
