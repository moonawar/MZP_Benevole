using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class BGM
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector] public AudioSource source;
}

[System.Serializable]
public class SFX
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [HideInInspector] public AudioSource source;
}