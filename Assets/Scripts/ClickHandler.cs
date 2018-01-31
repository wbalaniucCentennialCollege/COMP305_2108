using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

    public Sprite sprite;
    public SpriteRenderer sRend;

    private void OnMouseUpAsButton()
    {
        sRend.sprite = sprite;
    }
}
