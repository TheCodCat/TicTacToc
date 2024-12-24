using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private VariblController _controller;
    [Header("Èãðîêè")]
    [SerializeField] private PlayerNumber _playerNumber;
    [Header("Ëèñòû õîäîâ")]
    [SerializeField] private List<Vector2> _positionsTic = new List<Vector2>();
    [SerializeField] private List<Vector2> _positionsTac = new List<Vector2>();
    public PlayerNumber PlayerNumber { get { return _playerNumber; } private set { _playerNumber = value; } }

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
        PlayerNumber = PlayerNumber switch
        {
            PlayerNumber.OnePlayer => PlayerNumber.ThwoPlayer,
            PlayerNumber.ThwoPlayer => PlayerNumber.OnePlayer,
            _ => PlayerNumber.OnePlayer
        };

        if(PlayerNumber == PlayerNumber.OnePlayer)
        {
            _positionsTic.Add(vector2);
            ÑhecksPOsitionPlayer(PlayerNumber.OnePlayer);
        }
        else
        {
            _positionsTac.Add(vector2);
            ÑhecksPOsitionPlayer(PlayerNumber.ThwoPlayer);
        }
    }
    public void ÑhecksPOsitionPlayer(PlayerNumber playerNumber)
    {
        int count = 0;
        switch (playerNumber)
        {
            case PlayerNumber.OnePlayer:
            if (_positionsTic.Count < 3) return;

                for (int i = 0; i < _controller.Varibls.Count; i++)
                {
                    count = 0;
                    for (int j = 0; j < _positionsTic.Count; j++)
                    {
                        var result = _controller.Varibls[i].vector2s.Contains(_positionsTic[j]);
                        if (result) ++count;

                        if (count == 3)
                        {
                            Winner(PlayerNumber.OnePlayer);
                            return;
                        }
                        else continue;
                    }
                }
                break;
            case PlayerNumber.ThwoPlayer:
                if (_positionsTac.Count < 3) return;

                for (int i = 0; i < _controller.Varibls.Count; i++)
                {
                    count = 0;
                    for (int j = 0; j < _positionsTac.Count; j++)
                    {
                        var result = _controller.Varibls[i].vector2s.Contains(_positionsTac[j]);
                        if (result) ++count;

                        if (count == 3)
                        {
                            Winner(PlayerNumber.ThwoPlayer);
                            return;
                        }
                        else continue;
                    }
                }
                break;
        }
 
    }
    public void Winner(PlayerNumber playerNumber)
    {
        switch (playerNumber)
        {
            case PlayerNumber.OnePlayer:
                Debug.Log("Ïîáåäèë ïåðâûé èãðîê");
                break;
            case PlayerNumber.ThwoPlayer:
                Debug.Log("Ïîáåäèë âòîðîé èãðîê");
                break;
        }
    }
}
