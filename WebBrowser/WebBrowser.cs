using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.Globalization;
using System.Collections;

namespace WebBrowser
{
    public partial class frmBrowserMain : Form
    {
        public static String FavXml = "Favorits.xml", LinksXml = "Links.xml";
        String SettingsXml = "Setting.xml", HistoryXml = "History.xml";
        List<String> urls = new List<string>();
        XmlDocument Settings = new XmlDocument();
        String HomePage;
        CultureInfo currentCulture;

        public frmBrowserMain()
        {
            InitializeComponent();
            currentCulture = CultureInfo.CurrentCulture;
        }

        #region Form Set Visibility

        //visible items
        private void SetVisibility()
        {
            if(!File.Exists(SettingsXml))
            {
                XmlElement r = Settings.CreateElement("Settings");
                Settings.AppendChild(r);
                XmlElement el;

                el = Settings.CreateElement("MenuBar");
                el.SetAttribute("Visible", "True");
                r.AppendChild(el);

                el = Settings.CreateElement("AddressBar");
                el.SetAttribute("Visible", "True");
                r.AppendChild(el);

                el = Settings.CreateElement("LinkBar");
                el.SetAttribute("Visible", "True");
                r.AppendChild(el);

                el = Settings.CreateElement("FavoritesPanel");
                el.SetAttribute("Visible", "True");
                r.AppendChild(el);

                el = Settings.CreateElement("SplashScreen");
                el.SetAttribute("Checked", "True");
                r.AppendChild(el);

                el = Settings.CreateElement("HomePage");
                el.InnerText = "about:blank";
                r.AppendChild(el);

                el = Settings.CreateElement("Dropdown");
                el.InnerText = "15";
                r.AppendChild(el);
            }
            else
            {
                Settings.Load(SettingsXml);
                XmlElement r = Settings.DocumentElement;
                menuBar.Visible = (r.ChildNodes[0].Attributes[0].Value.Equals("True"));
                addressBar.Visible = (r.ChildNodes[1].Attributes[0].Value.Equals("True"));
                linkBar.Visible = (r.ChildNodes[2].Attributes[0].Value.Equals("True"));
                splashScreenToolStripMenuItem.Checked = (r.ChildNodes[4].Value.Equals("True"));
                HomePage = r.ChildNodes[5].InnerText;
            }


        }

        #endregion
    }
}
