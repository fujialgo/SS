using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {
    [SerializeField]
    Point m_point;
    public Point mPoint
    {
        get { return m_point; }
    }

}
