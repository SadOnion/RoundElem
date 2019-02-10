using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float minX, maxX, minY;
    public float smoothSpeed;

    private Ball focusedBall;


    // Use this for initialization
    void Start() {
        focusedBall = GameManager.Instance.focusedBall;

    }





    // Update is called once per frame
    void LateUpdate() {


        if (focusedBall != null)
        {


            float x, y;
            Vector3 desiredPosition = focusedBall.transform.position + Vector3.back;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);




            x = Mathf.Clamp(smoothedPos.x, minX + 9, maxX - 9);
            y = Mathf.Max(minY + Camera.main.orthographicSize, smoothedPos.y);


            transform.position = new Vector3(x, y, -1);
        }
    

}
    public void ChangeFocus()
    {
        focusedBall = GameManager.Instance.focusedBall;
    }
}
