using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMovementScr : MonoBehaviour {
    public ManPool pool;
    public Rigidbody rigid;
    public bool attacking;
    public int type;
    private bool moving;
    public float force;
    public int populationID;
    public CityManager city;
    private float _time;
    public float reproductionSpeed;
    public Vector3 destination;
    public bool atracted;
    public bool dead;
    public int id;

    // Use this for initialization
    void Start () {
        attacking = false;
        pool = FindObjectOfType<ManPool>();
        dead = false;
        atracted = false;
        StartCoroutine(Age());
        moving = false;
        type = 1;
        rigid = transform.GetComponent<Rigidbody>();
        reproductionSpeed = 10;
        _time = Time.time + reproductionSpeed;
        type = UnityEngine.Random.Range(1, 3);
        StartCoroutine(MoveRandom());

    }

    private IEnumerator Age()
    {
        yield return new WaitForSeconds(180f);
        Die();
    }
    public void Die()
    {
        city.RemoveMan(gameObject);
        pool.ReturnMan(id);
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
        if (!dead)
        {
            if (atracted)
            {
                Vector3 dir = destination - transform.position;
                rigid.AddForce(dir);
                atracted = false;
            }else if (attacking)
            {
                if (Vector3.Distance(transform.position, destination) < 5f)
                {
                    attacking = false;
                }else
                {
                    Vector3 dir = destination - transform.position;
                    rigid.AddForce(dir);
                }
                
            }
            else
            {
                int newX = 0;
                int newZ = 0;
                if (transform.position.x < city.x1)
                {
                    newX = 1;
                }
                else if (transform.position.x > city.x2)
                {
                    newX = -1;
                }
                if (transform.position.z < city.z1)
                {
                    newZ = 1;
                }
                else if (transform.position.z > city.z2)
                {
                    newZ = -1;
                }
                if ((newX + newZ) == 0)
                {
                    rigid.AddForce(new Vector3(UnityEngine.Random.Range(-force * type, force * type), 0, UnityEngine.Random.Range(-force * type, force * type)));
                }
                else
                {

                    rigid.AddForce(new Vector3(force * type * newX, 0, force * type * newZ));
                }
            }


        }else
        {
            StartCoroutine(Kill());
        }


        yield return new WaitForSeconds(0.6f);
        moving = false;
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "man")
        {
            ManMovementScr manScript = other.transform.GetComponent<ManMovementScr>();
            switch (type)
            {
                case 1:


                    if (manScript != null)
                    {

                        if (manScript.populationID == populationID && Time.time > _time)
                        {

                            _time = Time.time + reproductionSpeed;
                            manScript.Procreate();

                        }
                    }

                    break;
                case 2:
                    if (manScript != null)
                    {

                        if (manScript.populationID != populationID)
                        {
                            other.gameObject.GetComponent<ManMovementScr>().Die();

                        }
                    }

                    break;
                case 3:


                    break;

            }

        }

    }
    public void Procreate()
    {
        _time = Time.time + reproductionSpeed;
        Vector3 vect = transform.position;
        GameObject newMan = pool.GetMan(vect, Quaternion.identity);
        if(newMan == null)
        {
            print("Se acabo la pila");
            return;
        }
        newMan.GetComponent<Renderer>().material.color = transform.GetComponent<Renderer>().material.color;
        newMan.GetComponent<ManMovementScr>().populationID = populationID;
        city.AddMan(newMan);
    }
    public void SetState(int v)
    {
        
        type = v;
    }
}


