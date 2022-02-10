using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    bool onPlay; float nextSongTime;
    private void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return; 
        }
        s.source.Play;
    }

    private void Update() {
        if (Time.time > nextSongTime + 5)
        {
            int i = Random.Range(0, sounds.Length);
            PlaySound(sounds[i].name);
            
        }
    }
}
