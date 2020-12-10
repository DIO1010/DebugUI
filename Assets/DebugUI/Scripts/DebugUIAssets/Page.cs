using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DebugUIAssets
{
  public class Page : MonoBehaviour
  {
    List<IControl> _children = new List<IControl>();
    int _index = 0;

    [SerializeField] Text _title = null;

    public Page Parent { get; private set; } = null;

    public string Title
    {
      get
      {
        return name;
      }
      set
      {
        _title.text = value;
        name = value;
      }
    }

    public void Init(in Page parent)
    {
      Parent = parent;
    }

    public void AddChild(in IControl child)
    {
      if (_children.Count == 0) child.IsSelect = true;
      _children.Add(child);
      child.transform.SetParent(transform);
    }

    public void ChangeNextPage(in Page next)
    {
      gameObject.SetActive(false);
      next.gameObject.SetActive(true);
    }

    public void ChangePrevPage()
    {
      gameObject.SetActive(false);
      Parent.gameObject.SetActive(true);
    }

    private void Update()
    {
      if (_children.Count == 0) return;
      if (!_children[_index].IsMoveMenu()) return;

      if (Input.GetKeyDown(KeyCode.UpArrow))
        ChageIndex(false);
      if (Input.GetKeyDown(KeyCode.DownArrow))
        ChageIndex(true);
    }

    void ChageIndex(bool is_add)
    {
      _children[_index].IsSelect = false;
      _index = (_index + (is_add ? 1 : -1) + _children.Count) % _children.Count;
      _children[_index].IsSelect = true;
    }
  }
}