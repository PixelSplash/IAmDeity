using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationScr : MonoBehaviour {
    private int initialPob;
    public GameObject man;
    public int ID;
    public Color _color;
    public int _maxPob;

    // Use this for initialization
    void Start () {
        initialPob = 0;
        StartCoroutine(CreateMan());
    }

    private IEnumerator CreateMan()
    {
        Vector3 vect = transform.position;
        GameObject newObj = Instantiate(man, vect, Quaternion.identity);
        newObj.GetComponent<Renderer>().material.color = _color;
        newObj.GetComponent<ManMovementScr>().populationID = ID;
        yield return new WaitForSeconds(3f);
        initialPob++;
        if (initialPob < _maxPob)
        {
            StartCoroutine(CreateMan());
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
