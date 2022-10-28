public static class GlobalSettings
{
    private static bool _isGameMuted = false;
    private static bool _isMusicMuted = false;

    public static void ChangeGameMuted() => _isGameMuted = !_isGameMuted;
    public static void ChangeMusicMuted() => _isMusicMuted = !_isMusicMuted;
    public static bool IsGameMuted() => _isGameMuted;
    public static bool IsMusicMuted() => _isMusicMuted;
}