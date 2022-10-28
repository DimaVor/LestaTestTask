using UnityEngine;

public class SoundMute : MuteButton
{
    protected override void MuteCheck()
    {
        if (GlobalSettings.IsGameMuted()) ChangeMute();
    }

    protected override void MuteComponent()
    {
        AudioListener.volume = _isMuted ? 0 : 1;
        GlobalSettings.ChangeGameMuted();
    }
}
