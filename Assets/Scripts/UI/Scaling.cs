using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ���������� ������������ ���� ��� TextMeshPro

public class TextScaling : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float maxFontSize = 155f;
    public float minFontSize = 125f;
    private float _duration = 0.5f; // ����������������� ��������� ������� ������
    private float _timer; // ����������
    private bool _growing = true;


    void Update()
    {
        // ��������� ����������
        _timer += Time.deltaTime;

        // ���������, �� ���� �� �������� ����������� ��������� ������� ������
        if (_timer > _duration)
        {
            _growing = !_growing;
            _timer = 0; // ���������� ����������
        }

        // �������� ������ ������
        if (_growing)
        {
            // ������������ ����� ������ ������
            float newFontSize = Mathf.Lerp(minFontSize, maxFontSize, _timer / _duration);
            textComponent.fontSize = newFontSize;
        }
        else
        {
            // ������������ ����� ������ ������
            float newFontSize = Mathf.Lerp(maxFontSize, minFontSize, _timer / _duration);
            textComponent.fontSize = newFontSize;
        }
    }

}