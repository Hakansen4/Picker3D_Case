using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Manager
{
    public class AudioManager : MonoBehaviour
    {

        public static AudioManager instance;

        [SerializeField]
        public Sound[] _Sounds;
        [SerializeField]
        private int _AmountOfSourcePool;
        [SerializeField]
        private GameObject _AudioSourcePrefab;
        string[] soundsNames;
        ObjectPool<AudioSourceController> audioSourcePool;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Init();
            }
            else
                Destroy(gameObject);
        }
        private void Init()
        {
            audioSourcePool = new ObjectPool<AudioSourceController>(_AmountOfSourcePool, _AudioSourcePrefab);
            soundsNames = new string[_Sounds.Length];
            for (int i = 0; i < _Sounds.Length; i++)
            {
                soundsNames[i] = _Sounds[i].name;
            }
        }

        public void ChangeActivity(string soundName)
        {
            for (int i = 0; i < _Sounds.Length; i++)
            {

                if (_Sounds[i].name == soundName)
                {
                    _Sounds[i].changeActivity();

                    return;
                }
            }

            //no sound with _name
            Debug.LogWarning("AudioComponent: Sound not found in list" + soundName);

        }

        public void PlaySound(string soundName)
        {
            for (int i = 0; i < _Sounds.Length; i++)
            {

                if (_Sounds[i].name == soundName)
                {
                    if (!_Sounds[i].checkActivity())
                        return;

                    var Source = audioSourcePool.GetPooledObject();
                    _Sounds[i].SetSource(Source.GetAudioSource());
                    _Sounds[i].Play();
                    Source.StartTimer(audioSourcePool);
                    return;
                }
            }

            //no sound with _name
            Debug.LogWarning("AudioComponent: Sound not found in list" + soundName);

        }

        public void PlayMusic(string musicName)
        {
            for (int i = 0; i < _Sounds.Length; i++)
            {
                if (_Sounds[i].name == musicName)
                {
                    if (!_Sounds[i].checkActivity())
                    {
                        _Sounds[i]?.source.gameObject.GetComponent<AudioSourceController>().StartTimer(audioSourcePool, 0.1f);
                        return;
                    }

                    _Sounds[i].SetSource(audioSourcePool.GetPooledObject().GetAudioSource());
                    _Sounds[i].Play();
                    _Sounds[i].source.loop = true;

                    return;
                }
            }
        }

        public void AudioControl(float audioVolume)
        {
            for (int i = 0; i < _Sounds.Length; i++)
            {
                if (audioVolume == 0f)
                {
                    _Sounds[i].Stop();
                }

                else
                {
                    _Sounds[i].source.volume = audioVolume;
                }

            }
        }
    }
}
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
    private bool isActive;

    public void changeActivity()
    {
        isActive = !isActive;
    }

    public bool checkActivity()
    {
        return isActive;
    }
    public void SetSource(AudioSource audioSource)
    {
        source = audioSource;
        source.clip = clip;
        source.volume = 0.2f;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
        source.gameObject.GetComponent<IPoolable>().DeActivate();
    }


}