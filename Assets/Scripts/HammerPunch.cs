using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPunch : MonoBehaviour
{
    [SerializeField] private GameObject _hammer;
    private float _rotationSpeed = 90f; // �������� �������� � �������� � �������
    public float Multiplier = 5;
    private float _destroyTime = 0.4f;
    private bool _isRotating = true; // ���� ��� �����������, ��������� �� ������

    // Update is called once per frame
    void Update()
    {
        if (_isRotating)
        {
            // ������������ ������ �� 90 �������� ������ ��� Z
            float rotationAmount = _rotationSpeed* Multiplier * Time.deltaTime;
            _hammer.transform.Rotate(Vector3.forward, rotationAmount); 

            // ���� �������� 90 ��������, ����������� ���� � �������� ���������� ������
            if (_hammer.transform.localEulerAngles.z >= 90f)
            {
                _isRotating = false;
            }
        }
       /* else
        {
            // ���������� ������ � ������� 0 �� ��� Z
            _hammer.transform.localEulerAngles = Vector3.zero;

            // �������� ����� ������������ �������
           
        }*/
        Destroy(_hammer, _destroyTime);
    }
}
