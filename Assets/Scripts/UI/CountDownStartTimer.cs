using System.Collections;
using TMPro;
using UnityEngine;


public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI StartText;

    private void Start()
    {
        // Устанавливаем TimeScale на 0 при старте
        Time.timeScale = 0f;

        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        int timeLeft = 3; // Начальное значение таймера

        // Пока оставшееся время больше или равно нулю
        while (timeLeft >= 1)
        {
            // Отображаем текущее время в текстовом поле
            countdownText.text = timeLeft.ToString();

            // Ждем одну секунду
            yield return new WaitForSecondsRealtime(1f);

            // Уменьшаем оставшееся время на одну секунду
            timeLeft--;
        }

        // После завершения обратного отсчета можно выполнить какие-либо действия
        // Например, запустить функцию, которая должна выполняться по завершении таймера
        Debug.Log("Время вышло!");
        countdownText.gameObject.SetActive(false);
        
        StartText.gameObject.SetActive(true);
        Destroy(StartText, 0.4f);
        
        

        // Включаем TimeScale до 1 после завершения корутины
        Time.timeScale = 1f;
    }
}
