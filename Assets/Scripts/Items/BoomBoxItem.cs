using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used changes to the next song, when out of songs turns off, when used while off, plays first song.
/// 
/// TODO; It should auto play, randomise order potentially and go to next track when used.
///     In other words, act kind of like the radio in a GTA style game.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BoomBoxItem : InteractiveItem
    
{
    
    //TODO: you will need more data than this, like clips to play and a way to know which clip is playing
    protected AudioSource audioSource;
    public AudioClip[] songs;
    protected int curPlayerIndex = 0;
    protected bool isPlaying = false;
    protected override void Start()
    {
        base.Start();

        audioSource = GetComponent<AudioSource>();
        PlayClip();
        audioSource.loop = true;


        //TODO; prep the boom box
    }

    public void PlayClip()
    {
        audioSource.clip = songs[curPlayerIndex];
        audioSource.Play();

        //TODO; this is where you might want to setup and ensure the desire clip is playing on the source
    }

    public override void OnUse()
    {
        base.OnUse();
        curPlayerIndex++;

    if (curPlayerIndex >= songs.Length)
        {
            curPlayerIndex = 0;
            PlayClip();
        }
    else
        PlayClip();


        // audioSource.Stop();

        //TODO; this where we need to go to next track and start and stop playing
    }

        
}
