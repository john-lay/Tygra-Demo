using UnityEngine;

public class EventManager : MonoBehaviour
{

    public delegate void IsDrivingEvent(bool isDriving);
    public event IsDrivingEvent OnDrivingChanged;

    public void UpdateDriving(bool isDriving)
    {
        if (OnDrivingChanged != null)
            OnDrivingChanged(isDriving);
    }

}
