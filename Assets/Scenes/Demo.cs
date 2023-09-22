using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        Log.TextUI = text;
        Log.L("Test1");
        Log.W("Test2");
        Log.W("Test3", Color.green);
        Log.W("Test4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
