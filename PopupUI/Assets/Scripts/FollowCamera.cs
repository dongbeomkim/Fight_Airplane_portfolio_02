using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //인스펙터에서 타겟 넣어줌
    public Transform Target;

    //카메라가 타겟을 따라가는 속도
    float followSpeed = 0.5f;

    //카메라와 타겟 사이의 유지될 거리
    Vector3 Offset;

    void Start()
    {
        //타겟이 null이 아닐 때만 계산하도록
        if(Target != null)
            Offset = Target.position - transform.position;
    }

    
    void Update()
    {
        //러프 함수 이용해서 천천히 따라가도록
        transform.position = Vector3.Lerp(transform.position, Target.position - Offset, followSpeed * Time.deltaTime);
    }
}
