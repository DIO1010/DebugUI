using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

namespace DebugUIAssets
{
  public class LoggerText : Text
  {
    const int MAX_LINES = 34;

    [NonSerialized] public bool canShowTrace = false;

    protected override void Awake()
    {
      Clear();
    }

    public void AddText(DateTime now, string condition, string stackTrace, LogType type)
    {
      string buf = text + Format(condition, stackTrace, type);
      if ((buf.Count(c => c == '\n') is int line) && line > MAX_LINES)
      {
        int remove_lines = line - MAX_LINES;
        int startIndex = buf.IndexOf('\n');
        for (int i = 1; i < remove_lines; ++i)
          startIndex = buf.IndexOf('\n', startIndex + 1);
        buf = buf.Substring(startIndex + 1);
      }
      text = buf;
    }

    public void Clear()
    {
      text = "";
    }

    string Format(string condition, string stackTrace, LogType type)
    {
      if (!canShowTrace) return $"[!{type,-10}!]{condition}\n";
      stackTrace = stackTrace.Replace("\n", "\n\t");
      stackTrace = stackTrace.Remove(stackTrace.LastIndexOf("\n\t")) + "\n";
      return $"[!{type,-10}!]{condition}\n\t{stackTrace}";
    }
  }
}
