using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private float _sunPos = 0;
    [SerializeField]
    private float _dayVelocity = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _sunPos += _dayVelocity * Time.deltaTime;
        Vector3 _newDirection = new Vector3(_sunPos, 45.0f, 0f);
        transform.localEulerAngles = _newDirection;
    }
}
