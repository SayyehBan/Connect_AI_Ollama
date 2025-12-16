using SayehBanTools.AI.Ollama.gemma;

namespace Connect_AI_Ollama
{
    public partial class FrmGemma3 : Form
    {
        private LocalAiVisionAssistant? _assistant;
        private string? _selectedImagePath; // مسیر تصویر انتخاب‌شده
        public FrmGemma3()
        {
            InitializeComponent();
        }

        private async void FrmQwen_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("در حال اتصال به Ollama...");

            try
            {
                // پرامپت سیستم رو طوری تنظیم کن که هم برای vision و هم برای متن کار کنه
                string systemPrompt = $"""
                    متن زیر را به کد زبان  ترجمه کن.
                    اگر متن به کد زبان  بود، به کد زبان  ترجمه کن.
                    فقط ترجمه را بده، بدون توضیح.
                    """;
                //string systemPrompt = """
                //    You are a helpful AI assistant with vision and text capabilities.
                //    - وقتی تصویر داری: فقط تحلیل دقیق و مستقیم بده (به فارسی).
                //    - وقتی فقط متن داری: اگر درخواست ترجمه بود، دقیق ترجمه کن.
                //    پاسخ‌ها همیشه به زبان فارسی باشند مگر اینکه زبان مقصد چیز دیگری باشد.
                //    توضیح اضافه، سلام یا مقدمه نده.
                //    """;

                _assistant = new LocalAiVisionAssistant("http://localhost:11434", "gemma3", systemPrompt);
                //_assistant = new LocalAiVisionAssistant("http://localhost:11434", "llama3.1", systemPrompt);
                //_assistant = new LocalAiVisionAssistant("http://localhost:11434", "qwen3-vl", systemPrompt);
                await _assistant.InitializeAsync();

                listBox1.Items.Add("✅ مدل qwen3-vl آماده شد!");
                listBox1.Items.Add("برای تحلیل تصویر: روی کادر کلیک کنید و سپس 'تحلیل تصویر' را بزنید.");
                listBox1.Items.Add("برای ترجمه متن: متن را در کادر بنویسید و 'ترجمه متن' را بزنید.");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("❌ خطا در اتصال:");
                listBox1.Items.Add(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "انتخاب تصویر";
                ofd.Filter = "فایل‌های تصویری|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;

                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromFile(_selectedImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    label1.Text = $"تصویر: {Path.GetFileName(_selectedImagePath)}";
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_assistant == null) { MessageBox.Show("مدل آماده نیست!"); return; }
            if (string.IsNullOrEmpty(_selectedImagePath) || !File.Exists(_selectedImagePath))
            {
                MessageBox.Show("لطفاً ابتدا یک تصویر انتخاب کنید.");
                return;
            }

            listBox1.Items.Add("در حال تحلیل تصویر...");
            Application.DoEvents();

            try
            {
                string result = await _assistant.AnalyzeImageAutomaticallyAsync(_selectedImagePath);
                // یا اگر متد بالا رو نداری، از این استفاده کن:
                // string result = await _assistant.AskAboutImageAsync("این تصویر را دقیق تحلیل کن و اطلاعات مهم را استخراج کن.", _selectedImagePath);

                listBox1.Items.Add("نتیجه تحلیل تصویر:");
                listBox1.Items.Add(result);
                listBox1.Items.Add("──────────────────────────");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("❌ خطا:");
                listBox1.Items.Add(ex.Message);
            }
        }

        private async  void button2_Click(object sender, EventArgs e)
        {
            if (_assistant == null) { MessageBox.Show("مدل آماده نیست!"); return; }

            string inputText = richTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("لطفاً متنی برای ترجمه وارد کنید.");
                return;
            }

            listBox1.Items.Add("در حال ترجمه متن...");
            Application.DoEvents();
            try
            {
                // پرامپت ترجمه هوشمند (از انگلیسی/هر زبان به فارسی، یا برعکس)
                string translatePrompt = $"""
                    متن زیر را به کد زبان {TxtSource.Text.Trim()} ترجمه کن.
                    اگر متن بهکد زبان  {TxtSource.Text.Trim()} بود، به کد زبان {Txttarget.Text.Trim()} ترجمه کن.
                    فقط ترجمه را بده، بدون توضیح.

                    متن:
                    {inputText}
                    """;


                // استفاده از AskAsync چون فقط متن داریم (بدون تصویر)
                string translated = await _assistant.AskAsync(translatePrompt);

                listBox1.Items.Add("متن اصلی:");
                listBox1.Items.Add(inputText);
                listBox1.Items.Add("ترجمه:");
                listBox1.Items.Add(translated);
                listBox1.Items.Add("──────────────────────────");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("❌ خطا در ترجمه:");
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}
