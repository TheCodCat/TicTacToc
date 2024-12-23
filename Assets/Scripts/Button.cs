using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private bool _isFree = true;
    [SerializeField] private Image _image;

    public void SetPosition()
    {
        _isFree = false;
        GameController.instance.SetPosition(_position);
        _image.color = Color.black;
    }
}
