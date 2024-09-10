using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace nitou.UI.Component {


    public class MyToggle : Selectable{

        public override void OnMove(AxisEventData eventData) {
            if (!IsActive() || !IsInteractable()) {
                base.OnMove(eventData);
                return;
            }

            switch (eventData.moveDir) {
                case MoveDirection.Left:
                    Debug_.Log("Move Left", Colors.Orange);
                    break;

                case MoveDirection.Right:
                    Debug_.Log("Move Right", Colors.Orange);
                    break;

                case MoveDirection.Up:
                case MoveDirection.Down:
                        base.OnMove(eventData);
                    break;
            }
        }

    }

}