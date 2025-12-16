using SayehBanTools.AI.Ollama.llama;

namespace Connect_AI_Ollama
{
    public partial class FrmLlama : Form
    {

        // لیست جملات انگلیسی که می‌خوای ترجمه بشن
        private readonly string[] missingTranslate = new string[]
        {
            "Hello, how are you today?",
            "I love learning new languages.",
            "The weather is beautiful today.",
            "What is your favorite food?",
            "Programming in C# is fun and powerful.",
            "Success comes with hard work and patience.",
            "Can you help me with this problem?",
            "I’m going to the park this afternoon.",
            "Thank you for your help!",
            "Have a wonderful day!"
        };
        private LocalAiTranslator? _translator;
        public FrmLlama()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("در حال اتصال به Ollama...");

            try
            {
                string systemPrompt = """
            You are a translation assistant for a software system.
            Rules:
            - Translate exactly, preserving placeholders like {0}, {Name}, etc.
            - Do NOT add explanations.
            - Respond only with the translated string.
            - Keep capitalization and punctuation.
            - Do NOT explain anything.
            - Do NOT add comments.
            - Do NOT include language names.
            - Do NOT add quotes unless they exist in the original.
            """;

                _translator = new LocalAiTranslator("http://localhost:11434", "llama3.1", systemPrompt);

                listBox1.Items.Add("در حال مقداردهی اولیه مدل (ارسال دستورالعمل)...");
                Application.DoEvents();

                // اینجا صبر می‌کنیم تا پرامپت سیستم ارسال بشه
                await _translator.InitializeAsync();

                listBox1.Items.Add("✅ مدل آماده شد! شروع ترجمه...");
                Application.DoEvents();

                // حالا ترجمه‌ها رو انجام بده
                foreach (var english in missingTranslate)
                {
                    string persian = await _translator.TranslateAsync(english, "en", "fa");
                    listBox1.Items.Add($"انگلیسی: {english}");
                    listBox1.Items.Add($"فارسی:  {persian}");
                    listBox1.Items.Add("──────────────────────────");
                    Application.DoEvents();
                }

                listBox1.Items.Add("✅ تمام ترجمه‌ها انجام شد!");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("❌ خطا:");
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}