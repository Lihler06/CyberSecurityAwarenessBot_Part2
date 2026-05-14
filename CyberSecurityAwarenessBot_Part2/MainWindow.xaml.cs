using System.Windows;
using System.Windows.Input;
using System.Media;

namespace CyberSecurityAwarenessBot_Part2
{
    public partial class MainWindow : Window
    {
        // ==============================
        // CHATBOT + DELEGATE
        // ==============================

        private Chatbot chatbot;

        
        public delegate string ChatbotDelegate(string input);
        private ChatbotDelegate processMessage;

        // AUDIO PLAYER
        private SoundPlayer player;

        public MainWindow()
        {
            InitializeComponent();

            // ==============================
            // AUDIO GREETING
            // ==============================
            try
            {
                
                player = new SoundPlayer("Greeting.wav");
                player.Play();
            }
            catch
            {
                ChatDisplay.AppendText("Audio file not found or could not be played.\n");
            }

            chatbot = new Chatbot();

            // Assign delegate to chatbot method
            processMessage = chatbot.GetResponse;

            // UI Header
            ChatDisplay.AppendText("═══════════════════════════════\n");
            ChatDisplay.AppendText(" Cybersecurity Awareness Bot\n");
            ChatDisplay.AppendText("═══════════════════════════════\n\n");

            ChatDisplay.AppendText("Bot: Hello! I am your Cybersecurity Awareness Bot.\n");
            ChatDisplay.AppendText("Bot: Ask me about passwords, phishing, scams, malware, or privacy.\n\n");
        }

        // ==============================
        // SEND BUTTON CLICK
        // ==============================
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessMessage();
        }

        // ==============================
        // ENTER KEY SUPPORT
        // ==============================
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessMessage();
            }
        }

        // ==============================
        // MAIN MESSAGE HANDLER
        // ==============================
        private void ProcessMessage()
        {
            string userMessage = UserInput.Text;

            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                ChatDisplay.AppendText("You: " + userMessage + "\n");

               
                string response = processMessage(userMessage);

                ChatDisplay.AppendText("Bot: " + response + "\n\n");

                UserInput.Clear();

                ChatDisplay.ScrollToEnd();
            }
        }
    }
}