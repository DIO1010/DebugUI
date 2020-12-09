using UnityEngine;
using UnityEngine.UI;

public abstract class IControl : Text
{
  public bool IsSelect { get; set; } = false;

  public Color UnSelectColor = new Color(0, 0, 0);
  public Color SelectColor = new Color(1, 1, 1);

  private void Update()
  {
    color = IsSelect ? SelectColor : UnSelectColor;
    OnUpdate();
  }

  protected bool IsDicision() => Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return);
  protected bool IsLeft() => Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.W);
  protected bool IsRight() => Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
  protected bool IsShift() => Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift);

  protected virtual void OnUpdate() { }
}
