using UnityEngine;
using UnityEngine.UI;
using System;

public static class Log
{
    #region Text format
    public static Color ColorLog = Color.black;
    public static Color ColorWaring = Color.yellow;
    public static Color ColorError = Color.red;
    #endregion

    public static Text TextUI = null;
    public static Scrollbar Scrollbar = null;
    public static bool IsConsole = true;

    private const string ColorTextFormate = "<color=\"#{0}\">{1}</color>\n";

    public enum TextMode
    {
        Append,
        Write,
    }

    public static void L(string message, Color color = default(Color), TextMode mode = TextMode.Append)
    {
        if(color == default(Color)) 
            color = ColorLog;

        ShowUI(message, color, mode);

        if(IsConsole)
            Debug.Log(message);
    }

    public static void W(string message, Color color = default(Color), TextMode mode = TextMode.Append)
    {
        if (color == default(Color))
            color = ColorWaring;

        ShowUI(message, color, mode);

        if (IsConsole)
            Debug.LogWarning(message);
    }

    public static void E(string message, Color color = default(Color), TextMode mode = TextMode.Append)
    {
        if (color == default(Color))
            color = ColorError;

        ShowUI(message, color, mode);

        if (IsConsole)
            Debug.LogError(message);
    }

    private static void ShowUI(string message, Color color, TextMode mode)
    {
        var htmlColor = ColorUtility.ToHtmlStringRGB(color);
        message = String.Format(ColorTextFormate, htmlColor,
                         message);
        if (TextUI != null)
        {
            switch (mode)
            {
                case TextMode.Append:
                    TextUI.text += message;
                    break;
                case TextMode.Write: 
                    TextUI.text = message; 
                    break;
                default:
                    TextUI.text += message;
                    break;
            }
        }
        if (Scrollbar != null)
            Scrollbar.value = 0;
    }

}
