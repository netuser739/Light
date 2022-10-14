using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField][Range(0f, 10f)] private float _speedDayNightCgange = 0.5f;

    private float _angleRotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _angleRotate += _speedDayNightCgange * Time.deltaTime;

        transform.rotation = Quaternion.Euler(_angleRotate, _angleRotate, 0f);//new Vector3(0f, 0f, 1f) * _speedDayNightCgange * Time.deltaTime;
    }
}
