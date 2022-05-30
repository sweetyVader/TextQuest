using UnityEngine;
using UnityEngine.UI;

public class Step : MonoBehaviour
{
    #region Variables

    public string DebugHeaderText;
    public string LocationText;

    public Sprite LocationImage;

    [TextArea(4, 8)]
    public string DescriptionText;

    [TextArea(4, 6)]
    public string ChoicesText;

    public Step[] Choices;

    #endregion
}