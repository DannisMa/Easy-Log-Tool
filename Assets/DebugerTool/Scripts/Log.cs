using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public static class Log
{
    #region Text format
    public static Color ColorLog = Color.black;
    public static Color ColorWaring = Color.yellow;
    public static Color ColorError = Color.red;
    #endregion

    public static Text TextUI = null;
    public static TMP_Text TextTMPUI = null;
    public static bool IsConsole = true;

    private const string ColorTextFormate = "<color=\"#{0}\">{1}</color>\n";

    public static void L(string message, Color color = default(Color))
    {
        if(color == default(Color)) 
            color = ColorLog;

        ShowUI(message, color);

        if(IsConsole)
            Debug.Log(message);
    }

    public static void W(string message, Color color = default(Color))
    {
        if (color == default(Color))
            color = ColorWaring;

        ShowUI(message, color);

        if (IsConsole)
            Debug.LogWarning(message);
    }

    public static void E(string message, Color color = default(Color))
    {
        if (color == default(Color))
            color = ColorError;

        ShowUI(message, color);

        if (IsConsole)
            Debug.LogError(message);
    }

    private static void ShowUI(string message, Color color)
    {
        var htmlColor = ColorUtility.ToHtmlStringRGB(color);
        message = String.Format(ColorTextFormate, htmlColor,
                         message);
        if (TextUI != null)
        {
            TextUI.text += message;
        }
        if (TextTMPUI != null)
        {
            TextTMPUI.text += message;
        }
    }

}
