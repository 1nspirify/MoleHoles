using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAdditionEvents : MonoBehaviour
{
    // Reference to TimeSpeedUp
    
    public GameObject Prefab;
    public AudioClip audioClip;

    private void Start()
    {
       
        GetComponent<ObjectInterAction>().OnObjectTapped += HandleObjectTapped;
    }

    // Override the HandleObjectTapped method
    public void HandleObjectTapped()
    {

        
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
