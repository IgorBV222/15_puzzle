using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace _15_puzzle
{
    public partial class Form1 : Form
    {
        Game game;
        List<Image> images;
        public Form1()
        {
            InitializeComponent();
            game = new Game(4);  
        }
        private void btn00_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);  
            game.mixUpBtn(position);
            updateField();
            if (game.checkGame())
            {
                DialogResult result = MessageBox.Show("Вы победили!", "ПОЗДРАВЛЯЕМ",
                                        MessageBoxButtons.RetryCancel,
                                        MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)                    
                {                    
                    this.Close();
                }
                startGame();
            }            
        }
        private Button button_name(int position)
        {
            switch (position)
            {
                case 0: return button1;
                case 1: return button2;
                case 2: return button3;
                case 3: return button4;
                case 4: return button5;
                case 5: return button6;
                case 6: return button7;
                case 7: return button8;
                case 8: return button9;
                case 9: return button10;
                case 10: return button11;
                case 11: return button12;
                case 12: return button13;
                case 13: return button14;
                case 14: return button15;
                case 15: return button16;
                default: return null;   
            }
        }
        private void startGame()
        {
            game.start();
            for (int i = 0; i < 100; i++)
            {
                game.updateFieldRandom();
            }
            updateField();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            images = new List<Image>();
            for (int i = 1; i < 17; i++)
            {
                images.Add(Image.FromFile(i + ".png"));
            }           
            startGame();
        }
        private void menu_Click(object sender, EventArgs e)
        {
            startGame();
        }
        private void updateField()
        {
            for (int position = 0; position < 16; position++)
            {
                int btn_num = game.getNumber(position);                
                button_name(position).Image = images[btn_num];
                button_name(position).Visible = (btn_num > 0);  
            }
        } 
    }
}
