using Celezt.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

[ExecuteInEditMode]
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textGUI;

    public void OnProcessClip(DialogueSystemBinder.Callback callback)
    {
        if (callback.Asset is DialogueAsset asset)
        {
            _textGUI.text = asset.Text;
            _textGUI.maxVisibleCharacters = Mathf.RoundToInt(_textGUI.textInfo.characterCount * callback.VisibilityInterval);
        }
    }

    public void OnEnterClip(DialogueSystemBinder.Callback callback)
    {
        _textGUI.text = null;
    }

    public void OnExitClip(DialogueSystemBinder.Callback callback)
    {
        _textGUI.text = null;
    }
}
