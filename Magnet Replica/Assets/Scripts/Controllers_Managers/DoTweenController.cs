using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public static class DoTweenController
{
    private static void Start()
    {
        DOTween.Init();
    }

    //Bu Script sayesinde 3 boyutlu düzlemde local pozisyonunu değiştiren bir animasyon çalıştırabiliriz.
    internal static void DoMove3D(Transform thisTransform, Vector3 endValue, float duration)
    {
        thisTransform.DOMove(endValue, duration, false);
    }

    //Bu Script sayesinde 3 boyutlu düzlemde local pozisyonunu değiştiren bir animasyon çalıştırabiliriz.
    internal static void DoLocalMove3D(Transform thisTransform, Vector3 endValue, float duration)
    {
        thisTransform.DOLocalMove(endValue, duration, false);
    }

    internal static void DoLocalMove3DWithEase(Transform thisTransform, Vector3 endValue, float duration, Ease ease)
    {
        thisTransform.DOLocalMove(endValue, duration, false).SetEase(ease);
    }

    internal static void DoMove2D(Transform thisTransform, Vector2 endValue, float duration)
    {
        thisTransform.DOMove(endValue, duration, false);
    }

    internal static void DoLocalMove2D(Transform thisTransform, Vector2 endValue, float duration)
    {
        thisTransform.DOLocalMove(endValue, duration, false);
    }

    public static void SequenceMoveAndRotate3D(Transform thisTransform, Vector3 endValuePos, Vector3 endValueRot, float duration)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(thisTransform.DOLocalRotate(endValueRot, duration));
    }
    internal static void SequenceMoveYandChangeColor(Transform thisTransform, float endValuePos, MeshRenderer meshMat, Color color, float duration)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(thisTransform.DOMoveY(endValuePos, duration)).Join(meshMat.material.DOColor(color, duration));
    }
    internal static void SequenceMoveYandChangeColorWithEase(Transform thisTransform, float endValuePos, MeshRenderer meshMat, Color color, float duration)
    {
        Ease ease = Ease.OutBounce;
        Sequence seq = DOTween.Sequence();
        seq.Append(thisTransform.DOMoveY(endValuePos, duration)).Join(meshMat.material.DOColor(color, duration)).SetEase(ease);
    }

    internal static void ScaleX(Transform thisTransform, float endValue, float duration)
    {
        thisTransform.DOScaleX(endValue, duration).SetEase(Ease.Unset);
    }

    internal static void ScaleZ(Transform thisTransform, float endValue, float duration)
    {
        thisTransform.DOScaleZ(endValue, duration).SetEase(Ease.Unset);
    }

    internal static void BarFill(Image image, float endValue, float duration)
    {
        image.DOFillAmount(endValue, duration);
    }

    internal static void ScaleXY(Transform thisTransform, float scaleValueX, float scaleValueY, float duration)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(thisTransform.DOScaleX(scaleValueX, duration)).Join(thisTransform.DOScaleY(scaleValueY, duration)).SetAutoKill(true);
    }
    internal static void ScaleXYAndMove2D(Transform thisTransform, Behaviour behaviour, float endValue, float scaleEndValueX, float scaleEndValueY, float duration)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(thisTransform.DOScaleX(scaleEndValueX, duration)).Join(thisTransform.DOScaleY(scaleEndValueY, duration)).Join(thisTransform.transform.DOLocalMoveY(endValue, duration)).OnComplete(() => DestroyObjBehaviour((behaviour)));
    }

    internal static void DestroyObjBehaviour(Behaviour component)
    {
        component.enabled = false;
    }
}
