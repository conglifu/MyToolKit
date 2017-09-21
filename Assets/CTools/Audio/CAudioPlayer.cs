using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CTool.Audio
{
	public class CAudioPlayer   
	{
		private static AudioSource audioSource = null;
		private CAudioPlayer(){}
		private static void InitAudioPlayer()
		{
			GameObject go = new GameObject ("CAudioPlayer");
			MonoBehaviour.DontDestroyOnLoad (go);
			audioSource = go.AddComponent<AudioSource> ();
			audioSource.volume = 1;
			audioSource.loop = false;
			audioSource.playOnAwake = false;
		}
		internal static AudioSource GetAudioSource()
		{
			if (audioSource == null)
				InitAudioPlayer ();
			return audioSource;
		}

		internal static void Play(AudioClip clip)
		{
			Play (clip, false, 1);
		}
		internal static void Play(AudioClip clip,bool isLoop)
		{
			Play (clip, isLoop, 1);
		}
		internal static void Play(AudioClip clip,bool isLoop,float volume)
		{
			if (audioSource == null)
				InitAudioPlayer ();
			if (audioSource.isPlaying)
				audioSource.Stop();
			audioSource.clip = clip;
			audioSource.loop = isLoop;
			audioSource.volume = Mathf.Clamp01 (volume);
			audioSource.Play ();
		}
		internal static void Pause()
		{
			if (audioSource == null||audioSource.clip==null)
				return;
			if (audioSource.isPlaying)
				audioSource.Pause ();
		}
		internal static void Resume()
		{
			if (audioSource == null || audioSource.clip == null || audioSource.isPlaying)
				return;
			audioSource.Play ();
		}
		internal static void Stop()
		{
			if(audioSource!=null)
				audioSource.Stop();
		}
		internal static void Destory()
		{
			if (audioSource != null) 
			{
				MonoBehaviour.Destroy(audioSource.gameObject);
				audioSource = null;
			}
		}
	}
}

