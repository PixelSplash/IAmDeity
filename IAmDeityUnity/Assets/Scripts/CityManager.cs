using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour {
    public float x1;
    public float x2;
    public float z1;
    public float z2;
    public List<GameObject> reproductorPopulation;
    public List<GameObject> depredatorPopulation;

    // Use this for initialization
    void Start () {

        reproductorPopulation = new List<GameObject>();
        depredatorPopulation = new List<GameObject>();

    }
	
	// Update is called once per frame
	void Update () {

    }
    public void AddMan(GameObject newMan)
    {

        x1 -= 0.005f;
        x2 += 0.005f;
        z1 -= 0.005f;
        z2 += 0.005f;
        ManMovementScr newManScript = newMan.GetComponent<ManMovementScr>();
        newManScript.city = this;
        if (newManScript.type == 2)
        {
            depredatorPopulation.Add(newMan);
        }
        else
        {
            reproductorPopulation.Add(newMan);
        }
    }
    public void RemoveMan(GameObject newMan)
    {
        int id = newMan.GetComponent<ManMovementScr>().type;
        if (id == 2)
        {
            depredatorPopulation.Remove(newMan);
        }
        else
        {
            reproductorPopulation.Remove(newMan);
        }
    }
}
