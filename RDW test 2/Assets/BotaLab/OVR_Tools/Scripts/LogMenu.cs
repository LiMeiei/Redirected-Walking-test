using UnityEngine;
using UnityEngine.UI;

// Console Logger in Game Environment
public class LogMenu : MonoBehaviour {
    [SerializeField]
    private Text    m_textUI    = null;
    [SerializeField]
    private int m_textMax = 512;

    [SerializeField]
    private ScrollRect ScrollRect;

    private void Awake() {
        Application.logMessageReceived  += OnLogMessage;
    }

    private void OnDestroy() {
        Application.logMessageReceived  -= OnLogMessage;
    }

    private void OnLogMessage( string i_logText, string i_stackTrace, LogType i_type ) {
        if ( string.IsNullOrEmpty( i_logText ) ) {
            return;
        }

        if ( !string.IsNullOrEmpty( i_stackTrace ) ) {
            switch ( i_type ) {
            case LogType.Error:
            case LogType.Assert:
            case LogType.Exception:
                i_logText   += System.Environment.NewLine + i_stackTrace;
                break;
            default:
                break;
            }
        }

        switch ( i_type ) {
        case LogType.Error:
        case LogType.Assert:
        case LogType.Exception:
            i_logText = string.Format( "<color=#e27878>{0}</color>", i_logText );
            break;
        case LogType.Warning:
            i_logText = string.Format( "<color=#b4be82>{0}</color>", i_logText );
            break;
        default:
            break;
        }

        if (m_textUI != null) {
            if (m_textUI.text.Length > m_textMax) {
                m_textUI.text = "";
            }
            m_textUI.text   += i_logText + System.Environment.NewLine;
        }

        ScrollRect.verticalNormalizedPosition = 0; //ここでスクロールを一番下にする
        // Debug.Log(string.Format( "text length: {0}", m_textUI.text.Length ));

    }

} // class LogMenu