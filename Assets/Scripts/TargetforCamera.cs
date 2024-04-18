using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetforCamera : MonoBehaviour
{
    public Transform Target;
    private float _smoothSpeed = 0.250f;
    
    
    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z); // ”станавливаем желаемую позицию камеры по X и Y, сохран€€ еЄ текущую позицию по Z
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed); // »спользуем сглаживание дл€ плавного перемещени€ камеры
        transform.position = smoothedPosition;
    }
}
