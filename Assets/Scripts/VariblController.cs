using System.Collections.Generic;
using UnityEngine;

public class VariblController : MonoBehaviour
{
    [SerializeField] private List<Varibl> _varibls = new List<Varibl>();
    public IList<Varibl> Varibls => _varibls;

    private void Start()
    {
        foreach (var item in _varibls)
        {
            item.Init();
        }
    }
}
