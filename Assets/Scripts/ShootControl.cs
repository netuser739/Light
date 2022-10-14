using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour
{

    [SerializeField] private Transform _camera;
    private Light _shootFlash;

    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _shootFlash = GetComponent<Light>();

        _shootFlash.enabled = false;

        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        //Targeting();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            _shootFlash.enabled = true;
        }
        else
        {
            _shootFlash.enabled = false;
        }
    }

    private void Targeting()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _camera.position = new Vector3(-1.64f, 0.791f, -1.254f);
        }
        else
        {
            _camera.position = _startPosition;
        }

    }
}
