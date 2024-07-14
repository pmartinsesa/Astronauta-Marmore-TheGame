using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Sound
{
    public class SoundBase : MonoBehaviour
    {
        [Header("Audio Settings")]
        public List<AudioClip> audioClips;
        public AudioSource defaultAudioSource;
        public AudioMixerGroup defaultAudioMixerGroup;

        public void OnPlay()
        {
            OnPlayMultipleSounds(defaultAudioSource, audioClips[Random.Range(0, audioClips.Count - 1)]);
        }

        public void OnPlayMultipleSounds(AudioSource source, AudioClip clip)
        {
            if(!source.isPlaying)
            {
                PlaySound(source, clip);
                return;
            }

            var newAudioSource = gameObject.AddComponent<AudioSource>();
            PlaySound(newAudioSource, clip);
            Destroy(newAudioSource, 1.5f);
        }

        private void PlaySound(AudioSource source, AudioClip clip)
        {
            source.outputAudioMixerGroup = defaultAudioMixerGroup;
            source.clip = clip;
            source.Play();
        }
    }
}
