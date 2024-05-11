using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventBus
{
    public static Action hideIteractionButton; 

    public static Action<UnityAction> showInteractionButton;
    public static Action showInteractionButtonWithSameState;
    public static Action<bool> playerSetInvisible;

    public static Action<IEnumerable<DialogSource.Phrase>, Sprite> processDialog;
}
