using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    public static float CountUpTIme { get; private set; } = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CountUpTIme = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CountUpTIme += Time.deltaTime;
    }
}
