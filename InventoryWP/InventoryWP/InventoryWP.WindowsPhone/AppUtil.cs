using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InventoryWP
{
    internal static class AppUtil
    {
        public static async Task LoadVoiceCommandDefinition()
        {
            Uri uri = new Uri("ms-appx:///VoiceCommands.xml", UriKind.Absolute);
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);

            try
            {
                await Windows.Media.SpeechRecognition.VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(file);
            }
            catch (Exception ex){
                string errorMessage = string.Format(
                    "An error was encountered installing the Voice Command Definition file: \r\n {0:x} \r\n {1}",
                    ex.HResult,
                    ex.Message);
                new MessageDialog(errorMessage).ShowAsync();
            }
        }

        public static void OnActivated(IActivatedEventArgs e)
        {

            if (e.Kind != ActivationKind.VoiceCommand)
            {
                return;
            }

            var commandArgs = e as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
            SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;

            string voiceCommandName = speechRecognitionResult.RulePath[0];
            string textSpoken = speechRecognitionResult.Text;

            string commandMode = speechRecognitionResult.SemanticInterpretation.Properties["commandMode"][0];

            Frame rootFrame = Window.Current.Content as Frame;
            List<string> parameters = new List<string>();

            switch (voiceCommandName)
            {
                case "ShowAllItems":
                    rootFrame.Navigate(typeof(NewItem));
                    break;
                case "AddNewItem":
                    parameters.Add(speechRecognitionResult.SemanticInterpretation.Properties["item"][0]);
                    parameters.Add("");
                    rootFrame.Navigate(typeof(NewItem),parameters);
                    break;
                case "AddNewItemToCategory":
                    parameters.Add(speechRecognitionResult.SemanticInterpretation.Properties["item"][0]);
                    parameters.Add(speechRecognitionResult.SemanticInterpretation.Properties["category"][0]);
                    rootFrame.Navigate(typeof(NewItem), parameters);
                    break;
                default:
                    rootFrame.Navigate(typeof(MainPage));
                    break;
            }
        }
    }
}
