using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] music;
    public MusicManager MusicManager;
    public int value;

    public void PlayRandom()
    {
        value = Random.Range(0, music.Length);//Randomise a random track and play it!
        MusicManager.PlayAudio(music[value]);
    }
}
