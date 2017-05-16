using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationScr : MonoBehaviour {
    private ManPool pool;
    public int population;
    public GameObject man;
    public GameObject city;
    public int ID;
    public Color _color;
    public int _maxRepPob;
    public int _maxDepPob;
    List<CityManager> cities;
    private CityManager cityScript;


    // Use this for initialization
    void Start () {
        pool = null;
        pool = FindObjectOfType<ManPool>();
        cities = new List<CityManager>();
        population = 0;
        
        StartCoroutine(StartCity());
        StartCoroutine(CheckCityPob());
    }

    private IEnumerator StartCity()
    {

        yield return new WaitForSeconds(0.5f);
        if(pool == null)
        {
            pool = FindObjectOfType<ManPool>();
            StartCoroutine(StartCity());
        }else
        {
            CreateCity(transform.position.x, transform.position.x + 10, transform.position.z, transform.position.z + 10, 6);
        }
    }

    private IEnumerator CheckCityPob()
    {
        yield return new WaitForSeconds(1);
       for(int i = 0; i < cities.Count; i++)
        {
            if (cities[i].reproductorPopulation.Count > _maxRepPob)
            {
                
                float xxx = transform.position.x + UnityEngine.Random.Range(-89.8f, 99.5f);
                float zzz = transform.position.z + UnityEngine.Random.Range(71.7f, -71.1f);
                cityScript = CreateCity(xxx, xxx + 10, zzz, zzz + 10, 0);
                
                for(int j = 0; j < _maxRepPob / 2; j++)
                {
                    
                    
                        GameObject pman = cities[i].reproductorPopulation[0];
                        if (pman != null)
                        {
                            pman.GetComponent<ManMovementScr>().city = cityScript;
                            cityScript.AddMan(pman);
                            cities[i].reproductorPopulation.Remove(pman);
                        }
                    
                }
            }
            if (cities[i].depredatorPopulation.Count > _maxDepPob)
            {

                float xxx = transform.position.x + UnityEngine.Random.Range(-89.8f, 99.5f);
                float zzz = transform.position.z + UnityEngine.Random.Range(71.7f, -71.1f);
                Vector3 point = new Vector3(xxx, 0, zzz);
               
                for (int j = 0; j < _maxDepPob / 2; j++)
                {


                    GameObject pman = cities[i].depredatorPopulation[0];
                    if (pman != null)
                    {
                        pman.GetComponent<ManMovementScr>().destination = point;
                        pman.GetComponent<ManMovementScr>().attacking = true;
                    }

                }
            }
        }
        StartCoroutine(CheckCityPob());
    }

    private CityManager CreateCity(float x1, float x2, float z1, float z2, int numbOfPeople)
    {
        GameObject newCity = Instantiate(city);
       
        cityScript = newCity.GetComponent<CityManager>();
        cities.Add(cityScript);
        cityScript.x1 = x1;
        cityScript.x2 = x2;
        cityScript.z1 = z1;
        cityScript.z2 = z2;
        for(int i = 0; i < numbOfPeople; i++)
        {
            
            CreateMan(((x1 + x2) / 2.0f) + i, (z1 + z2) / 2.0f);
            
            
        }
        cities.Add(cityScript);
        return cityScript;
    }

    private void CreateMan(float x,float z)
    {
        Vector3 vect = new Vector3(x, 1,z);
        GameObject newMan = pool.GetMan(vect, Quaternion.identity);
        newMan.GetComponent<Renderer>().material.color = _color;
        newMan.GetComponent<ManMovementScr>().populationID = ID;
        ManMovementScr newManScript = newMan.GetComponent<ManMovementScr>();
        newManScript.city = cityScript;
        cityScript.AddMan(newMan);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
