using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManPool : MonoBehaviour {
    GameObject[] pool;
    public GameObject man;
    List<int> availables;
    public int maxSize;
    GameObject tman;
	// Use this for initialization
	void Start () {
        availables = new List<int>();
        
        pool = new GameObject[maxSize];
        for (int i = 0; i<maxSize; i++)
        {
            tman = Instantiate(man);
            tman.SetActive(false);
            pool[i] = tman;
            tman.GetComponent<ManMovementScr>().id = i;
            availables.Add(i);

        }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public GameObject GetMan(Vector3 pos, Quaternion quat)
    {
        
        if (availables.Count > 0)
        {
           
            tman = pool[availables[0]];
            availables.RemoveAt(0);
            tman.transform.position = pos;
            tman.transform.rotation = quat;
            tman.SetActive(true);
            return tman;
        }else { return null; }
        
    }
    public void ReturnMan( int id )
    {
        tman = pool[id];
        tman.SetActive(false);
        availables.Add(id);
    }
}
