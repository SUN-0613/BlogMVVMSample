using BlogMVVMSample.Data;
using System.IO;
using System.Windows;
using System.Windows.Interactivity;

namespace BlogMVVMSample.Behaviors
{

    /// <summary>言語変更トリガアクション</summary>
    public class LanguageTriggerAction : TriggerAction<FrameworkElement>
    {

        /// <summary>言語を変更</summary>
        /// <param name="parameter">LanguageInfoクラス</param>
        protected override void Invoke(object parameter)
        {
            
            if (parameter is DependencyPropertyChangedEventArgs e
                && e.NewValue is LanguageInfo info)
            {

                // MergedDictionariesより同ファイル名のindexを検索する
                var index = -1;
                var fileName = Path.GetFileName(info.LanguageDictionary.Source.OriginalString);

                for (var i = 0; i < AssociatedObject.Resources.MergedDictionaries.Count; i++)
                {

                    var dictionary = AssociatedObject.Resources.MergedDictionaries[i];

                    if (Path.GetFileName(dictionary.Source.OriginalString).Equals(fileName))
                    {
                        index = i;
                        break;
                    }

                }

                if (index.Equals(-1))
                {

                    // MergedDictionaries未登録なら追加
                    AssociatedObject.Resources.MergedDictionaries.Add(info.LanguageDictionary);

                }
                else
                {

                    // 新規言語に切替
                    AssociatedObject.Resources.MergedDictionaries[index] = info.LanguageDictionary;

                }

            }

        }

    }

}
