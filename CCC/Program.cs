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

                if (komut.ToLower() == "start")
                {
                    Console.WriteLine("CV'yi Harvard Template'e göre düzenleme işlemi başlatılıyor...");

                    string cvText = "Yaren Tekdemir\r\n  Istanbul, Maltepe  tekdemiryrn@gmail.com  +90-552-544-79-91\r\nYüksek motivasyona sahip, sonuç odaklı ve yaratıcı bir problem çözücüyüm. Takım çalışmasına tam uyum sağladığıma\r\ninanıyorum. Yeniliklere açıklığım ve teknolojiye uygunluğumla, kendimi daha uyumlu bir birey olarak görüyorum.\r\nEğitim\r\nMaltepe Üniversitesi Istanbul, Maltepe\r\n Bilgisayar Mühendisliği Mezuniyet Tarihi: Haziran 2024\r\nTecrübe\r\n INOKSAN\r\n03.2023-... Istanbul, Türkiye\r\n• SAP sisteminde veri girişi operasyonlarını gerçekleştirdim ve SAP tabanını öğrenme fırsatı elde ettim.\r\n• İlgili departmanlarla iş birliği yaparak web sitesinin verimliliğini ve kullanıcı dostu olmasını artırdım.\r\n• Proje ilerlemesini raporladım ve düzenli toplantılarda takım çalışma becerilerimi geliştirdim.\r\n• Farklı departmanlarda yardımcı olarak takım çalışma becerilerimi geliştirdim ve farklı iş süreçleri hakkında bilgi edindim.\r\nLiderlik & Aktiviteler\r\nEğitim Teknolojileri / Teknofest 2022\r\nBig-O-8 takımı adıyla Education Technologies yarışması için rapor yazma sürecinde önemli bir rol oynadım. Raporumuz\r\nyüksek bir puanla birinci aşamayı geçti – 86-.\r\nKarma Sürü / Teknofest 2022\r\nBig-O-8 takımı adıyla Swarm Simulation yarışmasına için katıldık. Raporumuz birinci aşamayı başarıyla geçti.\r\nAktiviteler;\r\n• Habitat ile Teknosa tarafından düzenlenen \"Kadın İçin Teknoloji\" adlı projede eğitmenlik yapmak için eğitimimi\r\ntamamladım.\r\n• Robotik kulübünü kurarak öğrenciler arasında teknolojiye ilgi duyanları bir araya getirdik.\r\n• İngilizce pratik yapma amacıyla English Practice Club'ı kurarak dil becerilerini geliştirmek isteyen öğrencileri bir\r\naraya getirdik.\r\n• VBT Yazılım A.Ş.'nin 2023 Yaz Dönemi Staj Programı'na seçildim ve katılımlarımı sürdürüyorum.\r\nBeceriler & İlgi alanları &Sertifikalar\r\nBilgisayar yazılımları: Windows, GitHub, Word, Excel, PowerPoint, Outlook, ClickUp, Figma, Asana\r\nProgramlama dilleri: C, C#, Java, MATLAB, Python, Kotlin, SQL, HTML, CSS\r\nDil: İngilizce- Upper-Intermediate\r\nGeliştirme Ortamları: Visual Studio (2019, 2022), IntelliJ IDEA, MSSQL, MySQL, SAP, MVC\r\nSertifikalar;\r\n• MathWorks eğitimlerini tamamladım ve Simulink, Stateflow, MATLAB sertifikaları almaya hak kazandım.\r\n• Kadın ve Aile Çalışmaları Uygulama ve Araştırma Merkezi (MÜKÇAM) - UNESCO Toplumsal Cinsiyet Eşitliği\r\nToplumsal Cinsiyet Eşitliği Eğitimine katılarak belge almaya hak kazandım.\r\n• \"Kadın İçin Teknoloji\" eğitimimi tamamladığım için sertifika almaya hak kazandım.\r\nReferanslar\r\nEsra Batkın Inoksan Genel Müdür  :0532 251 72 60 E-mail: esra.altay@inoksan.com.tr\r\nRaif Önvural Maltepe Üniversitesi Eğitim Görevlisi  :0543 285 46 46 E-mail: raifonvural@maltepe.edu.tr\r\nSerpil Erden Inoksan CRM  :0501222 22 83 E-mail: serpil.erden@inoksan.com.tr";

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
                    Console.WriteLine("Geçersiz komut. 'start' veya 'exit' komutlarını girin.");
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

                chat.AppendUserInput(cvText + "CV deki tüm kelimelerin yarısını kedi ile değiştir");

                var response = await chat.GetResponseFromChatbotAsync();

                return response;
            }
        }
    }
}