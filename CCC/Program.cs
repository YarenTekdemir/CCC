using System;
using System.Threading.Tasks;
using OpenAI_API;

namespace CV
{
    public class Program
    {
        private static ChatOnerisi chatOnerisi;

        public static async Task Main(string[] args)
        {
            chatOnerisi = new ChatOnerisi();

            while (true)
            {
                Console.Write("Komut: ");
                string komut = Console.ReadLine();

                if (komut.ToLower() == "ol")
                {
                    Console.WriteLine("CV'yi oluşturma ve düzenleme işlemi başlatılıyor...");

                    string cvText = "İsim: Ravza Nur Şişik\r\nAdres: İstanbul\r\nTelefon: 5345503650\r\nE-posta: ravzasisiknur@gmail.com\r\n\r\n\r\nEğitim:\r\n- Lise: Nazmi Arıkan Fen Lisesi  \r\n- Üniversite: Medipol Üni. – 3.sınıf\r\n\r\nDeneyim:\r\n- Hiç iş deneyimim yok.\r\n\r\nYetenekler:\r\n•\tHTML/CSS \r\n•\tOrta seviye python\r\n•\\n\r\nSoft Skills:\r\n\r\n•\tProblem çözme\r\n•\tAraştırma-geliştirme\r\n•\tZaman yönetimi\r\n\r\nHobiler:\r\n•\tTeknolojideki yenilikler\r\n•\tİnternette sörf yapmak\r\n•\r\nDil:\r\n•\tTürkçe\r\n•\tİngilizce \r\n\r\nReferanslar:\r\n- İsteyenler için elimde referans yok.\r\n";

                    string response = await chatOnerisi.GetChatResponse(cvText);

                    Console.WriteLine("OpenAI'dan gelen yanıt:");
                    Console.WriteLine(response);
                }
                else if (komut.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz komut. 'ol' veya 'exit' komutlarını girin.");
                }
            }
        }

        public class ChatOnerisi
        {
            private OpenAIAPI api;

            public ChatOnerisi()
            {
                var apiKey = "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";
                api = new OpenAIAPI(apiKey);
            }

            public async Task<string> GetChatResponse(string cvText)
            {
                var chat = api.Chat.CreateConversation();

                chat.AppendUserInput(cvText + "  CV yi  eğitim deneyim yetenekler olaraka ayır ve güçlü bir şekilde her bir maddeyi açıkla ve yeniden cv oluştur\r\n");

                var response = await chat.GetResponseFromChatbotAsync();

                return response;
            }
        }
    }
}