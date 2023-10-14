using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private TMP_Text textTMP;
    [SerializeField] private Scrollbar scrollbar;

    private Coroutine showCurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        Log.TextUI = text;
        Log.TMPTextUI = textTMP;
        Log.Scrollbar = scrollbar;
        Log.IsConsole = false;
        showCurrentTime = StartCoroutine(CurrentTime());
    }

    IEnumerator CurrentTime()
    {
        while (true)
        {
            Log.L(Time.time.ToString(),new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)),Log.TextMode.Append);
            yield return new WaitForSecondsRealtime(2.0f);
        }
    }

    private void OnDestroy()
    {
        if(showCurrentTime != null)
        {
            StopCoroutine(showCurrentTime);
            showCurrentTime = null;
        }
    }
}
