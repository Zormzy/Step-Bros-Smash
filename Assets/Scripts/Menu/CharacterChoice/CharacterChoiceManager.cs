using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterChoiceManager : MonoBehaviour
{
    //[SerializeField] Sprite icone1;
    //[SerializeField] Sprite icone2;

    //[SerializeField] Image p1Icone;
    //[SerializeField] Image p2Icone;
    //[SerializeField] Image p3Icone;
    //[SerializeField] Image p4Icone;


    public int chosenCharacter;

    //get l'image/ ready text du bon canvas -> dans le menu helper?
    //get les input des players pour modifier les bons trucs
    //activer le texte ready quannd le joueur appuie sur un bouton character (desactiver le texte + retirer le sprite + set couleur gris quand le joueur qui a deja selectionner un perso appuie sur la touche retour

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChoseCharacter1()
    {
        chosenCharacter = 1;
        Debug.Log(chosenCharacter);

        //p1Icone.sprite = icone1;
        //p1Icone.color = Color.white;
        //p1Ready.gameObject.SetActive(true);
    }

    public void ChoseCharacter2()
    {
        chosenCharacter = 2;
        Debug.Log(chosenCharacter);

        //p1Icone.sprite = icone2;
        //p1Icone.color = Color.white;
        //p1Ready.gameObject.SetActive(true);
    }

}
