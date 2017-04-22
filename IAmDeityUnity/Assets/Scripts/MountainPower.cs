using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainPower : MonoBehaviour {
    public GameObject mountain;
    RaycastHit hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), hit){
                Destroy(hit.transform.gameObject);
            }
            Vector3 position = Camera.main.ViewportToWorldPoint(Input.mousePosition);
            position.y = -10;
            
            GameObject newMountain = Instantiate(mountain, position, Quaternion.identity);
            Vector3 _newDirection = new Vector3(-89.98f, 0f, 0f);
            newMountain.transform.localEulerAngles = _newDirection;
        }
	}
}
