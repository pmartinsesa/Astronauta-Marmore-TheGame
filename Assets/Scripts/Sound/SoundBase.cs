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
            audioSource.clip = audioClips[Random.Range(0, audioClips.Count - 1)];

            Debug.Log(audioSource.clip);

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
