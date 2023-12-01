using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayControl : MonoBehaviour
{
    //зміння для руху 
    float speed = 0.5f;
    
    //змінні для погляду
    float rotation_x_speed = 5.0f;
    float rotation_y_speed = 5.0f;

    float max_vert = 89.0f;
    float min_vert = -89.0f;

    float rotation_x = 0f;

    void Update()
    {
        //завжди горизонтальний погляд
        rotation_x -= Input.GetAxis("Mouse Y") * rotation_y_speed;
        rotation_x = Mathf.Clamp(rotation_x, min_vert, max_vert);

        float delta = Input.GetAxis("Mouse X") * rotation_x_speed;
        float rotation_y = transform.localEulerAngles.y + delta;

        transform.localEulerAngles= new Vector3(rotation_x, rotation_y, 0);

        //рух по x z
        float deltax = Input.GetAxis("Horizontal")* speed;
        float deltaz = Input.GetAxis("Vertical") * speed;
        transform.Translate(deltax, 0, deltaz);


        // повороти грвця мишкою в космо стилі
        //transform.Rotate(0, Input.GetAxis("Mouse X") * rotation_x_speed , 0);
        //transform.Rotate(Input.GetAxis("Mouse Y") * -rotation_y_speed , 0 , 0); 
    }
}
