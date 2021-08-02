using UnityEngine;

public static class Difficulty
{
    static float secondToMaxDifficulty = 60;

    public static float GetDifficultyPercent()
    {
        // return 1;
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondToMaxDifficulty);
    }
}
