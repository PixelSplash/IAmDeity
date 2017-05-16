using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainPower : MonoBehaviour {
    public GameObject mountain;
    RaycastHit hit;
    AudioSource[] aaudio;
    // Use this for initialization
    void Start () {
        aaudio = gameObject.GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            float maxDistance = Mathf.Infinity;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDistance, LayerMask.GetMask("Land","Mountain"))) {
                if(hit.collider.gameObject.tag == "Land")
                {
                    aaudio[0].Play();
                    Vector3 pos = hit.point;
                    pos.y = -15.2f;
                    GameObject newMountain = Instantiate(mountain, pos, Quaternion.identity);

                    Vector3 _newDirection = new Vector3(-89.98f, 0f, 0f);
                    newMountain.transform.localEulerAngles = _newDirection;
                }else if (hit.collider.gameObject.tag == "Mountain")
                {
                    aaudio[0].Play();
                    MountainUp mountainScr = hit.collider.gameObject.GetComponent<MountainUp>();
                    mountainScr.up = false;
                }

            }

            
        }
	}
}
