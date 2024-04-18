using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Используем пространство имен для TextMeshPro

public class TextScaling : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float maxFontSize = 155f;
    public float minFontSize = 125f;
    private float _duration = 0.5f; // Продолжительность изменения размера шрифта
    private float _timer; // Секундомер
    private bool _growing = true;


    void Update()
    {
        // Обновляем секундомер
        _timer += Time.deltaTime;

        // Проверяем, не пора ли изменить направление изменения размера шрифта
        if (_timer > _duration)
        {
            _growing = !_growing;
            _timer = 0; // Сбрасываем секундомер
        }

        // Изменяем размер шрифта
        if (_growing)
        {
            // Рассчитываем новый размер шрифта
            float newFontSize = Mathf.Lerp(minFontSize, maxFontSize, _timer / _duration);
            textComponent.fontSize = newFontSize;
        }
        else
        {
            // Рассчитываем новый размер шрифта
            float newFontSize = Mathf.Lerp(maxFontSize, minFontSize, _timer / _duration);
            textComponent.fontSize = newFontSize;
        }
    }

}