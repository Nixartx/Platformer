using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] public float speed;
    private float x;
    private float pointToEndLeft;
    private float pointToEndRight;
    private float pointToOriginal;

    void Start () {
        pointToOriginal = transform.localPosition.x;
        pointToEndLeft = pointToOriginal - 9.14f;
        pointToEndRight = pointToOriginal + 9.14f;
        //x2 background speed
        speed *= 2;
    }
	
    void Update () {
    
    	x = transform.localPosition.x;

        x += speed * Time.deltaTime * GameManager.Instance.PlayerMoveDirection;
    	transform.localPosition = new Vector3 (x, transform.localPosition.y, transform.localPosition.z);
    
    	if (x <= pointToEndLeft || x >= pointToEndRight){
    		x = pointToOriginal;
    		transform.localPosition = new Vector3 (x, transform.localPosition.y, transform.localPosition.z);
    	}
    }
}
