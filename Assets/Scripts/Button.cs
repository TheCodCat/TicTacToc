using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private bool _isFree = true;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _Tic;
    [SerializeField] private Sprite _Tac;

    public void SetPosition()
    {
        _image.sprite = GameController.instance.PlayerNumber switch
        {
            PlayerNumber.OnePlayer => _Tic,
            PlayerNumber.ThwoPlayer => _Tac,
            _ => _Tic
        };

        _isFree = false;
        GameController.instance.SetPosition(_position);
    }
}
