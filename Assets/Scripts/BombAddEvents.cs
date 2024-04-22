using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAddEvents : MonoBehaviour
{
    // Reference to PointsCollector
    public PointsCollector PointsCollector;
    public GameObject HammerPrefab;

    public GameObject Prefab;
    public AudioClip audioClip; // Используйте AudioClip вместо AudioSource

    private void Start()
    {
        PointsCollector = FindObjectOfType<PointsCollector>();
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    // Override the HandleObjectTapped method
    public void HandleObjectTapped()
    {
        Instantiate(HammerPrefab, transform.position, Quaternion.identity);
        PointsCollector.PointsRemove();
        PlaySound();
        Destroy(Prefab, 0.1f);
    }

    // Создаем временный объект для воспроизведения звука
    private void PlaySound()
    {
        GameObject tempAudioObject = new GameObject("TempAudio");
        AudioSource audioSource = tempAudioObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = 0.3f; // Устанавливаем громкость на 0.3
  
        audioSource.Play();

        // Уничтожаем временный объект после воспроизведения звука
        Destroy(tempAudioObject, audioClip.length);
    }
}
