using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalPositionLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        if (MainWorldPosition.Position != Vector3.zero) {
            Debug.Log("Position is not 0, teleport to " + MainWorldPosition.Position);
            gameObject.transform.position = MainWorldPosition.Position;
        }
    }
}
