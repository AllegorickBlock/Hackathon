using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationWithSpeak : MonoBehaviour
{
    static public int indice = 0;
    static public string textAParler = null;
    private char actuel_caractère;
    private float delay_Avant_Changer_Animation = 0;
    [SerializeField] private Image FV;
    [SerializeField] private Image E;
    [SerializeField] private Image KGH;
    [SerializeField] private Image L;
    [SerializeField] private Image MBP;
    [SerializeField] private Image O;
    [SerializeField] private Image R;
    [SerializeField] private Image SCZDNSHTGCHJ;
    [SerializeField] private Image TH;
    [SerializeField] private Image âêîû;
    [SerializeField] private Image Ô;
    [SerializeField] private Image Nothing;

    void Update()
    {
        delay_Avant_Changer_Animation += Time.deltaTime;

        if ( (indice < textAParler.Length && delay_Avant_Changer_Animation >= 0.1f))
        {
            actuel_caractère = textAParler[indice];
            indice++;

            delay_Avant_Changer_Animation = 0;
            switch (actuel_caractère)
            {
                case 'f': case 'v': gestion_Animation_en_fonction_des_sons(fv: true); break;
                case 'e': gestion_Animation_en_fonction_des_sons(e: true); break;
                case 'k': case 'g': case 'h': gestion_Animation_en_fonction_des_sons(kgh: true); break;
                case 'l': gestion_Animation_en_fonction_des_sons(l: true); break;
                case 'm': case 'b': case 'p': gestion_Animation_en_fonction_des_sons(mbp: true); break;
                case 'o': gestion_Animation_en_fonction_des_sons(o: true); break;
                case 'r': gestion_Animation_en_fonction_des_sons(r: true); break;
                case 's': case 'c': case 'z': case 'd': case 'n': case 'j': gestion_Animation_en_fonction_des_sons(scz: true); break;
                case 't': gestion_Animation_en_fonction_des_sons(th: true); break;
                case 'a': case 'i': case 'u': gestion_Animation_en_fonction_des_sons(th: true); break;
                default: gestion_Animation_en_fonction_des_sons(nothing: true); break;
            }
        }
        else if (delay_Avant_Changer_Animation >= 10)
        {
            gestion_Animation_en_fonction_des_sons(nothing: true);
            indice = 0;
        }
    }

    private void gestion_Animation_en_fonction_des_sons(bool fv = false, bool e = false, bool kgh = false, bool l = false, bool mbp = false, bool o = false, bool r = false, bool scz = false, bool th = false, bool aeiu = false, bool ô = false, bool nothing = false)
    {
        FV.enabled = fv;
        E.enabled = e;
        KGH.enabled = kgh;
        L.enabled = l;
        MBP.enabled = mbp;
        O.enabled = O;
        R.enabled = r;
        SCZDNSHTGCHJ.enabled = scz;
        TH.enabled = th;
        âêîû.enabled = aeiu;
        Ô.enabled = ô;
        Nothing.enabled = nothing;
    }

}
