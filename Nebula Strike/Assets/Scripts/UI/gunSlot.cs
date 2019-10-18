using UnityEngine;
using UnityEngine.UI;

public class gunSlot : MonoBehaviour
{
    [SerializeField] Image image;

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


    private void OnValidate()
    {
        {
            if (image == null)
                image = GetComponent<Image>();
        }
    }
}
