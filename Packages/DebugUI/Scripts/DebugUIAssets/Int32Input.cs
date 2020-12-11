using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DebugUIAssets
{
  public class Int32Input : IControl
  {
    public const int DEFAULT_DELTA = 1;
    public const int DEFAULT_SHIFT_DELTA = 10;

    Func<int> GetValue = null;
    Action<int> SetValue = null;
    int _delta = 1;
    int _shift_delta = 10;

    public void Init(in string name, Func<int> getter, Action<int> setter, in int delta, in int shift_delta)
    {
      GetValue = getter;
      SetValue = setter;
      _delta = delta;
      _shift_delta = shift_delta;
      this.name = name;
      SetText(getter());
    }

    protected override void OnUpdate()
    {
      if (IsRight())
        ChangeValue(true);
      if (IsLeft())
        ChangeValue(false);
    }

    void ChangeValue(bool is_add)
    {
      int value = GetValue() + (is_add ? 1 : -1) * (IsShift() ? _shift_delta : _delta);
      SetText(value);
      SetValue(value);
    }

    void SetText(in int value) => text = $"[V]{name}:{value}";
  }
}
