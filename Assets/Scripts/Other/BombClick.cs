using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombClick : MonoBehaviour {

    public GameObject bombLit;

    private void OnMouseUpAsButton()
    {
        Instantiate(bombLit, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
