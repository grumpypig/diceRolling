using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    public BackgroundMusic MusicRestart;
    public AudioSource source;
    private static bool created = false;

    void Awake()
    {
        if (!created) 
            //This segment will make sure that this thing is always 
            //working and the object isn't destroyed and will destroy and created ones!
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PlayAudio(AudioClip music) //Play an audio on the first source!
    {
        source.Stop(); //Stop the current
        source.clip = music; //Switch the track
        source.Play(); //Play the new one!
    }
    void Update() //If music isn't playing get a random track from background music!
    {
        if (!audio.isPlaying)
        {
            MusicRestart.PlayRandom();
        }
    }
}
