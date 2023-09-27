using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField] private Text text;

    private Coroutine showCurrentTime;

    // Start is called before the first frame update
    void Start()
    {
        Log.TextUI = text;
        Log.IsConsole = false;
        showCurrentTime = StartCoroutine(CurrentTime());
    }

    IEnumerator CurrentTime()
    {
        while (true)
        {
            Log.L(Time.time.ToString());
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
