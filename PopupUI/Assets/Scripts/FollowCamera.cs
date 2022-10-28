using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //�ν����Ϳ��� Ÿ�� �־���
    public Transform Target;

    //ī�޶� Ÿ���� ���󰡴� �ӵ�
    float followSpeed = 0.5f;

    //ī�޶�� Ÿ�� ������ ������ �Ÿ�
    Vector3 Offset;

    void Start()
    {
        //Ÿ���� null�� �ƴ� ���� ����ϵ���
        if(Target != null)
            Offset = Target.position - transform.position;
    }

    
    void Update()
    {
        //���� �Լ� �̿��ؼ� õõ�� ���󰡵���
        transform.position = Vector3.Lerp(transform.position, Target.position - Offset, followSpeed * Time.deltaTime);
    }
}
