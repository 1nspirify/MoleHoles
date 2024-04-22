using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public List<GameObject> hats; // Список шапок
    private Dictionary<Transform, GameObject> hatDictionary = new Dictionary<Transform, GameObject>();

    private void Update()
    {
        // Обновляем шапки только для активных объектов с компонентом TargetForHat
        foreach (KeyValuePair<Transform, GameObject> kvp in hatDictionary)
        {
            if (kvp.Key.gameObject.activeInHierarchy)
            {
                kvp.Value.SetActive(true);
                kvp.Value.transform.position = kvp.Key.position; // Помещаем шапку на место объекта TargetForHat
            }
            else
            {
                kvp.Value.SetActive(false);
            }
        }
    }

    private void Start()
    {
        // Создаем словарь, где ключ - Transform объекта с дочерним TargetForHat, а значение - шапка
        foreach (Transform child in transform)
        {
            TargetForHat targetForHat = child.GetComponent<TargetForHat>();
            if (targetForHat != null)
            {
                GameObject randomHat = GetRandomHat();
                hatDictionary[child] = randomHat;
                randomHat.SetActive(false); // Начально отключаем все шапки
            }
        }
    }

    private GameObject GetRandomHat()
    {
        // Возвращает случайную шапку из списка
        int randomIndex = Random.Range(0, hats.Count);
        return hats[randomIndex];
    }
}