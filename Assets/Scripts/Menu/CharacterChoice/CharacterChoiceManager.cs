using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterChoiceManager : MonoBehaviour
{
    [SerializeField] Sprite icone1;
    [SerializeField] Sprite icone2;

    [SerializeField] Image p1Icone;
    [SerializeField] Image p2Icone;
    [SerializeField] Image p3Icone;
    [SerializeField] Image p4Icone;

    [SerializeField] TextMeshProUGUI p1Ready;
    [SerializeField] TextMeshProUGUI p2Ready;
    [SerializeField] TextMeshProUGUI p3Ready;
    [SerializeField] TextMeshProUGUI p4Ready;

    //get les input des players pour modifier les bons trucs
    //activer le texte ready quannd le joueur appuie sur un bouton character (desactiver le texte + retirer le sprite + set couleur gris quand le joueur qui a deja selectionner un perso appuie sur la touche retour

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChoseCharacter1()
    {
        p1Icone.sprite = icone1;
        p1Icone.color = Color.white;
        p1Ready.gameObject.SetActive(true);
    }

    public void ChoseCharacter2()
    {
        p1Icone.sprite = icone2;
        p1Icone.color = Color.white;
        p1Ready.gameObject.SetActive(true);
    }

}
