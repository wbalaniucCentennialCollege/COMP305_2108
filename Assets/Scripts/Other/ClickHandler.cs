using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

    public GameObject bombLit;

    private void OnMouseUpAsButton()
    {
        Destroy(this.gameObject);
        Instantiate(bombLit, this.transform.position, this.transform.rotation);
    }
}
