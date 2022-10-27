using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

//목적지 오브젝트의 타입을 구별하기 위함
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
        _CollisionLogText.text = "닿은 것이 없습니다.";
    }

    private void OnTriggerEnter(Collider other)
    {
        //목적지 오브젝트와 부딛히면 목적지 타입에 따라 루트가 끄고 켜짐
        //추후에 Ui상의 버튼 클릭에 따라 루트를 시작하도록 바꿔야함
        if (other.CompareTag("MainCamera"))
        {
            if(_count >= 2)
            {
                switch (_typeOfDestination)
                {
                    case TypeOfDestination.StartQuest1:
                        _count++;
                        _CollisionLogText.text = $"{_count}번 부딪힘 {_typeOfDestination}와 닿았다.";
                        //Stage1RouteController.OffRoute("StartRoute");
                        //작은 이야기 파편 생성
                        //프로토 이후 퀘스트1을 시작할 것인지 말것인지 UI출력
                        break;
                    case TypeOfDestination.EndQuest1:
                        _count++;
                        _CollisionLogText.text = $"{_count}번 부딪힘,{_typeOfDestination}와 닿았다.";
                        //Stage1RouteController.OnRoute("Secondroute");
                        //이야기 책 출력(퀘스트)
                        //프로토 이후 퀘스트1이 끝났다는 UI 출력
                        break;
                    case TypeOfDestination.StartQuest2:
                        _count++;
                        _CollisionLogText.text = $"{_count}번 부딪힘 {_typeOfDestination}와 닿았다.";
                        // Stage1RouteController.OffRoute("Secondroute");
                        //프로토 이후 퀘스트2를 시작할 것인지 말것인지 UI출력
                        break;
                    case TypeOfDestination.EndQuest2:
                        _count++;
                        _CollisionLogText.text = $"{_count}번 부딪힘 {_typeOfDestination}와 닿았다.";
                        //Stage1RouteController.OnRoute("ThirdRoute");
                        //프로토 이후 퀘스트2가 끝났다는 UI 출력
                        //상호작용 하는 NPC 생성
                        break;
                    case TypeOfDestination.StartMiniGame:
                        _count++;
                        _CollisionLogText.text = $"{_count}번 부딪힘 {_typeOfDestination}와 닿았다.";
                        //Stage1RouteController.OffRoute("ThirdRoute");
                        //풀덩이 생성
                        //프로토 이후 미니게임을 시작할 것인지 말것인지 UI출력
                        break;
                    case TypeOfDestination.EndMiniGame:
                        _count++;
                        _CollisionLogText.text = $"{_count}번 부딪힘 {_typeOfDestination}와 닿고 게임이 꺼짐";
                        //stage1 종료}
                        break;
                }
            }
        }
    }
}