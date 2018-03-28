using UnityEngine;
using System.Collections;

public class DestructionScript : MonoBehaviour {

	void OnTriggerExit2D(Collider2D obj)
	{
		Destroy(obj.gameObject);
	}
}
