using UnityEngine;
using System.Collections;

public class TestRoomZone : MonoBehaviour {

    [SerializeField]
    private TestRoom testRoom;

	void OnTriggerEnter(Collider coll)
    {
        testRoom.StartTest();
    }
}
