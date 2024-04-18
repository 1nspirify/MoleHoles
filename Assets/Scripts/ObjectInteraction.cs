using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

public class ObjectInterAction : MonoBehaviour
{
    // Создаем событие для нажатия
    public event System.Action OnObjectTapped;

    private void OnEnable()
    {
        // Подписываемся на событие нажатия
        GetComponent<TapGesture>().Tapped += OnTapped;
    }

    private void OnDisable()
    {
        // Отписываемся от события нажатия
        GetComponent<TapGesture>().Tapped -= OnTapped;
    }

    private void OnTapped(object sender, System.EventArgs e)
    {
        // Вызываем событие нажатия
        OnObjectTapped.Invoke();
       
    }
}
