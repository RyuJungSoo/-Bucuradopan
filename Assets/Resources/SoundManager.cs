using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public AudioSource backGroundSound;
    public AudioSource effectSound;

    public GameObject[] audioSoundPrefab; // �پ��� ȿ����
    

    public void PlayBackGroundSound(AudioClip audioClip)
    {
        backGroundSound.Pause();

        backGroundSound.clip = audioClip;

        backGroundSound.Play();

    }

    // ȿ������ ����ϴ� �޼���
    public void PlayEffectSound(int idx)
    {
        // AudioSource �������� �ν��Ͻ��� ����
        GameObject effectSource = Instantiate(audioSoundPrefab[idx], transform);
        AudioSource audioSource = effectSource.GetComponent<AudioSource>();

        //�ɼǿ��� ������ ���� ũ�⸸ŭ ȿ���� ���
        audioSource.volume = effectSound.volume;

        audioSource.Play();

        // ȿ���� ����� ������ �ν��Ͻ� �ı�
        Destroy(effectSource, audioSource.clip.length);
    }

}
