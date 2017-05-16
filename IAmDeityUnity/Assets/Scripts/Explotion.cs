using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour {
    public float force;

    // Use this for initialization
    void Start () {
        StartCoroutine(Kill());
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "man")
        {
            ManMovementScr script = other.gameObject.GetComponent<ManMovementScr>();
            script.dead = true;
            script.destination = other.gameObject.transform.position - transform.position;
            script.destination.y = 30;
            script.rigid.AddForce(script.destination * force);
        }
    }
    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
