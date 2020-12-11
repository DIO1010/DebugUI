using System;

namespace DebugUIAssets
{
  public class NoArgsAction : IControl
  {
    Action _action = null;

    public void Init(in string name, Action action)
    {
      this.name = name;
      _action = action;
      SetText();
    }

    protected override void OnUpdate()
    {
      if (IsDicision()) _action();
    }

    public void SetText() => text = $"[F]{name}()";
  }
}
