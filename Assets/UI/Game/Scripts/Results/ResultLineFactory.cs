using TMPro;
using UnityEngine;

namespace UI.Game.Results
{
    public class ResultLineFactory
    {
        private const string prefabPath = "UI Results/ResultLine";

        private const string redDerivative = "#FF2B33";
        private const string greenDerivative = "#63EB10";
        private readonly GameObject prefab;


        public ResultLineFactory()
        {
            prefab = Resources.Load<GameObject>(prefabPath);
        }

        public RectTransform MakeResultLine(ResultLine line)
        {
            var lineTransform = Object.Instantiate(prefab).transform;

            var title = GetText(lineTransform.Find("Title"));
            var valueTransf = lineTransform.Find("Value");

            var number = GetText(valueTransf.Find("Number"));

            title.text = line.Title;
            number.text = line.Value;

            var derivationTranform = valueTransf.Find("Derivation");
            if (line.WithDerivation == true)
            {
                var derivationVal = line.Derivation;
                var derivationStart = GetDerivationPrefix(derivationVal, line.DerivationFlavour);

                var derivation = GetText(derivationTranform);
                derivation.text = $"{derivationStart}{derivationVal}";
            }
            else
            {
                derivationTranform.gameObject.SetActive(false);
            }

            var rectTransform = lineTransform.GetComponent<RectTransform>();
            return rectTransform;
        }

        private static string GetDerivationPrefix(int derivationVal, bool flavour)
        {
            string derivationStart;
            var red = $"<color={redDerivative}>";
            var green = $"<color={greenDerivative}>";


            if (flavour)
            {
                (red, green) = (green, $"{red}+");
            }
            else
            {
                green = $"{green}+";
            }

            if (derivationVal > 0)
            {
                derivationStart = green;
            }
            else if (derivationVal < 0)
            {
                derivationStart = red;
            }
            else
            {
                derivationStart = string.Empty;
            }

            return derivationStart;
        }

        private static TextMeshProUGUI GetText(Transform tr)
        {
            return tr.GetComponent<TextMeshProUGUI>();
        }
    }
}