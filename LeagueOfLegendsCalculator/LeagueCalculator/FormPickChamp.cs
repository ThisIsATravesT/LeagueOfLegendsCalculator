using LeagueCalculator.Champs;
using LeagueCalculator.Classes;
using System;
using System.Windows.Forms;

namespace LeagueCalculator
{
    public partial class FormPickChamp : Form
    {
        public FormPickChamp()
        {
            InitializeComponent();
        }

        private void btnAatrox_Click(object sender, EventArgs e)
        {
            var champ = new Aatrox();

            Console.WriteLine("");
            Console.WriteLine("Displaying Estimated Base QWER Damage At Each Level:");

            foreach (var val in champ.EstimatedBaseQWERDamageAtEachLevel)
            {
                Console.WriteLine("@Level"+ val.Key + ": " + val.Value + " damage");
            }
        }
    }
}
