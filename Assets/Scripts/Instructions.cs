using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public float minY;
	public float maxY;
	
	private Vector3 startPos;
	private Vector3 screenPoint;
	private Vector3 offset;

	void Start(){
		minY = 4.5f;
		maxY = 28f;
	}

	void OnMouseDown(){
		startPos = gameObject.transform.position;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag(){
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		curPosition.y = Mathf.Clamp (curPosition.y, minY, maxY);
		curPosition.x = startPos.x;
		transform.position = curPosition;
	}
	
	public void ShowInstructions(){
		Vector3 newPosition = new Vector3 (8f, transform.position.y, transform.position.z);
		transform.position = newPosition;
	}
	
	public void HideInstructions(){
		Vector3 newPosition = new Vector3 (40f, transform.position.y, transform.position.z);
		transform.position = newPosition;
	}
	
}
