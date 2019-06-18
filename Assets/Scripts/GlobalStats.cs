using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : Singleton<GlobalStats>
{
    public IDictionary<string, float> stats = new Dictionary<string, float>(){
        {"health", 1f},
    };
}
