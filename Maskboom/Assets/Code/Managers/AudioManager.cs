using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Punches;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AudioManager>();

            return _instance;
        }
    }

    private static AudioManager _instance;

    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySoundFx(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

    public void PlayRandomPunch()
    {
        var index = Random.Range(0, Punches.Length);
        PlaySoundFx(Punches[index]);
    }
}
