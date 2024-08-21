using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float rangeX; 
    public float elapsedTime; // ��� �ð� = ȭ�� ���� �ð�

    public enum ArrowState
    {
        Start, Stop
    }
    public ArrowState arrowState;

    void Update()
    {
       // Debug.Log($"��� �ð� ���� üũ: {this.elapsedTime}");
        this.elapsedTime += Time.deltaTime; // ��� �ð� ���
        
        arrowState= ArrowState.Start;

        if (this.elapsedTime > 1.3f) // 1.3����
        {
            CreateArrow();
           this.elapsedTime = 0;
        //    Debug.Log($"��� �ð� ���� üũ: {this.elapsedTime}");
        }
    }

    // �ż��带 ������ ������ �ϳ��� �ż���� �ϳ��� ��ɸ� ����.
    void CreateArrow()
    {
        bool flag = true;

        while (true)
        {
            // ȭ�� ����
            // ���� x��ǥ ����
            rangeX = Random.Range(-8.0f, 8.0f);
            // Debug.Log($"x ����:{rangeX}");

            GameObject arrowGo = Object.Instantiate(arrowPrefab);
            arrowGo.transform.position = new Vector3(rangeX, 5.5f, 0);

            if (arrowState == ArrowState.Stop)
            {
                flag = false;
            }

        }
    }


}