using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Functions

namespace SeaBattleWinForms
{
    public partial class Form1 : Form
    {
        #region Functions
        private void InitCoordinates()
        {
            for (int i = 0; i < rang; ++i)
            {
                lettersCoordinatesPlayer[i] = new Label() { Text = ((char)('A' + i)).ToString() };
                numbersCoordinatesPlayer[i] = new Label() { Text = i.ToString() };
                lettersCoordinatesPC[i] = new Label() { Text = ((char)('A' + i)).ToString() };
                numbersCoordinatesPC[i] = new Label() { Text = i.ToString() };

                lettersCoordinatesPlayer[i].Dock = DockStyle.Fill;
                numbersCoordinatesPlayer[i].Dock = DockStyle.Fill;
                lettersCoordinatesPC[i].Dock = DockStyle.Fill;
                numbersCoordinatesPC[i].Dock = DockStyle.Fill;

                lettersCoordinatesPlayer[i].TextAlign = ContentAlignment.MiddleCenter;
                numbersCoordinatesPlayer[i].TextAlign = ContentAlignment.MiddleCenter;
                lettersCoordinatesPC[i].TextAlign = ContentAlignment.MiddleCenter;
                numbersCoordinatesPC[i].TextAlign = ContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < rang; ++i)
            {
                this.tableLayoutPlayer.Controls.Add(lettersCoordinatesPlayer[i], i + 1, 0);
                this.tableLayoutPlayer.Controls.Add(numbersCoordinatesPlayer[i], 0, i + 1);

                this.tableLayoutPC.Controls.Add(lettersCoordinatesPC[i], i + 1, 0);
                this.tableLayoutPC.Controls.Add(numbersCoordinatesPC[i], 0, i + 1);
            }
        }

        private void InitPCField()
        {
            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    buttonsOnPCField[i, j] = new Button() { Text = "" };//$"{i};{j}" 
                    buttonsOnPCField[i, j].Font = new Font(buttonsOnPCField[i, j].Font.Name, 14f, FontStyle.Regular);
                    buttonsOnPCField[i, j].TextAlign = ContentAlignment.TopCenter;
                    buttonsOnPCField[i, j].Dock = DockStyle.Fill;
                    buttonsOnPCField[i, j].Margin = new Padding(0);
                    buttonsOnPCField[i, j].Padding = new Padding(0);
                    buttonsOnPCField[i, j].FlatAppearance.BorderSize = 0;
                    buttonsOnPCField[i, j].FlatStyle = FlatStyle.Flat;
                    buttonsOnPCField[i,j].BackColor = Color.White;
                }

            for (int i = 1; i <= rang; ++i)
                for (int j = 1; j <= rang; ++j)
                {
                    this.tableLayoutPC.Controls.Add(buttonsOnPCField[i - 1, j - 1], i, j);
                }
        }

        private void InitPlayerField()
        {
            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    buttonsOnPlayerField[i, j] = new Button() { Text = "" };//$"{i};{j}" 
                    buttonsOnPlayerField[i, j].Font = new Font(buttonsOnPlayerField[i, j].Font.Name, 14f, FontStyle.Regular);
                    buttonsOnPlayerField[i, j].TextAlign = ContentAlignment.TopCenter;
                    buttonsOnPlayerField[i, j].Dock = DockStyle.Fill;
                    buttonsOnPlayerField[i, j].Margin = new Padding(0);
                    buttonsOnPlayerField[i, j].Padding = new Padding(0);
                    buttonsOnPlayerField[i, j].FlatAppearance.BorderSize = 0;
                    buttonsOnPlayerField[i, j].FlatStyle = FlatStyle.Flat;
                    buttonsOnPlayerField[i, j].BackColor = Color.White;
                    buttonsOnPlayerField[i, j].Click += btn_ClickPlayerField;

                    if (this.player.getFieldElement(i, j) == 0)
                        buttonsOnPlayerField[i, j].Text = "";
                    if (this.player.getFieldElement(i, j) == 1)
                    {
                        buttonsOnPlayerField[i, j].Text = "O";
                        buttonsOnPlayerField[i, j].BackColor = Color.YellowGreen;
                    }
                    if (this.player.getFieldElement(i, j) == 2)
                        buttonsOnPlayerField[i, j].Text = "X";
                }

            for (int i = 1; i <= rang; ++i)
                for (int j = 1; j <= rang; ++j)
                {
                    this.tableLayoutPlayer.Controls.Add(buttonsOnPlayerField[i - 1, j - 1], i, j);
                }
        }

        private void ResetDisplayPlayerField()
        {
            //sw.Restart();
            this.SuspendLayout();
            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    buttonsOnPlayerField[i, j].BackColor = Color.White;
                    if (this.player.getFieldElement(i, j) == 0)
                        buttonsOnPlayerField[i, j].Text = "";
                    if (this.player.getFieldElement(i, j) == 1)
                    {
                        buttonsOnPlayerField[i, j].Text = "O";
                        buttonsOnPlayerField[i, j].BackColor = Color.YellowGreen;
                    }
                    if (this.player.getFieldElement(i, j) == 2)
                    {
                        buttonsOnPlayerField[i, j].Text = "X";
                        buttonsOnPlayerField[i, j].BackColor = Color.Orange;
                    }
                }
            this.ResumeLayout();
            //sw.Stop();
            //this.Timer.Text = (sw.ElapsedMilliseconds / 1000.0).ToString() + "s";
        }

        private void ResetDisplayPCField()
        {            
            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    if (this.player.getMyMoveElement(i, j) == 0)
                        buttonsOnPCField[i, j].Text = "";
                    if (this.player.getMyMoveElement(i, j) == 1)
                        buttonsOnPCField[i, j].Text = "X";
                    if (this.player.getMyMoveElement(i, j) == 2)
                        buttonsOnPCField[i, j].Text = "*";
                }            
        }

        private void ResetDisplayMyField()
        {
            for (int i = 0; i < rang; ++i)
                for (int j = 0; j < rang; ++j)
                {
                    if (this.pc.getMyMoveElement(i, j) == 1)
                    {
                        buttonsOnPlayerField[i, j].Text = "X";
                        buttonsOnPlayerField[i, j].BackColor = Color.Orange;
                    }
                    if (this.pc.getMyMoveElement(i, j) == 2)
                        buttonsOnPlayerField[i, j].Text = "*";
                }
        }        
        #endregion
    }
}
