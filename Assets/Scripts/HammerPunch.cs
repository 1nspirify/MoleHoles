using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPunch : MonoBehaviour
{
    [SerializeField] private GameObject _hammer;
    private float _rotationSpeed = 90f; // Скорость вращения в градусах в секунду
    public float Multiplier = 5;
    private float _destroyTime = 0.4f;
    private bool _isRotating = true; // Флаг для определения, вращается ли объект

    // Update is called once per frame
    void Update()
    {
        if (_isRotating)
        {
            // Поворачиваем объект на 90 градусов вокруг оси Z
            float rotationAmount = _rotationSpeed* Multiplier * Time.deltaTime;
            _hammer.transform.Rotate(Vector3.forward, rotationAmount); 

            // Если достигли 90 градусов, переключаем флаг и начинаем возвращать объект
            if (_hammer.transform.localEulerAngles.z >= 90f)
            {
                _isRotating = false;
            }
        }
       /* else
        {
            // Возвращаем объект в позицию 0 по оси Z
            _hammer.transform.localEulerAngles = Vector3.zero;

            // Задержка перед уничтожением объекта
           
        }*/
        Destroy(_hammer, _destroyTime);
    }
}
