using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePower : MonoBehaviour {
    RaycastHit hit;
    AudioSource aaudio;
    // Use this for initialization
    void Start () {
        aaudio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(2))
        {
            float maxDistance = Mathf.Infinity;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDistance, LayerMask.GetMask("Land")))
            {
                if (hit.collider.gameObject.tag == "Land")
                {
                    transform.position = hit.point;
                    aaudio.Play();

                }
              

            }


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "man")
        {
            ManMovementScr script = other.gameObject.GetComponent<ManMovementScr>();
            script.atracted = true;
            script.destination = transform.position;
        }
    }
}
