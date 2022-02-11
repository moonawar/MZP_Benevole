using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public BGM[] bgms; float nextSongTime;
    public SFX[] sfxs;

    private void Awake() {
        foreach (BGM b in bgms)
        {
            b.source = gameObject.AddComponent<AudioSource>();
            b.source.clip = b.clip;

            b.source.volume = b.volume;
        }

        foreach (SFX s in sfxs)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }

    }

    public void PlaySound(string name){
        BGM b = Array.Find(bgms, bgm => bgm.name == name);
        if (b == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return; 
        }
        b.source.Play();
    }

    public void PlaySFX(string name){
        SFX s = Array.Find(sfxs, s => s.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return; 
        }
        s.source.Play();
    }
       private void Update() {
        if (Time.time > nextSongTime)
        {
            int i = UnityEngine.Random.Range(0, bgms.Length);
            FindObjectOfType<AudioManager>().PlaySound(bgms[i].name);
            nextSongTime = Time.time + bgms[i].clip.length + 2;
        }
    }
    

}
