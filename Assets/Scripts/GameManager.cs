using TMPro;  // TextMeshPro ����� ���� ���ӽ����̽� �߰�
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    // TextMeshProUGUI�� ���� (TextMeshPro �ؽ�Ʈ ������Ʈ ���)
    public TextMeshProUGUI gameOverText;  // TextMeshPro �ؽ�Ʈ �ʵ�� ����

    public GameObject gameOverPanel;  // Game Over ȭ��

    void Start()
    {
        // �ʱ�ȭ: Game Over ȭ�� �����
        gameOverPanel.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    public void NextStage()
    {
        // Change Stage
        if (stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else
        { // Game Clear
            // Player Control Lock
            Time.timeScale = 0;
            // Result UI
            Debug.Log("���� Ŭ����!");
            // Restart Button UI (�߰������� ���� �ʿ�)
        }

        // Calculate Point
        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void HealthDown()
    {
        if (health > 1)
            health--;
        else
        {
            // Player Die Effect
            player.OnDie();

            // Result UI
            Debug.Log("�׾����ϴ�!");
            TriggerGameOver();  // Game Over ȭ�� ǥ�� �Լ� ȣ��
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (health > 1)
            {
                PlayerReposition();
                HealthDown();
            }
            else
            {
                HealthDown();
            }
        }
        else if (collision.CompareTag("Finish"))
        {
            Debug.Log("Player reached Finish - Proceeding to the Next Stage");
            NextStage(); // NextStage ȣ��
        }
    }




    void PlayerReposition()
    {
        player.transform.position = new Vector3(0, 0, -1);
        player.VelocityZero();
    }

    // Game Over ȭ�� Ȱ��ȭ �Լ�
    void TriggerGameOver()
    {
        gameOverPanel.SetActive(true);  // Game Over Panel Ȱ��ȭ
        gameOverText.gameObject.SetActive(true);  // "Game Over" �ؽ�Ʈ Ȱ��ȭ
    }
}
