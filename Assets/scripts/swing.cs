using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swing : MonoBehaviour
{

    public HingeJoint2D hinge; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.jointAngle >= hinge.limits.max || hinge.jointAngle <= hinge.limits.min)
        {
            var motor = hinge.motor;
            motor.motorSpeed = -motor.motorSpeed;
            hinge.motor = motor; 
            //hinge.motor.motorSpeed = hinge.motor.motorSpeed;//
            
        }
    }
}
