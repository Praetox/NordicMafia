using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LM
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
        }

        private string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }

        private void tsLogin_Click(object sender, EventArgs e)
        {
            string myURL = wb.Document.Url.ToString();
            wb.Navigate("about:<center><font size=+3><br><br><br><i>Logger inn...</i></font></center>");
            Application.DoEvents(); Program.doLogin(); wb.Navigate(myURL);
        }

        private void tsMenu_Click(object sender, EventArgs e)
        {
            wb.Navigate("about:blank"); Application.DoEvents();
            wb.Document.Write(
                "<center><font size=+2><i>Hoved</i></font><br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=poeng\">Poenghandel</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=poverfor\">Overfør Poeng</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=bank\">Banken</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=politi\">Politistasjon</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=politinytt\">Politinytt</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=fest\">Fester</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=eiendom\">Eiendom</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=omrader\">Territorium</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=lesavis\">Les avis</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=flyplass\">Flyplass</a>" +
                "<br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=krim\">Kriminalitet</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=utpressing\">Utpressing</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=drep\">Drep</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=sykehus\">Sykehus</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=hitlist\">Hitlist</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=gta\">Biltyveri / garasje</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=oc\">Organisert krim</a> |"  +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=skytetrening\">Skytetrening</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=cdgny\">Club dé gangster</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=oppdrag\">Oppdrag</a>" +
                "<br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=fightclub\">Fight club</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=borsen\">Børsen</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=livvakt\">Livvaktutleie</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=plantasje\">Hasjplantasje</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=filmprod\">Filmproduksjon</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=racing&valg=mod\">Modifiser bil</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=racing&valg=race\">Streetracing</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=fengsel\">Fengsel</a>" +
                "<br><br>" +
                "<font size=+2><i>Annet</i></font><br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=kuler\">Kjøp kuler</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=bruktbilo\">Kjøp bruktbil</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=bruktbilo&akt=selg\">Selg bruktbil</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=flyhandel\">Kjøp fly</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=vapenhandel\">Kjøp våpen</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=protecthandel\">Kjøp beskyttelse</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=underground\">The underground</a>" +
                "<br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=forsok\">Mordforsøk</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=rankbar\">Rankbar</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=gjengcp\">Gjengsenter</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=firmacp\">Firmapanel</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=openbud\">Statsauksjon</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=avisfirma\">Avisfirma</a>" +
                "<br><br>" +
                "<font size=+2><i>Gambling</i></font><br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=poker\">Poker</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=blackjack\">Blackjack</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=keno\">Keno</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=lotto\">Lotto</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=hestelop\">Veddeløpsbanen</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=russisk\">Russisk rulett</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=nummer\">Nummerspillet</a>" +
                "<br><br>" +
                "<font size=+2><i>Kommunikasjon</i></font><br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=pm_inn\">Innboks</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=pm_ny\">Send melding</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=pm_sendt\">Utboks</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=kontakter\">Kontakter</a>" +
                "<br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=genforum\">Generelt forum</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=sokforum\">Salg/søknad forum</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=cdgforum\">CDG forum</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=otforum\">Offtopic forum</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=gjengforum\">Gjeng forum</a>" +
                "<br><br>" +
                "<font size=+2><i>System</i></font><br>" +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=hoved\">Nyheter</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=support\">In-game support</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=finn\">Finn spiller</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=online\">Spillere pålogget</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=endre_bruker\">Rediger profil</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=stats\">Statistikk</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=dagensmord\">Dagens mord</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=faq\">FAQ</a> | " +
                "<a href=\"http://www.nordicmafia.net/nordic/index.php?side=kontaktinfo\">Kontaktinformasjon</a>" +
                "</center>");
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            tsMenu_Click(new object(), new EventArgs());
        }
    }
}
