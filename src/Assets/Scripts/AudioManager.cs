using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip explosionClip;
    private AudioClip shotClip;
    private AudioClip scoreClip;

    private void Start()
    {        
        audioSource = GetComponent<AudioSource>();
    }

    public void DoAudioShot()
    {
        shotClip = Resources.Load<AudioClip>(string.Format("{0}", GetShotSoundName()));
        audioSource.clip = shotClip;
        audioSource.Play();
    }

    public void DoAudioExplosion()
    {
        explosionClip = Resources.Load<AudioClip>(string.Format("{0}", GetExplosionSoundName()));
        audioSource.clip = explosionClip;
        audioSource.Play();
    }

    public void DoPlayAudio(string audioPath)
    {
        var clip = Resources.Load<AudioClip>(audioPath);
        audioSource.PlayOneShot(clip);
    }

    private string GetExplosionSoundName()
    {
        var rndSound = UnityEngine.Random.Range(0, 4);
        switch (rndSound)
        {
            case 0:
                return "Sounds/expl01";
            case 1:
                return "Sounds/expl02";
            case 2:
                return "Sounds/expl03";
            case 3:
                return "Sounds/expl04";
            default:
                throw new System.ArgumentException("sound missing");
        }
    }

    private string GetShotSoundName()
    {
        var rndSound = UnityEngine.Random.Range(0, 8);
        switch (rndSound)
        {
            case 0:
                return "Sounds/shot01";
            case 1:
                return "Sounds/shot02";
            case 2:
                return "Sounds/shot03";
            case 3:
                return "Sounds/shot04";
            case 4:
                return "Sounds/shot05";
            case 5:
                return "Sounds/shot06";
            case 6:
                return "Sounds/shot07";
            case 7:
                return "Sounds/shot08";
            default:
                throw new System.ArgumentException("sound missing");
        }
    }
}
