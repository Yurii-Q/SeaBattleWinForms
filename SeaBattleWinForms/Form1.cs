
namespace SeaBattleWinForms
{
    using SeaBattle;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            player = new Player();
            pc = new Player();

            InitCoordinates();
            InitPCField();
            InitPlayerField();
        }  

        #region Fields
        //Fields for Interface
        const int rang = 10;
        private readonly Label[] lettersCoordinatesPlayer = new Label[rang];
        private readonly Label[] numbersCoordinatesPlayer = new Label[rang];
        private readonly Label[] lettersCoordinatesPC = new Label[rang];
        private readonly Label[] numbersCoordinatesPC = new Label[rang];

        private Button[,] buttonsOnPCField = new Button[rang,rang];
        //private Button[,] buttonsOnPlayerField = new Button[rang,rang];
        private Button[,] buttonsOnPlayerField = new Button[rang,rang];

        //For diagnostic
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        //Fields for Game
        Player player;
        Player pc;

        InputClassPC movesPC = new InputClassPC();

        Handler handler = new Handler();
        #endregion

        //Handlers of events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            if(e.KeyCode == Keys.R)
            {
                this.player.Init();
                ResetPlayerField();
            }
        }        

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.player.Init();
            this.pc.Init();
            ResetPCField();
            ResetPlayerField();
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            handler.jPlayer = this.tableLayoutPC.Controls.Container.GetRow(btn) - 1;
            handler.iPlayer = this.tableLayoutPC.Controls.Container.GetColumn(btn) - 1;                
                                    

            movesPC.readKeyPC(pc, handler);

            int flagWin = handler.handler(player, pc);


            if (flagWin != 0)
            {    
                if (flagWin == 1)
                   MessageBox.Show("You Win!");
                else
                    MessageBox.Show("You Lose!");                
            }

            ResetPCField();
            ResetMyField();
        }
    }   
}