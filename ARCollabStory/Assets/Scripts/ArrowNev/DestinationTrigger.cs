using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

//������ ������Ʈ�� Ÿ���� �����ϱ� ����
public enum TypeOfDestination
{
    StartQuest1,
    EndQuest1,
    StartQuest2,
    EndQuest2,
    StartMiniGame,
    EndMiniGame
}

public class DestinationTrigger : MonoBehaviour
{
    public TypeOfDestination _typeOfDestination;
    public Text _CollisionLogText;

    private int _count = 0;

    private RouteController Stage1RouteController;

    private void Awake()
    {
        Stage1RouteController = GameObject.Find("Stage1Routes").GetComponent<RouteController>();
    }

    private void Start()
    {
        _CollisionLogText.text = "���� ���� �����ϴ�.";
    }

    private void OnTriggerEnter(Collider other)
    {
        //������ ������Ʈ�� �ε����� ������ Ÿ�Կ� ���� ��Ʈ�� ���� ����
        //���Ŀ� Ui���� ��ư Ŭ���� ���� ��Ʈ�� �����ϵ��� �ٲ����
        if (other.CompareTag("MainCamera"))
        {
            if(_count >= 2)
            {
                switch (_typeOfDestination)
                {
                    case TypeOfDestination.StartQuest1:
                        _count++;
                        _CollisionLogText.text = $"{_count}�� �ε��� {_typeOfDestination}�� ��Ҵ�.";
                        //Stage1RouteController.OffRoute("StartRoute");
                        //���� �̾߱� ���� ����
                        //������ ���� ����Ʈ1�� ������ ������ �������� UI���
                        break;
                    case TypeOfDestination.EndQuest1:
                        _count++;
                        _CollisionLogText.text = $"{_count}�� �ε���,{_typeOfDestination}�� ��Ҵ�.";
                        //Stage1RouteController.OnRoute("Secondroute");
                        //�̾߱� å ���(����Ʈ)
                        //������ ���� ����Ʈ1�� �����ٴ� UI ���
                        break;
                    case TypeOfDestination.StartQuest2:
                        _count++;
                        _CollisionLogText.text = $"{_count}�� �ε��� {_typeOfDestination}�� ��Ҵ�.";
                        // Stage1RouteController.OffRoute("Secondroute");
                        //������ ���� ����Ʈ2�� ������ ������ �������� UI���
                        break;
                    case TypeOfDestination.EndQuest2:
                        _count++;
                        _CollisionLogText.text = $"{_count}�� �ε��� {_typeOfDestination}�� ��Ҵ�.";
                        //Stage1RouteController.OnRoute("ThirdRoute");
                        //������ ���� ����Ʈ2�� �����ٴ� UI ���
                        //��ȣ�ۿ� �ϴ� NPC ����
                        break;
                    case TypeOfDestination.StartMiniGame:
                        _count++;
                        _CollisionLogText.text = $"{_count}�� �ε��� {_typeOfDestination}�� ��Ҵ�.";
                        //Stage1RouteController.OffRoute("ThirdRoute");
                        //Ǯ���� ����
                        //������ ���� �̴ϰ����� ������ ������ �������� UI���
                        break;
                    case TypeOfDestination.EndMiniGame:
                        _count++;
                        _CollisionLogText.text = $"{_count}�� �ε��� {_typeOfDestination}�� ��� ������ ����";
                        //stage1 ����}
                        break;
                }
            }
        }
    }
}