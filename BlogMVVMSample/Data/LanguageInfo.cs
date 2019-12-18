using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace BlogMVVMSample.Data
{

    /// <summary>表示言語情報</summary>
    public class LanguageInfo
    {

        /// <summary>該当言語のResourceDictionary</summary>
        public ResourceDictionary LanguageDictionary { get; private set; }

        /// <summary>選択中の言語</summary>
        public Languages SelectedLanguage { get; private set; }

        /// <summary>ResourceDictionaryの保存フォルダパス</summary>
        private const string _LanguagePath = "Forms/Languages";

        /// <summary>表示言語情報</summary>
        /// <param name="fileName">ResourceDictionaryのファイル名</param>
        public LanguageInfo(string fileName)
        {

            // 言語はCurrentUICultureから取得
            Languages selectedLanguage = Languages.English;

            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {

                case "en-US":
                    selectedLanguage = Languages.English;
                    break;

                case "ja-JP":
                    selectedLanguage = Languages.Japanese;
                    break;

            }

            LanguageDictionary = GetResourceDictionary(_LanguagePath, selectedLanguage, GetFileName(fileName));

        }

        /// <summary>表示言語情報</summary>
        /// <param name="fileName">ResourceDictionaryのファイル名</param>
        /// <param name="selectedLanguage">選択した言語</param>
        public LanguageInfo(string fileName, Languages selectedLanguage)
        {
            LanguageDictionary = GetResourceDictionary(_LanguagePath, selectedLanguage, GetFileName(fileName));
        }

        /// <summary>表示言語情報</summary>
        /// <param name="fileName">ResourceDictionaryのファイル名</param>
        /// <param name="selectedLanguage">選択した言語</param>
        /// <param name="languagePath">ResourceDictionaryの保存フォルダパス</param>
        public LanguageInfo(string fileName, Languages selectedLanguage, string languagePath)
        {
            LanguageDictionary = GetResourceDictionary(languagePath, selectedLanguage, GetFileName(fileName));
        }

        /// <summary>拡張子付きファイル名の取得</summary>
        /// <param name="fileName">ResourceDictionaryのファイル名</param>
        private string GetFileName(string fileName)
        {

            // 拡張子付与
            if (fileName.Length <= 4
                || !fileName.Substring(fileName.Length - 5, 5).ToUpper().Equals(".XAML"))
            {
                fileName += ".xaml";
            }

            return fileName;

        }

        /// <summary>ResourceDictionaryの取得</summary>
        private ResourceDictionary GetResourceDictionary(string languagePath, Languages selectedLanguage, string fileName)
        {

            var culture = Thread.CurrentThread.CurrentUICulture.Name;

            switch (selectedLanguage)
            {

                case Languages.English:
                    culture = "en-US";
                    break;

                case Languages.Japanese:
                    culture = "ja-JP";
                    break;

            }

            // 選択中の言語の保存
            SelectedLanguage = selectedLanguage;

            // ResourceDictionaryの取得
            return new ResourceDictionary()
            {
                Source = new Uri(Path.Combine(Path.Combine(languagePath, culture), fileName), UriKind.Relative)
            };

        }


    }

}
