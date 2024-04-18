using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnList : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // массив объектов для спавна
    public Transform[] spawnPoints; // точки респавна
    public float[] spawnChances; // вероятности появления для каждого объекта
    public float spawnTimeMin = 1f; // минимальное время между спавнами
    public float spawnTimeMax = 5f; // максимальное время между спавнами

    private int lastSpawnPointIndex = -1; // Индекс последней точки респавна

    private void Start()
    {
        StartCoroutine(CheckAndSpawn());
    }

    private IEnumerator CheckAndSpawn()
    {
        while (true) // Бесконечный цикл для постоянной проверки
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectsToSpawn.Length != spawnChances.Length)
        {
            Debug.LogError("Ошибка: массивы objectsToSpawn и spawnChances должны быть одинаковой длины!");
            return;
        }

        float totalChance = 0f;
        foreach (var chance in spawnChances)
        {
            totalChance += chance;
        }

        float randomPoint = Random.Range(0, totalChance);
        int objectIndex = 0;

        for (float currentChance = spawnChances[0]; objectIndex < spawnChances.Length - 1; objectIndex++)
        {
            if (randomPoint < currentChance)
                break;

            currentChance += spawnChances[objectIndex + 1];
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Проверяем, чтобы новая точка респавна не совпадала с последней использованной
        while (spawnPointIndex == lastSpawnPointIndex)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
        }

        lastSpawnPointIndex = spawnPointIndex; // Обновляем последнюю использованную точку респавна

        // Проверяем, свободна ли точка респавна
        if (IsSpawnPointFree(spawnPointIndex))
        {
            Vector3 spawnDirection = spawnPoints[spawnPointIndex].forward; // Получаем направление по оси Z от точки респавна
            Instantiate(objectsToSpawn[objectIndex], spawnPoints[spawnPointIndex].position, Quaternion.LookRotation(spawnDirection));
        }
        else
        {
            // Если точка респавна занята, ждем 1.5 секунды и повторяем попытку
            StartCoroutine(WaitAndRetrySpawn(objectIndex));
        }
    }

    private IEnumerator WaitAndRetrySpawn(int objectIndex)
    {
        yield return new WaitForSeconds(1.5f); // Задержка перед повторной попыткой спавна
        SpawnObject(); // Повторная попытка спавна
    }

    private bool IsSpawnPointFree(int spawnPointIndex)
    {
        // Получаем позицию точки респавна
        Vector3 spawnPointPosition = spawnPoints[spawnPointIndex].position;

        // Находим все объекты со скриптом MouseMove в сцене
        MouseMove[] allMouseMoveObjects = FindObjectsOfType<MouseMove>();

        // Проверяем каждый объект со скриптом MouseMove
        foreach (var mouseMoveObject in allMouseMoveObjects)
        {
            // Если какой-либо объект MouseMove находится в точке респавна, возвращаем false
            if (mouseMoveObject.transform.position == spawnPointPosition)
            {
                return false;
            }
        }

        // Если ни один объект MouseMove не находится в точке респавна, возвращаем true
        return true;
    }
}