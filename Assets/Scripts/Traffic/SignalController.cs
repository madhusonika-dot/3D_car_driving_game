using UnityEngine;

namespace OpenWorldDriving.Traffic
{
    /// <summary>
    /// Simple traffic signal state machine.
    /// </summary>
    public class SignalController : MonoBehaviour
    {
        public enum SignalState { Green, Yellow, Red }

        [SerializeField] private SignalState currentState = SignalState.Green;
        [SerializeField] private float greenDuration = 10f;
        [SerializeField] private float yellowDuration = 2f;
        [SerializeField] private float redDuration = 10f;

        private float timer;

        private void Update()
        {
            timer += Time.deltaTime;
            switch (currentState)
            {
                case SignalState.Green:
                    if (timer >= greenDuration)
                    {
                        SetState(SignalState.Yellow);
                    }
                    break;
                case SignalState.Yellow:
                    if (timer >= yellowDuration)
                    {
                        SetState(SignalState.Red);
                    }
                    break;
                case SignalState.Red:
                    if (timer >= redDuration)
                    {
                        SetState(SignalState.Green);
                    }
                    break;
            }
        }

        private void SetState(SignalState state)
        {
            currentState = state;
            timer = 0f;
        }

        public bool CanProceed()
        {
            return currentState == SignalState.Green;
        }
    }
}
