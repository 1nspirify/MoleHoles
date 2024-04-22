using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAdditionEvents : MonoBehaviour
{
    // Reference to PointsCollector
    public PointsCollector PointsCollector;
    public GameObject Prefab;
    public AudioClip AudioClip;
    public GameObject HammerPrefab;


    private void Start()
    {
        PointsCollector = FindObjectOfType<PointsCollector>();
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    // Override the HandleObjectTapped method
    public void HandleObjectTapped()
    {
        Instantiate(HammerPrefab, transform.position, Quaternion.identity);
        PointsCollector.PointsAdd();
        PlaySound();
        Destroy(Prefab);
    }

    // Создаем временный объект для воспроизведения звука
    private void PlaySound()
    {
        GameObject tempAudioObject = new GameObject("TempAudio");
        AudioSource audioSource = tempAudioObject.AddComponent<AudioSource>();
        audioSource.clip = AudioClip;
        audioSource.volume = 0.3f; // Устанавливаем громкость на 0.3
        audioSource.pitch = Random.Range(0.7f, 0.9f); // Устанавливаем случайный pitch в диапазоне от 0.95 до 1.05
        audioSource.Play();

        // Уничтожаем временный объект после воспроизведения звука
        Destroy(tempAudioObject, AudioClip.length);
    }
}
