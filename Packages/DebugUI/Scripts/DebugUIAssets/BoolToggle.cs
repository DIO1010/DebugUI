using System;

namespace DebugUIAssets
{
  public class BoolToggle : IControl
  {
    Func<bool> GetValue = default;
    Action<bool> SetValue = default;

    public void Init(in string name, Func<bool> getter, Action<bool> setter)
    {
      GetValue = getter;
      SetValue = setter;
      this.name = name;
      SetText(getter());
    }

    protected override void OnUpdate()
    {
      if(IsDicision())
      {
        bool value = !GetValue();
        SetText(value);
        SetValue(value);
      }
    }

    void SetText(in bool value) => text = $"[V]{name}:{(value ? "O" : "X")}";
  }
}
