using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System.Linq;

public class Test_animSpeed : MonoBehaviour
{
    [SerializeField] PlayableDirector pd;
    [SerializeField] float m_animSpeed;

    public void AnimSpeedUp()
    {
        var p = (TimelineAsset) pd.playableAsset;
        var clips = p.GetOutputTrack(6).GetClips();
        var a = clips.FirstOrDefault(x => x.displayName == "Train");
        a.timeScale = 0.1;
    }

}
