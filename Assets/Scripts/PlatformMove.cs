using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Vector3 startPos; // ���� ��ġ
    public Vector3 endPos;   // �� ��ġ
    public float speed = 2.0f; // �̵� �ӵ�
    private bool movingToEnd = true;

    void Start()
    {
        // �ʱ� ��ġ ����
        if (startPos == Vector3.zero)
            startPos = transform.position;
    }

    void Update()
    {
        // �̵� ����
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPos) < 0.1f)
                movingToEnd = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPos) < 0.1f)
                movingToEnd = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPos, endPos);
    }





}
