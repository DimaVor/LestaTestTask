using UnityEngine;

public class MusicMute : MuteButton
{
    [SerializeField] private AudioSource _audioSource;

    protected override void MuteCheck()
    {
        if (GlobalSettings.IsMusicMuted()) ChangeMute();
    }

    protected override void MuteComponent()
    {
        _audioSource.mute = _isMuted;
        GlobalSettings.ChangeMusicMuted();
    }
}
