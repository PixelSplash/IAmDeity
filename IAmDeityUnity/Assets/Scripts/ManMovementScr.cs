using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMovementScr : MonoBehaviour {
    Rigidbody rigid;
    public int state;
    private bool moving;
    public float force;
    public int populationID;
    private float _time;
    public float reproductionSpeed;

    // Use this for initialization
    void Start () {
        moving = false;
        state = 1;
        rigid = transform.GetComponent<Rigidbody>();
        _time = Time.time + 10;
        reproductionSpeed = 10;

    }
	
	// Update is called once per frame
	void Update () {
		
        if (!moving)
        {
            StartCoroutine(MoveRandom());
            moving = true;
        }

    }

    private IEnumerator MoveRandom()
    {
        rigid.AddForce(new Vector3(UnityEngine.Random.Range(-force*state, force * state), 0, UnityEngine.Random.Range(-force * state, force * state)));
        yield return new WaitForSeconds(0.6f);
        moving = false;
    }


    void OnTriggerEnter(Collider other)
    {
        ManMovementScr manScript = other.transform.GetComponent<ManMovementScr>();
        switch (state)
        {
            case 1:

               
                if(manScript != null)
                {

                    if (manScript.populationID == populationID && Time.time > _time)
                    {
                        
                        _time = Time.time + reproductionSpeed;
                        Vector3 vect = transform.position;
                        GameObject newObj = Instantiate(transform.gameObject, vect, Quaternion.identity);
                        newObj.transform.GetComponent<ManMovementScr>().SetState(UnityEngine.Random.Range(1, 3));
                        newObj.GetComponent<Renderer>().material.color = transform.GetComponent<Renderer>().material.color;
                        
                    }
                }

                break;
            case 2:
                if (manScript != null)
                {

                    if (manScript.populationID != populationID)
                    {
                        Destroy(other.gameObject);

                    }
                }

                break;
            case 3:


                break;

        }
        
    }

    public void SetState(int v)
    {
        
        state = v;
    }
}


