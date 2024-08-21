using UnityEngine;
using UnityEngine.EventSystems;

namespace HyperCasual.Runner
{
    public class ClickableView : MonoBehaviour
    {
        public delegate void OnClickAction();
        public event OnClickAction OnClick;

        public void OnPointerClick(BaseEventData eventData)
        {
            OnClick?.Invoke();
        }
    }

}
