namespace Connect_AI_Ollama;

public partial class FormRoute : Form
{
    public FormRoute()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        FrmLlama fm = new FrmLlama();
        fm.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        FrmGemma3 fm=new FrmGemma3();
        fm.ShowDialog();
    }
}
