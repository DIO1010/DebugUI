using System;
using UnityEngine;

namespace DebugUIAssets
{
  public class DebugCanvas : MonoBehaviour
  {
    #region Singleton
    public static DebugCanvas Instance { get; private set; } = null;

    private void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
        Init();
        DontDestroyOnLoad(gameObject);
        return;
      }
      Destroy(gameObject);
    }
    #endregion

    [SerializeField] GameObject _page = null;
    [SerializeField] GameObject _trans_page = null;
    [SerializeField] GameObject _int_32_input = null;
    [SerializeField] GameObject _string_input = null;
    [SerializeField] GameObject _no_args_action = null;

    void Init()
    {
      Root = Instantiate(_page).GetComponent<Page>();
      Root.Init(null);
      Root.Title = "root";
      Root.transform.SetParent(transform, false);
    }

    public Page Root { get; private set; } = null;

    public Page CreatePage(in string title) => CreatePage(title, Root);

    public Page CreatePage(in string title, in Page parent)
    {
      Page page = Instantiate(_page).GetComponent<Page>();
      page.Init(parent);
      page.Title = title;
      page.transform.SetParent(transform, false);
      page.gameObject.SetActive(false);

      TransPage trans = Instantiate(_trans_page).GetComponent<TransPage>();
      trans.Init(parent, page);
      trans.text = $">>  {title}...";
      parent.AddChild(trans);

      return page;
    }

    public void PushPrevTransPage(in Page current)
    {
      TransPage trans = Instantiate(_trans_page).GetComponent<TransPage>();
      trans.Init(current);
      trans.text = $"<<  {current.Parent.Title}...";
      current.AddChild(trans);
    }

    public void PushEditInt32(
      in Page current, 
      in string name,
      in Func<int> getter,
      in Action<int> setter,
      in int delta = Int32Input.DEFAULT_DELTA,
      in int shift_delta = Int32Input.DEFAULT_SHIFT_DELTA)
    {
      Int32Input input = Instantiate(_int_32_input).GetComponent<Int32Input>();
      input.Init(name, getter, setter, delta, shift_delta);
      current.AddChild(input);
    }

    public void PushEditString(
      in Page current,
      in string name,
      in Action<string> setter,
      in string default_str)
    {
      StringInput input = Instantiate(_string_input).GetComponent<StringInput>();
      input.Init(name, setter, default_str);
      current.AddChild(input);
    }

    public void PushNoArgsAction(
      in Page current,
      in string name,
      in Action action)
    {
      NoArgsAction input = Instantiate(_no_args_action).GetComponent<NoArgsAction>();
      input.Init(name, action);
      current.AddChild(input);
    }
  }
}