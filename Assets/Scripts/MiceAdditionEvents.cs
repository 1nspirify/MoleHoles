using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiceAdditionEvents : MonoBehaviour
{
    // Reference to PointsCollector
    public PointsCollector _pointsCollector;
    public GameObject Prefab;
    public AudioClip audioClip;

    private void Start()
    {
        _pointsCollector = FindObjectOfType<PointsCollector>();
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    // Override the HandleObjectTapped method
    public void HandleObjectTapped()
    {
         _pointsCollector.PointsAdd();
        PlaySound();
        Destroy(Prefab);
    }

    // ������� ��������� ������ ��� ��������������� �����
    private void PlaySound()
    {
        GameObject tempAudioObject = new GameObject("TempAudio");
        AudioSource audioSource = tempAudioObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = 0.3f; // ������������� ��������� �� 0.3
        audioSource.pitch = Random.Range(0.7f, 0.9f); // ������������� ��������� pitch � ��������� �� 0.95 �� 1.05
        audioSource.Play();

        // ���������� ��������� ������ ����� ��������������� �����
        Destroy(tempAudioObject, audioClip.length);
    }
}
