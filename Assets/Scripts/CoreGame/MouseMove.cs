using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject Prefab;
    public Transform objectAppeared;
    public Transform StartPos;
    public Transform EndPos;

    public float DestroyTimer = 4f;
    public float ObjectSpeed = 1f;
    public float DelayAtEnd = 0.9f; // Переменная для задержки у EndPos

    private bool movingUpward = true;
    private bool isWaiting = false; // Флаг для проверки, находится ли объект в состоянии ожидания

    void Update()
    {
        if (isWaiting) return; // Если объект ожидает, не выполняем остальной код

        Vector3 EndPosPoint = EndPos.localPosition;
        Vector3 StartPosPoint = StartPos.localPosition;
        Vector3 MousePoint = objectAppeared.localPosition;

        if (MousePoint.y >= EndPosPoint.y && movingUpward)
        {
            StartCoroutine(WaitAtEnd());
        }
        else if (MousePoint.y < StartPosPoint.y && !movingUpward)
        {
            movingUpward = true;
        }
        else if (MousePoint.y == StartPosPoint.y && !movingUpward)
        {
            Destroy(Prefab);
        }

        float moveSpeed = ObjectSpeed * Time.deltaTime;
        Vector3 moveDirection = movingUpward ? Vector3.up : Vector3.down;
        objectAppeared.Translate(moveDirection * moveSpeed);
        Destroy(Prefab, DestroyTimer);
    }

    IEnumerator WaitAtEnd()
    {
        isWaiting = true; // Устанавливаем флаг ожидания
        yield return new WaitForSeconds(DelayAtEnd); // Ожидаем установленное время
        movingUpward = false; // Меняем направление движения
        isWaiting = false; // Снимаем флаг ожидания
    }
}