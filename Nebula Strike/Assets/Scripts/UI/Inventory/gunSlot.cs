using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class gunSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;

    public event Action<Gun> OnRightClickEvent;

    private Gun _gun;
    public Gun Gun
    {
        get { return _gun; }
        set
        {
            _gun = value;

            if (_gun == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _gun.Icon;
                image.enabled = true;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Gun != null & OnRightClickEvent != null)
                OnRightClickEvent(Gun);
        }
    }

    protected virtual void OnValidate()
    {
        {
            if (image == null)
                image = GetComponent<Image>();
        }
    }
}
