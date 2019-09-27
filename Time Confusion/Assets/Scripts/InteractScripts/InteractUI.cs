using UnityEngine;
using UnityEngine.UI;

public class InteractUI
{
    private BaseNPC npc;
    private Image interactImage;
    public Button InteractButton { get; private set; }
    public InteractUI(BaseNPC npc)
    {
        this.npc = npc;
        interactImage = npc.GetComponentInChildren<Image>();
        InteractButton = npc.GetComponentInChildren<Button>();
        interactImage.gameObject.SetActive(false);
    }
    public void ShowandCloseTheInteractButton()
    {       
        if (!interactImage.IsActive())
        {
            interactImage.gameObject.SetActive(true);
        }
        else
        {
            interactImage.gameObject.SetActive(false);
        }
    }
}
