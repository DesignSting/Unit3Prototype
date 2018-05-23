using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class TriggerDisplay : MonoBehaviour {

    public Color mainColor = Color.red;
    public Color lineColor = Color.red;

	//This does some magic and draws a box that is only visable in the editor view. Great for debugging
	void OnDrawGizmos()
	{
		GetComponent<BoxCollider>().isTrigger = true;
		Vector3 drawBoxVector = new Vector3(
			this.transform.lossyScale.x * this.GetComponent<BoxCollider>().size.x,
			this.transform.lossyScale.y * this.GetComponent<BoxCollider>().size.y,
			this.transform.lossyScale.z * this.GetComponent<BoxCollider>().size.z
			);

		Vector3 drawBoxposition = this.transform.position + this.GetComponent<BoxCollider>().center;

		Gizmos.matrix = Matrix4x4.TRS (drawBoxposition, this.transform.rotation, drawBoxVector);
        Gizmos.color = mainColor;
		Gizmos.DrawCube(Vector3.zero,Vector3.one);
		Gizmos.color = lineColor;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
