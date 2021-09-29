using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomChance
{
    public static bool GetThisChanceResult(float Chance)
    {
        if (Chance < 0.0000001f)
        {
            Chance = 0.0000001f;
        }

        bool Success = false;
        int RandAccuracy = 10000000;
        float RandHitRange = Chance * RandAccuracy; //30 * 100 3000
        int Rand = UnityEngine.Random.Range(1, RandAccuracy + 1); //1~100
        if(Rand <= RandHitRange) // 5 <= 3000
        {
            Success = true;
        }
        return Success;
    }
    
}
