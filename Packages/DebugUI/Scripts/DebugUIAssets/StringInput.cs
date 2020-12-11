using System;

namespace DebugUIAssets
{
  public partial class StringInput : IControl
  {
    Action<string> SetValue = null;
    string _buf = "";
    string _old = "";

    public void Init(in string name, Action<string> setter, in string default_str)
    {
      SetValue = setter;
      _buf = default_str;
      _old = default_str;
      this.name = name;
      SetText(default_str);
    }

    protected override void OnUpdate()
    {
      StateUpdate();
      SetText(_buf);
    }

    void SetText(in string str) => text = $"[V]{name}:{str}";
  }
}
