using UnityEngine;

[System.Serializable]
public class AudioClipArray
{
    public AudioClip[] Clips;

    private int lastPlayedIndex = -1;

    public void PlayRandomAtPoint(Vector3 position)
    {
        Play(Random.Range(0, Clips.Length), position);
    }

    public void PlayNextAtPoint(Vector3 position)
    {
        Play((lastPlayedIndex + 1)%Clips.Length, position);
    }

    private void Play(int index, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(Clips[index], position);
        lastPlayedIndex = index;
    }


}