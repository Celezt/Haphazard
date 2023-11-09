using Celezt.DialogueSystem;
using Celezt.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _actorGUI;
    [SerializeField] private TextMeshProUGUI _textGUI;

    private char[] _actorBuffer = new char[2048];
    private char[] _textBuffer = new char[2048];

    public void OnProcessClip(DialogueSystemBinder.Callback callback)
    {
        if (callback.Asset.TryGetExtension(out TextExtension extension))
        {
            _textGUI.maxVisibleCharacters = Mathf.RoundToInt(_textGUI.textInfo.characterCount * ((ITime)extension).VisibilityInterval);
        }
    }

    public void OnEnterClip(DialogueSystemBinder.Callback callback)
    {
        if (callback.Asset.TryGetExtension(out ActorExtension actorExtension))
        {
            actorExtension.RuntimeText.CopyTo(_actorBuffer);
            _actorGUI.SetCharArray(_actorBuffer, 0, actorExtension.RuntimeText.Length);
        }

        if (callback.Asset.TryGetExtension(out TextExtension textExtension))
        {
            textExtension.RuntimeText.CopyTo(_textBuffer);
            _textGUI.SetCharArray(_textBuffer, 0, textExtension.RuntimeText.Length);

            _textGUI.maxVisibleCharacters = Mathf.RoundToInt(_textGUI.textInfo.characterCount * ((ITime)textExtension).VisibilityInterval);
        }
    }

    public void OnExitClip(DialogueSystemBinder.Callback callback)
    {
        _actorGUI.text = null;
        _textGUI.text = null;
    }
}
