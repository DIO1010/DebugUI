using UnityEngine;

using DebugUIAssets;

namespace TMuranaga
{
  public class Demo : MonoBehaviour
  {
    public int test_field = 0;
    public string test_str = "default";

    void Start()
    {
      Page page = DebugCanvas.Instance.CreatePage("child");
      DebugCanvas.Instance.PushEditInt32(page, "test_filed", () => test_field, value => test_field = value);
      DebugCanvas.Instance.PushEditString(page, "test_str", value => test_str = value, test_str);
      DebugCanvas.Instance.PushNoArgsAction(page, "TestAction", TestAction);
      DebugCanvas.Instance.PushPrevTransPage(page);
    }

    void TestAction()
    {
      print("call test action");
    }
  }
}