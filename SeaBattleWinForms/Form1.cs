
namespace SeaBattleWinForms
{
    using SeaBattle;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            InitCoordinates();

            player = new Player(false);
            pc = new Player();
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
                player.zeroingField();                
                pc.InitAuto();
                ResetDisplayPCField();
                ResetDisplayPlayerField();
                for (int i = 0; i < rang; ++i)
                    for (int j = 0; j < rang; ++j)
                    {
                        buttonsOnPCField[i, j].Click -= btn_ClickPCField;
                        buttonsOnPlayerField[i, j].Click += btn_ClickPlayerField;
                    }
                this.btnAutoFill.Enabled = true;
            }
        }        

        private void btnReset_Click(object sender, EventArgs e)
        {
            player.zeroingField();
            pc.InitAuto();
            ResetDisplayPCField();
            ResetDisplayPlayerField();
            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    buttonsOnPCField[i, j].Click -= btn_ClickPCField;
                    buttonsOnPlayerField[i, j].Click += btn_ClickPlayerField;
                }
            this.btnAutoFill.Enabled = true;
        }

        private void btnAutoFill_Click(object sender, EventArgs e)
        {
            this.player.InitAuto();
            

            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    buttonsOnPCField[i, j].Click += btn_ClickPCField;
                    buttonsOnPlayerField[i, j].Click -= btn_ClickPlayerField;
                }
            ResetDisplayPCField();
            ResetDisplayPlayerField();
            this.btnAutoFill.Enabled = false;
        }

        private void btn_ClickPCField(object sender, EventArgs e)
        {
            Button btn = sender as Button;
                        
            handler.iPlayer = this.tableLayoutPC.Controls.Container.GetColumn(btn) - 1;
            handler.jPlayer = this.tableLayoutPC.Controls.Container.GetRow(btn) - 1;

            movesPC.readKeyPC(pc, handler);

            int flagWin = handler.handler(player, pc);

            ResetDisplayPCField();
            ResetDisplayMyField();

            if (flagWin != 0)
            {
                for (int i = 0; i < rang; ++i)
                    for (int j = 0; j < rang; ++j)
                    {
                        buttonsOnPCField[i, j].Click -= btn_ClickPCField;                        
                    }

                if (flagWin == 1)
                   MessageBox.Show("You Win!");
                else
                    MessageBox.Show("You Lose!");                
            }            
        }

        private void btn_ClickPlayerField(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int indexi = this.tableLayoutPC.Controls.Container.GetColumn(btn) - 1;
            int indexj = this.tableLayoutPC.Controls.Container.GetRow(btn) - 1;

            player.ManuallyFill(indexi, indexj);

            ResetDisplayPlayerField();

            if(player.numberShips == 0)
            {
                for (int i = 0; i < rang; ++i)
                    for (int j = 0; j < rang; ++j)
                    {
                        buttonsOnPCField[i, j].Click += btn_ClickPCField;
                        buttonsOnPlayerField[i, j].Click -= btn_ClickPlayerField;
                    }
                player.numberShips = 10;
                this.btnAutoFill.Enabled = false;
            }           

        }        
    }   
}