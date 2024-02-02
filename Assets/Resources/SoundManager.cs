using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{

    public AudioSource backGroundSound;
    public AudioSource effectSound;

    public GameObject[] audioSoundPrefab; // 다양한 효과음
    

    public void PlayBackGroundSound(AudioClip audioClip)
    {
        backGroundSound.Pause();

        backGroundSound.clip = audioClip;

        backGroundSound.Play();

    }

    // 효과음을 재생하는 메서드
    public void PlayEffectSound(int idx)
    {
        // AudioSource 프리팹의 인스턴스를 생성
        GameObject effectSource = Instantiate(audioSoundPrefab[idx], transform);
        AudioSource audioSource = effectSource.GetComponent<AudioSource>();

        //옵션에서 설정한 볼륨 크기만큼 효과음 재생
        audioSource.volume = effectSound.volume;

        audioSource.Play();

        // 효과음 재생이 끝나면 인스턴스 파괴
        Destroy(effectSource, audioSource.clip.length);
    }

}
