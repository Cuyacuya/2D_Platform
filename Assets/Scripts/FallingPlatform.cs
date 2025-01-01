using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float waitTime = 2f; // ��ٸ� �ð� (��)
    public float fallSpeed = 2f; // �������� �ӵ�

    private bool isFalling = false;
    private Vector3 originalPosition; // ���� ��ġ ����
    private bool isPlayerOnPlatform = false; // �÷��̾ �÷����� �ִ��� Ȯ��

    private void Awake()
    {
        originalPosition = transform.position; // ���� ��ġ ����
    }

    void Update()
    {
        if (isFalling)
        {
            // �÷����� ���������� �̵�
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
    }

    // �÷����� �÷��̾ ����� ��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerOnPlatform)
        {
            isPlayerOnPlatform = true;
            isFalling = true; // �÷��̾ ����� �� �÷����� �������� ����
            StartCoroutine(ResetPlatformAfterTime(waitTime)); // ���� �ð� �� �÷��� �����
        }
    }

    // ���� �ð� �� �ٽ� �÷����� ����ġ�� �ǵ����� ����
    private IEnumerator ResetPlatformAfterTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // ���� �ð� ���
        isFalling = false; // �÷��� �������� ����
        transform.position = originalPosition; // ���� ��ġ�� �ǵ�����
        yield return new WaitForSeconds(1f); // ��� ���� �� �ٽ� �����
        isPlayerOnPlatform = false; // �ٽ� �÷��̾ �ö�� �� �ְ�
    }
}
