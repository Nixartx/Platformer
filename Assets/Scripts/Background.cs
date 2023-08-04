using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float backgroundSize;
    [SerializeField] private bool automaticMove = false; 
    private float x;
    private float pointToEndLeft;
    private float pointToEndRight;
    private float pointToOriginal;

    void Start () {
        pointToOriginal = transform.localPosition.x;
        pointToEndLeft = pointToOriginal - backgroundSize;
        pointToEndRight = pointToOriginal + backgroundSize;
        //x2 background speed
        speed *= 2;
    }
	
    void Update () {
    
    	x = transform.localPosition.x;
        var directionSpeed = automaticMove ? speed : speed * GameManager.Instance.PlayerMoveDirection;
        x += directionSpeed * Time.deltaTime;
    	transform.localPosition = new Vector3 (x, transform.localPosition.y, transform.localPosition.z);
    
    	if (x <= pointToEndLeft || x >= pointToEndRight){
    		x = pointToOriginal;
    		transform.localPosition = new Vector3 (x, transform.localPosition.y, transform.localPosition.z);
    	}
    }
}
