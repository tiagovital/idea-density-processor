using Domain.Model;

namespace Data.Gateway.Iltec.Adapters
{
    public class WordClassFactory
    {
        public static WordClass Create(string name)
        {
            string category = GetUniformedName(name);
            return GetWordClass(category);
        }

        private static string GetUniformedName(string name)
        {
            name = name ?? string.Empty;

            return name.ToLower().Trim();
        }

        private static WordClass GetWordClass(string category)
        {
            switch (category)
            {
                case "adjetivo":
                    return WordClass.Adjective;

                case "artigo definido":
                    return WordClass.DefinedArticle;

                case "artigo indefinido":

                    return WordClass.UndefinedArticle;

                case "artigo demostrativo":
                    return WordClass.DemonstrativeArticle;

                case "artigo possessivo":
                    return WordClass.PossessiveArticle;

                case "artigo interrogativo":
                    return WordClass.QuestioningArticle;

                case "advérbio":
                    return WordClass.Adverb;

                case "conjunção":
                    return WordClass.Conjunction;

                case "contração":
                    return WordClass.Contraction;

                case "verbo":
                    return WordClass.Verb;

                case "interjeição":
                    return WordClass.Interjection;

                case "nome masculino":
                    return WordClass.MaleNoun;

                case "nome feminino":
                    return WordClass.FemaleNoun;

                case "substantivo":
                    return WordClass.Noun;

                case "pronome demostrativo":
                case "pronome demonstrativo":
                    return WordClass.DemonstrativePronoun;

                case "pronome indefinido":
                    return WordClass.UndefinedPronoun;

                case "pronome pessoal":
                    return WordClass.PersonalPronoun;

                case "pronome possessivo":
                    return WordClass.PosssessivePronoun;

                case "pronome interrogativo":
                    return WordClass.QuestioningPronoun;

                case "pronome relativo":
                    return WordClass.RelativePronoune;

                case "preposição":
                    return WordClass.Preposition;

                case "número cardinal":
                    return WordClass.Number;

                default:
                    return WordClass.Unknown;
            }
        }
    }
}