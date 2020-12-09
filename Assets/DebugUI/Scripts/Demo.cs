using UnityEngine;

using DebugUIAssets;

namespace TMuranaga
{
  public class Demo : MonoBehaviour
  {
    public int test_field = 0;

    void Start()
    {
      Page page = DebugCanvas.Instance.CreatePage("child");
      DebugCanvas.Instance.PushEditInt32(page, "test_filed", () => test_field, value => test_field = value);
      DebugCanvas.Instance.PushPrevTransPage(page);
    }
  }
}