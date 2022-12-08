using System;
namespace Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<string, string> dict = new Dictionary<string, string>();
        int numberOfWords = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            BuildDictionary(dict, ref numberOfWords);
            DisplayWords(dict);
            SetNumberOfWords(numberOfWords);
        }
        private void BuildDictionary(Dictionary<string, string> dict, ref int numberOfWords)
        {
            StreamReader reader = File.OpenText("D:\\GIGABYTE\\Project\\Dictionary\\Dictionary\\Dictionary.txt");
            string line;
            string[] words;
            while (reader.Peek() != -1)
            {
                line = reader.ReadLine();
                words = line.Split(',');
                if (words.Length == 2)
                {
                    dict.Add(words[0], words[1]);
                    numberOfWords++;
                }     
            }
            reader.Close();  
        }
        private void DisplayWords(Dictionary<string, string> dict)
        {
            string[] words = new string[numberOfWords];
            dict.Keys.CopyTo(words, 0);
            foreach (string word in words)
            {
                if (word != null)
                {
                    listBox1.Items.Add(word);
                }    
            }    
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object word = listBox1.SelectedItem;
            textBox2.Text = dict[word.ToString()];
        }
        
        private void SetNumberOfWords(int numberOfWords)
        {
            textBox3.Text = numberOfWords.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.ToLower();
            if (dict.ContainsKey(input))
            {
                textBox2.Text = dict[input];
            }  
            else
            {
                textBox2.Text = "Không tìm thấy từ " + "'" + input + "'" + " trong từ điển này.";
            }    
        }
    }
}