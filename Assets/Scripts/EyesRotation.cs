using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesRotation : MonoBehaviour
{
    [SerializeField] private Transform _eye;
    private float _rotationSpeed = 90f; // Скорость вращения в градусах в секунду
    public float Multiplier = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _eye.Rotate(Vector3.forward * _rotationSpeed * Multiplier * Time.deltaTime, Space.World);
    }
}

