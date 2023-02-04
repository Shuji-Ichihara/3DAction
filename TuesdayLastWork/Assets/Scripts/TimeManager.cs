using UnityEngine;
using UnityEngine.UI;

public class TimeManager : SingletonMonoBehaviour<TimeManager>
{
    public static float CountUpTIme { get; private set; } = 0.0f;

    private Text _timeText = null;

    // Start is called before the first frame update
    void Start()
    {
        _timeText = GameObject.Find("Timer").GetComponent<Text>();
        CountUpTIme = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CountUpTIme += Time.deltaTime;
        //_timeText.text = CountUpTIme.ToString(string.Format("{0:##.##}", CountUpTIme));
    }
}
