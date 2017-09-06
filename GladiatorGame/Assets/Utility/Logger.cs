using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{

    // ログの記録
    //private static List<string> logMsg_ = new List<string>();
    private static Hashtable logMsg_ = new Hashtable();
    private static int logCnt_;
    public static int Log(string argMeg)
    {
        logMsg_.Add(logCnt_++, argMeg);
        return logCnt_;
    }
    public static void RemoveLog(int argIndex)
    {
        logMsg_.Remove(argIndex - 1);
    }

    // 記録されたログを画面出力する
    void OnGUI()
    {
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);

        // フォントサイズを10px,白文字にする。
        // styleのnewは遅いため、本来はStart()で実施すべき...
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.fontStyle = FontStyle.Normal;
        style.normal.textColor = Color.white;

        // 出力された文字列を改行でつなぐ
        string outMessage = "";
        foreach (string msg in logMsg_.Values)
        {
            outMessage += msg + System.Environment.NewLine;
        }

        // 改行でつないだログメッセージを画面に出す
        GUI.Label(rect, outMessage, style);
    }
}
