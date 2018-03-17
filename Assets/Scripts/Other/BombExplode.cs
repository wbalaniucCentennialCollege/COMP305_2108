using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour {

    public GameObject scoreIndicator;

	void Explode()
    {
        Instantiate(scoreIndicator, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
