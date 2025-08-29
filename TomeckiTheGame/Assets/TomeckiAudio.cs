using NUnit.Framework;
using Swinie.Audio;
using System.Collections.Generic;
using UnityEngine;

public class TomeckiAudio : MonoBehaviour
{
    [SerializeField] List<AudioSource> audioSources;
    [SerializeField] AudioAsset shot;
    [SerializeField] AudioAsset baton;
    [SerializeField] AudioAsset money;
    [SerializeField] AudioAsset bread;


    public void PlayOnEmptyPlayer(EnemyType type)
    {
        foreach (var source in audioSources)
        {
            if(!source.isPlaying)
            {
                if (type == EnemyType.Traitor)
                    shot.PlayOnSource(source);
                else if (type == EnemyType.Villager)
                    bread.PlayOnSource(source);
                else if (type == EnemyType.Jews)
                    money.PlayOnSource(source);
                else if(type == EnemyType.Worker)
                    baton.PlayOnSource(source);
                    return;
            }    
        }
    }
}
