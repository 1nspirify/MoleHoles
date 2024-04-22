using System.Collections.Generic;
using UnityEngine;

public class TargetForHat : MonoBehaviour
{
    public List<GameObject> hats; // Список шапок
    public GameObject Target;
    private GameObject currentHat; // Ссылка на текущую шапку

    private void Start()
    {
        SetRandomHat();
    }

    private void SetRandomHat()
    {
        if (hats.Count > 0)
        {
            // Выбираем случайную шапку из списка
            GameObject randomHat = hats[Random.Range(0, hats.Count)];

            // Создаем экземпляр выбранной шапки и сохраняем ссылку на нее
            currentHat = Instantiate(randomHat, Target.transform.position, Quaternion.identity);
           
        }
        else
        {
            Debug.LogWarning("No hats available for TargetForHat.");
        }
    }

    private void Update()
    {
        // Проверяем, что шапка существует и следим за позицией цели Target
        if (currentHat && Target)
        {
            currentHat.transform.position = Target.transform.position;
            currentHat.transform.rotation = Target.transform.rotation;
            currentHat.transform.localScale = Target.transform.localScale;

           
        }
    }

    private void OnDestroy()
    {
        // Уничтожаем текущую шапку при удалении родительского объекта
        Destroy(currentHat);
    }
}
