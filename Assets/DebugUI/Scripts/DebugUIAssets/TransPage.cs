using UnityEngine;
using UnityEngine.UI;

namespace DebugUIAssets
{
  public class TransPage : IControl
  {
    public enum TransType
    {
      Prev,
      Next,

      None,
    }

    Page _current = null;
    Page _next = null;
    TransType _type = TransType.None;

    public void Init(in Page current, in Page next)
    {
      _current = current;
      _next = next;
      _type = TransType.Next;
    }

    public void Init(in Page current)
    {
      _current = current;
      _type = TransType.Prev;
    }

    public void OnClick()
    {
      if (!_current)
      {
        Debug.LogError("Init関数が呼ばれていません");
        return;
      }

      switch (_type)
      {
        case TransType.Prev:
          {
            _current.ChangePrevPage();
            break;
          }
        case TransType.Next:
          {
            _current.ChangeNextPage(_next);
            break;
          }
      }
    }

    protected override void OnUpdate()
    {
      if (IsSelect && IsDicision())
      {
        OnClick();
      }
    }
  }
}// namespace DebugUIAssets
