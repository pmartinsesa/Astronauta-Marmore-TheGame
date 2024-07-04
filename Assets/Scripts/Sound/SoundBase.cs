using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundBase : MonoBehaviour
    {
        [Header("Audio Settings")]
        public List<AudioClip> audioClips;
        public AudioSource audioSource;

        public void OnPlay()
        {
            OnPlayWithAudioSource(audioSource, audioClips[Random.Range(0, audioClips.Count - 1)]);
        }

        public void OnPlayWithAudioSource(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
