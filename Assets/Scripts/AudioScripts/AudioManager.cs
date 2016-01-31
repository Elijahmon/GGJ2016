using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour {

    
    [SerializeField]
    protected AudioSource source;

    /// <summary>
    /// Plays the supplied sound effect with 
    /// </summary>
    /// <param name="clip">SoudEffect clip to play</param>
    /// <param name="volume">Volume to play the clip at (optional - deafult is .5)</param>
    /// <param name="delay">Delay for playing the clip (optional - default is 0)</param>
    public virtual void PlaySoundEffect(AudioClip clip, float volume = .5f, int delay = 0)
    {
        if(clip == null)
        {
            Debug.LogWarning("Given Clip is null");
            return;
        }
        if (clip == source.clip)
        {
            return;
        }
        if(source.isPlaying)
        {
            source.Stop();
        }
        if(source == null)
        {
            Debug.LogWarning("Creating Runtime AudioSource for " + this.name);
            source = this.gameObject.AddComponent<AudioSource>();
        }
        source.loop = false;
        source.volume = volume;
        source.clip = clip;
        source.PlayDelayed(delay);
        StartCoroutine(ResetClip(delay));
    }
    IEnumerator ResetClip(int d)
    {
        yield return new WaitForSeconds(source.clip.length + d);
        source.clip = null;
    }
    
    public virtual void StopSoundEffect()
    {
        source.Stop();
        source.clip = null;
    }
}
