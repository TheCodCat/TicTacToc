using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private VariblController _controller;
    [SerializeField] private List<Vector2> _positions = new List<Vector2>();

    private void Awake()
    {
         if(instance == null)
        {
            instance = this;
        }
         else Destroy(instance.gameObject);
    }

    public void SetPosition(Vector2 vector2)
    {
        int count = 0;
        _positions.Add(vector2);
        if (_positions.Count < 3) return;

        for (int i = 0; i < _controller.Varibls.Count; i++)
        {
            count = 0;
            for (int j = 0; j < _positions.Count; j++)
            {
                var result = _controller.Varibls[i].vector2s.Contains(_positions[j]);
                if (result) ++count;

                if (count == 3)
                {
                    Winner();
                    return;
                }
                else continue;
            }
        }
    }
    private void Winner()
    {
        Debug.Log(" то-то победил");
    }
}
