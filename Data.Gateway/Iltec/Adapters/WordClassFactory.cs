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
                case "artigo indefinido":
                case "artigo demostrativo":
                    return WordClass.Article;

                case "artigo possessivo":
                    return WordClass.PossessiveArticle;

                case "advérbio":
                    return WordClass.Adverb;

                case "conjunção":
                    return WordClass.Conjunction;

                case "contração":
                    return WordClass.Contraction;

                case "verbo":
                    return WordClass.Verb;

                case "nome masculino":
                case "nome feminino":
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

                case "preposição":
                    return WordClass.Preposition;

                default:
                    return WordClass.Unknown;
            }
        }
    }
}