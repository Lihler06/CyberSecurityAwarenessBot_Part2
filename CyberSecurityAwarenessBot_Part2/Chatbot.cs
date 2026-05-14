using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBot_Part2
{
    public class Chatbot
    {
        // Dictionary stores cybersecurity topics and responses
        private Dictionary<string, List<string>> responses;

        // Random object for random responses
        private Random random = new Random();

        // Memory feature
        private string rememberedTopic = "";

        public Chatbot()
        {
            responses = new Dictionary<string, List<string>>();

            // PASSWORD RESPONSES
            responses.Add("password", new List<string>
            {
                "Use strong and unique passwords for every account.",
                "Avoid using personal information in your passwords.",
                "Consider using a password manager for better security."
            });

            // PHISHING RESPONSES
            responses.Add("phishing", new List<string>
            {
                "Be cautious of suspicious emails and links.",
                "Always verify the sender before clicking attachments.",
                "Scammers often pretend to be trusted organisations."
            });

            // PRIVACY RESPONSES
            responses.Add("privacy", new List<string>
            {
                "Review your social media privacy settings regularly.",
                "Avoid sharing sensitive personal information online.",
                "Use two-factor authentication for extra protection."
            });

            // SCAM RESPONSES
            responses.Add("scam", new List<string>
            {
                "Never share banking details with untrusted sources.",
                "Online scammers often create fake urgency to pressure victims.",
                "Be careful of deals or prizes that seem too good to be true."
            });

            // MALWARE RESPONSES
            responses.Add("malware", new List<string>
            {
                "Keep your antivirus software updated regularly.",
                "Avoid downloading files from untrusted websites.",
                "Malware can steal personal information from your device."
            });
        }

        public string GetResponse(string userInput)
        {
            // Convert user input to lowercase
            userInput = userInput.ToLower();

            // ==============================
            // SENTIMENT DETECTION
            // ==============================

            if (userInput.Contains("worried") ||
                userInput.Contains("scared") ||
                userInput.Contains("nervous"))
            {
                return "It's understandable to feel worried about cybersecurity threats. Staying informed and cautious is the best way to protect yourself online.";
            }

            if (userInput.Contains("frustrated") ||
                userInput.Contains("angry"))
            {
                return "Cybersecurity can sometimes feel overwhelming, but taking small steps like using strong passwords and avoiding suspicious links can make a big difference.";
            }

            if (userInput.Contains("curious"))
            {
                return "It's great that you're curious about cybersecurity. Learning more helps you stay safer online.";
            }

            if (userInput.Contains("confused"))
            {
                return "No problem — cybersecurity topics can seem confusing at first. I can help explain them more clearly.";
            }

            // ==============================
            // MEMORY DETECTION
            // ==============================

            if (userInput.Contains("interested in"))
            {
                if (userInput.Contains("privacy"))
                {
                    rememberedTopic = "privacy";

                    return "Great! I'll remember that you're interested in privacy.";
                }

                if (userInput.Contains("password"))
                {
                    rememberedTopic = "password";

                    return "Awesome! I'll remember that you're interested in password safety.";
                }

                if (userInput.Contains("phishing"))
                {
                    rememberedTopic = "phishing";

                    return "Got it! I'll remember that you're interested in phishing protection.";
                }

                if (userInput.Contains("scam"))
                {
                    rememberedTopic = "scam";

                    return "Thanks! I'll remember that you're interested in scam awareness.";
                }

                if (userInput.Contains("malware"))
                {
                    rememberedTopic = "malware";

                    return "Great! I'll remember that you're interested in malware protection.";
                }
            }

            // ==============================
            // FOLLOW-UP CONVERSATION FLOW
            // ==============================

            if (userInput.Contains("tell me more") ||
                userInput.Contains("another tip") ||
                userInput.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(rememberedTopic))
                {
                    List<string> rememberedResponses = responses[rememberedTopic];

                    int memoryIndex = random.Next(rememberedResponses.Count);

                    return "Since you're interested in " + rememberedTopic + ": "
                           + rememberedResponses[memoryIndex];
                }

                return "Please first ask about a cybersecurity topic like password safety, phishing, privacy, scams, or malware.";
            }

            // ==============================
            // KEYWORD RECOGNITION
            // ==============================

            foreach (var keyword in responses.Keys)
            {
                if (userInput.Contains(keyword))
                {
                    // Save topic into memory
                    rememberedTopic = keyword;

                    List<string> possibleResponses = responses[keyword];

                    int index = random.Next(possibleResponses.Count);

                    return possibleResponses[index];
                }
            }

            // ==============================
            // GENERAL QUESTIONS
            // ==============================

            if (userInput.Contains("how are you"))
            {
                return "I'm functioning perfectly and ready to help you stay safe online.";
            }

            if (userInput.Contains("your purpose"))
            {
                return "My purpose is to educate users about cybersecurity awareness and online safety.";
            }

            if (userInput.Contains("help"))
            {
                return "You can ask me about passwords, phishing, scams, malware, or privacy.";
            }

            // ==============================
            // DEFAULT RESPONSE
            // ==============================

            return "I'm not sure I understand. Can you try rephrasing?";
        }
    }
}