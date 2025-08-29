using UnityEngine;

namespace Swinie.Audio
{
    [CreateAssetMenu(fileName = "Audio Asset", menuName = "Audio/Audio Asset", order = 0)]
    public class AudioAsset : ScriptableObject
    {
        public AudioClip clip;
        public float volume = 1f;
        public float pitch = 1f;
        public float pitchVariation;

        public void PlayOnSource(AudioSource source)
        {
            source.clip = clip;
            source.volume = volume;
            source.pitch = pitch + Random.Range(-pitchVariation, pitchVariation);
            source.Play();
        }
    }
}