using UnityEngine;
using System.Collections;

public class BlinkHandler : MonoBehaviour {

    [SerializeField]
    Animator anim;

	public void Blink()
    {
        anim.SetTrigger("Blink");
    }
}
