using UnityEngine;

namespace DebugUIAssets
{
  public partial class StringInput : IControl
  {
    public enum StringInputState
    {
      Select,
      Edit,
    }

    StringInputState _state = StringInputState.Select;

    public override bool IsMoveMenu()
    {
      return _state == StringInputState.Select;
    }

    void StateUpdate()
    {
      switch(_state)
      {
        case StringInputState.Select:
          {
            SelectUpdate();
            break;
          }
        case StringInputState.Edit:
          {
            EditUpdate();
            break;
          }
      }
    }

    void SelectUpdate()
    {
      if (IsDicision())
      {
        _old = _buf;
        ChangeState();
      }
    }

    void EditUpdate()
    {
      foreach (char c in Input.inputString)
      {
        if (c == '\b' && _buf.Length != 0)
        {
          _buf = _buf.Substring(0, _buf.Length - 1);
        }
        else if(0x20 <= c && c <= 0x7e)
        {
          _buf += c;
        }
      }

      if(Input.GetKeyDown(KeyCode.Escape)
        || Input.GetKeyDown(KeyCode.UpArrow)
        || Input.GetKeyDown(KeyCode.DownArrow))
      {
        _buf = _old;
        SetValue(_buf);
        ChangeState();
      }
      else if(Input.GetKeyDown(KeyCode.Return))
      {
        SetValue(_buf);
        ChangeState();
      }
    }

    void ChangeState()
    {
      switch(_state)
      {
        case StringInputState.Select:
          {
            _state = StringInputState.Edit;
            return;
          }
        case StringInputState.Edit:
          {
            _state = StringInputState.Select;
            break;
          }
      }
    }
  }
}
