using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionPower : MonoBehaviour {
    RaycastHit hit;
    public GameObject explotion;
    AudioSource[] aaudio;
    // Use this for initialization
    void Start()
    {
        aaudio = gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float maxDistance = Mathf.Infinity;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, maxDistance, LayerMask.GetMask("Land")))
            {
                if (hit.collider.gameObject.tag == "Land")
                {
                    aaudio[1].Play();
                    Instantiate(explotion, hit.point, Quaternion.identity);
                }


            }


        }
    }

}
