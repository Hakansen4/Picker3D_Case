using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour,IPoolable
{
    private AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public AudioSource GetAudioSource()
    {
        return audio;
    }

    public void StartTimer(ObjectPool<AudioSourceController> pool)
    {
        float time = audio.clip.length;
        StartCoroutine(SoundFinished(time, pool));
    }
    public void StartTimer(ObjectPool<AudioSourceController> pool, float time)
    {
        StartCoroutine(SoundFinished(time, pool));
    }
    private IEnumerator SoundFinished(float Time, ObjectPool<AudioSourceController> pool)
    {
        yield return new WaitForSeconds(Time);
        pool.ObjectDeactivated(this);
        DeActivate();
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }
}
