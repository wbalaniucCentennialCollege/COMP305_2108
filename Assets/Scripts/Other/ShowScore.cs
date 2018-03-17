using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour {

	void UpdateScore()
    {
        Debug.Log("+1");
        Destroy(this.gameObject);
    }
}
